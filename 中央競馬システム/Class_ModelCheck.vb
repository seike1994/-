Public Class Class_ModelCheck
    Private Sub ModelCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub startBtn_Click(sender As Object, e As EventArgs) Handles startBtn.Click
        If kaisaiCmb.SelectedItem = "" Or raceNumCmb.SelectedItem = "" Then
            MsgBox("レース選択をしてください")
            Return
        End If

        If localHost = "" Or localUser = "" Or localPw = "" Or localDb = "" Then
            Class_UserSetting.Show()
            MsgBox("ユーザー設定をしてください")
            Return
        End If

        Dim yyyymmdd = dayPicker.Value.ToString("yyyyMMdd")
        Dim kaisai = kaisaiCmb.SelectedItem
        Dim raceNumCode = raceNumCmb.SelectedItem
        Dim kaisaiCode = getChangeCode(kaisai)
        raceId = CLng(yyyymmdd & kaisaiCode & raceNumCode)
        Dim trackCode As Integer = Class_Jv_Link.getTrackCode()
        If trackCode < 50 Then
            getResultPersentWrite()
        Else
            MsgBox("データ範囲外レースのため実施できません")
        End If
    End Sub

    Sub getResultPersentWrite()
        percentDgv.Rows.Clear()
        Dim tansyoPercentDictionary As Dictionary(Of Integer, Double) = getTansyoPercentAll()
        Dim bameiDictionary As Dictionary(Of Integer, String) = Class_Jv_Link.getBamei()
        tansyoPercentDictionary = tansyoPercentDictionary.OrderByDescending(Function(pair) pair.Value).ToDictionary(Function(pair) pair.Key, Function(pair) pair.Value)
        Dim tansyoOddsDictionary As Dictionary(Of Integer, Double) = Class_Jv_Link.getTansyoOdds()
        Dim i As Integer = 0
        For Each pair In tansyoPercentDictionary
            Dim umaban As Integer = pair.Key
            Dim percent As Double = pair.Value
            Try
                Dim bamei As String = bameiDictionary(umaban)
                Dim odds As Double = 0
                tansyoOddsDictionary.TryGetValue(umaban, odds)
                percentDgv.Rows.Add()
                percentDgv.Rows(i).Cells(0).Value = umaban
                percentDgv.Rows(i).Cells(1).Value = bamei
                percent = Math.Floor(percent * 100 * 100) / 100
                Dim strPercent As String = percent.ToString("0.00") & "%"
                percentDgv.Rows(i).Cells(2).Value = strPercent
                Dim strOdds As String = odds.ToString("0.0") & "倍"
                percentDgv.Rows(i).Cells(3).Value = strOdds
                i += 1
            Catch
            End Try
        Next
        For Each column As DataGridViewColumn In percentDgv.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next

    End Sub
End Class