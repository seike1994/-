Imports Npgsql

Public Class Class_Jv_Link
    Public buffSize As Integer = 150000
    Public horseCount As Integer
    Public buff As String = New String(vbNullChar, buffSize)
    Public fName As String = ""

    Private conn As Npgsql.NpgsqlConnection
    Private sql As NpgsqlCommand
    Private sqlArrayList As ArrayList
    Sub Jv_Link_Init()
        Dim sid As String
        Dim lReturnCode As Long
        '引数設定
        sid = "Test"
        'JVLink 初期化
        lReturnCode = Me.AxJVLink1.JVInit(sid)
        'エラー判定
        If lReturnCode <> 0 Then
            MsgBox("JVInit エラー Code：" & lReturnCode & "：", MessageBoxIcon.Error)
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Exit Sub
        End If
    End Sub
    Sub JvSetting()
        Try
            Dim lReturnCode As Long
            lReturnCode = AxJVLink1.JVSetUIProperties()
            If lReturnCode <> 0 Then
                MsgBox("JVSetUIPropertiesエラー Code：" & lReturnCode & "：", MessageBoxIcon.Error)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Function JvRTOpens(dataID As String)

        Dim key As String = raceId
        If dataID = "0B14" Then
            key = key.Substring(0, key.Length - 4)
        End If

        Dim ReturnCode As Integer

        ReturnCode = Me.AxJVLink1.JVRTOpen(dataID, key)


        Return ReturnCode
    End Function

    Function JvRTOpenRaceData(dataID As String, time As DateTime)

        Dim fromtime As String = time.ToString("yyyyMMdd")
        Return AxJVLink1.JVRTOpen(dataID, fromtime)
    End Function
    Sub getRaceData(time As DateTime)
        TopReset()
        If JvRTOpenRaceData("0B15", time) = 0 Then
            Dim ReturnCode As Long
            Dim RaceInfo As JV_RA_RACE
            Dim kai As String
            Dim niti As String
            Dim hassoTime As String
            Dim tc As Integer = 1
            Dim raceNum As Integer
            Dim mmddDate
            mmddDate = time.ToString("MMdd")
            Dim loopCount As Integer = 0

            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0 ' 正常
                        If Mid(buff, 1, 2) = "RA" Then
                            RaceInfo.SetData(buff)
                            Dim Code = RaceInfo.id.JyoCD
                            kai = RaceInfo.id.Kaiji
                            niti = RaceInfo.id.Nichiji

                            kai = Replace(kai, "0", "")
                            If niti < 10 Then
                                niti = Replace(niti, "0", "")
                            End If

                            kaisai = getChangeKaisai(Code)
                            hassoTime = RaceInfo.HassoTime
                            hassoTime = hassoTime.Insert(2, ":")
                            raceNum = RaceInfo.id.RaceNum
                            Dim mmddDateJv As String
                            mmddDateJv = RaceInfo.id.MonthDay
                            If mmddDate < mmddDateJv Then
                                GoTo readEnd
                            End If


                            If mmddDate = mmddDateJv Then
                                Dim currentTable As DataTable
                                If loopCount = 0 Then
                                    Class_MainForm.kaisai1.Text = kai & "回 " & kaisai & " " & niti & "日"
                                    currentTable = dayDgvTable1
                                    loopCount = 1
                                ElseIf Class_MainForm.kaisai1.Text <> kai & "回 " & kaisai & " " & niti & "日" And loopCount = 1 Then
                                    Class_MainForm.kaisai2.Text = kai & "回 " & kaisai & " " & niti & "日"
                                    currentTable = dayDgvTable2
                                    loopCount = 2
                                ElseIf loopCount = 2 And Class_MainForm.kaisai2.Text <> kai & "回 " & kaisai & " " & niti & "日" Then
                                    Class_MainForm.kaisai3.Text = kai & "回 " & kaisai & " " & niti & "日"
                                    currentTable = dayDgvTable3
                                    loopCount = 3
                                End If

                                ' 現在のDataTableに行を追加
                                For i = currentTable.Rows.Count To 11
                                    Dim newRow As DataRow = currentTable.NewRow()
                                    newRow(0) = i + 1
                                    currentTable.Rows.Add(newRow)
                                Next i

                                ' hassoTimeの設定
                                If tc < 13 Then
                                    dayDgvTable1.Rows(raceNum - 1)(2) = hassoTime
                                    dayDgvTable1.Rows(raceNum - 1)(1) = "9"
                                ElseIf tc > 12 And tc < 25 Then
                                    dayDgvTable2.Rows(raceNum - 1)(2) = hassoTime
                                    dayDgvTable2.Rows(raceNum - 1)(1) = "9"
                                ElseIf tc > 24 And tc < 37 Then
                                    dayDgvTable3.Rows(raceNum - 1)(2) = hassoTime
                                    dayDgvTable3.Rows(raceNum - 1)(1) = "9"
                                End If
                                tc += 1
                            End If
                        End If


                    Case -1
     '何もしない
                    Case 0 ' 読込終了
                        Exit Do
                    Case Else ' エラー
                        logTxt += "JVReadエラー:" & ReturnCode & ControlChars.CrLf
                        Dim LineMsg = "JVReadエラー:" & ReturnCode
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop
readEnd:
            Dim dgvCount = 0
            Dim dgv
            If tc > 10 Then
                dgvCount = 2
                If tc > 30 Then
                    dgvCount = 3
                End If
                For i = 1 To dgvCount
                    Dim dgvTable As DataTable = If(i = 1, dayDgvTable1, If(i = 2, dayDgvTable2, dayDgvTable3))
                    Dim totalRow As DataRow = dgvTable.NewRow()
                    totalRow(2) = "合計"
                    totalRow(0) = "---"
                    totalRow(1) = "---"
                    totalRow(3) = 0
                    totalRow(4) = 0
                    totalRow(5) = 0
                    totalRow(6) = "0%"
                    dgvTable.Rows.Add(totalRow)
                Next i

            End If

            ' JVClose
            ReturnCode = AxJVLink1.JVClose()
            changeDgvColor()
        End If
    End Sub

    Sub getHassoTime()
        Dim time As DateTime = Now
        If JvRTOpenRaceData("0B15", time) = 0 Then
            Dim ReturnCode As Integer
            Dim RaceInfo As JV_RA_RACE
            Dim hassoTime As String
            Dim loopCount As Integer = 0
            Dim raceNum As Integer
            Dim mmddDate
            mmddDate = Now.ToString("MMdd")

            loopCount = 1
            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0
                        If Mid(buff, 1, 2) = "RA" Then
                            RaceInfo.SetData(buff)
                            hassoTime = RaceInfo.HassoTime
                            hassoTime = hassoTime.Insert(2, ":")
                            raceNum = RaceInfo.id.RaceNum
                            Dim mmddDateJv As String
                            mmddDateJv = RaceInfo.id.MonthDay
                            If mmddDate < mmddDateJv Then
                                GoTo endclose
                            End If
                            If mmddDate = mmddDateJv Then

                                If loopCount < 13 Then
                                    dayDgvTable1.Rows(raceNum - 1)(2) = hassoTime
                                End If
                                If loopCount > 12 And loopCount < 25 Then
                                    dayDgvTable2(raceNum - 1)(2) = hassoTime
                                End If
                                If loopCount > 24 And loopCount < 37 Then
                                    dayDgvTable3.Rows(raceNum - 1)(2) = hassoTime
                                End If
                                loopCount = loopCount + 1
                            End If
                        End If
                    Case -1
     '何もしない
                    Case 0 ' 読込終了
                        Exit Do
                    Case Else ' エラー
                        Dim LineMsg = "JVReadエラー:" & ReturnCode
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop
endclose:


            ' JVClose
            ReturnCode = AxJVLink1.JVClose()

        End If
    End Sub

    Function getTansyoOdds()
        If JvRTOpens("0B31") = 0 Then
            Dim RaceInfo As JV_O1_ODDS_TANFUKUWAKU
            Dim tansyoNinki
            Dim tansyoUmaban
            Dim tansyoOdds
            Dim tansyoDictionary = New Dictionary(Of Integer, Double)
            tansyoOddsArray = New ArrayList
            tansyoUmabanArray = New ArrayList
            tansyoNinkiArray = New ArrayList
            Dim ReturnCode As Integer
            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0 ' 正常
                        If Mid(buff, 1, 2) = "O1" Then

                            RaceInfo.SetData(buff)

                            horseCount = RaceInfo.TorokuTosu
                            For i = 0 To horseCount - 1
                                tansyoNinki = RaceInfo.OddsTansyoInfo(i).Ninki
                                tansyoUmaban = RaceInfo.OddsTansyoInfo(i).Umaban
                                tansyoOdds = RaceInfo.OddsTansyoInfo(i).Odds
                                If InStr(tansyoOdds, "*") > 0 Or InStr(tansyoOdds, "-") Or InStr(tansyoOdds, " ") > 0 Then
                                    tansyoOdds = "0"
                                    tansyoNinki = "0"
                                Else
                                    tansyoOdds /= 10
                                    tansyoNinkiArray.Add(tansyoNinki)
                                    tansyoUmabanArray.Add(tansyoUmaban)
                                    tansyoOddsArray.Add(tansyoOdds)
                                    tansyoDictionary.Add(Int(tansyoUmaban), CDbl(tansyoOdds))
                                End If
                            Next i
                        End If
                        Exit Do

                    Case -1

                    Case 0
                        Exit Do
                    Case Else ' エラー
                        logTxt += "getTansyoOddsエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "getTansyoOddsエラー"
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop

            ReturnCode = AxJVLink1.JVClose()
            Return tansyoDictionary
        Else
            logTxt += "getTansyoOddsエラー" & vbLf
            Dim LineMsg = "getTansyoOddsエラー"
            If postEr = True Then
                postLine(LineMsg)
            End If
            Return vbNull
        End If
    End Function

    Function getFukusyoOdds()
        If JvRTOpens("0B31") = 0 Then
            Dim RaceInfo As JV_O1_ODDS_TANFUKUWAKU
            Dim fukusyoNinki
            Dim fukusyoUmaban
            Dim fukusyoOdds
            Dim fukusyoDictionary = New Dictionary(Of String, Double)
            fukusyoOddsArray = New ArrayList
            fukusyoUmabanArray = New ArrayList
            fukusyoNinkiArray = New ArrayList
            Dim ReturnCode As Integer
            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0 ' 正常
                        If Mid(buff, 1, 2) = "O1" Then

                            RaceInfo.SetData(buff)

                            horseCount = RaceInfo.TorokuTosu
                            For i = 0 To horseCount - 1
                                fukusyoNinki = RaceInfo.OddsFukusyoInfo(i).Ninki
                                fukusyoUmaban = RaceInfo.OddsFukusyoInfo(i).Umaban
                                fukusyoOdds = RaceInfo.OddsFukusyoInfo(i).OddsLow
                                If InStr(fukusyoOdds, "*") > 0 Or InStr(fukusyoOdds, "-") Or InStr(fukusyoOdds, " ") > 0 Then
                                    fukusyoOdds = "0"
                                    fukusyoNinki = "0"
                                Else
                                    fukusyoOdds /= 10
                                    fukusyoNinkiArray.Add(fukusyoNinki)
                                    fukusyoUmabanArray.Add(fukusyoUmaban)
                                    fukusyoOddsArray.Add(fukusyoOdds)
                                    fukusyoDictionary.Add(fukusyoUmaban, CDbl(fukusyoOdds))
                                End If
                            Next i
                        End If
                        Exit Do

                    Case -1

                    Case 0
                        Exit Do
                    Case Else ' エラー
                        logTxt += "getFukusyoOddsエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "getFukusyoOddsエラー"
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop

            ReturnCode = AxJVLink1.JVClose()
            Return fukusyoDictionary
        Else
            logTxt += "getFukusyoOddsエラー" & vbLf
            Dim LineMsg = "getFukusyoOddsエラー"
            If postEr = True Then
                postLine(LineMsg)
            End If
            Return vbNull
        End If
    End Function
    Function getWakurenOdds()
        If JvRTOpens("0B31") = 0 Then
            Dim RaceInfo As JV_O1_ODDS_TANFUKUWAKU
            Dim wakurenNinki
            Dim wakurenKumi
            Dim wakurenOdds
            Dim wakurenDictionary = New Dictionary(Of String, Double)
            wakurenOddsArray = New ArrayList
            wakurenUmabanArray = New ArrayList
            wakurenNinkiArray = New ArrayList
            Dim ReturnCode As Integer
            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0 ' 正常
                        If Mid(buff, 1, 2) = "O1" Then

                            RaceInfo.SetData(buff)

                            For i = 0 To RaceInfo.OddsWakurenInfo.Count - 1
                                wakurenNinki = RaceInfo.OddsWakurenInfo(i).Ninki
                                wakurenKumi = RaceInfo.OddsWakurenInfo(i).Kumi
                                wakurenOdds = RaceInfo.OddsWakurenInfo(i).Odds
                                If InStr(wakurenOdds, "*") > 0 Or InStr(wakurenOdds, "-") Or InStr(wakurenOdds, " ") > 0 Then
                                    wakurenOdds = "0"
                                    wakurenNinki = "0"
                                Else
                                    wakurenKumi = wakurenKumi.Substring(0, 1) & "-" & wakurenKumi.Substring(1)
                                    wakurenOdds /= 10
                                    wakurenNinkiArray.Add(wakurenNinki)
                                    wakurenUmabanArray.Add(wakurenKumi)
                                    wakurenOddsArray.Add(wakurenOdds)
                                    wakurenDictionary.Add(wakurenKumi, CDbl(wakurenOdds))
                                End If
                            Next i
                        End If
                        Exit Do

                    Case -1

                    Case 0
                        Exit Do
                    Case Else ' エラー
                        logTxt += "getWakurenOddsエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "getWakurenOddsエラー"
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop

            ReturnCode = AxJVLink1.JVClose()
            Return wakurenDictionary
        Else
            logTxt += "getWakurenOddsエラー" & vbLf
            Dim LineMsg = "getWakurenOddsエラー"
            If postEr = True Then
                postLine(LineMsg)
            End If
            Return vbNull
        End If
    End Function
    Function getUmarenOdds()
        If JvRTOpens("0B32") = 0 Then
            Dim RaceInfo As JV_O2_ODDS_UMAREN
            Dim umarenNinki
            Dim umarenKumi
            Dim umarenOdds
            Dim umarenDictionary = New Dictionary(Of String, Double)
            umarenOddsArray = New ArrayList
            umarenUmabanArray = New ArrayList
            umarenNinkiArray = New ArrayList
            Dim ReturnCode As Integer
            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0 ' 正常
                        If Mid(buff, 1, 2) = "O2" Then

                            RaceInfo.SetData(buff)

                            For i = 0 To RaceInfo.OddsUmarenInfo.Count - 1
                                umarenNinki = RaceInfo.OddsUmarenInfo(i).Ninki
                                umarenKumi = RaceInfo.OddsUmarenInfo(i).Kumi
                                umarenOdds = RaceInfo.OddsUmarenInfo(i).Odds
                                If InStr(umarenOdds, "*") > 0 Or InStr(umarenOdds, "-") Or InStr(umarenOdds, " ") > 0 Then
                                    umarenOdds = "0"
                                    umarenNinki = "0"
                                Else
                                    umarenKumi = umarenKumi.Substring(0, 2) & "-" & umarenKumi.Substring(2)
                                    umarenOdds /= 10
                                    umarenNinkiArray.Add(umarenNinki)
                                    umarenUmabanArray.Add(umarenKumi)
                                    umarenOddsArray.Add(umarenOdds)
                                    umarenDictionary.Add(umarenKumi, CDbl(umarenOdds))
                                End If
                            Next i
                        End If
                        Exit Do

                    Case -1

                    Case 0
                        Exit Do
                    Case Else ' エラー
                        logTxt += "getUmarenOddsエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "getUmarenOddsエラー"
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop

            ReturnCode = AxJVLink1.JVClose()
            Return umarenDictionary
        Else
            logTxt += "getUmarenOddsエラー" & vbLf
            Dim LineMsg = "getUmarenOddsエラー"
            If postEr = True Then
                postLine(LineMsg)
            End If
            Return vbNull
        End If
    End Function
    Function getWideOdds()
        If JvRTOpens("0B33") = 0 Then
            Dim RaceInfo As JV_O3_ODDS_WIDE
            Dim wideNinki
            Dim wideKumi
            Dim wideOdds
            Dim wideDictionary = New Dictionary(Of String, Double)
            wideOddsArray = New ArrayList
            wideUmabanArray = New ArrayList
            wideNinkiArray = New ArrayList
            Dim ReturnCode As Integer
            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0 ' 正常
                        If Mid(buff, 1, 2) = "O3" Then

                            RaceInfo.SetData(buff)

                            For i = 0 To RaceInfo.OddsWideInfo.Count - 1
                                wideNinki = RaceInfo.OddsWideInfo(i).Ninki
                                wideKumi = RaceInfo.OddsWideInfo(i).Kumi
                                wideOdds = RaceInfo.OddsWideInfo(i).OddsLow
                                If InStr(wideOdds, "*") > 0 Or InStr(wideOdds, "-") Or InStr(wideOdds, " ") > 0 Then
                                    wideOdds = "0"
                                    wideNinki = "0"
                                Else
                                    wideKumi = wideKumi.Substring(0, 2) & "-" & wideKumi.Substring(2)
                                    wideOdds /= 10
                                    wideNinkiArray.Add(wideNinki)
                                    wideUmabanArray.Add(wideKumi)
                                    wideOddsArray.Add(wideOdds)
                                    wideDictionary.Add(wideKumi, CDbl(wideOdds))
                                End If
                            Next i
                        End If
                        Exit Do

                    Case -1

                    Case 0
                        Exit Do
                    Case Else ' エラー
                        logTxt += "getWideOddsエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "getWideOddsエラー"
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop

            ReturnCode = AxJVLink1.JVClose()
            Return wideDictionary
        Else
            logTxt += "getwideOddsエラー" & vbLf
            Dim LineMsg = "getWideOddsエラー"
            If postEr = True Then
                postLine(LineMsg)
            End If
            Return vbNull
        End If
    End Function
    Function getUmatanOdds()
        If JvRTOpens("0B34") = 0 Then
            Dim RaceInfo As JV_O4_ODDS_UMATAN
            Dim umatanNinki
            Dim umatanKumi
            Dim umatanOdds
            Dim umatanDictionary = New Dictionary(Of String, Double)
            umatanOddsArray = New ArrayList
            umatanUmabanArray = New ArrayList
            umatanNinkiArray = New ArrayList
            Dim ReturnCode As Integer
            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0 ' 正常
                        If Mid(buff, 1, 2) = "O4" Then

                            RaceInfo.SetData(buff)

                            For i = 0 To RaceInfo.OddsUmatanInfo.Count - 1
                                umatanNinki = RaceInfo.OddsUmatanInfo(i).Ninki
                                umatanKumi = RaceInfo.OddsUmatanInfo(i).Kumi
                                umatanOdds = RaceInfo.OddsUmatanInfo(i).Odds
                                If InStr(umatanOdds, "*") > 0 Or InStr(umatanOdds, "-") Or InStr(umatanOdds, " ") > 0 Then
                                    umatanOdds = "0"
                                    umatanNinki = "0"
                                Else
                                    umatanKumi = umatanKumi.Substring(0, 2) & "-" & umatanKumi.Substring(2)
                                    umatanOdds /= 10
                                    umatanNinkiArray.Add(umatanNinki)
                                    umatanUmabanArray.Add(umatanKumi)
                                    umatanOddsArray.Add(umatanOdds)
                                    umatanDictionary.Add(umatanKumi, CDbl(umatanOdds))
                                End If
                            Next i
                        End If
                        Exit Do

                    Case -1

                    Case 0
                        Exit Do
                    Case Else ' エラー
                        logTxt += "getUmatanOddsエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "getUmatanOddsエラー"
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop

            ReturnCode = AxJVLink1.JVClose()
            Return umatanDictionary
        Else
            logTxt += "getumatanOddsエラー" & vbLf
            Return vbNull
        End If
    End Function
    Function getSanrenpukuOdds()
        If JvRTOpens("0B35") = 0 Then
            Dim buff As String = New String(vbNullChar, buffSize)
            Dim fName As String = ""
            Dim ReturnCode As Integer
            Dim RaceInfo As JV_O5_ODDS_SANREN
            Dim sanrenpukuOdds
            Dim sanrenpukuKumi
            Dim Umaban1 As String
            Dim Umaban2 As String
            Dim Umaban3 As String

            Dim sanrenpukuDictionary = New Dictionary(Of String, Double)

            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0 ' 正常
                        If Mid(buff, 1, 2) = "O5" Then

                            RaceInfo.SetData(buff)

                            For i = 0 To RaceInfo.OddsSanrenInfo.Count - 1

                                sanrenpukuKumi = RaceInfo.OddsSanrenInfo(i).Kumi
                                sanrenpukuOdds = RaceInfo.OddsSanrenInfo(i).Odds
                                '除外を確認する
                                If Strings.InStr(sanrenpukuOdds, "*") = 0 And Strings.InStr(sanrenpukuOdds, "-") = 0 And Strings.InStr(sanrenpukuOdds, " ") = 0 Then
                                    Umaban1 = sanrenpukuKumi.substring(0, 2)
                                    Umaban2 = sanrenpukuKumi.substring(2, 2)
                                    Umaban3 = sanrenpukuKumi.substring(4, 2)
                                    sanrenpukuKumi = Umaban1 & "-" & Umaban2 & "-" & Umaban3
                                    sanrenpukuOdds = sanrenpukuOdds / 10

                                    sanrenpukuDictionary.Add(sanrenpukuKumi, CDbl(sanrenpukuOdds))
                                End If

                            Next i
                        End If


                    Case -1

                    Case 0
                        Exit Do
                    Case Else ' エラー
                        logTxt += "getSanrenpukuOddsエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "getSanrenpukuOddsエラー"
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop

            ReturnCode = AxJVLink1.JVClose()
            Return sanrenpukuDictionary
        Else
            logTxt += "getSanrenpukuOddsエラー" & vbLf
            Return vbNull
        End If
    End Function
    Function getSanrentanOdds()
        If JvRTOpens("0B36") = 0 Then
            Dim buff As String = New String(vbNullChar, buffSize)
            Dim fName As String = ""
            Dim ReturnCode As Integer
            Dim RaceInfo As JV_O6_ODDS_SANRENTAN
            Dim sanrentanOdds
            Dim sanrentanKumi
            Dim Umaban1 As String
            Dim Umaban2 As String
            Dim Umaban3 As String
            Dim sanrentanNinki
            Dim sanrentanDictionary = New Dictionary(Of String, Double)

            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0 ' 正常
                        If Mid(buff, 1, 2) = "O6" Then

                            RaceInfo.SetData(buff)

                            For i = 0 To RaceInfo.OddsSanrentanInfo.Count - 1

                                sanrentanKumi = RaceInfo.OddsSanrentanInfo(i).Kumi
                                sanrentanOdds = RaceInfo.OddsSanrentanInfo(i).Odds
                                sanrentanNinki = RaceInfo.OddsSanrentanInfo(i).Ninki
                                '除外を確認する
                                If Strings.InStr(sanrentanOdds, "*") = 0 And Strings.InStr(sanrentanOdds, "-") = 0 And Strings.InStr(sanrentanOdds, " ") = 0 Then
                                    Umaban1 = sanrentanKumi.substring(0, 2)
                                    Umaban2 = sanrentanKumi.substring(2, 2)
                                    Umaban3 = sanrentanKumi.substring(4, 2)
                                    sanrentanKumi = Umaban1 & "-" & Umaban2 & "-" & Umaban3
                                    sanrentanOdds = sanrentanOdds / 10
                                    sanrentanDictionary.Add(sanrentanKumi, CDbl(sanrentanOdds))
                                End If

                            Next i
                        End If


                    Case -1

                    Case 0
                        Exit Do
                    Case Else ' エラー
                        logTxt += "getSanrentanOddsエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "getSanrentanOddsエラー"
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop

            ReturnCode = AxJVLink1.JVClose()
            Return sanrentanDictionary
        Else
            logTxt += "getSanrentanOddsエラー" & vbLf
            Dim LineMsg = "getSanrentanOddsエラー"
            If postEr = True Then
                postLine(LineMsg)
            End If
            Return vbNull
        End If
    End Function
    Sub getResult()
        If JvRTOpens("0B15") = 0 Then
            Dim ReturnCode As Integer
            Dim RaceInfo As JV_HR_PAY
            Dim jRaceNumber As Long
            Dim Henkanflag
            Dim HenkanHorse
            Dim henkanUmaban
            Dim HenkanUmabanArray As New ArrayList
            Dim RaceNumber As Integer = raceNumberCode
            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0
                        If Mid(buff, 1, 2) = "HR" Then
                            RaceInfo.SetData(buff)
                            jRaceNumber = RaceInfo.id.RaceNum
                            Henkanflag = RaceInfo.HenkanFlag(0)
                            If Henkanflag = 1 Then
                                For i = 0 To 20
                                    HenkanHorse = RaceInfo.HenkanUma(i)
                                    If HenkanHorse = 1 Then
                                        henkanUmaban = i + 1
                                        If henkanUmaban < 10 Then
                                            henkanUmaban = "0" & henkanUmaban
                                            HenkanUmabanArray.Add(henkanUmaban)
                                        End If
                                    End If
                                Next i
                            End If

                            Dim TansyoNinki = RaceInfo.PayTansyo(0).Ninki
                            Dim tansyoPayDictionary As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
                            Dim fukusyoPayDictionary As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
                            Dim wakurenPayDictionary As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
                            Dim umarenPayDictionary As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
                            Dim widePayDictionary As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
                            Dim umatanPayDictionary As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
                            Dim sanrentanPayDictionary As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
                            Dim sanrenpukuPayDictionary As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)

                            For i = 0 To 2
                                Dim tansyoUmaban = RaceInfo.PayTansyo(i).Umaban
                                Dim wakurenKumi = RaceInfo.PayWakuren(i).Umaban
                                Dim SanrenpukuKumi = RaceInfo.PaySanrenpuku(i).Kumi
                                Dim umarenKumi = RaceInfo.PayUmaren(i).Kumi

                                Try
                                    If InStr(tansyoUmaban, " ") = 0 Then
                                        Dim tansyoPay As Integer = RaceInfo.PayTansyo(i).Pay
                                        tansyoPayDictionary.Add(tansyoUmaban, tansyoPay)
                                    End If
                                Catch
                                End Try
                                Try
                                    If InStr(wakurenKumi, " ") = 0 And wakurenKumi <> "00" Then
                                        Dim wakurenPay As Integer = RaceInfo.PayWakuren(i).Pay
                                        wakurenKumi = wakurenKumi.Substring(0, 1) & "-" & wakurenKumi.Substring(1)
                                        wakurenPayDictionary.Add(wakurenKumi, wakurenPay)
                                    End If
                                Catch
                                End Try
                                Try
                                    If InStr(umarenKumi, " ") = 0 Then
                                        Dim umarenPay As Integer = RaceInfo.PayUmaren(i).Pay
                                        umarenKumi = umarenKumi.Substring(0, 2) & "-" & umarenKumi.Substring(2)
                                        umarenPayDictionary.Add(umarenKumi, umarenPay)
                                    End If
                                Catch
                                End Try
                                Try
                                    If InStr(SanrenpukuKumi, " ") = 0 Then
                                        Dim sanrenpukuPay As Integer = RaceInfo.PaySanrenpuku(i).Pay
                                        Dim umaban1 = SanrenpukuKumi.Substring(0, 2)
                                        Dim umaban2 = SanrenpukuKumi.Substring(2, 2)
                                        Dim umaban3 = SanrenpukuKumi.Substring(4, 2)
                                        SanrenpukuKumi = umaban1 & "-" & umaban2 & "-" & umaban3
                                        sanrenpukuPayDictionary.Add(SanrenpukuKumi, sanrenpukuPay)
                                    End If
                                Catch
                                End Try
                            Next i
                            For i = 0 To 5
                                Dim umatanKumi = RaceInfo.PayUmatan(i).Kumi
                                Dim sanrentanKumi = RaceInfo.PaySanrentan(i).Kumi
                                Try
                                    If InStr(umatanKumi, " ") = 0 Then
                                        Dim umatanPay As Integer = RaceInfo.PayUmatan(i).Pay
                                        umatanKumi = umatanKumi.Substring(0, 2) & "-" & umatanKumi.Substring(2)
                                        umatanPayDictionary.Add(umatanKumi, umatanPay)
                                    End If
                                Catch
                                End Try

                                Try
                                    If InStr(sanrentanKumi, " ") = 0 Then
                                        Dim sanrentanPay As Integer = RaceInfo.PaySanrentan(i).Pay
                                        Dim umaban1 = sanrentanKumi.Substring(0, 2)
                                        Dim umaban2 = sanrentanKumi.Substring(2, 2)
                                        Dim umaban3 = sanrentanKumi.Substring(4, 2)
                                        sanrentanKumi = umaban1 & "-" & umaban2 & "-" & umaban3
                                        sanrentanPayDictionary.Add(sanrentanKumi, sanrentanPay)
                                    End If
                                Catch
                                End Try
                            Next i

                            For i = 0 To 4
                                Dim fukusyoUmaban = RaceInfo.PayFukusyo(i).Umaban
                                Try
                                    If InStr(fukusyoUmaban, " ") = 0 And fukusyoUmaban <> "00" Then
                                        Dim fukusyoPay As Integer = RaceInfo.PayFukusyo(i).Pay
                                        fukusyoPayDictionary.Add(fukusyoUmaban, fukusyoPay)
                                    End If
                                Catch
                                End Try
                            Next i
                            For i = 0 To 6
                                Dim wideKumi = RaceInfo.PayWide(i).Kumi
                                Try
                                    If InStr(wideKumi, " ") = 0 And wideKumi <> "00" Then
                                        Dim widePay As Integer = RaceInfo.PayWide(i).Pay
                                        wideKumi = wideKumi.Substring(0, 2) & "-" & wideKumi.Substring(2)
                                        widePayDictionary.Add(wideKumi, widePay)
                                    End If
                                Catch
                                End Try
                            Next i


                            Call setResult(Henkanflag, HenkanUmabanArray, tansyoPayDictionary, fukusyoPayDictionary, wakurenPayDictionary,
                                           umarenPayDictionary, widePayDictionary, umatanPayDictionary, sanrenpukuPayDictionary, sanrentanPayDictionary)

                        End If

                    Case -1

                    Case 0 ' 読込終了
                        Exit Do
                    Case Else ' エラー
                        logTxt += "JVReadエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "JVReadエラー:" & ReturnCode
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop


            ' JVClose
            ReturnCode = AxJVLink1.JVClose()

        End If
    End Sub

    Sub getAllOdds()
        getTansyoOdds()
        getFukusyoOdds()
        getWakurenOdds()
        getUmarenOdds()
        getWideOdds()
        getUmatanOdds()
        getSanrenpukuOdds()
        getSanrentanOdds()
    End Sub


    Sub UpdateJvRaceData()
        Using conn As New NpgsqlConnection(localConnStr)
            conn.Open()
            Dim transaction As NpgsqlTransaction = conn.BeginTransaction()
            Dim dmDictionary As Dictionary(Of Integer, Double) = getDM() 'タイムデータマイニング
            Dim tmDictionary As Dictionary(Of Integer, Double) = getBM() '対戦データマイニング
            Dim baTaijuDictionary As Dictionary(Of Integer, String) = getWH() '馬体重
            Dim babaTenkoArrayList As ArrayList = getWE() '天候馬場状態
            Dim zyogaiDictionary As Dictionary(Of Integer, Integer) = getIjyoData() ' 除外
            For i = 1 To dmDictionary.Count
                Dim umaban As String = i.ToString("00")
                Dim raceIdSE As String = Str(raceId) & umaban
                Dim bataijus As String = baTaijuDictionary(umaban)
                Dim sptBataijus = Split(bataijus, "_")
                Dim bataiju As Integer = sptBataijus(0)
                Dim zogen As Double = sptBataijus(1)
                Dim dm As Double = dmDictionary(umaban)
                Dim bm As Double = tmDictionary(umaban)
                Dim tenko As Integer = babaTenkoArrayList(1)
                Dim baba As Integer = babaTenkoArrayList(0)
                Dim zyogai As Integer = zyogaiDictionary(Int(umaban))
                Dim insertSql As New NpgsqlCommand($"INSERT INTO real_time_jv_data (race_id,bataiju,zogen,baba,tenko,dm,bm,zyogai) 
                                                     VALUES ({raceIdSE},{bataiju},{zogen},{baba},{tenko},{dm},{bm},{zyogai}) ON CONFLICT (race_id) DO NOTHING;", conn)
                insertSql.ExecuteNonQuery()
                Dim updateSql As New NpgsqlCommand($"UPDATE race_se SET taijyu = {bataiju},zogen = {zogen},baba_condition = {baba},tenko_code = {tenko},zyogai = {zyogai},dm = {dm},bm = {bm}
                                                         WHERE race_id = {raceIdSE};", conn)
                updateSql.ExecuteNonQuery()
            Next i
            transaction.Commit()
        End Using
    End Sub

    Function getBM()
        Dim tmDictionary As Dictionary(Of Integer, Double) = New Dictionary(Of Integer, Double)
        If JvRTOpens("0B17") = 0 Then
            Dim RaceInfo As JV_TM_INFO
            Dim ReturnCode As Integer

            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0
                        If Mid(buff, 1, 2) = "TM" Then
                            RaceInfo.SetData(buff)

                            For i = 0 To 17
                                Dim mining As Double = 0
                                Try
                                    Dim umaban As Integer = RaceInfo.TMInfo(i).Umaban
                                    Dim tmTimeData As String = RaceInfo.TMInfo(i).TMScore
                                    mining = tmTimeData / 10
                                    tmDictionary.Add(umaban, mining)
                                Catch
                                    Exit Do
                                End Try
                            Next i
                        End If

                    Case -1

                    Case 0 ' 読込終了
                        Exit Do
                    Case Else ' エラー
                        logTxt += "JVReadエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "JVReadエラー:" & ReturnCode
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop
            ' JVClose
            ReturnCode = AxJVLink1.JVClose()

        End If
        Return tmDictionary

    End Function

    Function getDM()
        Dim dmDictionary As Dictionary(Of Integer, Double) = New Dictionary(Of Integer, Double)

        If JvRTOpens("0B13") = 0 Then
            Dim RaceInfo As JV_DM_INFO
            Dim ReturnCode As Integer

            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0
                        If Mid(buff, 1, 2) = "DM" Then
                            RaceInfo.SetData(buff)

                            For i = 0 To 17
                                Dim mining As Double = 0
                                Try
                                    Dim umaban As Integer = RaceInfo.DMInfo(i).Umaban
                                    Dim dmTimeData As String = RaceInfo.DMInfo(i).DMTime
                                    Dim min As Integer = dmTimeData.Substring(0, 1)
                                    Dim sec As Double = CDbl(dmTimeData.Substring(1)) / 100
                                    Dim minSec = min * 60
                                    mining = minSec + sec

                                    dmDictionary.Add(umaban, mining)

                                Catch
                                    Exit Do
                                End Try
                            Next i
                        End If

                    Case -1

                    Case 0 ' 読込終了
                        Exit Do
                    Case Else ' エラー
                        logTxt += "JVReadエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "JVReadエラー:" & ReturnCode
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop
            ' JVClose
            ReturnCode = AxJVLink1.JVClose()

        End If
        Return dmDictionary
    End Function

    Function getWE()

        Dim babaTenkoArrayList As ArrayList = New ArrayList
        If JvRTOpens("0B14") = 0 Then
            Dim RaceInfo As JV_WE_WEATHER
            Dim ReturnCode As Integer
            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0
                        If Mid(buff, 1, 2) = "WE" Then
                            RaceInfo.SetData(buff)
                            Try
                                Dim tenko As Integer = RaceInfo.TenkoBaba.TenkoCD
                                Dim sibaBaba As Integer = RaceInfo.TenkoBaba.SibaBabaCD
                                Dim dirtBaba As Integer = RaceInfo.TenkoBaba.DirtBabaCD
                                Dim babaCondition As Integer = 0
                                If sibaBaba = 0 Then
                                    babaCondition = dirtBaba
                                Else
                                    babaCondition = sibaBaba
                                End If
                                babaTenkoArrayList.Add(babaCondition)
                                babaTenkoArrayList.Add(tenko)

                            Catch
                                logTxt += "JV_WEエラー" & vbLf
                                Dim LineMsg = "JVReadエラー:" & ReturnCode
                                If postEr = True Then
                                    postLine(LineMsg)
                                End If
                                Exit Do
                            End Try

                        End If
                    Case -1

                    Case 0 ' 読込終了
                        Exit Do
                    Case Else ' エラー
                        logTxt += "JVReadエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "JVReadエラー:" & ReturnCode
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop
            ' JVClose
            ReturnCode = AxJVLink1.JVClose()

        End If
        Return babaTenkoArrayList

    End Function

    Function getWH()
        Dim baTaijuDictionary As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
        If JvRTOpens("0B11") = 0 Then
            Dim RaceInfo As JV_WH_BATAIJYU
            Dim ReturnCode As Integer
            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0
                        If Mid(buff, 1, 2) = "WH" Then
                            RaceInfo.SetData(buff)
                            Try
                                For i = 0 To RaceInfo.BataijyuInfo.Count - 1

                                    Dim umaban As Integer = RaceInfo.BataijyuInfo(i).Umaban
                                    Dim baTaiju As String = RaceInfo.BataijyuInfo(i).BaTaijyu
                                    Dim zougenFugo As String = RaceInfo.BataijyuInfo(i).ZogenFugo
                                    Dim zougenNullCheck As String = RaceInfo.BataijyuInfo(i).ZogenSa
                                    Dim zougenSa As Integer = 0
                                    If InStr(zougenNullCheck, " ") = 0 Then
                                        zougenSa = zougenFugo & RaceInfo.BataijyuInfo(i).ZogenSa
                                    End If
                                    Dim setTaiju As String = baTaiju & "_" & zougenSa
                                    baTaijuDictionary.Add(umaban, setTaiju)
                                Next i
                            Catch

                                Exit Do
                            End Try
                        End If
                    Case -1

                    Case 0 ' 読込終了
                        Exit Do
                    Case Else ' エラー
                        logTxt += "JVReadエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "JVReadエラー:" & ReturnCode
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop
            ' JVClose
            ReturnCode = AxJVLink1.JVClose()
        End If
        Return baTaijuDictionary
    End Function

    Function getBamei()
        Dim bameiDictionary As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
        If JvRTOpens("0B15") = 0 Then
            Dim RaceInfo As JV_SE_RACE_UMA
            Dim ReturnCode As Integer

            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0
                        If Mid(buff, 1, 2) = "SE" Then
                            RaceInfo.SetData(buff)
                            Dim bamei As String = RaceInfo.Bamei.Replace(" ", "").Replace("　", "")
                            Dim umaban As Integer = RaceInfo.Umaban
                            bameiDictionary.Add(umaban, bamei)
                        End If
                    Case -1

                    Case 0 ' 読込終了
                        Exit Do
                    Case Else ' エラー
                        logTxt += "JVReadエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "JVReadエラー:" & ReturnCode
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop
            ' JVClose
            ReturnCode = AxJVLink1.JVClose()

        End If
        Return bameiDictionary
    End Function

    Function getIjyoData()
        Dim iJyoDictionary As Dictionary(Of Integer, Integer) = New Dictionary(Of Integer, Integer)
        For i = 1 To 18
            iJyoDictionary.Add(i, 0)
        Next i
        If JvRTOpens("0B14") = 0 Then
            Dim RaceInfo As JV_AV_INFO
            Dim ReturnCode As Integer

            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0
                        If Mid(buff, 1, 2) = "AV" Then
                            RaceInfo.SetData(buff)
                            Dim jvRaceNumCode As String = RaceInfo.id.RaceNum
                            Dim jvCode As String = RaceInfo.id.JyoCD
                            If jvRaceNumCode = raceNumberCode And Code = jvCode Then
                                Dim ijyo As Integer = RaceInfo.JiyuKubun
                                If ijyo <> 0 Then
                                    ijyo = 1
                                End If
                                Dim umaban As Integer = RaceInfo.Umaban
                                iJyoDictionary(umaban) = ijyo
                            End If
                        End If
                    Case -1

                    Case 0 ' 読込終了
                        Exit Do
                    Case Else ' エラー
                        logTxt += "JVReadエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "JVReadエラー:" & ReturnCode
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop
            ' JVClose
            ReturnCode = AxJVLink1.JVClose()

        End If
        Return iJyoDictionary
    End Function

    Function getTrackCode()
        Dim trackCode As Integer = 51
        If JvRTOpens("0B15") = 0 Then
            Dim ReturnCode As Integer
            Dim RaceInfo As JV_RA_RACE
            Dim hassoTime As String
            Dim raceNum As Integer
            Dim mmddDate
            mmddDate = Now.ToString("MMdd")

            Do
                ReturnCode = AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0
                        If Mid(buff, 1, 2) = "RA" Then
                            RaceInfo.SetData(buff)
                            trackCode = RaceInfo.TrackCD
                        End If
                    Case -1
     '何もしない
                    Case 0 ' 読込終了
                        Exit Do
                    Case Else ' エラー
                        Dim LineMsg = "JVReadエラー:" & ReturnCode
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop
endclose:


            ' JVClose
            ReturnCode = AxJVLink1.JVClose()

        End If
        Return trackCode
    End Function

    Function getAllBabaCondition()
        Dim allBabaTenkoDictionary As Dictionary(Of String, ArrayList) = New Dictionary(Of String, ArrayList)
        Dim babaTenkoArrayList As ArrayList = New ArrayList
        If JvRTOpens("0B14") = 0 Then
            Dim RaceInfo As JV_WE_WEATHER
            Dim ReturnCode As Integer
            Do
                ReturnCode = Me.AxJVLink1.JVRead(buff, buffSize, fName)
                Select Case ReturnCode
                    Case Is > 0
                        If Mid(buff, 1, 2) = "WE" Then
                            RaceInfo.SetData(buff)
                            Try
                                Dim kaisaiCode As String = RaceInfo.id.JyoCD

                                Dim tenko As Integer = RaceInfo.TenkoBaba.TenkoCD
                                Dim sibaBaba As Integer = RaceInfo.TenkoBaba.SibaBabaCD
                                Dim dirtBaba As Integer = RaceInfo.TenkoBaba.DirtBabaCD
                                Dim babaCondition As Integer = 0
                                If sibaBaba = 0 Then
                                    babaCondition = dirtBaba
                                Else
                                    babaCondition = sibaBaba
                                End If
                                babaTenkoArrayList.Add(babaCondition)
                                babaTenkoArrayList.Add(tenko)
                                allBabaTenkoDictionary.Add(kaisaiCode, babaTenkoArrayList)

                            Catch

                            End Try

                        End If
                    Case -1

                    Case 0 ' 読込終了
                        Exit Do
                    Case Else ' エラー
                        logTxt += "jvReadエラー:" & ReturnCode & vbLf
                        Dim LineMsg = "jvReadエラー:" & ReturnCode
                        If postEr = True Then
                            postLine(LineMsg)
                        End If
                        Exit Do
                End Select
            Loop
            ' jvClose
            ReturnCode = Me.AxJVLink1.JVClose()

        End If
        Return allBabaTenkoDictionary
    End Function

    Private Sub Jv_Link_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class