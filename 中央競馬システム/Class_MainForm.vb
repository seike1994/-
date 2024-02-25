Imports Npgsql

Public Class Class_MainForm

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        checkDgvSave()
        allDayTable = New DataTable
        allAreaTable = New DataTable
        dayDgvTable1 = New DataTable
        dayDgvTable2 = New DataTable
        dayDgvTable3 = New DataTable
        sapporoTable = New DataTable
        hakodateTable = New DataTable
        fukushimaTable = New DataTable
        niigataTable = New DataTable
        tokyoTable = New DataTable
        nakayamaTable = New DataTable
        chukyoTable = New DataTable
        kyotoTable = New DataTable
        hanshinTable = New DataTable
        kokuraTable = New DataTable
        mySettingLoad()
        dgvLoad()


        For Each c As DataGridViewColumn In dayResultDgv1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
        For Each c As DataGridViewColumn In dayResultDgv2.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c
        For Each c As DataGridViewColumn In dayResultDgv3.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        Class_Jv_Link.Jv_Link_Init()

        Me.nowTimer.Interval = 1000
        Me.nowTimer.Enabled = True
        Me.nowTimer.Start()

        Class_IPAT.GetZandaka()
        dgvWidthSize()
        dgvSave()
        changeDgvColor()

        DateTimePicker1.Value = Now()

        dayResultDgv1.BorderStyle = BorderStyle.None
        dayResultDgv2.BorderStyle = BorderStyle.None
        dayResultDgv3.BorderStyle = BorderStyle.None

    End Sub
    Private Sub JvLink設定JToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JvLink設定JToolStripMenuItem.Click
        Class_Jv_Link.JvSetting()
    End Sub
    Private Sub 投票設定Show_Click(sender As Object, e As EventArgs) Handles ShowTohyoSettingBtn.Click
        Class_TohyoSetting.Show()
    End Sub

    Private Sub 投票履歴Show_Click(sender As Object, e As EventArgs) Handles ShowLogBtn.Click
        Log.Show()
    End Sub


    Private Sub Start_Click(sender As Object, e As EventArgs) Handles startBtn.Click, zidouka.Click
        If startBtn.Text = "自動運転開始" Then
            If pastRaceBtn.Text = "シミュレーション中" Then
                MsgBox("シミュレーション中のため開始できません")
                Exit Sub
            End If
            isPastRace = False
            dgvSave()
            Dim sc = startcheck()
            If sc = -1 Then
                MsgBox("IPAT情報を入力してください")
                Exit Sub
            ElseIf sc = -2 Then
                Exit Sub
            Else

                Dim result As DialogResult = MessageBox.Show("自動投票を開始しますか？", "確認", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    getRaceInfomation()
                    Class_Jv_Link.getRaceData(Now)
                    TimerStart()
                End If
            End If
        Else
            Dim result As DialogResult = MessageBox.Show("自動投票を停止しますか？", "確認", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                TimerStop()
                startBtn.Text = "自動運転開始"
                startBtn.ForeColor = Color.White
            End If
        End If
    End Sub

    Function startcheck()
        If inetId = "" Or kanyusyaNum = "" Or secretNum = "" Or pars = "" Then
            Return -1
        Else
            Return 0
        End If

        Return Class_UserSetting.dbTest(0)

    End Function

    Sub MainFormDgvClear()
        dayDgvTable1.Clear()
        dayDgvTable2.Clear()
        dayDgvTable3.Clear()
    End Sub

    Private Sub startTimer_Tick(sender As Object, e As EventArgs) Handles startTimer.Tick
        RaceSelect()
    End Sub


    Private Sub MainForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        mySettingSave()
        dgvSave()
    End Sub


    Private Sub 競馬場共通設定RToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 競馬場共通設定RToolStripMenuItem.Click
        Class_IPAT.Show()
    End Sub


    Private Sub TimerStop_Tick(sender As Object, e As EventArgs) Handles stopTimer.Tick
        Me.stopTimer.Enabled = False
        Me.stopTimer.Stop()
        Call TimerStop()
    End Sub


    Private Sub PastRace_Click(sender As Object, e As EventArgs) Handles pastRaceBtn.Click


        If pastRaceBtn.Text = "シミュレーション" Then
            If startBtn.Text = "自動運転中" Then
                MsgBox("自動運転中のため開始できません")
                Exit Sub
            End If
            If Class_UserSetting.dbTest(0) = -2 Then
                Exit Sub
            End If

            Dim result As DialogResult = MessageBox.Show("シミュレーションを開始しますか？", "確認", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                isPastRace = True
                Dim time As DateTime = DateTimePicker1.Value
                Dim 日付 As String = time.ToString("yyyy年M月d日")
                kaisai1Day.Text = 日付
                kaisai2Day.Text = 日付
                kaisai3Day.Text = 日付
                kaisai1.Text = "---"
                kaisai2.Text = "---"
                kaisai3.Text = "---"
                Class_Jv_Link.getRaceData(time)
                If kaisai1.Text = "---" Then
                    MsgBox("対象日のレース取得ができません")
                    Exit Sub
                End If
                TimerStart()
                pastRaceBtn.Text = "シミュレーション中"
                pastRaceBtn.ForeColor = Color.Red
            End If
        Else
            Dim result As DialogResult = MessageBox.Show("シミュレーションを停止しますか？", "確認", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                TimerStop()
                pastRaceBtn.Text = "シミュレーション"
                pastRaceBtn.ForeColor = Color.White
            End If
        End If
    End Sub

    Sub getRaceInfomation()
        Dim nowYyyymmdd As String = Now.ToString("yyyy年M月d日")
        Dim pastYyyymmdd As String = kaisai2Day.Text
        If nowYyyymmdd <> pastYyyymmdd Then
            kaisai1Day.Text = nowYyyymmdd
            kaisai2Day.Text = nowYyyymmdd
            kaisai3Day.Text = nowYyyymmdd
            kaisai1.Text = "---"
            kaisai2.Text = "---"
            kaisai3.Text = "---"
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)
        Log.Show()
    End Sub

    Private Sub NowTimer_Tick(sender As Object, e As EventArgs) Handles nowTimer.Tick
        NowTime.Text = Now
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ShowResultBtn.Click
        Class_TotalResult.Show()
    End Sub

    Private Sub dayTimer_Tick(sender As Object, e As EventArgs) Handles dayTimer.Tick
        Dim time As DateTime = Now
        Dim yyyymmdd1 As String = time.ToString("yyyy年M月d日")
        Dim yyyymmdd2 As String = kaisai3Day.Text
        If yyyymmdd1 <> yyyymmdd2 Then
            kaisai1Day.Text = yyyymmdd1
            kaisai2Day.Text = yyyymmdd1
            kaisai3Day.Text = yyyymmdd1
            kaisai1.Text = "---"
            kaisai2.Text = "---"
            kaisai3.Text = "---"
            Class_Jv_Link.getRaceData(Now)
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Class_ModelCheck.Show()
    End Sub

    Private Sub SQLServer設定SToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SQLServer設定SToolStripMenuItem.Click
        Class_UserSetting.Show()
    End Sub

    Private Sub データベース更新ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles データベース更新ToolStripMenuItem.Click
        Class_DB_ModelUpdate.Show()
    End Sub

End Class
