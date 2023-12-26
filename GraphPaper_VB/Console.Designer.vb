<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Console
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        lbShape = New ListBox()
        tlpShapeSize = New TableLayoutPanel()
        rbSizeIn = New RadioButton()
        nudShapeWidth = New NumericUpDown()
        rbSizeMM = New RadioButton()
        gbLineColor = New GroupBox()
        tlpLineColor = New TableLayoutPanel()
        tlpHex = New TableLayoutPanel()
        Label7 = New Label()
        tbHexColor = New TextBox()
        rbInvisible1 = New RadioButton()
        tlpRGBbutton = New TableLayoutPanel()
        rbRGB = New RadioButton()
        panelRGB = New Panel()
        tlpWebColor = New TableLayoutPanel()
        rbWebColor = New RadioButton()
        cboxWebColor = New ComboBox()
        tlpLineWidth = New TableLayoutPanel()
        rbLineWeightIn = New RadioButton()
        nudLineWidth = New NumericUpDown()
        rbLineWeightMM = New RadioButton()
        Label12 = New Label()
        rbWebColor = New RadioButton()
        rbRGB = New RadioButton()
        tlpRGB = New TableLayoutPanel()
        Label11 = New Label()
        Label4 = New Label()
        tbHexColor = New TextBox()
        nudR = New NumericUpDown()
        Label9 = New Label()
        nudG = New NumericUpDown()
        Label10 = New Label()
        nudB = New NumericUpDown()
        tlpShape = New TableLayoutPanel()
        Label5 = New Label()
        Label6 = New Label()
        tlpDetails = New TableLayoutPanel()
        MenuStrip1 = New MenuStrip()
        PrintingToolStripMenuItem = New ToolStripMenuItem()
        PrintToolStripMenuItem = New ToolStripMenuItem()
        PageSetupToolStripMenuItem = New ToolStripMenuItem()
        ObservePageMarginsToolStripMenuItem = New ToolStripMenuItem()
        tlpMain = New TableLayoutPanel()
        GraphPaperControl1 = New GraphPaperControl()
        TableLayoutPanel3 = New TableLayoutPanel()
        RadioButton3 = New RadioButton()
        NumericUpDown4 = New NumericUpDown()
        tlpShapeSize.SuspendLayout()
        CType(nudShapeWidth, ComponentModel.ISupportInitialize).BeginInit()
        gbGridlines.SuspendLayout()
        tlpGridLines.SuspendLayout()
        TableLayoutPanel4.SuspendLayout()
        tlpLineWidth.SuspendLayout()
        CType(nudLineWidth, ComponentModel.ISupportInitialize).BeginInit()
        tlpRGB.SuspendLayout()
        CType(nudR, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudG, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudB, ComponentModel.ISupportInitialize).BeginInit()
        tlpShape.SuspendLayout()
        tlpDetails.SuspendLayout()
        MenuStrip1.SuspendLayout()
        tlpMain.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        CType(NumericUpDown4, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(39, 15)
        Label1.TabIndex = 2
        Label1.Text = "Shape"
        ' 
        ' lbShape
        ' 
        lbShape.FormattingEnabled = True
        lbShape.ItemHeight = 15
        lbShape.Items.AddRange(New Object() {"Squares", "Hexagons", "Triangles", "Diamonds"})
        lbShape.Location = New Point(3, 18)
        lbShape.Name = "lbShape"
        lbShape.Size = New Size(81, 64)
        lbShape.TabIndex = 3
        ' 
        ' tlpShapeSize
        ' 
        tlpShapeSize.AutoSize = True
        tlpShapeSize.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tlpShapeSize.ColumnCount = 2
        tlpShapeSize.ColumnStyles.Add(New ColumnStyle())
        tlpShapeSize.ColumnStyles.Add(New ColumnStyle())
        tlpShapeSize.Controls.Add(rbSizeIn, 1, 1)
        tlpShapeSize.Controls.Add(nudShapeWidth, 0, 0)
        tlpShapeSize.Controls.Add(rbSizeMM, 1, 0)
        tlpShapeSize.Location = New Point(90, 18)
        tlpShapeSize.Name = "tlpShapeSize"
        tlpShapeSize.RowCount = 2
        tlpShapeSize.RowStyles.Add(New RowStyle())
        tlpShapeSize.RowStyles.Add(New RowStyle())
        tlpShapeSize.Size = New Size(115, 50)
        tlpShapeSize.TabIndex = 5
        ' 
        ' rbSizeIn
        ' 
        rbSizeIn.AutoSize = True
        rbSizeIn.Checked = True
        rbSizeIn.Location = New Point(65, 28)
        rbSizeIn.Name = "rbSizeIn"
        rbSizeIn.Size = New Size(35, 19)
        rbSizeIn.TabIndex = 7
        rbSizeIn.TabStop = True
        rbSizeIn.Text = "in"
        rbSizeIn.UseVisualStyleBackColor = True
        ' 
        ' nudSize
        ' 
        nudShapeWidth.Anchor = AnchorStyles.Right
        nudShapeWidth.AutoSize = True
        nudShapeWidth.DecimalPlaces = 2
        nudShapeWidth.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        nudShapeWidth.Location = New Point(3, 13)
        nudShapeWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        nudShapeWidth.Name = "nudSize"
        tlpShapeSize.SetRowSpan(nudShapeWidth, 2)
        nudShapeWidth.Size = New Size(56, 23)
        nudShapeWidth.TabIndex = 5
        nudShapeWidth.Value = New Decimal(New Integer() {25, 0, 0, 131072})
        ' 
        ' rbSizeMM
        ' 
        rbSizeMM.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        rbSizeMM.AutoSize = True
        rbSizeMM.Location = New Point(65, 3)
        rbSizeMM.Name = "rbSizeMM"
        rbSizeMM.Size = New Size(47, 19)
        rbSizeMM.TabIndex = 6
        rbSizeMM.TabStop = True
        rbSizeMM.Text = "mm"
        rbSizeMM.UseVisualStyleBackColor = True
        ' 
        ' gbGridlines
        ' 
        gbGridlines.AutoSize = True
        gbGridlines.AutoSizeMode = AutoSizeMode.GrowAndShrink
        gbGridlines.Controls.Add(tlpGridLines)
        gbGridlines.Dock = DockStyle.Fill
        gbGridlines.Location = New Point(3, 111)
        gbGridlines.Margin = New Padding(3, 20, 3, 3)
        gbGridlines.Name = "gbGridlines"
        gbGridlines.Size = New Size(243, 163)
        gbGridlines.TabIndex = 8
        gbGridlines.TabStop = False
        gbGridlines.Text = "Gridlines"
        ' 
        ' tlpGridLines
        ' 
        tlpLineColor.AutoSize = True
        tlpLineColor.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tlpLineColor.ColumnCount = 1
        tlpLineColor.ColumnStyles.Add(New ColumnStyle())
        tlpLineColor.Controls.Add(tlpHex, 0, 3)
        tlpLineColor.Controls.Add(tlpRGBbutton, 0, 1)
        tlpLineColor.Controls.Add(tlpWebColor, 0, 0)
        tlpLineColor.Controls.Add(tlpRGB, 0, 2)
        tlpLineColor.Dock = DockStyle.Fill
        tlpLineColor.Location = New Point(3, 19)
        tlpLineColor.Name = "tlpLineColor"
        tlpLineColor.RowCount = 4
        tlpLineColor.RowStyles.Add(New RowStyle())
        tlpLineColor.RowStyles.Add(New RowStyle())
        tlpLineColor.RowStyles.Add(New RowStyle())
        tlpLineColor.RowStyles.Add(New RowStyle())
        tlpLineColor.Size = New Size(257, 140)
        tlpLineColor.TabIndex = 9
        ' 
        ' TableLayoutPanel4
        ' 
        tlpHex.AutoSize = True
        tlpHex.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tlpHex.ColumnCount = 5
        tlpHex.ColumnStyles.Add(New ColumnStyle())
        tlpHex.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpHex.ColumnStyles.Add(New ColumnStyle())
        tlpHex.ColumnStyles.Add(New ColumnStyle())
        tlpHex.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpHex.Controls.Add(Label7, 2, 0)
        tlpHex.Controls.Add(rbInvisible1, 0, 1)
        tlpHex.Controls.Add(tbHexColor, 3, 0)
        tlpHex.Dock = DockStyle.Fill
        tlpHex.Enabled = False
        tlpHex.Location = New Point(3, 107)
        tlpHex.Name = "tlpHex"
        tlpHex.RowCount = 2
        tlpHex.RowStyles.Add(New RowStyle())
        tlpHex.RowStyles.Add(New RowStyle(SizeType.Absolute, 1.0F))
        tlpHex.Size = New Size(251, 30)
        tlpHex.TabIndex = 21
        ' 
        ' cboxWebColor
        ' 
        Label7.Anchor = AnchorStyles.None
        Label7.AutoSize = True
        Label7.Location = New Point(94, 7)
        Label7.Name = "Label7"
        Label7.Size = New Size(21, 15)
        Label7.TabIndex = 22
        Label7.Text = "##"
        ' 
        ' tbHexColor
        ' 
        tbHexColor.Location = New Point(121, 3)
        tbHexColor.MaxLength = 6
        tbHexColor.Name = "tbHexColor"
        tbHexColor.Size = New Size(55, 23)
        tbHexColor.TabIndex = 23
        ' 
        ' rbInvisible1
        ' 
        rbLineWeightIn.AutoSize = True
        rbLineWeightIn.Location = New Point(65, 48)
        rbLineWeightIn.Name = "rbLineWeightIn"
        rbLineWeightIn.Size = New Size(35, 19)
        rbLineWeightIn.TabIndex = 30
        rbLineWeightIn.Text = "in"
        rbLineWeightIn.UseVisualStyleBackColor = True
        ' 
        ' tlpRGBbutton
        ' 
        nudLineWidth.Anchor = AnchorStyles.Right
        nudLineWidth.AutoSize = True
        nudLineWidth.DecimalPlaces = 2
        nudLineWidth.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        nudLineWidth.Location = New Point(3, 33)
        nudLineWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        nudLineWidth.Name = "nudLineWidth"
        tlpLineWidth.SetRowSpan(nudLineWidth, 2)
        nudLineWidth.Size = New Size(56, 23)
        nudLineWidth.TabIndex = 28
        nudLineWidth.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        ' 
        ' rbLineWeightMM
        ' 
        rbRGB.AutoSize = True
        rbRGB.Location = New Point(3, 3)
        rbRGB.Name = "rbRGB"
        rbRGB.Size = New Size(50, 19)
        rbRGB.TabIndex = 0
        rbRGB.Text = "RGB:"
        rbRGB.UseVisualStyleBackColor = True
        ' 
        ' Label12
        ' 
        panelRGB.BorderStyle = BorderStyle.FixedSingle
        panelRGB.Location = New Point(59, 3)
        panelRGB.Name = "panelRGB"
        panelRGB.Size = New Size(40, 20)
        panelRGB.TabIndex = 13
        ' 
        ' rbWebColor
        ' 
        rbWebColor.Anchor = AnchorStyles.Left
        rbWebColor.AutoSize = True
        rbWebColor.Checked = True
        rbWebColor.Location = New Point(3, 3)
        rbWebColor.Name = "rbWebColor"
        rbWebColor.Size = New Size(82, 19)
        rbWebColor.TabIndex = 10
        rbWebColor.TabStop = True
        rbWebColor.Text = "Web color"
        rbWebColor.UseVisualStyleBackColor = True
        ' 
        ' rbRGB
        ' 
        cboxWebColor.DrawMode = DrawMode.OwnerDrawFixed
        cboxWebColor.DropDownStyle = ComboBoxStyle.DropDownList
        cboxWebColor.FormattingEnabled = True
        cboxWebColor.Location = New Point(91, 3)
        cboxWebColor.Name = "cboxWebColor"
        cboxWebColor.Size = New Size(157, 24)
        cboxWebColor.TabIndex = 11
        ' 
        ' tlpRGB
        ' 
        tlpRGB.AutoSize = True
        tlpRGB.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tlpRGB.ColumnCount = 2
        tlpRGB.ColumnStyles.Add(New ColumnStyle())
        tlpRGB.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        tlpRGB.Controls.Add(Label11, 0, 3)
        tlpRGB.Controls.Add(Label4, 0, 0)
        tlpRGB.Controls.Add(tbHexColor, 1, 3)
        tlpRGB.Controls.Add(nudR, 1, 0)
        tlpRGB.Controls.Add(Label9, 0, 1)
        tlpRGB.Controls.Add(nudG, 1, 1)
        tlpRGB.Controls.Add(Label10, 0, 2)
        tlpRGB.Controls.Add(nudB, 1, 2)
        tlpRGB.Enabled = False
        tlpRGB.Location = New Point(136, 25)
        tlpRGB.Margin = New Padding(0)
        tlpRGB.Name = "tlpRGB"
        tlpRGB.RowCount = 2
        tlpRGB.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        tlpRGB.RowStyles.Add(New RowStyle(SizeType.Absolute, 1.0F))
        tlpRGB.Size = New Size(251, 30)
        tlpRGB.TabIndex = 14
        ' 
        ' Label4
        ' 
        nudB.AutoSize = True
        nudB.Location = New Point(206, 3)
        nudB.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        nudB.Name = "nudB"
        nudB.Size = New Size(41, 23)
        nudB.TabIndex = 20
        nudB.Value = New Decimal(New Integer() {255, 0, 0, 0})
        ' 
        ' tbHexColor
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Location = New Point(23, 7)
        Label2.Name = "Label2"
        Label2.Size = New Size(14, 15)
        Label2.TabIndex = 15
        Label2.Text = "R"
        Label2.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' nudR
        ' 
        nudR.AllowDrop = True
        nudR.Anchor = AnchorStyles.Left
        nudR.AutoSize = True
        nudR.Location = New Point(43, 3)
        nudR.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        nudR.Name = "nudR"
        nudR.Size = New Size(41, 23)
        nudR.TabIndex = 18
        nudR.Value = New Decimal(New Integer() {255, 0, 0, 0})
        ' 
        ' Label9
        ' 
        Label9.Anchor = AnchorStyles.Right
        Label9.AutoSize = True
        Label9.Location = New Point(19, 36)
        Label9.Name = "Label9"
        Label9.Size = New Size(18, 15)
        Label9.TabIndex = 19
        Label9.Text = "G:"
        Label9.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' nudG
        ' 
        nudG.Anchor = AnchorStyles.Left
        nudG.AutoSize = True
        nudG.Location = New Point(43, 32)
        nudG.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        nudG.Name = "nudG"
        nudG.Size = New Size(41, 23)
        nudG.TabIndex = 20
        nudG.Value = New Decimal(New Integer() {255, 0, 0, 0})
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Location = New Point(104, 7)
        Label3.Name = "Label3"
        Label3.Size = New Size(15, 15)
        Label3.TabIndex = 17
        Label3.Text = "G"
        Label3.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblB
        ' 
        lblB.Anchor = AnchorStyles.None
        lblB.AutoSize = True
        lblB.Location = New Point(186, 7)
        lblB.Name = "lblB"
        lblB.Size = New Size(14, 15)
        lblB.TabIndex = 19
        lblB.Text = "B"
        lblB.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' rbInvisible0
        ' 
        rbInvisible0.AutoSize = True
        rbInvisible0.Enabled = False
        rbInvisible0.Location = New Point(3, 32)
        rbInvisible0.Name = "rbInvisible0"
        rbInvisible0.Size = New Size(14, 1)
        rbInvisible0.TabIndex = 20
        rbInvisible0.UseVisualStyleBackColor = True
        ' 
        ' tlpLineWeight
        ' 
        tlpLineWeight.AutoSize = True
        tlpLineWeight.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tlpLineWeight.ColumnCount = 2
        tlpLineWeight.ColumnStyles.Add(New ColumnStyle())
        tlpLineWeight.ColumnStyles.Add(New ColumnStyle())
        tlpLineWeight.Controls.Add(rbLineWeightIn, 1, 2)
        tlpLineWeight.Controls.Add(nudLineWeight, 0, 1)
        tlpLineWeight.Controls.Add(rbLineWeightMM, 1, 1)
        tlpLineWeight.Controls.Add(Label8, 0, 0)
        tlpLineWeight.Location = New Point(3, 279)
        tlpLineWeight.Margin = New Padding(3, 3, 6, 3)
        tlpLineWeight.Name = "tlpLineWeight"
        tlpLineWeight.RowCount = 3
        tlpLineWeight.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0F))
        tlpLineWeight.RowStyles.Add(New RowStyle())
        tlpLineWeight.RowStyles.Add(New RowStyle())
        tlpLineWeight.Size = New Size(115, 70)
        tlpLineWeight.TabIndex = 24
        ' 
        ' rbLineWeightIn
        ' 
        rbLineWeightIn.AutoSize = True
        rbLineWeightIn.Location = New Point(65, 48)
        rbLineWeightIn.Name = "rbLineWeightIn"
        rbLineWeightIn.Size = New Size(35, 19)
        rbLineWeightIn.TabIndex = 28
        rbLineWeightIn.Text = "in"
        rbLineWeightIn.UseVisualStyleBackColor = True
        ' 
        ' nudLineWeight
        ' 
        nudLineWeight.Anchor = AnchorStyles.Right
        nudLineWeight.AutoSize = True
        nudLineWeight.DecimalPlaces = 2
        nudLineWeight.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        nudLineWeight.Location = New Point(3, 33)
        nudLineWeight.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        nudLineWeight.Name = "nudLineWeight"
        tlpLineWeight.SetRowSpan(nudLineWeight, 2)
        nudLineWeight.Size = New Size(56, 23)
        nudLineWeight.TabIndex = 26
        nudLineWeight.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        ' 
        ' rbLineWeightMM
        ' 
        rbLineWeightMM.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        rbLineWeightMM.AutoSize = True
        rbLineWeightMM.Checked = True
        rbLineWeightMM.Location = New Point(65, 23)
        rbLineWeightMM.Name = "rbLineWeightMM"
        rbLineWeightMM.Size = New Size(47, 19)
        rbLineWeightMM.TabIndex = 27
        rbLineWeightMM.TabStop = True
        rbLineWeightMM.Text = "mm"
        rbLineWeightMM.UseVisualStyleBackColor = True
        ' 
        ' nudB
        ' 
        Label8.AutoSize = True
        tlpLineWeight.SetColumnSpan(Label8, 2)
        Label8.Location = New Point(3, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(68, 15)
        Label8.TabIndex = 25
        Label8.Text = "Line weight"
        ' 
        ' tlpShape
        ' 
        tlpShape.AutoSize = True
        tlpShape.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tlpShape.ColumnCount = 2
        tlpShape.ColumnStyles.Add(New ColumnStyle())
        tlpShape.ColumnStyles.Add(New ColumnStyle())
        tlpShape.Controls.Add(tlpShapeSize, 1, 1)
        tlpShape.Controls.Add(lbShape, 0, 1)
        tlpShape.Controls.Add(Label1, 0, 0)
        tlpShape.Controls.Add(Label5, 1, 0)
        tlpShape.Location = New Point(3, 3)
        tlpShape.Name = "tlpShape"
        tlpShape.RowCount = 2
        tlpShape.RowStyles.Add(New RowStyle())
        tlpShape.RowStyles.Add(New RowStyle())
        tlpShape.Size = New Size(208, 85)
        tlpShape.TabIndex = 1
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(90, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(27, 15)
        Label5.TabIndex = 4
        Label5.Text = "Size"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(53, 375)
        Label6.Name = "Label6"
        Label6.Size = New Size(10, 15)
        Label6.TabIndex = 11
        Label6.Text = "."
        ' 
        ' tlpDetails
        ' 
        tlpDetails.AutoSize = True
        tlpDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tlpDetails.ColumnCount = 1
        tlpDetails.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        tlpDetails.Controls.Add(tlpShape, 0, 0)
        tlpDetails.Controls.Add(gbGridlines, 0, 1)
        tlpDetails.Location = New Point(23, 3)
        tlpDetails.Name = "tlpDetails"
        tlpDetails.RowCount = 3
        tlpDetails.RowStyles.Add(New RowStyle())
        tlpDetails.RowStyles.Add(New RowStyle())
        tlpDetails.RowStyles.Add(New RowStyle())
        tlpDetails.Size = New Size(249, 277)
        tlpDetails.TabIndex = 0
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {PrintingToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(800, 24)
        MenuStrip1.TabIndex = 13
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' PrintingToolStripMenuItem
        ' 
        PrintingToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {PrintToolStripMenuItem, PageSetupToolStripMenuItem, ObservePageMarginsToolStripMenuItem})
        PrintingToolStripMenuItem.Name = "PrintingToolStripMenuItem"
        PrintingToolStripMenuItem.Size = New Size(61, 20)
        PrintingToolStripMenuItem.Text = "Printing"
        ' 
        ' PrintToolStripMenuItem
        ' 
        PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        PrintToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.P
        PrintToolStripMenuItem.Size = New Size(192, 22)
        PrintToolStripMenuItem.Text = "Print"
        ' 
        ' PageSetupToolStripMenuItem
        ' 
        PageSetupToolStripMenuItem.Name = "PageSetupToolStripMenuItem"
        PageSetupToolStripMenuItem.Size = New Size(192, 22)
        PageSetupToolStripMenuItem.Text = "Page setup"
        ' 
        ' ObservePageMarginsToolStripMenuItem
        ' 
        ObservePageMarginsToolStripMenuItem.Checked = True
        ObservePageMarginsToolStripMenuItem.CheckState = CheckState.Checked
        ObservePageMarginsToolStripMenuItem.Name = "ObservePageMarginsToolStripMenuItem"
        ObservePageMarginsToolStripMenuItem.Size = New Size(192, 22)
        ObservePageMarginsToolStripMenuItem.Text = "Observe page margins"
        ' 
        ' tlpMain
        ' 
        tlpMain.ColumnCount = 4
        tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
        tlpMain.ColumnStyles.Add(New ColumnStyle())
        tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
        tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
        tlpMain.Controls.Add(tlpDetails, 1, 0)
        tlpMain.Controls.Add(GraphPaperControl1, 2, 0)
        tlpMain.Dock = DockStyle.Fill
        tlpMain.Location = New Point(0, 24)
        tlpMain.Name = "tlpMain"
        tlpMain.RowCount = 1
        tlpMain.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        tlpMain.Size = New Size(800, 426)
        tlpMain.TabIndex = 14
        ' 
        ' GraphPaperControl1
        ' 
        GraphPaperControl1.BackColor = SystemColors.Window
        GraphPaperControl1.Dock = DockStyle.Fill
        GraphPaperControl1.Location = New Point(278, 3)
        GraphPaperControl1.Name = "GraphPaperControl1"
        GraphPaperControl1.Size = New Size(499, 420)
        GraphPaperControl1.TabIndex = 1
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.AutoSize = True
        TableLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink
        TableLayoutPanel3.ColumnCount = 2
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel3.Controls.Add(RadioButton3, 1, 2)
        TableLayoutPanel3.Location = New Point(0, 0)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 3
        TableLayoutPanel3.Size = New Size(200, 100)
        TableLayoutPanel3.TabIndex = 0
        ' 
        ' RadioButton3
        ' 
        RadioButton3.AutoSize = True
        RadioButton3.Location = New Point(3, 3)
        RadioButton3.Name = "RadioButton3"
        RadioButton3.Size = New Size(35, 19)
        RadioButton3.TabIndex = 30
        RadioButton3.Text = "in"
        RadioButton3.UseVisualStyleBackColor = True
        ' 
        ' NumericUpDown4
        ' 
        NumericUpDown4.Anchor = AnchorStyles.Right
        NumericUpDown4.AutoSize = True
        NumericUpDown4.DecimalPlaces = 2
        NumericUpDown4.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        NumericUpDown4.Location = New Point(3, 38)
        NumericUpDown4.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        NumericUpDown4.Name = "NumericUpDown4"
        NumericUpDown4.Size = New Size(56, 23)
        NumericUpDown4.TabIndex = 28
        NumericUpDown4.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        ' 
        ' Console
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(tlpMain)
        Controls.Add(Label6)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "Console"
        Text = "Print graph paper"
        tlpShapeSize.ResumeLayout(False)
        tlpShapeSize.PerformLayout()
        CType(nudShapeWidth, ComponentModel.ISupportInitialize).EndInit()
        gbGridlines.ResumeLayout(False)
        gbGridlines.PerformLayout()
        tlpGridLines.ResumeLayout(False)
        tlpGridLines.PerformLayout()
        TableLayoutPanel4.ResumeLayout(False)
        TableLayoutPanel4.PerformLayout()
        tlpLineWidth.ResumeLayout(False)
        tlpLineWidth.PerformLayout()
        CType(nudLineWidth, ComponentModel.ISupportInitialize).EndInit()
        tlpRGB.ResumeLayout(False)
        tlpRGB.PerformLayout()
        CType(nudR, ComponentModel.ISupportInitialize).EndInit()
        CType(nudG, ComponentModel.ISupportInitialize).EndInit()
        CType(nudB, ComponentModel.ISupportInitialize).EndInit()
        tlpShape.ResumeLayout(False)
        tlpShape.PerformLayout()
        tlpDetails.ResumeLayout(False)
        tlpDetails.PerformLayout()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        tlpMain.ResumeLayout(False)
        tlpMain.PerformLayout()
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        CType(NumericUpDown4, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents lbShape As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents gbGridlines As GroupBox
    Friend WithEvents rbSizeIn As RadioButton
    Friend WithEvents rbSizeMM As RadioButton
    Friend WithEvents nudShapeWidth As NumericUpDown
    Friend WithEvents tlpShapeSize As TableLayoutPanel
    Friend WithEvents tlpDetails As TableLayoutPanel
    Friend WithEvents tlpShape As TableLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents PrintingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PageSetupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ObservePageMarginsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents GraphPaperControl1 As GraphPaperControl
    Friend WithEvents tlpGridLines As TableLayoutPanel
    Friend WithEvents rbWebColor As RadioButton
    Friend WithEvents rbRGB As RadioButton
    Friend WithEvents cboxWebColor As ComboBox
    Friend WithEvents tlpRGB As TableLayoutPanel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents nudR As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents nudG As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents nudB As NumericUpDown
    Friend WithEvents tbHexColor As TextBox
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents tlpLineWidth As TableLayoutPanel
    Friend WithEvents rbLineWeightIn As RadioButton
    Friend WithEvents nudLineWidth As NumericUpDown
    Friend WithEvents rbLineWeightMM As RadioButton
    Friend WithEvents Label12 As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents NumericUpDown4 As NumericUpDown

End Class
