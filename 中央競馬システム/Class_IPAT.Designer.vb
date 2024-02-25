<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Class_IPAT
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Class_IPAT))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.kakusu = New System.Windows.Forms.CheckBox()
        Me.shukkinBtn = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.nyukinValue = New System.Windows.Forms.NumericUpDown()
        Me.nyukinBtn = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ipatCloseBtn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.inet_id = New System.Windows.Forms.TextBox()
        Me.kanyusya_num = New System.Windows.Forms.TextBox()
        Me.P_ARS = New System.Windows.Forms.TextBox()
        Me.secret_Num = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.autoNyukinValue = New System.Windows.Forms.NumericUpDown()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.zandakaValue = New System.Windows.Forms.NumericUpDown()
        Me.autonyuukinCb = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.nyukinValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.autoNyukinValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.zandakaValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("メイリオ", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(-16, 0)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(457, 63)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "IPAT情報入力フォーム"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'kakusu
        '
        Me.kakusu.AutoSize = True
        Me.kakusu.Font = New System.Drawing.Font("游ゴシック", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.kakusu.ForeColor = System.Drawing.Color.White
        Me.kakusu.Location = New System.Drawing.Point(372, 193)
        Me.kakusu.Name = "kakusu"
        Me.kakusu.Size = New System.Drawing.Size(51, 20)
        Me.kakusu.TabIndex = 765
        Me.kakusu.Text = "隠す"
        Me.kakusu.UseVisualStyleBackColor = True
        '
        'shukkinBtn
        '
        Me.shukkinBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.shukkinBtn.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.shukkinBtn.ForeColor = System.Drawing.Color.Black
        Me.shukkinBtn.Location = New System.Drawing.Point(165, 346)
        Me.shukkinBtn.Name = "shukkinBtn"
        Me.shukkinBtn.Size = New System.Drawing.Size(72, 30)
        Me.shukkinBtn.TabIndex = 764
        Me.shukkinBtn.Text = "出金"
        Me.shukkinBtn.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(5, 346)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(143, 26)
        Me.Label6.TabIndex = 763
        Me.Label6.Text = "出金"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.ForeColor = System.Drawing.Color.Black
        Me.Label71.Location = New System.Drawing.Point(248, 230)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(17, 12)
        Me.Label71.TabIndex = 762
        Me.Label71.Text = "円"
        '
        'nyukinValue
        '
        Me.nyukinValue.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nyukinValue.Location = New System.Drawing.Point(165, 226)
        Me.nyukinValue.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nyukinValue.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nyukinValue.Name = "nyukinValue"
        Me.nyukinValue.Size = New System.Drawing.Size(77, 19)
        Me.nyukinValue.TabIndex = 761
        Me.nyukinValue.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'nyukinBtn
        '
        Me.nyukinBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.nyukinBtn.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.nyukinBtn.ForeColor = System.Drawing.Color.Black
        Me.nyukinBtn.Location = New System.Drawing.Point(271, 218)
        Me.nyukinBtn.Name = "nyukinBtn"
        Me.nyukinBtn.Size = New System.Drawing.Size(72, 30)
        Me.nyukinBtn.TabIndex = 760
        Me.nyukinBtn.Text = "入金"
        Me.nyukinBtn.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(5, 219)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(143, 26)
        Me.Label7.TabIndex = 759
        Me.Label7.Text = "入金"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ipatCloseBtn
        '
        Me.ipatCloseBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ipatCloseBtn.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ipatCloseBtn.Location = New System.Drawing.Point(165, 402)
        Me.ipatCloseBtn.Name = "ipatCloseBtn"
        Me.ipatCloseBtn.Size = New System.Drawing.Size(100, 34)
        Me.ipatCloseBtn.TabIndex = 758
        Me.ipatCloseBtn.Text = "OK"
        Me.ipatCloseBtn.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(5, 83)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 26)
        Me.Label4.TabIndex = 757
        Me.Label4.Text = "INET-ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 109)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 26)
        Me.Label2.TabIndex = 756
        Me.Label2.Text = "加入者番号"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 135)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 26)
        Me.Label1.TabIndex = 755
        Me.Label1.Text = "暗証番号"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(5, 161)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 26)
        Me.Label3.TabIndex = 754
        Me.Label3.Text = "P-ARS"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'inet_id
        '
        Me.inet_id.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.inet_id.Location = New System.Drawing.Point(167, 83)
        Me.inet_id.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.inet_id.Multiline = True
        Me.inet_id.Name = "inet_id"
        Me.inet_id.Size = New System.Drawing.Size(256, 26)
        Me.inet_id.TabIndex = 753
        Me.inet_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'kanyusya_num
        '
        Me.kanyusya_num.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.kanyusya_num.Location = New System.Drawing.Point(167, 109)
        Me.kanyusya_num.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.kanyusya_num.Multiline = True
        Me.kanyusya_num.Name = "kanyusya_num"
        Me.kanyusya_num.Size = New System.Drawing.Size(256, 26)
        Me.kanyusya_num.TabIndex = 752
        Me.kanyusya_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'P_ARS
        '
        Me.P_ARS.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.P_ARS.Location = New System.Drawing.Point(167, 161)
        Me.P_ARS.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.P_ARS.Multiline = True
        Me.P_ARS.Name = "P_ARS"
        Me.P_ARS.Size = New System.Drawing.Size(256, 26)
        Me.P_ARS.TabIndex = 751
        Me.P_ARS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'secret_Num
        '
        Me.secret_Num.Font = New System.Drawing.Font("メイリオ", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.secret_Num.Location = New System.Drawing.Point(167, 135)
        Me.secret_Num.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.secret_Num.Multiline = True
        Me.secret_Num.Name = "secret_Num"
        Me.secret_Num.Size = New System.Drawing.Size(256, 26)
        Me.secret_Num.TabIndex = 750
        Me.secret_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("メイリオ", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(5, 276)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(143, 26)
        Me.Label8.TabIndex = 773
        Me.Label8.Text = "自動入金"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.BackColor = System.Drawing.Color.White
        Me.Label52.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(316, 314)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(96, 18)
        Me.Label52.TabIndex = 936
        Me.Label52.Text = "円 自動入金する"
        '
        'autoNyukinValue
        '
        Me.autoNyukinValue.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.autoNyukinValue.Location = New System.Drawing.Point(228, 312)
        Me.autoNyukinValue.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.autoNyukinValue.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.autoNyukinValue.Name = "autoNyukinValue"
        Me.autoNyukinValue.Size = New System.Drawing.Size(77, 19)
        Me.autoNyukinValue.TabIndex = 935
        Me.autoNyukinValue.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.BackColor = System.Drawing.Color.White
        Me.Label53.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label53.ForeColor = System.Drawing.Color.Black
        Me.Label53.Location = New System.Drawing.Point(175, 314)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(56, 18)
        Me.Label53.TabIndex = 934
        Me.Label53.Text = "の場合、"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.BackColor = System.Drawing.Color.White
        Me.Label54.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label54.ForeColor = System.Drawing.Color.Black
        Me.Label54.Location = New System.Drawing.Point(372, 287)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(48, 18)
        Me.Label54.TabIndex = 933
        Me.Label54.Text = "円 以下"
        '
        'zandakaValue
        '
        Me.zandakaValue.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.zandakaValue.Location = New System.Drawing.Point(289, 286)
        Me.zandakaValue.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.zandakaValue.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.zandakaValue.Name = "zandakaValue"
        Me.zandakaValue.Size = New System.Drawing.Size(77, 19)
        Me.zandakaValue.TabIndex = 932
        Me.zandakaValue.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'autonyuukinCb
        '
        Me.autonyuukinCb.AutoSize = True
        Me.autonyuukinCb.BackColor = System.Drawing.Color.White
        Me.autonyuukinCb.Font = New System.Drawing.Font("メイリオ", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.autonyuukinCb.ForeColor = System.Drawing.Color.Black
        Me.autonyuukinCb.Location = New System.Drawing.Point(155, 286)
        Me.autonyuukinCb.Name = "autonyuukinCb"
        Me.autonyuukinCb.Size = New System.Drawing.Size(135, 22)
        Me.autonyuukinCb.TabIndex = 931
        Me.autonyuukinCb.Text = "投票実施後に残高が"
        Me.autonyuukinCb.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("HGS創英角ﾎﾟｯﾌﾟ体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(151, 276)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(272, 65)
        Me.Label9.TabIndex = 937
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Class_IPAT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(439, 448)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.autoNyukinValue)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.zandakaValue)
        Me.Controls.Add(Me.autonyuukinCb)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.kakusu)
        Me.Controls.Add(Me.shukkinBtn)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label71)
        Me.Controls.Add(Me.nyukinValue)
        Me.Controls.Add(Me.nyukinBtn)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ipatCloseBtn)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.inet_id)
        Me.Controls.Add(Me.kanyusya_num)
        Me.Controls.Add(Me.P_ARS)
        Me.Controls.Add(Me.secret_Num)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Class_IPAT"
        Me.Text = "ユーザー設定"
        CType(Me.nyukinValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.autoNyukinValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.zandakaValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents kakusu As CheckBox
    Friend WithEvents shukkinBtn As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label71 As Label
    Friend WithEvents nyukinValue As NumericUpDown
    Friend WithEvents nyukinBtn As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents ipatCloseBtn As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents inet_id As TextBox
    Friend WithEvents kanyusya_num As TextBox
    Friend WithEvents P_ARS As TextBox
    Friend WithEvents secret_Num As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents autoNyukinValue As NumericUpDown
    Friend WithEvents Label53 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents zandakaValue As NumericUpDown
    Friend WithEvents autonyuukinCb As CheckBox
    Friend WithEvents Label9 As Label
End Class
