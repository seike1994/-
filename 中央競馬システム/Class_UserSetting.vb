Imports Npgsql

Public Class Class_UserSetting
    Private Sub Class_UserSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        localHostTxt.Text = My.Settings.localHost
        localUserTxt.Text = My.Settings.localUser
        localPwTxt.Text = My.Settings.localPw
        localDbTxt.Text = My.Settings.localDb
        awsHostTxt.Text = My.Settings.awsHost
        awsPortTxt.Text = My.Settings.awsPort
        awsUserTxt.Text = My.Settings.awsUser
        awsPwTxt.Text = My.Settings.awsPw
        awsDbTxt.Text = My.Settings.awsDb
        LineTokenTxt.Text = My.Settings.LineToken
        HpURLTxt.Text = My.Settings.HpUrl
        BookersTokenTxt.Text = My.Settings.BookersToken
        xUserIdTxt.Text = My.Settings.xUserId
        xApiKeyTxt.Text = My.Settings.xApiKey
        xApiKeySTxt.Text = My.Settings.xApiKeyS
        xAccessTokenTxt.Text = My.Settings.xAccessToken
        xAccessTokenSTxt.Text = My.Settings.xAccessTokenS
        xBearerTokenTxt.Text = My.Settings.xBearerToken

    End Sub

    Private Sub Class_UserSetting_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        dataSave()
    End Sub

    Sub dataSave()
        localHost = localHostTxt.Text
        localUser = localUserTxt.Text
        localPw = localPwTxt.Text
        localDb = localDbTxt.Text
        awsHost = awsHostTxt.Text
        awsPort = awsPortTxt.Text
        awsUser = awsUserTxt.Text
        awsPw = awsPwTxt.Text
        awsDb = awsDbTxt.Text
        LineToken = LineTokenTxt.Text
        HpUrl = HpURLTxt.Text
        BookersToken = BookersTokenTxt.Text
        xUserId = xUserIdTxt.Text
        xApiKey = xApiKeyTxt.Text
        xApiKeyS = xApiKeySTxt.Text
        xAccessToken = xAccessTokenTxt.Text
        xAccessTokenS = xAccessTokenSTxt.Text
        xBearerToken = xBearerTokenTxt.Text
        localConnStr = "Host=" & localHost & ";Username=" & localUser & ";Password=" & localPw & ";Database=" & localDb
        awsConnStr = "Host=" & awsHost & ";Port=" & awsPort & ";Username=" & awsUser & ";Password=" & awsPw & ";Database=" & awsDb
    End Sub

    Private Sub dbTest_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dataSave()
        dbTest(1)
    End Sub

    Function dbTest(numCheck)
        ' PostgreSQLに接続
        Dim dbCode As Integer = 0
        If localHost = "" Or localUser = "" Or localPw = "" Or localDb = "" Or awsHost = "" Or awsUser = "" Or awsPw = "" Or awsDb = "" Then
            MsgBox("ユーザー設定をしてください")
            Return -2
        End If
        Using conn As NpgsqlConnection = New NpgsqlConnection(localConnStr)
            Try
                conn.Open()
                If numCheck = 1 Then
                    MsgBox("ローカル PostgreSQLへの接続に成功しました。")
                End If
            Catch ex As Exception
                MsgBox("ローカル PostgreSQLへの接続に失敗しました。")
                dbCode = -2
            End Try
        End Using
        Using conn As NpgsqlConnection = New NpgsqlConnection(awsConnStr)
            Try
                conn.Open()
                If numCheck = 1 Then
                    MsgBox("AWS PostgreSQLへの接続に成功しました。")
                End If
            Catch ex As Exception
                MsgBox("AWS PostgreSQLへの接続に失敗しました。")
                dbCode = -2
            End Try
        End Using
        Return dbCode
    End Function

    Private Sub LineTest_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dataSave()
        If postLine("送信テスト") = -1 Then
            MsgBox("送信エラーです。" & vbLf & "トークンを確認してください。")
        Else
            MsgBox("送信完了。" & vbLf & "LINEを確認してください。")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        postX("自動投稿テストです" & vbLf & "※非通知推奨")
    End Sub

    Private Sub ipatCloseBtn_Click(sender As Object, e As EventArgs) Handles ipatCloseBtn.Click
        Me.Close()
    End Sub
End Class