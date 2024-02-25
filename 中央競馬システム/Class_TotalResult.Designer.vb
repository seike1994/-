<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Class_TotalResult
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Class_TotalResult))
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Button7 = New System.Windows.Forms.Button()
        Me.kokuraPage = New System.Windows.Forms.TabPage()
        Me.kokuraDgv = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.hanshinPage = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.hanshinDgv = New System.Windows.Forms.DataGridView()
        Me.kyotoPage = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.kyotoDgv = New System.Windows.Forms.DataGridView()
        Me.chukyoPage = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chukyoDgv = New System.Windows.Forms.DataGridView()
        Me.nakayamaPage = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nakayamaDgv = New System.Windows.Forms.DataGridView()
        Me.tokyoPage = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tokyoDgv = New System.Windows.Forms.DataGridView()
        Me.niigataPage = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.niigataDgv = New System.Windows.Forms.DataGridView()
        Me.fukushimaPage = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.fukushimaDgv = New System.Windows.Forms.DataGridView()
        Me.hakodatePage = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.hakodateDgv = New System.Windows.Forms.DataGridView()
        Me.sapporoPage = New System.Windows.Forms.TabPage()
        Me.Label145 = New System.Windows.Forms.Label()
        Me.sapporoDgv = New System.Windows.Forms.DataGridView()
        Me.mainPage = New System.Windows.Forms.TabPage()
        Me.AllResultDay = New System.Windows.Forms.DataGridView()
        Me.AllResultArea = New System.Windows.Forms.DataGridView()
        Me.Label113 = New System.Windows.Forms.Label()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.tab = New System.Windows.Forms.TabControl()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.loadCheck = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kokuraPage.SuspendLayout()
        CType(Me.kokuraDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.hanshinPage.SuspendLayout()
        CType(Me.hanshinDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kyotoPage.SuspendLayout()
        CType(Me.kyotoDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.chukyoPage.SuspendLayout()
        CType(Me.chukyoDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.nakayamaPage.SuspendLayout()
        CType(Me.nakayamaDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tokyoPage.SuspendLayout()
        CType(Me.tokyoDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.niigataPage.SuspendLayout()
        CType(Me.niigataDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fukushimaPage.SuspendLayout()
        CType(Me.fukushimaDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.hakodatePage.SuspendLayout()
        CType(Me.hakodateDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sapporoPage.SuspendLayout()
        CType(Me.sapporoDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainPage.SuspendLayout()
        CType(Me.AllResultDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AllResultArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button7.Font = New System.Drawing.Font("游ゴシック", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.White
        Me.Button7.Location = New System.Drawing.Point(702, 19)
        Me.Button7.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(89, 32)
        Me.Button7.TabIndex = 1145
        Me.Button7.Text = "Excel出力"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'kokuraPage
        '
        Me.kokuraPage.BackColor = System.Drawing.Color.Green
        Me.kokuraPage.Controls.Add(Me.kokuraDgv)
        Me.kokuraPage.Controls.Add(Me.Label7)
        Me.kokuraPage.Location = New System.Drawing.Point(4, 22)
        Me.kokuraPage.Name = "kokuraPage"
        Me.kokuraPage.Padding = New System.Windows.Forms.Padding(3)
        Me.kokuraPage.Size = New System.Drawing.Size(775, 539)
        Me.kokuraPage.TabIndex = 10
        Me.kokuraPage.Text = "小倉"
        '
        'kokuraDgv
        '
        Me.kokuraDgv.AllowUserToAddRows = False
        Me.kokuraDgv.AllowUserToDeleteRows = False
        Me.kokuraDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.kokuraDgv.Location = New System.Drawing.Point(5, 34)
        Me.kokuraDgv.Name = "kokuraDgv"
        Me.kokuraDgv.ReadOnly = True
        Me.kokuraDgv.RowHeadersVisible = False
        Me.kokuraDgv.RowTemplate.Height = 21
        Me.kokuraDgv.Size = New System.Drawing.Size(760, 497)
        Me.kokuraDgv.TabIndex = 765
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("游ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(6, 5)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(759, 26)
        Me.Label7.TabIndex = 764
        Me.Label7.Text = "小倉収支表"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'hanshinPage
        '
        Me.hanshinPage.BackColor = System.Drawing.Color.Green
        Me.hanshinPage.Controls.Add(Me.Label6)
        Me.hanshinPage.Controls.Add(Me.hanshinDgv)
        Me.hanshinPage.Location = New System.Drawing.Point(4, 22)
        Me.hanshinPage.Name = "hanshinPage"
        Me.hanshinPage.Padding = New System.Windows.Forms.Padding(3)
        Me.hanshinPage.Size = New System.Drawing.Size(775, 539)
        Me.hanshinPage.TabIndex = 9
        Me.hanshinPage.Text = "阪神"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("游ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 5)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(759, 26)
        Me.Label6.TabIndex = 764
        Me.Label6.Text = "阪神収支表"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'hanshinDgv
        '
        Me.hanshinDgv.AllowUserToAddRows = False
        Me.hanshinDgv.AllowUserToDeleteRows = False
        Me.hanshinDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.hanshinDgv.Location = New System.Drawing.Point(5, 34)
        Me.hanshinDgv.Name = "hanshinDgv"
        Me.hanshinDgv.ReadOnly = True
        Me.hanshinDgv.RowHeadersVisible = False
        Me.hanshinDgv.RowTemplate.Height = 21
        Me.hanshinDgv.Size = New System.Drawing.Size(760, 497)
        Me.hanshinDgv.TabIndex = 763
        '
        'kyotoPage
        '
        Me.kyotoPage.BackColor = System.Drawing.Color.Green
        Me.kyotoPage.Controls.Add(Me.Label5)
        Me.kyotoPage.Controls.Add(Me.kyotoDgv)
        Me.kyotoPage.Location = New System.Drawing.Point(4, 22)
        Me.kyotoPage.Name = "kyotoPage"
        Me.kyotoPage.Padding = New System.Windows.Forms.Padding(3)
        Me.kyotoPage.Size = New System.Drawing.Size(775, 539)
        Me.kyotoPage.TabIndex = 8
        Me.kyotoPage.Text = "京都"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("游ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 5)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(759, 26)
        Me.Label5.TabIndex = 764
        Me.Label5.Text = "京都収支表"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'kyotoDgv
        '
        Me.kyotoDgv.AllowUserToAddRows = False
        Me.kyotoDgv.AllowUserToDeleteRows = False
        Me.kyotoDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.kyotoDgv.Location = New System.Drawing.Point(5, 34)
        Me.kyotoDgv.Name = "kyotoDgv"
        Me.kyotoDgv.ReadOnly = True
        Me.kyotoDgv.RowHeadersVisible = False
        Me.kyotoDgv.RowTemplate.Height = 21
        Me.kyotoDgv.Size = New System.Drawing.Size(760, 497)
        Me.kyotoDgv.TabIndex = 763
        '
        'chukyoPage
        '
        Me.chukyoPage.BackColor = System.Drawing.Color.Green
        Me.chukyoPage.Controls.Add(Me.Label4)
        Me.chukyoPage.Controls.Add(Me.chukyoDgv)
        Me.chukyoPage.Location = New System.Drawing.Point(4, 22)
        Me.chukyoPage.Name = "chukyoPage"
        Me.chukyoPage.Padding = New System.Windows.Forms.Padding(3)
        Me.chukyoPage.Size = New System.Drawing.Size(775, 539)
        Me.chukyoPage.TabIndex = 7
        Me.chukyoPage.Text = "中京"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("游ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(6, 5)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(759, 26)
        Me.Label4.TabIndex = 764
        Me.Label4.Text = "中京収支表"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chukyoDgv
        '
        Me.chukyoDgv.AllowUserToAddRows = False
        Me.chukyoDgv.AllowUserToDeleteRows = False
        Me.chukyoDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.chukyoDgv.Location = New System.Drawing.Point(5, 34)
        Me.chukyoDgv.Name = "chukyoDgv"
        Me.chukyoDgv.ReadOnly = True
        Me.chukyoDgv.RowHeadersVisible = False
        Me.chukyoDgv.RowTemplate.Height = 21
        Me.chukyoDgv.Size = New System.Drawing.Size(760, 497)
        Me.chukyoDgv.TabIndex = 763
        '
        'nakayamaPage
        '
        Me.nakayamaPage.BackColor = System.Drawing.Color.Green
        Me.nakayamaPage.Controls.Add(Me.Label3)
        Me.nakayamaPage.Controls.Add(Me.nakayamaDgv)
        Me.nakayamaPage.Location = New System.Drawing.Point(4, 22)
        Me.nakayamaPage.Name = "nakayamaPage"
        Me.nakayamaPage.Padding = New System.Windows.Forms.Padding(3)
        Me.nakayamaPage.Size = New System.Drawing.Size(775, 539)
        Me.nakayamaPage.TabIndex = 6
        Me.nakayamaPage.Text = "中山"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("游ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 5)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(759, 26)
        Me.Label3.TabIndex = 764
        Me.Label3.Text = "中山収支表"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'nakayamaDgv
        '
        Me.nakayamaDgv.AllowUserToAddRows = False
        Me.nakayamaDgv.AllowUserToDeleteRows = False
        Me.nakayamaDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.nakayamaDgv.Location = New System.Drawing.Point(5, 34)
        Me.nakayamaDgv.Name = "nakayamaDgv"
        Me.nakayamaDgv.ReadOnly = True
        Me.nakayamaDgv.RowHeadersVisible = False
        Me.nakayamaDgv.RowTemplate.Height = 21
        Me.nakayamaDgv.Size = New System.Drawing.Size(760, 497)
        Me.nakayamaDgv.TabIndex = 763
        '
        'tokyoPage
        '
        Me.tokyoPage.BackColor = System.Drawing.Color.Green
        Me.tokyoPage.Controls.Add(Me.Label2)
        Me.tokyoPage.Controls.Add(Me.tokyoDgv)
        Me.tokyoPage.Location = New System.Drawing.Point(4, 22)
        Me.tokyoPage.Name = "tokyoPage"
        Me.tokyoPage.Padding = New System.Windows.Forms.Padding(3)
        Me.tokyoPage.Size = New System.Drawing.Size(775, 539)
        Me.tokyoPage.TabIndex = 5
        Me.tokyoPage.Text = "東京"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("游ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 5)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(759, 26)
        Me.Label2.TabIndex = 764
        Me.Label2.Text = "東京収支表"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tokyoDgv
        '
        Me.tokyoDgv.AllowUserToAddRows = False
        Me.tokyoDgv.AllowUserToDeleteRows = False
        Me.tokyoDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tokyoDgv.Location = New System.Drawing.Point(5, 34)
        Me.tokyoDgv.Name = "tokyoDgv"
        Me.tokyoDgv.ReadOnly = True
        Me.tokyoDgv.RowHeadersVisible = False
        Me.tokyoDgv.RowTemplate.Height = 21
        Me.tokyoDgv.Size = New System.Drawing.Size(760, 497)
        Me.tokyoDgv.TabIndex = 763
        '
        'niigataPage
        '
        Me.niigataPage.BackColor = System.Drawing.Color.Green
        Me.niigataPage.Controls.Add(Me.Label1)
        Me.niigataPage.Controls.Add(Me.niigataDgv)
        Me.niigataPage.Location = New System.Drawing.Point(4, 22)
        Me.niigataPage.Name = "niigataPage"
        Me.niigataPage.Padding = New System.Windows.Forms.Padding(3)
        Me.niigataPage.Size = New System.Drawing.Size(775, 539)
        Me.niigataPage.TabIndex = 4
        Me.niigataPage.Text = "新潟"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("游ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 5)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(759, 26)
        Me.Label1.TabIndex = 764
        Me.Label1.Text = "新潟収支表"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'niigataDgv
        '
        Me.niigataDgv.AllowUserToAddRows = False
        Me.niigataDgv.AllowUserToDeleteRows = False
        Me.niigataDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.niigataDgv.Location = New System.Drawing.Point(5, 34)
        Me.niigataDgv.Name = "niigataDgv"
        Me.niigataDgv.ReadOnly = True
        Me.niigataDgv.RowHeadersVisible = False
        Me.niigataDgv.RowTemplate.Height = 21
        Me.niigataDgv.Size = New System.Drawing.Size(760, 497)
        Me.niigataDgv.TabIndex = 763
        '
        'fukushimaPage
        '
        Me.fukushimaPage.BackColor = System.Drawing.Color.Green
        Me.fukushimaPage.Controls.Add(Me.Label9)
        Me.fukushimaPage.Controls.Add(Me.fukushimaDgv)
        Me.fukushimaPage.Location = New System.Drawing.Point(4, 22)
        Me.fukushimaPage.Name = "fukushimaPage"
        Me.fukushimaPage.Padding = New System.Windows.Forms.Padding(3)
        Me.fukushimaPage.Size = New System.Drawing.Size(775, 539)
        Me.fukushimaPage.TabIndex = 3
        Me.fukushimaPage.Text = "福島"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("游ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(6, 5)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(759, 26)
        Me.Label9.TabIndex = 764
        Me.Label9.Text = "福島収支表"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fukushimaDgv
        '
        Me.fukushimaDgv.AllowUserToAddRows = False
        Me.fukushimaDgv.AllowUserToDeleteRows = False
        Me.fukushimaDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.fukushimaDgv.Location = New System.Drawing.Point(5, 34)
        Me.fukushimaDgv.Name = "fukushimaDgv"
        Me.fukushimaDgv.RowHeadersVisible = False
        Me.fukushimaDgv.RowTemplate.Height = 21
        Me.fukushimaDgv.Size = New System.Drawing.Size(760, 497)
        Me.fukushimaDgv.TabIndex = 763
        '
        'hakodatePage
        '
        Me.hakodatePage.BackColor = System.Drawing.Color.Green
        Me.hakodatePage.Controls.Add(Me.Label8)
        Me.hakodatePage.Controls.Add(Me.hakodateDgv)
        Me.hakodatePage.Location = New System.Drawing.Point(4, 22)
        Me.hakodatePage.Name = "hakodatePage"
        Me.hakodatePage.Padding = New System.Windows.Forms.Padding(3)
        Me.hakodatePage.Size = New System.Drawing.Size(775, 539)
        Me.hakodatePage.TabIndex = 2
        Me.hakodatePage.Text = "函館"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("游ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(6, 5)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(759, 26)
        Me.Label8.TabIndex = 764
        Me.Label8.Text = "函館収支表"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'hakodateDgv
        '
        Me.hakodateDgv.AllowUserToAddRows = False
        Me.hakodateDgv.AllowUserToDeleteRows = False
        Me.hakodateDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.hakodateDgv.Location = New System.Drawing.Point(5, 34)
        Me.hakodateDgv.Name = "hakodateDgv"
        Me.hakodateDgv.ReadOnly = True
        Me.hakodateDgv.RowHeadersVisible = False
        Me.hakodateDgv.RowTemplate.Height = 21
        Me.hakodateDgv.Size = New System.Drawing.Size(760, 497)
        Me.hakodateDgv.TabIndex = 763
        '
        'sapporoPage
        '
        Me.sapporoPage.BackColor = System.Drawing.Color.Green
        Me.sapporoPage.Controls.Add(Me.Label145)
        Me.sapporoPage.Controls.Add(Me.sapporoDgv)
        Me.sapporoPage.Location = New System.Drawing.Point(4, 22)
        Me.sapporoPage.Name = "sapporoPage"
        Me.sapporoPage.Padding = New System.Windows.Forms.Padding(3)
        Me.sapporoPage.Size = New System.Drawing.Size(775, 539)
        Me.sapporoPage.TabIndex = 1
        Me.sapporoPage.Text = "札幌"
        '
        'Label145
        '
        Me.Label145.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label145.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label145.Font = New System.Drawing.Font("游ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label145.ForeColor = System.Drawing.Color.White
        Me.Label145.Location = New System.Drawing.Point(6, 5)
        Me.Label145.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label145.Name = "Label145"
        Me.Label145.Size = New System.Drawing.Size(759, 26)
        Me.Label145.TabIndex = 764
        Me.Label145.Text = "札幌収支表"
        Me.Label145.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'sapporoDgv
        '
        Me.sapporoDgv.AllowUserToAddRows = False
        Me.sapporoDgv.AllowUserToDeleteRows = False
        Me.sapporoDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.sapporoDgv.Location = New System.Drawing.Point(5, 34)
        Me.sapporoDgv.Name = "sapporoDgv"
        Me.sapporoDgv.ReadOnly = True
        Me.sapporoDgv.RowHeadersVisible = False
        Me.sapporoDgv.RowTemplate.Height = 21
        Me.sapporoDgv.Size = New System.Drawing.Size(760, 497)
        Me.sapporoDgv.TabIndex = 763
        '
        'mainPage
        '
        Me.mainPage.BackColor = System.Drawing.Color.Green
        Me.mainPage.Controls.Add(Me.AllResultDay)
        Me.mainPage.Controls.Add(Me.AllResultArea)
        Me.mainPage.Controls.Add(Me.Label113)
        Me.mainPage.Controls.Add(Me.Label114)
        Me.mainPage.Location = New System.Drawing.Point(4, 22)
        Me.mainPage.Name = "mainPage"
        Me.mainPage.Padding = New System.Windows.Forms.Padding(3)
        Me.mainPage.Size = New System.Drawing.Size(775, 539)
        Me.mainPage.TabIndex = 0
        Me.mainPage.Text = "全体収支"
        '
        'AllResultDay
        '
        Me.AllResultDay.AllowUserToAddRows = False
        Me.AllResultDay.AllowUserToDeleteRows = False
        Me.AllResultDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AllResultDay.Location = New System.Drawing.Point(5, 34)
        Me.AllResultDay.Name = "AllResultDay"
        Me.AllResultDay.ReadOnly = True
        Me.AllResultDay.RowHeadersVisible = False
        Me.AllResultDay.RowTemplate.Height = 21
        Me.AllResultDay.Size = New System.Drawing.Size(372, 268)
        Me.AllResultDay.TabIndex = 761
        '
        'AllResultArea
        '
        Me.AllResultArea.AllowUserToAddRows = False
        Me.AllResultArea.AllowUserToDeleteRows = False
        Me.AllResultArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AllResultArea.Location = New System.Drawing.Point(383, 33)
        Me.AllResultArea.Name = "AllResultArea"
        Me.AllResultArea.ReadOnly = True
        Me.AllResultArea.RowHeadersVisible = False
        Me.AllResultArea.RowTemplate.Height = 21
        Me.AllResultArea.Size = New System.Drawing.Size(382, 269)
        Me.AllResultArea.TabIndex = 760
        '
        'Label113
        '
        Me.Label113.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label113.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label113.Font = New System.Drawing.Font("游ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label113.ForeColor = System.Drawing.Color.White
        Me.Label113.Location = New System.Drawing.Point(385, 5)
        Me.Label113.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(380, 26)
        Me.Label113.TabIndex = 759
        Me.Label113.Text = "競馬場別収支表"
        Me.Label113.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label114
        '
        Me.Label114.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label114.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label114.Font = New System.Drawing.Font("游ゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label114.ForeColor = System.Drawing.Color.White
        Me.Label114.Location = New System.Drawing.Point(6, 5)
        Me.Label114.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(371, 26)
        Me.Label114.TabIndex = 758
        Me.Label114.Text = "式別毎収支表"
        Me.Label114.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tab
        '
        Me.tab.Controls.Add(Me.mainPage)
        Me.tab.Controls.Add(Me.sapporoPage)
        Me.tab.Controls.Add(Me.hakodatePage)
        Me.tab.Controls.Add(Me.fukushimaPage)
        Me.tab.Controls.Add(Me.niigataPage)
        Me.tab.Controls.Add(Me.tokyoPage)
        Me.tab.Controls.Add(Me.nakayamaPage)
        Me.tab.Controls.Add(Me.chukyoPage)
        Me.tab.Controls.Add(Me.kyotoPage)
        Me.tab.Controls.Add(Me.hanshinPage)
        Me.tab.Controls.Add(Me.kokuraPage)
        Me.tab.Location = New System.Drawing.Point(12, 37)
        Me.tab.Name = "tab"
        Me.tab.SelectedIndex = 0
        Me.tab.Size = New System.Drawing.Size(783, 565)
        Me.tab.TabIndex = 1144
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.Font = New System.Drawing.Font("游ゴシック", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(590, 19)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 32)
        Me.Button1.TabIndex = 1146
        Me.Button1.Text = "全データクリア"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'loadCheck
        '
        Me.loadCheck.AutoSize = True
        Me.loadCheck.ForeColor = System.Drawing.Color.White
        Me.loadCheck.Location = New System.Drawing.Point(109, 16)
        Me.loadCheck.Name = "loadCheck"
        Me.loadCheck.Size = New System.Drawing.Size(145, 16)
        Me.loadCheck.TabIndex = 1147
        Me.loadCheck.Text = "シミュレーションも反映する"
        Me.loadCheck.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button2.Font = New System.Drawing.Font("游ゴシック", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(14, 10)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 25)
        Me.Button2.TabIndex = 1148
        Me.Button2.Text = "再更新"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button3.Font = New System.Drawing.Font("游ゴシック", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(356, 606)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(111, 29)
        Me.Button3.TabIndex = 1149
        Me.Button3.Text = "閉じる"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Class_TotalResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Green
        Me.ClientSize = New System.Drawing.Size(818, 639)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.loadCheck)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.tab)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Class_TotalResult"
        Me.Text = "総合結果"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kokuraPage.ResumeLayout(False)
        CType(Me.kokuraDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hanshinPage.ResumeLayout(False)
        CType(Me.hanshinDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kyotoPage.ResumeLayout(False)
        CType(Me.kyotoDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.chukyoPage.ResumeLayout(False)
        CType(Me.chukyoDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.nakayamaPage.ResumeLayout(False)
        CType(Me.nakayamaDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tokyoPage.ResumeLayout(False)
        CType(Me.tokyoDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.niigataPage.ResumeLayout(False)
        CType(Me.niigataDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fukushimaPage.ResumeLayout(False)
        CType(Me.fukushimaDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.hakodatePage.ResumeLayout(False)
        CType(Me.hakodateDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sapporoPage.ResumeLayout(False)
        CType(Me.sapporoDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainPage.ResumeLayout(False)
        CType(Me.AllResultDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AllResultArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Button7 As Button
    Friend WithEvents tab As TabControl
    Friend WithEvents mainPage As TabPage
    Friend WithEvents AllResultDay As DataGridView
    Friend WithEvents AllResultArea As DataGridView
    Friend WithEvents Label113 As Label
    Friend WithEvents Label114 As Label
    Friend WithEvents sapporoPage As TabPage
    Friend WithEvents Label145 As Label
    Friend WithEvents sapporoDgv As DataGridView
    Friend WithEvents hakodatePage As TabPage
    Friend WithEvents Label8 As Label
    Friend WithEvents hakodateDgv As DataGridView
    Friend WithEvents fukushimaPage As TabPage
    Friend WithEvents Label9 As Label
    Friend WithEvents fukushimaDgv As DataGridView
    Friend WithEvents niigataPage As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents niigataDgv As DataGridView
    Friend WithEvents tokyoPage As TabPage
    Friend WithEvents Label2 As Label
    Friend WithEvents tokyoDgv As DataGridView
    Friend WithEvents nakayamaPage As TabPage
    Friend WithEvents Label3 As Label
    Friend WithEvents nakayamaDgv As DataGridView
    Friend WithEvents chukyoPage As TabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents chukyoDgv As DataGridView
    Friend WithEvents kyotoPage As TabPage
    Friend WithEvents Label5 As Label
    Friend WithEvents kyotoDgv As DataGridView
    Friend WithEvents hanshinPage As TabPage
    Friend WithEvents Label6 As Label
    Friend WithEvents hanshinDgv As DataGridView
    Friend WithEvents kokuraPage As TabPage
    Friend WithEvents Label7 As Label
    Friend WithEvents kokuraDgv As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents loadCheck As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class
