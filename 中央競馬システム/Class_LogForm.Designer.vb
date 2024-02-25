<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Log
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Log))
        Me.logFormTxt = New System.Windows.Forms.RichTextBox()
        Me.LogCloseBtn = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.LogCrearBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'logFormTxt
        '
        Me.logFormTxt.Location = New System.Drawing.Point(13, 74)
        Me.logFormTxt.Name = "logFormTxt"
        Me.logFormTxt.Size = New System.Drawing.Size(404, 343)
        Me.logFormTxt.TabIndex = 50
        Me.logFormTxt.Text = ""
        '
        'LogCloseBtn
        '
        Me.LogCloseBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LogCloseBtn.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LogCloseBtn.Location = New System.Drawing.Point(161, 439)
        Me.LogCloseBtn.Name = "LogCloseBtn"
        Me.LogCloseBtn.Size = New System.Drawing.Size(100, 34)
        Me.LogCloseBtn.TabIndex = 49
        Me.LogCloseBtn.Text = "閉じる"
        Me.LogCloseBtn.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(13, 9)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(404, 51)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "ログ"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(487, 662)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 31)
        Me.Button1.TabIndex = 47
        Me.Button1.Text = "データ出力"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("メイリオ", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(448, 655)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(149, 46)
        Me.Label32.TabIndex = 80
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LogCrearBtn
        '
        Me.LogCrearBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LogCrearBtn.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.LogCrearBtn.Location = New System.Drawing.Point(317, 439)
        Me.LogCrearBtn.Name = "LogCrearBtn"
        Me.LogCrearBtn.Size = New System.Drawing.Size(100, 34)
        Me.LogCrearBtn.TabIndex = 81
        Me.LogCrearBtn.Text = "クリア"
        Me.LogCrearBtn.UseVisualStyleBackColor = False
        '
        'Log
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(433, 494)
        Me.Controls.Add(Me.LogCrearBtn)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.logFormTxt)
        Me.Controls.Add(Me.LogCloseBtn)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Log"
        Me.Text = "ログ"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents logFormTxt As RichTextBox
    Friend WithEvents LogCloseBtn As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label32 As Label
    Friend WithEvents LogCrearBtn As Button
End Class
