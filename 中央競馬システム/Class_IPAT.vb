Imports System.Media

Public Class Class_IPAT
    Private Sub IPAT_Load(sender As Object, e As EventArgs) Handles Me.Load
        On Error Resume Next
        inet_id.Text = inetId
        kanyusya_num.Text = kanyusyaNum
        secret_Num.Text = secretNum
        P_ARS.Text = pars
        autoNyukinValue.Value = autoInMoney
        autonyuukinCb.Checked = autoNyukin
        zandakaValue.Value = zandaka
    End Sub

    Private Sub IPAT_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        inetId = inet_id.Text
        kanyusyaNum = kanyusya_num.Text
        secretNum = secret_Num.Text
        pars = P_ARS.Text
        autoInMoney = autoNyukinValue.Value
        autoNyukin = autonyuukinCb.Checked
        zandaka = zandakaValue.Value
    End Sub

    Private Sub ipatClose_Click_1(sender As Object, e As EventArgs) Handles ipatCloseBtn.Click
        Me.Close()
    End Sub
    Private Sub kakusu_CheckedChanged(sender As Object, e As EventArgs) Handles kakusu.CheckedChanged
        If kakusu.Checked = True Then
            inet_id.PasswordChar = "●"
            kanyusya_num.PasswordChar = "●"
            secret_Num.PasswordChar = "●"
            P_ARS.PasswordChar = "●"
        Else
            inet_id.PasswordChar = ""
            kanyusya_num.PasswordChar = ""
            secret_Num.PasswordChar = ""
            P_ARS.PasswordChar = ""
        End If
    End Sub
    Public Structure IpatLogin
        Public InetID As String 'INET_ID
        Public UserNo As String '加入者番号
        Public PassNo As String '暗証番号
        Public ParsNo As String 'P-ARS番号
    End Structure


    Function IpatgoBuy()
        Dim iplg As IpatLogin
        Dim LineMsg As String
        Dim tohyoHantei As Boolean
        ' IPATログイン情報を指定
        iplg.InetID = inetId ' <-----実際のINET-IDを設定します
        iplg.UserNo = kanyusyaNum ' <-----実際の加入者番号を設定します
        iplg.PassNo = secretNum    ' <-----実際の暗証番号を設定します
        iplg.ParsNo = pars   ' <-----実際のP-ARS番号を設定します

        SystemSounds.Beep.Play()

        ' fileモードで投票実行
        If Vote_file("c:\umagen\ipatgo\", iplg, "c:\umagen\ipatgo\JRA購入ツール.txt") = 0 Then
            logTxt += Now & " " & kaisai & raceNumber & "R 投票成功しました" & vbLf
            LineMsg = Now & " " & kaisai & raceNumber & "R 投票成功しました"
            tohyoHantei = True
            If postBuy = True Then
                postLine(LineMsg)
            End If
        Else
            logTxt += Now & " " & kaisai & raceNumber & "R 投票失敗しました" & vbLf
            tohyoHantei = False
            LineMsg = Now & " " & kaisai & raceNumber & "R 投票失敗しました"
            If postEr = True Then
                postLine(LineMsg)
            End If
        End If
        GetZandaka()
        Return tohyoHantei

    End Function


    Public Function Vote_file(ByVal filepath As String, ByVal IL As IpatLogin, ByVal vf As String) As Long
        Dim psInfo As New ProcessStartInfo()

        psInfo.FileName = filepath & "ipatgo.exe" ' 実行するファイル
        psInfo.CreateNoWindow = True ' コンソール・ウィンドウを開かない
        psInfo.UseShellExecute = False ' シェル機能を使用しない
        psInfo.Arguments = "file" & " " &
                        IL.InetID & " " &
                        IL.UserNo & " " &
                        IL.PassNo & " " &
                        IL.ParsNo & " " &
                        vf

        Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(psInfo)

        p.WaitForExit() ' 終了するまで待つ

        Vote_file = p.ExitCode

    End Function
    Private Sub ipatNyukin_Click(sender As Object, e As EventArgs) Handles nyukinBtn.Click
        If System.IO.File.Exists("c:\umagen\ipatgo\ipatgo.exe") = False Then
            MsgBox("ipatgo.exeが見つかりません")
            Exit Sub
        End If

        ' コントロール値からパラメータの作成
        Dim param = " deposit " &
                    inet_id.Text & " " &
                    kanyusya_num.Text & " " &
                    secret_Num.Text & " " &
                    P_ARS.Text & " " &
                    nyukinValue.Value

        Dim result As DialogResult = MessageBox.Show(nyukinValue.Value & "円を登録口座からIPAT口座に入金しますか？" & vbCrLf & vbCrLf & "※注 1日あたり3回目以降は手数料がかかります",
                                             "即パット入金",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.None,
                                             MessageBoxDefaultButton.Button2)

        If result = DialogResult.No Then
            Exit Sub
        End If

        ' 外部プログラムの実行
        Dim psInfo As New ProcessStartInfo()

        psInfo.FileName = "c:\umagen\ipatgo\ipatgo.exe" ' 実行するファイル
        psInfo.CreateNoWindow = True ' コンソール・ウィンドウを開かない
        psInfo.UseShellExecute = False ' シェル機能を使用しない
        psInfo.Arguments = param

        Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(psInfo) '外部プロセスの実行
        p.WaitForExit() ' 終了するまで待つ

        If p.ExitCode = 0 Then

            MsgBox("即パット入金処理を実行しました")
            GetZandaka2()
        Else
            MsgBox("即パット入金処理にエラーがありました")
        End If
    End Sub



    Private Sub ipatSyukin_Click(sender As Object, e As EventArgs) Handles shukkinBtn.Click
        If System.IO.File.Exists("c:\umagen\ipatgo\ipatgo.exe") = False Then
            MsgBox("ipatgo.exeが見つかりません")
            Exit Sub
        End If


        ' コントロール値からパラメータの作成
        Dim param = " withdraw " &
                    inet_id.Text & " " &
                    kanyusya_num.Text & " " &
                    secret_Num.Text & " " &
                    P_ARS.Text

        Dim result As DialogResult = MessageBox.Show("IPAT口座から登録口座に全額出金しますか？",
                                             "即パット出金",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.None,
                                             MessageBoxDefaultButton.Button2)

        If result = DialogResult.No Then
            Exit Sub
        End If

        ' 外部プログラムの実行
        Dim psInfo As New ProcessStartInfo()

        psInfo.FileName = "c:\umagen\ipatgo\ipatgo.exe" ' 実行するファイル
        psInfo.CreateNoWindow = True ' コンソール・ウィンドウを開かない
        psInfo.UseShellExecute = False ' シェル機能を使用しない
        psInfo.Arguments = param

        Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(psInfo) '外部プロセスの実行
        p.WaitForExit() ' 終了するまで待つ

        If p.ExitCode = 0 Then
            MsgBox("即パット出金処理を実行しました")
            GetZandaka2()
        Else
            MsgBox("即パット出金処理にエラーがありました")
        End If
    End Sub
    Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (
        ByVal lpApplicationName As String,
        ByVal lpKeyName As String,
        ByVal lpDefault As String,
        ByVal lpReturnedString As String,
        ByVal nSize As Integer,
        ByVal lpFileName As String) As Integer
    Public Structure StatInfo
        Public stat_date As String          ' 取得年月日
        Public stat_time As String          ' 取得時刻
        Public total_vote_amount As String  ' 累計購入金額
        Public total_repayment As String    ' 累計払戻金額
        Public daily_vote_amount As String  ' 1日分購入金額
        Public daily_repayment As String    ' 1日分払戻金額
        Public limit_vote_amount As String  ' 購入限度額
        Public limit_vote_count As String   ' 購入可能件数
    End Structure
    Public Function GetZandaka()
        Dim iplg As IpatLogin
        Dim stin As StatInfo

        stin = New StatInfo()

        ' IPATログイン情報を指定
        iplg.InetID = inetId ' <-----実際のINET-IDを設定します
        iplg.UserNo = kanyusyaNum ' <-----実際の加入者番号を設定します
        iplg.PassNo = secretNum    ' <-----実際の暗証番号を設定します
        iplg.ParsNo = pars   ' <-----実際のP-ARS番号を設定します

        ' statモードで取得実行
        If Get_Stat("c:\umagen\ipatgo\", iplg, stin) = 0 Then
            Class_MainForm.NowMoneyLimit.Text = "購入可能額:" & stin.limit_vote_amount & "円"
            If stin.limit_vote_amount <= zandaka And autoNyukin = True Then
                AutoNyuukin()
            End If
            Class_MainForm.dayTotalBuyTxt.Text = stin.daily_vote_amount
            Class_MainForm.dayTotalPayTxt.Text = stin.daily_repayment
            Class_MainForm.dayTotalBalanceTxt.Text = CLng(stin.daily_repayment) - CLng(stin.daily_vote_amount)
            Class_MainForm.dayTotalParseTxt.Text = stin.daily_repayment / stin.daily_repayment
            Return True

        Else
            logTxt += Now & " IPAT残高の反映に失敗しました" & vbLf
            Class_MainForm.dayTotalBuyTxt.Text = "0"
            Class_MainForm.dayTotalPayTxt.Text = "0"
            Class_MainForm.dayTotalBalanceTxt.Text = "0"
            Class_MainForm.dayTotalParseTxt.Text = "0"
            Return False
        End If

    End Function

    Public Sub GetZandaka2()
        Dim iplg As IpatLogin
        Dim stin As StatInfo

        stin = New StatInfo()

        ' IPATログイン情報を指定
        iplg.InetID = inetId ' <-----実際のINET-IDを設定します
        iplg.UserNo = kanyusyaNum ' <-----実際の加入者番号を設定します
        iplg.PassNo = secretNum    ' <-----実際の暗証番号を設定します
        iplg.ParsNo = pars   ' <-----実際のP-ARS番号を設定します

        ' statモードで取得実行
        If Get_Stat("c:\umagen\ipatgo\", iplg, stin) = 0 Then
            Class_MainForm.NowMoneyLimit.Text = "購入可能額:" & stin.limit_vote_amount & "円"
        Else
            logTxt += Now & " IPAT残高の反映に失敗しました" & vbLf
        End If

    End Sub


    Function Get_Stat(ByVal filepath As String, ByVal IL As IpatLogin, ByRef ST As StatInfo) As Long
        Dim ret As Integer
        Const def As String = vbNullString
        Dim buff As String = New String(" ", 1024)

        Dim psInfo As New ProcessStartInfo()

        psInfo.FileName = filepath & "ipatgo.exe" ' 実行するファイル
        psInfo.CreateNoWindow = True ' コンソール・ウィンドウを開かない
        psInfo.UseShellExecute = False ' シェル機能を使用しない
        psInfo.Arguments = "stat" & " " &
                    IL.InetID & " " &
                    IL.UserNo & " " &
                    IL.PassNo & " " &
                    IL.ParsNo

        Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(psInfo)

        p.WaitForExit() ' 終了するまで待つ

        If p.ExitCode <> 0 Then
            Get_Stat = p.ExitCode
            Exit Function
        End If

        ' 更新されたstat.iniから値を取得
        Dim iniFile As String = filepath & "\stat.ini"

        ret = GetPrivateProfileString("stat", "date", def, buff, buff.Length, (iniFile))
        ST.stat_date = buff.Substring(0, buff.IndexOf(vbNullChar))
        ret = GetPrivateProfileString("stat", "time", def, buff, buff.Length, (iniFile))
        ST.stat_time = buff.Substring(0, buff.IndexOf(vbNullChar))
        ret = GetPrivateProfileString("stat", "total_vote_amount", def, buff, buff.Length, (iniFile))
        ST.total_vote_amount = buff.Substring(0, buff.IndexOf(vbNullChar))
        ret = GetPrivateProfileString("stat", "total_repayment", def, buff, buff.Length, (iniFile))
        ST.total_repayment = buff.Substring(0, buff.IndexOf(vbNullChar))
        ret = GetPrivateProfileString("stat", "daily_vote_amount", def, buff, buff.Length, (iniFile))
        ST.daily_vote_amount = buff.Substring(0, buff.IndexOf(vbNullChar))
        ret = GetPrivateProfileString("stat", "daily_repayment", def, buff, buff.Length, (iniFile))
        ST.daily_repayment = buff.Substring(0, buff.IndexOf(vbNullChar))
        ret = GetPrivateProfileString("stat", "limit_vote_amount", def, buff, buff.Length, (iniFile))
        ST.limit_vote_amount = buff.Substring(0, buff.IndexOf(vbNullChar))
        ret = GetPrivateProfileString("stat", "limit_vote_count", def, buff, buff.Length, (iniFile))
        ST.limit_vote_count = buff.Substring(0, buff.IndexOf(vbNullChar))

        Get_Stat = 0   '取得成功

    End Function
    Sub AutoNyuukin()
        If System.IO.File.Exists("c:\umagen\ipatgo\ipatgo.exe") = False Then
            logTxt += Now & "ipatGOエラー" & vbLf
            Exit Sub
        End If

        ' コントロール値からパラメータの作成
        Dim param = " deposit " &
                       inetId & " " &
                       kanyusyaNum & " " &
                       secretNum & " " &
                       pars & " " &
                       autoInMoney


        ' 外部プログラムの実行
        Dim psInfo As New ProcessStartInfo()

        psInfo.FileName = "c:\umagen\ipatgo\ipatgo.exe" ' 実行するファイル
        psInfo.CreateNoWindow = True ' コンソール・ウィンドウを開かない
        psInfo.UseShellExecute = False ' シェル機能を使用しない
        psInfo.Arguments = param

        Dim p As System.Diagnostics.Process = System.Diagnostics.Process.Start(psInfo) '外部プロセスの実行
        p.WaitForExit() ' 終了するまで待つ

        If p.ExitCode = 0 Then
            logTxt += Now & "即パット入金処理を実行しました" & vbLf
            GetZandaka()
        Else
            logTxt += Now & "即パット入金エラー" & vbLf
        End If
    End Sub

End Class