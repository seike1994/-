Module TimerModule
    Sub TimerStart()
        'スタートタイマー Main RaceSelect
        Class_MainForm.startTimer.Interval = 3000
        Class_MainForm.startTimer.Enabled = True
        Class_MainForm.startTimer.Start()

        '日付変更感知タイマー MainForm dayTimer_Tick
        If isPastRace = False Then
            Class_MainForm.dayTimer.Interval = 60000
            Class_MainForm.dayTimer.Enabled = True
            Class_MainForm.dayTimer.Start()
            Class_MainForm.startBtn.Text = "自動運転中"
            Class_MainForm.startBtn.ForeColor = Color.Red
        End If
    End Sub
    Sub TimerStop()
        Class_MainForm.startTimer.Enabled = False
        Class_MainForm.startTimer.Stop()

        Class_MainForm.dayTimer.Enabled = False
        Class_MainForm.dayTimer.Stop()

        Class_MainForm.startBtn.Text = "自動運転開始"
        Class_MainForm.startBtn.ForeColor = Color.White
        MsgBox("自動運転を停止しました")
    End Sub
End Module
