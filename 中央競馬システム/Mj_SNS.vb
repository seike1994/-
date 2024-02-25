Imports System.IO
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Imports Npgsql

Module Mj_SNS
    Function postLine(message As String)
        Dim erCode As Integer = 0
        Dim LineNotifyApiUrl As String = "https://notify-api.line.me/api/notify"
        Dim httpClient As New HttpClient()
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {LineToken}")

        Dim content As New StringContent($"message={message}", Encoding.UTF8, "application/x-www-form-urlencoded")

        Dim response = httpClient.PostAsync(LineNotifyApiUrl, content).Result

        If response.IsSuccessStatusCode Then

        Else
            logTxt += Now() & " LINE通知エラー" & vbLf
            erCode = -1
        End If
        Return erCode
    End Function


    Sub postHpPercent()
        Dim tansyoPercentDictionary As Dictionary(Of Integer, Double) = getTansyoPercent()

        tansyoPercentDictionary = tansyoPercentDictionary.OrderByDescending(Function(pair) pair.Value).ToDictionary(Function(pair) pair.Key, Function(pair) pair.Value)

        Dim bameiDictionary As Dictionary(Of Integer, String) = Class_Jv_Link.getBamei()

        Dim title As String = yyyymmdd & " " & kaisai & raceNumberCode & "R 【競馬AI 勝率予測】"
        Dim text As String = ""
        Dim suisyo As String = ""
        Dim isFirst As Boolean = True
        For Each pair In tansyoPercentDictionary
            Try
                Dim percent = pair.Value
                percent = Math.Floor(percent * 100 * 100) / 100
                Dim strPercent As String = percent.ToString("0.00") & "%"
                Dim umaban = pair.Key
                Dim bamei As String = bameiDictionary(umaban)
                text += "【" & strPercent & "】 " & umaban & "番 " & bamei & vbLf
                If isFirst = True Then
                    suisyo = "◎【" & strPercent & "】 " & umaban & "番 " & bamei & vbLf
                    isFirst = False
                End If
            Catch
                Exit For
            End Try
        Next


        If text <> "" And InStr(text, "N") = 0 Then
            Using conn As New NpgsqlConnection(awsConnStr)
                conn.Open()

                Dim sql As String = $"INSERT INTO yoso_data (id,title, article) VALUES (@raceId,@title, @text) ON CONFLICT (id) DO NOTHING"

                Using command As New NpgsqlCommand(sql, conn)
                    command.Parameters.AddWithValue("@raceId", CLng(raceId))
                    command.Parameters.AddWithValue("@title", title)
                    command.Parameters.AddWithValue("@text", text)
                    command.ExecuteNonQuery()
                End Using
            End Using
            If postXis = True Then
                Dim xText As String = yyyymmdd & " " & kaisai & raceNumberCode & "R 【競馬AI 勝率予測】" & vbLf &
                                             "ホームページにて全頭予想" & vbLf & suisyo & HpUrl
                postX(xText)
            End If
        End If
    End Sub
    Sub postHpKaime()

        Dim hpArticle As String = Create_Baken("bookers")
        Dim title As String = yyyymmdd & " " & kaisai & raceNumberCode & "R 【競馬AI 買い目】"

        If hpArticle = "" Then
            title = yyyymmdd & " " & kaisai & raceNumberCode & "R の買い目はありません"
            hpArticle = "買い目はありません"
        End If
        Using conn As New NpgsqlConnection(awsConnStr)
            conn.Open()
            Dim sql As String = "INSERT INTO yoso_data (id,title,article) VALUES (@raceId,@title, @text) ON CONFLICT (id) DO NOTHING"
            Using command As New NpgsqlCommand(sql, conn)
                command.Parameters.AddWithValue("@raceId", CLng(raceId))
                command.Parameters.AddWithValue("@title", title)
                command.Parameters.AddWithValue("@text", hpArticle)
                command.ExecuteNonQuery()
            End Using
        End Using
        If postXis = True Then
            Dim xText As String = "【テスト投稿】" & vbLf & yyyymmdd & " " & kaisai & raceNumberCode & "R 【競馬AI 買い目】" & vbLf & HpUrl
            postX(xText)
        End If

    End Sub

    Sub allPercentBookers()

        Dim yyyymmdd As String = Now.ToString("yyyyMMdd")
        raceId = yyyymmdd & "0000"
        setRaceNum = 13
        Dim allBabaTenkoDictionary As Dictionary(Of String, ArrayList) = Class_Jv_Link.getAllBabaCondition()

        Dim kaisaiList As ArrayList = New ArrayList
        Using conn As New NpgsqlConnection(localConnStr)
            conn.Open()
            For Each pair In allBabaTenkoDictionary
                Dim kaisaiCode As String = pair.Key
                Dim babaTenkoArrayList As ArrayList = pair.Value
                Dim baba As Integer = babaTenkoArrayList(0)
                Dim tenko As Integer = babaTenkoArrayList(1)
                raceId = yyyymmdd & kaisaiCode
                kaisaiList.Add(raceId)
                For i = 1 To 12
                    Dim strRaceNum As String = i.ToString("00")
                    Dim strRaceId As String = yyyymmdd & kaisaiCode & strRaceNum
                    Dim strFirstRaceSeId As String = strRaceId & "00"
                    Dim strLastRaceSeId As String = strRaceId & "18"
                    Dim updateSql As New NpgsqlCommand($"UPDATE race_se SET baba_condition = {baba},tenko_code = {tenko}
                                                             WHERE race_id > {strFirstRaceSeId} AND race_id <= {strLastRaceSeId};", conn)
                    updateSql.ExecuteNonQuery()

                Next i
            Next
        End Using
        Dim ymd As String = Now.ToString("yyyy年MM月dd日")
        Dim title As String = ymd & "競馬AI 中央競馬 1R～" & (setRaceNum - 1) & "R 勝率予測"
        Dim text As String = ""
        For Each race_id In kaisaiList
            Dim str_race_id As String = race_id & "00"
            pythonAllBookers(str_race_id)
        Next
        For Each race_id In kaisaiList
            Dim Code As String = race_id.Substring(race_id.Length - 2)
            For i = 1 To setRaceNum - 1

                Dim strRaceNum As String = i.ToString("00")
                raceId = race_id & strRaceNum
                Dim tansyoPercentDictionary As Dictionary(Of Integer, Double) = getTansyoPercent()
                If tansyoPercentDictionary.Count = 0 Then
                    Exit For
                End If
                tansyoPercentDictionary = tansyoPercentDictionary.OrderByDescending(Function(pair) pair.Value).ToDictionary(Function(pair) pair.Key, Function(pair) pair.Value)
                Dim bameiDictionary As Dictionary(Of Integer, String) = Class_Jv_Link.getBamei()

                Dim kaisai As String = getChangeKaisai(Code)
                Dim subTitle As String = "【" & yyyymmdd & " " & kaisai & i.ToString("00") & "R 勝率予測】"
                Dim index As Integer = 1
                Dim sirusi As String = ""
                text += subTitle & vbLf & vbLf
                For Each pair In tansyoPercentDictionary

                    Select Case index
                        Case 1
                            sirusi = "◎"
                        Case 2
                            sirusi = "〇"
                        Case 3
                            sirusi = "▲"
                        Case 4
                            sirusi = "△"
                        Case 5
                            sirusi = "★"
                        Case 6
                            sirusi = "☆"
                        Case Else
                            sirusi = "-"
                    End Select


                    Try
                        Dim percent = pair.Value
                        percent = Math.Floor(percent * 100 * 100) / 100
                        Dim strPercent As String = percent.ToString("0.00") & "%"
                        Dim umaban = pair.Key
                        Dim bamei As String = bameiDictionary(umaban)
                        text += sirusi & "【" & strPercent & "】 " & umaban & "番 " & bamei & vbLf
                        index += 1
                    Catch
                        Exit For
                    End Try
                Next
                text += vbLf

            Next
        Next

        Dim filePath As String = "C:\Users\Admin\Desktop\text.txt" ' 新規ファイルのパス

        ' 新規テキストファイルを作成し、文字列を書き込む
        Using writer As StreamWriter = New StreamWriter(filePath, False) ' Falseはファイルを新規作成することを意味する
            writer.WriteLine(text)
        End Using

        ' メモ帳でファイルを開く
        Process.Start("notepad.exe", filePath)
        If text <> "" And InStr(text, "N") = 0 Then
            Dim result As DialogResult = MessageBox.Show("実行しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                postBookers(title, text)
            Else
                MessageBox.Show("操作はキャンセルされました。", "キャンセル", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MsgBox("テキストが空、もしくは、NaNが入っている")
        End If
    End Sub

    Sub postX(xText)
        Dim psi As New ProcessStartInfo()
        Dim apies As String = xUserId & " " & xApiKey & " " & xApiKeyS & " " & xAccessToken & " " & xAccessTokenS & " " & xBearerToken & " " & BookersToken
        psi.FileName = "python.exe" ' Pythonのパス
        psi.Arguments = "C:\Users\Admin\Desktop\Python\post_sns\PostTwitter.py """ & xText & """" & " " & apies ' 変数を使用して引数を渡す
        Dim process As Process = Process.Start(psi)
        process.WaitForExit()
    End Sub

    Sub postBookers(bookersTitle, bookersArticle)
        Dim apies As String = xUserId & " " & xApiKey & " " & xApiKeyS & " " & xAccessToken & " " & xAccessTokenS & " " & xBearerToken & " " & BookersToken
        Dim psi As New ProcessStartInfo()
        psi.FileName = "python.exe" 'Pythonのパス
        psi.Arguments = "C:\Users\Admin\Desktop\Python\post_sns\bookers.py """ & bookersTitle & """ """ & bookersArticle & """" & " " & apies
        ' 変数を使用して引数を渡す
        Try
            Dim process As Process = Process.Start(psi)
            process.WaitForExit()
        Catch
            MsgBox("送信文字が多すぎます")
        End Try

    End Sub

    Sub todayPercentDelete()
        Using conn As New NpgsqlConnection(localConnStr)
            conn.Open()

            Dim today As String = Now.ToString("yyyyMMdd") & "0000"
            Dim updateSql As New NpgsqlCommand($"DELETE FROM tansyo_percent WHERE race_id > {today};", conn)
            updateSql.ExecuteNonQuery()

        End Using
    End Sub


    Function chengeBookers(num)
        Dim buyCb As Boolean = False
        Select Case num
            Case 1
                buyCb = bTansyo
            Case 2
                buyCb = bFukusyo
            Case 3
                buyCb = bWakuren
            Case 4
                buyCb = bUmaren
            Case 5
                buyCb = bWide
            Case 6
                buyCb = bUmatan
            Case 7
                buyCb = bSanrenpuku
            Case 8
                buyCb = bSanrentan
        End Select
        Return buyCb
    End Function
End Module