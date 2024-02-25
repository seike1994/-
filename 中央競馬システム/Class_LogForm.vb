Imports Microsoft.Office.Interop
Public Class Log

    Private Sub 投票結果1_Load(sender As Object, e As EventArgs) Handles Me.Load
        logFormTxt.Text = logTxt
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles LogCloseBtn.Click
        Me.Close()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles LogCrearBtn.Click
        logFormTxt.Clear()
        logTxt = ""
    End Sub

End Class