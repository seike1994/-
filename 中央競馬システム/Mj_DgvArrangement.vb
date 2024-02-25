
Imports System.IO
Imports System.Data
Imports System.Web.Caching
Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.InteropServices

Module Mj_DgvArrangement

    Sub TopReset()
        Class_MainForm.dayTotalBuyTxt.Text = "0"
        Class_MainForm.dayTotalPayTxt.Text = "0"
        Class_MainForm.dayTotalBalanceTxt.Text = "0"
        Class_MainForm.dayTotalParseTxt.Text = "0"

        For i = 0 To Class_MainForm.dayResultDgv3.Rows.Count - 1
            Class_MainForm.dayResultDgv3.Rows.RemoveAt(0)
        Next i
        For i = 0 To Class_MainForm.dayResultDgv2.Rows.Count - 1
            Class_MainForm.dayResultDgv2.Rows.RemoveAt(0)
            Class_MainForm.dayResultDgv1.Rows.RemoveAt(0)
        Next i
    End Sub

    Sub dgvSave()

        SaveDataToTextFile(allDayPath, allDayTable)
        SaveDataToTextFile(allAreaPath, allAreaTable)
        SaveDataToTextFile(dayDgvPath1, dayDgvTable1)
        SaveDataToTextFile(dayDgvPath2, dayDgvTable2)
        SaveDataToTextFile(dayDgvPath3, dayDgvTable3)
        SaveDataToTextFile(sapporoPath, sapporoTable)
        SaveDataToTextFile(hakodatePath, hakodateTable)
        SaveDataToTextFile(fukushimaPath, fukushimaTable)
        SaveDataToTextFile(niigataPath, niigataTable)
        SaveDataToTextFile(tokyoPath, tokyoTable)
        SaveDataToTextFile(nakayamaPath, nakayamaTable)
        SaveDataToTextFile(chukyoPath, chukyoTable)
        SaveDataToTextFile(kyotoPath, kyotoTable)
        SaveDataToTextFile(hanshinPath, hanshinTable)
        SaveDataToTextFile(kokuraPath, kokuraTable)


    End Sub

    Private Sub SaveDataToTextFile(filePath As String, dataTable As DataTable)
        ' テキストファイルにデータを保存
        Using writer As New StreamWriter(filePath)
            ' ヘッダ行を書き込む（列名）
            For Each column As DataColumn In dataTable.Columns
                If column.ColumnName <> "Column1" Then
                    writer.Write(column.ColumnName)
                    If column.Ordinal < dataTable.Columns.Count - 1 Then
                        writer.Write(vbTab) ' 列をタブ文字で区切る（または適切な区切り文字を使用）
                    End If
                End If
            Next
            writer.WriteLine() ' ヘッダ行の後に改行を追加

            ' データ行を書き込む
            For Each row As DataRow In dataTable.Rows
                Dim columnIndex As Integer = 0
                For Each item As Object In row.ItemArray
                    writer.Write(item.ToString())
                    If columnIndex < row.ItemArray.Length - 1 Then
                        writer.Write(vbTab) ' 最後の列でない場合はタブ文字を追加
                    End If
                    columnIndex += 1
                Next
                writer.WriteLine() ' 行の最後に改行を追加
            Next
            writer.Close()
        End Using
    End Sub

    ' テキストファイルからデータを読み取り、DataGridViewにバインドする関数
    Sub dgvLoad()
        Dim dgvTable As DataTable
        For i = 1 To 15
            Dim filePath As String = ""
            Select Case i
                Case 1
                    dgvTable = allDayTable
                    filePath = allDayPath
                    dgvTable.Clear()
                Case 2
                    dgvTable = allAreaTable
                    filePath = allAreaPath
                    dgvTable.Clear()
                Case 3
                    dgvTable = dayDgvTable1
                    filePath = dayDgvPath1
                    dgvTable.Clear()
                Case 4
                    dgvTable = dayDgvTable2
                    filePath = dayDgvPath2
                    dgvTable.Clear()
                Case 5
                    dgvTable = dayDgvTable3
                    filePath = dayDgvPath3
                    dgvTable.Clear()
                Case 6
                    dgvTable = sapporoTable
                    filePath = sapporoPath
                    dgvTable.Clear()
                Case 7
                    dgvTable = hakodateTable
                    filePath = hakodatePath
                    dgvTable.Clear()
                Case 8
                    dgvTable = fukushimaTable
                    filePath = fukushimaPath
                    dgvTable.Clear()
                Case 9
                    dgvTable = niigataTable
                    filePath = niigataPath
                    dgvTable.Clear()
                Case 10
                    dgvTable = tokyoTable
                    dgvTable.Clear()
                    filePath = tokyoPath
                Case 11
                    dgvTable = nakayamaTable
                    filePath = nakayamaPath
                    dgvTable.Clear()
                Case 12
                    dgvTable = chukyoTable
                    dgvTable.Clear()
                    filePath = chukyoPath
                Case 13
                    dgvTable = kyotoTable
                    filePath = kyotoPath
                    dgvTable.Clear()
                Case 14
                    dgvTable = hanshinTable
                    filePath = hanshinPath
                    dgvTable.Clear()
                Case 15
                    dgvTable = kokuraTable
                    filePath = kokuraPath
                    dgvTable.Clear()
            End Select
            dgvTable.Clear()

            ' テキストファイルからデータを読み取り、データテーブルに変換
            Dim textFileTable As New DataTable
            Using reader As New StreamReader(filePath)
                ' ヘッダ行を読み取り、データテーブルの列を作成
                Dim headerLine As String = reader.ReadLine()
                Dim columnNames As String() = headerLine.Split(vbTab) ' タブ文字を区切り文字として使用
                For Each columnName As String In columnNames
                    textFileTable.Columns.Add(columnName)
                Next

                ' データ行を読み取り、データテーブルに追加
                While Not reader.EndOfStream
                    Dim dataLine As String = reader.ReadLine()
                    Dim dataValues As String() = dataLine.Split(vbTab) ' タブ文字を区切り文字として使用
                    textFileTable.Rows.Add(dataValues)
                End While
            End Using
            dgvTable = textFileTable

            Select Case i
                Case 1
                    allDayTable = dgvTable
                Case 2
                    allAreaTable = dgvTable
                Case 3
                    dayDgvTable1 = dgvTable
                Case 4
                    dayDgvTable2 = dgvTable
                Case 5
                    dayDgvTable3 = dgvTable
                Case 6
                    sapporoTable = dgvTable
                Case 7
                    hakodateTable = dgvTable
                Case 8
                    fukushimaTable = dgvTable
                Case 9
                    niigataTable = dgvTable
                Case 10
                    tokyoTable = dgvTable
                Case 11
                    nakayamaTable = dgvTable
                Case 12
                    chukyoTable = dgvTable
                Case 13
                    kyotoTable = dgvTable
                Case 14
                    hanshinTable = dgvTable
                Case 15
                    kokuraTable = dgvTable
            End Select


            setDgv()



            dgvWidthSize()
        Next i
    End Sub
    Sub setDgv()
        Class_MainForm.dayResultDgv1.DataSource = dayDgvTable1
        Class_MainForm.dayResultDgv2.DataSource = dayDgvTable2
        Class_MainForm.dayResultDgv3.DataSource = dayDgvTable3
        Class_TotalResult.AllResultDay.DataSource = allDayTable
        Class_TotalResult.AllResultArea.DataSource = allAreaTable
        Class_TotalResult.sapporoDgv.DataSource = sapporoTable
        Class_TotalResult.hakodateDgv.DataSource = hakodateTable
        Class_TotalResult.fukushimaDgv.DataSource = fukushimaTable
        Class_TotalResult.niigataDgv.DataSource = niigataTable
        Class_TotalResult.tokyoDgv.DataSource = tokyoTable
        Class_TotalResult.nakayamaDgv.DataSource = nakayamaTable
        Class_TotalResult.chukyoDgv.DataSource = chukyoTable
        Class_TotalResult.kyotoDgv.DataSource = kyotoTable
        Class_TotalResult.hanshinDgv.DataSource = hanshinTable
        Class_TotalResult.kokuraDgv.DataSource = kokuraTable
    End Sub
    Sub dgvWidthSize()
        Class_MainForm.dayResultDgv1.AutoResizeColumns()
        Class_MainForm.dayResultDgv2.AutoResizeColumns()
        Class_MainForm.dayResultDgv3.AutoResizeColumns()
        Class_TotalResult.AllResultDay.AutoResizeColumns()
        Class_TotalResult.AllResultArea.AutoResizeColumns()
        Class_TotalResult.sapporoDgv.AutoResizeColumns()
        Class_TotalResult.hakodateDgv.AutoResizeColumns()
        Class_TotalResult.fukushimaDgv.AutoResizeColumns()
        Class_TotalResult.niigataDgv.AutoResizeColumns()
        Class_TotalResult.tokyoDgv.AutoResizeColumns()
        Class_TotalResult.nakayamaDgv.AutoResizeColumns()
        Class_TotalResult.chukyoDgv.AutoResizeColumns()
        Class_TotalResult.kyotoDgv.AutoResizeColumns()
        Class_TotalResult.hanshinDgv.AutoResizeColumns()
        Class_TotalResult.kokuraDgv.AutoResizeColumns()
    End Sub

    Sub checkDgvSave()
        Dim currentPath As String = Directory.GetCurrentDirectory()
        Dim dgvFolderPath As String = Path.Combine(currentPath, "dgv")

        ' アップロードされたファイルの内容を辞書に格納
        Dim fileContents As Dictionary(Of String, String) = New Dictionary(Of String, String)
        For i = 1 To 10
            Dim title As String = ""
            Select Case i
                Case 1
                    title = "sapporoArea"
                Case 2
                    title = "hakodateArea"
                Case 3
                    title = "fukushimaArea"
                Case 4
                    title = "niigataArea"
                Case 5
                    title = "tokyoArea"
                Case 6
                    title = "nakayamaArea"
                Case 7
                    title = "chukyoArea"
                Case 8
                    title = "kyotoArea"
                Case 9
                    title = "hanshinArea"
                Case 10
                    title = "kokuraArea"
            End Select

            fileContents.Add(title & ".txt", "開催日" & vbTab & "場名" & vbTab & "R" & vbTab & "式別" & vbTab & "馬番" & vbTab & "オッズ" & vbTab & "期待値" & vbTab & "投票時間" & vbTab & "投票の可否" & vbTab & "購入金額" & vbTab & "払戻金額")
        Next i

        For i = 1 To 3
            Dim title As String = ""
            Select Case i
                Case 1
                    title = "dayDgv1"
                Case 2
                    title = "dayDgv2"
                Case 3
                    title = "dayDgv3"

            End Select

            fileContents.Add(title & ".txt", "ﾚｰｽ" & vbTab & "-" & vbTab & "発走時刻" & vbTab & "購入金額" & vbTab & "払戻金額" & vbTab & "収支" & vbTab & "回収率")
        Next i
        For i = 1 To 2
            Dim title As String = ""
            Dim article As String = ""
            Select Case i
                Case 1
                    title = "allArea"
                    article = "競馬場別" & vbTab & "購入金額" & vbTab & "払戻金額" & vbTab & "収支" & vbTab & "回収率" & vbLf &
                        "札幌" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0%" & vbLf &
                        "函館" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0%" & vbLf &
                        "福島" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0%" & vbLf &
                        "新潟" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0%" & vbLf &
                        "東京" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0%" & vbLf &
                        "中山" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0%" & vbLf &
                        "中京" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0%" & vbLf &
                        "京都" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0%" & vbLf &
                        "阪神" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0%" & vbLf &
                        "小倉" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0%" & vbLf &
                        "全体" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0%" & vbLf
                Case 2
                    title = "allDay"
                    article = "式別" & vbTab & "購入金額" & vbTab & "払戻金額" & vbTab & "収支" & vbTab & "回収率" & vbLf &
                        "単勝" & vbLf &
                        "複勝" & vbLf &
                        "枠連" & vbLf &
                        "馬連" & vbLf &
                        "ワイド" & vbLf &
                        "馬単" & vbLf &
                        "3連複" & vbLf &
                        "3連単" & vbLf &
                        "合計"
            End Select

            fileContents.Add(title & ".txt", article)
        Next i

        ' dgvフォルダの存在チェックと作成
        If Not Directory.Exists(dgvFolderPath) Then
            Directory.CreateDirectory(dgvFolderPath)
        End If

        ' ファイルの存在チェック、作成、および内容の書き込み
        For Each fileName In fileContents.Keys
            Dim filePath As String = Path.Combine(dgvFolderPath, fileName)
            If Not File.Exists(filePath) Then
                Using writer As StreamWriter = File.CreateText(filePath)
                    writer.Write(fileContents(fileName))
                End Using
            End If
        Next
    End Sub

End Module
