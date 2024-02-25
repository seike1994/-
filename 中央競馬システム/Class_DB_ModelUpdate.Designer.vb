<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Class_DB_ModelUpdate
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Class_DB_ModelUpdate))
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.pastRaceBtn = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.allDataTxt = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("游ゴシック", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(18, 12)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(324, 97)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = "更新作業の前にPC-KEIBAを更新してください。" & Global.Microsoft.VisualBasic.ChrW(10) & "データ処理は時間がかかります。" & Global.Microsoft.VisualBasic.ChrW(10) & "①Javaの呼び出し→データベース成形" & Global.Microsoft.VisualBasic.ChrW(10) & "②Pythonの呼び出し→前処理→モデ" &
    "ル作成→バックテスト"
        '
        'pastRaceBtn
        '
        Me.pastRaceBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pastRaceBtn.Font = New System.Drawing.Font("游ゴシック", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.pastRaceBtn.ForeColor = System.Drawing.Color.White
        Me.pastRaceBtn.Location = New System.Drawing.Point(21, 132)
        Me.pastRaceBtn.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.pastRaceBtn.Name = "pastRaceBtn"
        Me.pastRaceBtn.Size = New System.Drawing.Size(115, 31)
        Me.pastRaceBtn.TabIndex = 77
        Me.pastRaceBtn.Text = "全データ更新"
        Me.pastRaceBtn.UseVisualStyleBackColor = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(18, 219)
        Me.ProgressBar1.Maximum = 2
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(324, 23)
        Me.ProgressBar1.TabIndex = 79
        '
        'allDataTxt
        '
        Me.allDataTxt.Location = New System.Drawing.Point(21, 173)
        Me.allDataTxt.Name = "allDataTxt"
        Me.allDataTxt.Size = New System.Drawing.Size(166, 19)
        Me.allDataTxt.TabIndex = 81
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button2.Font = New System.Drawing.Font("游ゴシック", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(370, 535)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(115, 31)
        Me.Button2.TabIndex = 83
        Me.Button2.Text = "更新停止"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Green
        Me.Label6.Font = New System.Drawing.Font("游ゴシック", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(358, 535)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 36)
        Me.Label6.TabIndex = 93
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Green
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("游ゴシック", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(18, 121)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(237, 82)
        Me.Label8.TabIndex = 95
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button3.Font = New System.Drawing.Font("游ゴシック", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(104, 264)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(130, 42)
        Me.Button3.TabIndex = 96
        Me.Button3.Text = "閉じる"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Class_DB_ModelUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(369, 355)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.allDataTxt)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.pastRaceBtn)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label8)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Class_DB_ModelUpdate"
        Me.Text = "データベース管理"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents pastRaceBtn As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents allDataTxt As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Button3 As Button
End Class
