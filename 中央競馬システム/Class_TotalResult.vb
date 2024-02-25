Imports Microsoft.Office.Interop

Public Class Class_TotalResult
    Private Sub TotalResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AllResultDay.DataSource = allDayTable
        AllResultArea.DataSource = allAreaTable
        sapporoDgv.DataSource = sapporoTable
        hakodateDgv.DataSource = hakodateTable
        fukushimaDgv.DataSource = fukushimaTable
        niigataDgv.DataSource = niigataTable
        tokyoDgv.DataSource = tokyoTable
        nakayamaDgv.DataSource = nakayamaTable
        chukyoDgv.DataSource = chukyoTable
        kyotoDgv.DataSource = kyotoTable
        hanshinDgv.DataSource = hanshinTable
        kokuraDgv.DataSource = kokuraTable

        dgv()
        dgvWidthSize()
        writeAllArea()

        For Each c As DataGridViewColumn In AllResultDay.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
        For Each c As DataGridViewColumn In AllResultArea.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
        For Each c As DataGridViewColumn In sapporoDgv.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
        For Each c As DataGridViewColumn In hakodateDgv.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
        For Each c As DataGridViewColumn In fukushimaDgv.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
        For Each c As DataGridViewColumn In niigataDgv.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
        For Each c As DataGridViewColumn In tokyoDgv.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
        For Each c As DataGridViewColumn In nakayamaDgv.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
        For Each c As DataGridViewColumn In chukyoDgv.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
        For Each c As DataGridViewColumn In kyotoDgv.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
        For Each c As DataGridViewColumn In hanshinDgv.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
        For Each c As DataGridViewColumn In kokuraDgv.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
    End Sub


    Sub writeAllArea()
        Dim strHantei As String = "〇"
        If loadCheck.Checked = True Then
            strHantei = "S"
        End If

        Dim totalTansyoBuy As Long = 0
        Dim totalFukusyoBuy As Long = 0
        Dim totalWakurenBuy As Long = 0
        Dim totalUmarenBuy As Long = 0
        Dim totalWideBuy As Long = 0
        Dim totalUmatanBuy As Long = 0
        Dim totalSanrenpukuBuy As Long = 0
        Dim totalSanrentanBuy As Long = 0
        Dim totalDayBuy As Long = 0
        Dim totalTansyoPay As Long = 0
        Dim totalFukusyoPay As Long = 0
        Dim totalWakurenPay As Long = 0
        Dim totalUmarenPay As Long = 0
        Dim totalWidePay As Long = 0
        Dim totalUmatanPay As Long = 0
        Dim totalSanrenpukuPay As Long = 0
        Dim totalSanrentanPay As Long = 0
        Dim totalDayPay As Long = 0
        For i = 1 To 10
            Dim table As DataTable
            Select Case i
                Case 1
                    table = sapporoTable
                Case 2
                    table = hakodateTable
                Case 3
                    table = fukushimaTable
                Case 4
                    table = niigataTable
                Case 5
                    table = tokyoTable
                Case 6
                    table = nakayamaTable
                Case 7
                    table = chukyoTable
                Case 8
                    table = kyotoTable
                Case 9
                    table = hanshinTable
                Case 10
                    table = kokuraTable
            End Select

            Dim totalBuy As Long = 0
            Dim totalPay As Long = 0
            For Each row In table.Rows
                Dim hantei As String = row("投票の可否")
                Dim sikibetu As String = row("式別")
                If hantei = strHantei Or hantei = "〇" Then
                    Dim buy As Integer = row("購入金額")
                    Dim payCheck = row("払戻金額")
                    Dim pay As Integer = 0
                    If payCheck Is DBNull.Value Then
                        pay = 0
                    ElseIf payCheck <> "" Then
                        pay = payCheck
                    End If
                    totalBuy += buy
                    totalPay += pay

                    Select Case sikibetu
                        Case "単勝"
                            totalTansyoBuy += buy
                            totalTansyoPay += pay
                        Case "複勝"
                            totalFukusyoBuy += buy
                            totalFukusyoPay += pay
                        Case "枠連"
                            totalWakurenBuy += buy
                            totalWakurenPay += pay
                        Case "馬連"
                            totalUmarenBuy += buy
                            totalUmarenPay += pay
                        Case "ワイド"
                            totalWideBuy += buy
                            totalWidePay += pay
                        Case "馬単"
                            totalUmatanBuy += buy
                            totalUmatanPay += pay
                        Case "3連複"
                            totalSanrenpukuBuy += buy
                            totalSanrenpukuPay += pay
                        Case "3連単"
                            totalSanrentanBuy += buy
                            totalSanrentanPay += pay
                    End Select
                End If
            Next
            allAreaTable.Rows(i - 1)(1) = totalBuy
            allAreaTable.Rows(i - 1)(2) = totalPay
            allAreaTable.Rows(i - 1)(3) = totalPay - totalBuy
            If totalBuy > 0 Then
                allAreaTable.Rows(i - 1)(4) = ((totalPay / totalBuy) * 100).ToString("0.0") & "%"
            Else
                allAreaTable.Rows(i - 1)(4) = "0%"
            End If
        Next i
        Dim allTotalBuy As Long = 0
        Dim allTotalPay As Long = 0
        For i = 0 To allAreaTable.Rows.Count - 2
            Dim row As DataRow = allAreaTable.Rows(i)
            Dim buy As Long = row("購入金額")
            Dim pay As Long = row("払戻金額")
            allTotalBuy += buy
            allTotalPay += pay
        Next
        allAreaTable.Rows(10)(1) = allTotalBuy
        allAreaTable.Rows(10)(2) = allTotalPay
        allAreaTable.Rows(10)(3) = allTotalPay - allTotalBuy
        If allTotalBuy > 0 Then
            allAreaTable.Rows(10)(4) = ((allTotalPay / allTotalBuy) * 100).ToString("0.0") & "%"
        Else
            allAreaTable.Rows(10)(4) = "0%"
        End If

        For i = 0 To 8
            Dim totalBuy As Long = 0
            Dim totalPay As Long = 0
            Select Case i
                Case 0
                    totalBuy = totalTansyoBuy
                    totalPay = totalTansyoPay
                Case 1
                    totalBuy = totalFukusyoBuy
                    totalPay = totalFukusyoPay
                Case 2
                    totalBuy = totalWakurenBuy
                    totalPay = totalWakurenPay
                Case 3
                    totalBuy = totalUmarenBuy
                    totalPay = totalUmarenPay
                Case 4
                    totalBuy = totalWideBuy
                    totalPay = totalWidePay
                Case 5
                    totalBuy = totalUmatanBuy
                    totalPay = totalUmatanPay
                Case 6
                    totalBuy = totalSanrenpukuBuy
                    totalPay = totalSanrenpukuPay
                Case 7
                    totalBuy = totalSanrentanBuy
                    totalPay = totalSanrentanPay
                Case 8
                    totalBuy = totalTansyoBuy + totalFukusyoBuy + totalWakurenBuy + totalUmarenBuy + totalWideBuy + totalUmatanBuy + totalSanrenpukuBuy + totalSanrentanBuy
                    totalPay = totalTansyoPay + totalFukusyoPay + totalWakurenPay + totalUmarenPay + totalWidePay + totalUmatanPay + totalSanrenpukuPay + totalSanrentanPay
            End Select
            allDayTable.Rows(i)(1) = totalBuy
            allDayTable.Rows(i)(2) = totalPay
            allDayTable.Rows(i)(3) = totalPay - totalBuy
            If totalBuy > 0 Then
                allDayTable.Rows(i)(4) = ((totalPay / totalBuy) * 100).ToString("0.0") & "%"
            Else
                allDayTable.Rows(i)(4) = "0%"
            End If
        Next i
    End Sub

    Sub dgv()

        tab.SelectedTab = sapporoPage
        tab.SelectedTab = hakodatePage
        tab.SelectedTab = fukushimaPage
        tab.SelectedTab = niigataPage
        tab.SelectedTab = tokyoPage
        tab.SelectedTab = nakayamaPage
        tab.SelectedTab = chukyoPage
        tab.SelectedTab = kyotoPage
        tab.SelectedTab = hanshinPage
        tab.SelectedTab = kokuraPage


        tab.SelectedTab = mainPage
    End Sub

    Private Sub Excel_Output_Click(sender As Object, e As EventArgs) Handles Button7.Click
        outputExcel()
    End Sub

    Sub outputExcel()
        Dim excelApp As New Microsoft.Office.Interop.Excel.Application()
        Dim workBook As Microsoft.Office.Interop.Excel.Workbook = excelApp.Workbooks.Add()
        While workBook.Sheets.Count < 12
            workBook.Sheets.Add(After:=workBook.Sheets(workBook.Sheets.Count))
        End While
        workBook.Sheets(1).Name = "総合結果"
        workBook.Sheets(2).Name = "式別毎"
        workBook.Sheets(3).Name = "札幌"
        workBook.Sheets(4).Name = "函館"
        workBook.Sheets(5).Name = "福島"
        workBook.Sheets(6).Name = "新潟"
        workBook.Sheets(7).Name = "東京"
        workBook.Sheets(8).Name = "中山"
        workBook.Sheets(9).Name = "中京"
        workBook.Sheets(10).Name = "京都"
        workBook.Sheets(11).Name = "阪神"
        workBook.Sheets(12).Name = "小倉"
        Dim sheet As Microsoft.Office.Interop.Excel.Worksheet
        For Each sheet In workBook.Sheets
            sheet.Columns("E:E").NumberFormat = "@"
        Next sheet
        writeExcel(allAreaTable, workBook.Sheets(1))
        writeExcel(allDayTable, workBook.Sheets(2))
        writeExcel(sapporoTable, workBook.Sheets(3))
        writeExcel(hakodateTable, workBook.Sheets(4))
        writeExcel(fukushimaTable, workBook.Sheets(5))
        writeExcel(niigataTable, workBook.Sheets(6))
        writeExcel(tokyoTable, workBook.Sheets(7))
        writeExcel(nakayamaTable, workBook.Sheets(8))
        writeExcel(chukyoTable, workBook.Sheets(9))
        writeExcel(kyotoTable, workBook.Sheets(10))
        writeExcel(hanshinTable, workBook.Sheets(11))
        writeExcel(kokuraTable, workBook.Sheets(12))
        Dim currentPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
        Dim filePath As String = System.IO.Path.Combine(currentPath, "中央競馬結果.xlsx")
        Try
            excelApp.DisplayAlerts = False
            workBook.SaveAs(filePath)
            MsgBox("データ出力完了")
        Catch ex As System.Runtime.InteropServices.COMException
            ' ファイルが開かれている場合のエラーをキャッチ
            MsgBox("Excelファイル が開かれています。ファイルを閉じてから再試行してください。")
        Finally
            excelApp.DisplayAlerts = True
            excelApp.Quit()
        End Try
    End Sub

    Sub writeExcel(ByVal dataTable As DataTable, ByVal sheet As Microsoft.Office.Interop.Excel.Worksheet)
        ' シートのタイトル（列名）をセット
        For col As Integer = 0 To dataTable.Columns.Count - 1
            sheet.Cells(1, col + 1) = dataTable.Columns(col).ColumnName
        Next

        ' データをセルにコピー
        For row As Integer = 0 To dataTable.Rows.Count - 1
            For col As Integer = 0 To dataTable.Columns.Count - 1
                sheet.Cells(row + 2, col + 1) = dataTable.Rows(row)(col).ToString()
            Next
        Next
        ' 罫線を追加する範囲を設定
        Dim lastRow As Integer = dataTable.Rows.Count + 1
        Dim lastCol As Integer = dataTable.Columns.Count
        Dim range As Microsoft.Office.Interop.Excel.Range = sheet.Range(sheet.Cells(1, 1), sheet.Cells(lastRow, lastCol))

        ' 罫線を追加
        range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
        range.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin
        ' セルの内容を中央揃えにする
        range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
    End Sub

    Private Sub TotalResult_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        dgvSave()
    End Sub

    Private Sub allClear_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("すべてのデータをクリアしますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
            sapporoTable.Rows.Clear()
            hakodateTable.Rows.Clear()
            fukushimaTable.Rows.Clear()
            niigataTable.Rows.Clear()
            tokyoTable.Rows.Clear()
            nakayamaTable.Rows.Clear()
            chukyoTable.Rows.Clear()
            kyotoTable.Rows.Clear()
            hanshinTable.Rows.Clear()
            kokuraTable.Rows.Clear()
            MsgBox("データをクリアしました")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles loadCheck.CheckedChanged

    End Sub

    Private Sub reload_Click(sender As Object, e As EventArgs) Handles Button2.Click
        writeAllArea()
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class