<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Class_ModelCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Class_ModelCheck))
        Me.dayPicker = New System.Windows.Forms.DateTimePicker()
        Me.kaisaiCmb = New System.Windows.Forms.ComboBox()
        Me.raceNumCmb = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.startBtn = New System.Windows.Forms.Button()
        Me.percentDgv = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.percentDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dayPicker
        '
        Me.dayPicker.Location = New System.Drawing.Point(85, 26)
        Me.dayPicker.Name = "dayPicker"
        Me.dayPicker.Size = New System.Drawing.Size(107, 19)
        Me.dayPicker.TabIndex = 1
        '
        'kaisaiCmb
        '
        Me.kaisaiCmb.FormattingEnabled = True
        Me.kaisaiCmb.Items.AddRange(New Object() {"札幌", "函館", "福島", "新潟", "東京", "中山", "中京", "京都", "阪神", "小倉"})
        Me.kaisaiCmb.Location = New System.Drawing.Point(85, 51)
        Me.kaisaiCmb.Name = "kaisaiCmb"
        Me.kaisaiCmb.Size = New System.Drawing.Size(107, 20)
        Me.kaisaiCmb.TabIndex = 2
        '
        'raceNumCmb
        '
        Me.raceNumCmb.FormattingEnabled = True
        Me.raceNumCmb.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.raceNumCmb.Location = New System.Drawing.Point(85, 77)
        Me.raceNumCmb.Name = "raceNumCmb"
        Me.raceNumCmb.Size = New System.Drawing.Size(107, 20)
        Me.raceNumCmb.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("游ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "日付"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("游ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 19)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "開催場"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("游ゴシック", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 19)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "レース数"
        '
        'startBtn
        '
        Me.startBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.startBtn.Font = New System.Drawing.Font("游ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.startBtn.ForeColor = System.Drawing.Color.White
        Me.startBtn.Location = New System.Drawing.Point(198, 52)
        Me.startBtn.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.startBtn.Name = "startBtn"
        Me.startBtn.Size = New System.Drawing.Size(127, 45)
        Me.startBtn.TabIndex = 20
        Me.startBtn.Text = "勝率出力"
        Me.startBtn.UseVisualStyleBackColor = False
        '
        'percentDgv
        '
        Me.percentDgv.AllowUserToAddRows = False
        Me.percentDgv.AllowUserToDeleteRows = False
        Me.percentDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.percentDgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.percentDgv.Location = New System.Drawing.Point(14, 103)
        Me.percentDgv.Name = "percentDgv"
        Me.percentDgv.ReadOnly = True
        Me.percentDgv.RowHeadersVisible = False
        Me.percentDgv.RowTemplate.Height = 21
        Me.percentDgv.Size = New System.Drawing.Size(311, 411)
        Me.percentDgv.TabIndex = 1167
        '
        'Column1
        '
        Me.Column1.HeaderText = "馬番"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "馬名"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "勝率"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "単勝オッズ"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Class_ModelCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(352, 526)
        Me.Controls.Add(Me.percentDgv)
        Me.Controls.Add(Me.startBtn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.raceNumCmb)
        Me.Controls.Add(Me.kaisaiCmb)
        Me.Controls.Add(Me.dayPicker)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Class_ModelCheck"
        Me.Text = "レース予想"
        CType(Me.percentDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dayPicker As DateTimePicker
    Friend WithEvents kaisaiCmb As ComboBox
    Friend WithEvents raceNumCmb As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents startBtn As Button
    Friend WithEvents percentDgv As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
End Class
