Imports System.Threading
Public Class Class_DB_ModelUpdate
    Private thread1 As Thread = Nothing
    Private Sub allRaceDataBtn_Click(sender As Object, e As EventArgs) Handles pastRaceBtn.Click
        ProgressBar1.Maximum = 2
        If thread1 IsNot Nothing AndAlso thread1.IsAlive Then
            MsgBox("スレッドは現在動作中です")
            Exit Sub
        End If
        thread1 = New Thread(AddressOf getAllData)
        thread1.Start()
    End Sub


    Sub setAllUpdateDay()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf setAllUpdateDay))
        Else
            allDataTxt.Text = "最終更新日" & Now.ToString("g")
            My.Settings.allDataTxt = "最終更新日" & Now.ToString("g")
        End If
    End Sub


    Sub getAllData()
        If MessageBox.Show("データ整理を行いますか？", "実行確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Try

                If getJavaDataBase() = 0 Then
                    UpdateProgressBar()
                    getPythonCreateNumpy()
                    UpdateProgressBar()
                    setAllUpdateDay()
                End If

            Catch ex As Exception
                MsgBox("エラーが発生しました: " & ex.Message)
            Finally
                endProgressBar()
            End Try
        End If
    End Sub

    Function getJavaDataBase()
        Dim process As New Process()
        process.StartInfo.FileName = "java"
        process.StartInfo.Arguments = "-cp ""C:\Users\Admin\git\keibaDB\Java\bin;C:\Users\Admin\Downloads\postgresql-42.7.1.jar"" sql.main.HorseRacingDataUpdateKeibaAi"
        process.StartInfo.WorkingDirectory = "C:\Users\Admin\git\keibaDB\Java\bin"
        process.StartInfo.UseShellExecute = False
        process.StartInfo.RedirectStandardError = True
        process.Start()

        ' エラーメッセージを読み取る
        Dim errorMessage As String = process.StandardError.ReadToEnd()
        process.WaitForExit()

        ' エラーメッセージがあれば表示
        If Not String.IsNullOrEmpty(errorMessage) Then
            MsgBox("エラー: " & errorMessage)
            Return -1
        End If
        Return 0
    End Function





    Sub getPythonCreateNumpy()
        Dim process As New Process()
        process.StartInfo.FileName = "C:\Users\Admin\anaconda3\python.exe"
        process.StartInfo.Arguments = "C:\Users\Admin\Desktop\Python\jra\Main_Standard_Create_Numpy.py"
        process.StartInfo.RedirectStandardError = True
        process.StartInfo.UseShellExecute = False
        process.Start()

        ' エラーメッセージを読み取る
        Dim errorMessage As String = process.StandardError.ReadToEnd()
        process.WaitForExit()

        ' エラーメッセージがあれば表示
        If Not String.IsNullOrEmpty(errorMessage) Then
            MsgBox("エラー: " & errorMessage)
        End If
    End Sub

    Sub getPythonCreateNumpyTemp()
        Dim process As New Process()
        process.StartInfo.FileName = "C:\Users\Admin\anaconda3\python.exe"
        process.StartInfo.Arguments = "C:\Users\Admin\Desktop\Python\keiba_ai\Main_Create_Numpy_Temp.py"
        process.StartInfo.RedirectStandardError = True
        process.StartInfo.UseShellExecute = False
        process.Start()

        ' エラーメッセージを読み取る
        Dim errorMessage As String = process.StandardError.ReadToEnd()
        process.WaitForExit()

        ' エラーメッセージがあれば表示
        If Not String.IsNullOrEmpty(errorMessage) Then
            MsgBox("エラー: " & errorMessage)
        End If
    End Sub


    Private Sub UpdateProgressBar()
        ' UIコントロールのスレッドセーフな更新
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateProgressBar))
        Else
            If ProgressBar1.Value < ProgressBar1.Maximum Then
                ProgressBar1.Value += 1
            End If
        End If
    End Sub

    Private Sub endProgressBar()
        ' UIコントロールのスレッドセーフな更新
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf endProgressBar))
        Else
            ProgressBar1.Value = 0
        End If
    End Sub
    Private Sub StopThread()
        If thread1 IsNot Nothing AndAlso thread1.IsAlive Then
            thread1.Abort() ' スレッドを強制終了
            MsgBox("更新を停止しました")
        Else
            MsgBox("更新作業は現在行われていません")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        StopThread()
    End Sub

    Private Sub Class_DataBaseUpdate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If thread1 IsNot Nothing AndAlso thread1.IsAlive Then
            If MessageBox.Show("更新プロセスがまだ実行中です。本当に閉じますか？", "プロセス実行中", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then
                e.Cancel = True ' フォームのクローズをキャンセル
            Else
                ' 必要に応じてスレッドのクリーンアップ処理をここに追加
            End If
        End If
    End Sub

    Private Sub Class_DataBaseUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        allDataTxt.Text = My.Settings.allDataTxt
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub
End Class