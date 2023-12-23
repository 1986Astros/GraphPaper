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
        NumericUpDown5 = New NumericUpDown()
        rbSizeMM = New RadioButton()
        gbLineColor = New GroupBox()
        tlpLineColor = New TableLayoutPanel()
        tlpHex = New TableLayoutPanel()
        Label7 = New Label()
        tbHexColor = New TextBox()
        tlpRGBbutton = New TableLayoutPanel()
        rbRGB = New RadioButton()
        panelRGB = New Panel()
        tlpWebColor = New TableLayoutPanel()
        rbWebColor = New RadioButton()
        cboxWebColor = New ComboBox()
        tlpRGB = New TableLayoutPanel()
        NumericUpDown4 = New NumericUpDown()
        Label2 = New Label()
        nudR = New NumericUpDown()
        nudG = New NumericUpDown()
        Label3 = New Label()
        nudB = New Label()
        tlpLineWeight = New TableLayoutPanel()
        rbLineWeightIn = New RadioButton()
        nudLineWeight = New NumericUpDown()
        rbLineWeightMM = New RadioButton()
        Label8 = New Label()
        tlpShape = New TableLayoutPanel()
        Label5 = New Label()
        Label6 = New Label()
        tlpMain = New TableLayoutPanel()
        rbInvisible0 = New RadioButton()
        rbInvisible1 = New RadioButton()
        tlpShapeSize.SuspendLayout()
        CType(NumericUpDown5, ComponentModel.ISupportInitialize).BeginInit()
        gbLineColor.SuspendLayout()
        tlpLineColor.SuspendLayout()
        tlpHex.SuspendLayout()
        tlpRGBbutton.SuspendLayout()
        tlpWebColor.SuspendLayout()
        tlpRGB.SuspendLayout()
        CType(NumericUpDown4, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudR, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudG, ComponentModel.ISupportInitialize).BeginInit()
        tlpLineWeight.SuspendLayout()
        CType(nudLineWeight, ComponentModel.ISupportInitialize).BeginInit()
        tlpShape.SuspendLayout()
        tlpMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(39, 15)
        Label1.TabIndex = 3
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
        lbShape.TabIndex = 1
        ' 
        ' tlpShapeSize
        ' 
        tlpShapeSize.AutoSize = True
        tlpShapeSize.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tlpShapeSize.ColumnCount = 2
        tlpShapeSize.ColumnStyles.Add(New ColumnStyle())
        tlpShapeSize.ColumnStyles.Add(New ColumnStyle())
        tlpShapeSize.Controls.Add(rbSizeIn, 1, 1)
        tlpShapeSize.Controls.Add(NumericUpDown5, 0, 0)
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
        rbSizeIn.TabIndex = 1
        rbSizeIn.TabStop = True
        rbSizeIn.Text = "in"
        rbSizeIn.UseVisualStyleBackColor = True
        ' 
        ' NumericUpDown5
        ' 
        NumericUpDown5.Anchor = AnchorStyles.Right
        NumericUpDown5.AutoSize = True
        NumericUpDown5.DecimalPlaces = 2
        NumericUpDown5.Increment = New Decimal(New Integer() {5, 0, 0, 131072})
        NumericUpDown5.Location = New Point(3, 13)
        NumericUpDown5.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        NumericUpDown5.Name = "NumericUpDown5"
        tlpShapeSize.SetRowSpan(NumericUpDown5, 2)
        NumericUpDown5.Size = New Size(56, 23)
        NumericUpDown5.TabIndex = 0
        NumericUpDown5.Value = New Decimal(New Integer() {25, 0, 0, 131072})
        ' 
        ' rbSizeMM
        ' 
        rbSizeMM.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        rbSizeMM.AutoSize = True
        rbSizeMM.Location = New Point(65, 3)
        rbSizeMM.Name = "rbSizeMM"
        rbSizeMM.Size = New Size(47, 19)
        rbSizeMM.TabIndex = 1
        rbSizeMM.Text = "mm"
        rbSizeMM.UseVisualStyleBackColor = True
        ' 
        ' gbLineColor
        ' 
        gbLineColor.AutoSize = True
        gbLineColor.AutoSizeMode = AutoSizeMode.GrowAndShrink
        gbLineColor.Controls.Add(tlpLineColor)
        gbLineColor.Dock = DockStyle.Fill
        gbLineColor.Location = New Point(3, 111)
        gbLineColor.Margin = New Padding(3, 20, 3, 3)
        gbLineColor.Name = "gbLineColor"
        gbLineColor.Size = New Size(263, 162)
        gbLineColor.TabIndex = 4
        gbLineColor.TabStop = False
        gbLineColor.Text = "Line color"
        ' 
        ' tlpLineColor
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
        tlpLineColor.TabIndex = 5
        ' 
        ' tlpHex
        ' 
        tlpHex.AutoSize = True
        tlpHex.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tlpHex.ColumnCount = 5
        tlpHex.ColumnStyles.Add(New ColumnStyle())
        tlpHex.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpHex.ColumnStyles.Add(New ColumnStyle())
        tlpHex.ColumnStyles.Add(New ColumnStyle())
        tlpHex.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpHex.Controls.Add(Label7, 2, 0)
        tlpHex.Controls.Add(tbHexColor, 3, 0)
        tlpHex.Controls.Add(rbInvisible1, 0, 1)
        tlpHex.Dock = DockStyle.Fill
        tlpHex.Location = New Point(3, 107)
        tlpHex.Name = "tlpHex"
        tlpHex.RowCount = 2
        tlpHex.RowStyles.Add(New RowStyle())
        tlpHex.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        tlpHex.Size = New Size(251, 30)
        tlpHex.TabIndex = 14
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.None
        Label7.AutoSize = True
        Label7.Location = New Point(94, 7)
        Label7.Name = "Label7"
        Label7.Size = New Size(21, 15)
        Label7.TabIndex = 13
        Label7.Text = "##"
        ' 
        ' tbHexColor
        ' 
        tbHexColor.Location = New Point(121, 3)
        tbHexColor.Name = "tbHexColor"
        tbHexColor.Size = New Size(55, 23)
        tbHexColor.TabIndex = 12
        ' 
        ' tlpRGBbutton
        ' 
        tlpRGBbutton.AutoSize = True
        tlpRGBbutton.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tlpRGBbutton.ColumnCount = 2
        tlpRGBbutton.ColumnStyles.Add(New ColumnStyle())
        tlpRGBbutton.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlpRGBbutton.Controls.Add(rbRGB, 0, 0)
        tlpRGBbutton.Controls.Add(panelRGB, 1, 0)
        tlpRGBbutton.Location = New Point(3, 39)
        tlpRGBbutton.Name = "tlpRGBbutton"
        tlpRGBbutton.RowCount = 1
        tlpRGBbutton.RowStyles.Add(New RowStyle())
        tlpRGBbutton.Size = New Size(102, 26)
        tlpRGBbutton.TabIndex = 12
        ' 
        ' rbRGB
        ' 
        rbRGB.AutoSize = True
        rbRGB.Location = New Point(3, 3)
        rbRGB.Name = "rbRGB"
        rbRGB.Size = New Size(50, 19)
        rbRGB.TabIndex = 0
        rbRGB.Text = "RGB:"
        rbRGB.UseVisualStyleBackColor = True
        ' 
        ' panelRGB
        ' 
        panelRGB.BorderStyle = BorderStyle.FixedSingle
        panelRGB.Location = New Point(59, 3)
        panelRGB.Name = "panelRGB"
        panelRGB.Size = New Size(40, 20)
        panelRGB.TabIndex = 3
        ' 
        ' tlpWebColor
        ' 
        tlpWebColor.AutoSize = True
        tlpWebColor.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tlpWebColor.ColumnCount = 2
        tlpWebColor.ColumnStyles.Add(New ColumnStyle())
        tlpWebColor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlpWebColor.Controls.Add(rbWebColor, 0, 0)
        tlpWebColor.Controls.Add(cboxWebColor, 1, 0)
        tlpWebColor.Location = New Point(3, 3)
        tlpWebColor.Name = "tlpWebColor"
        tlpWebColor.RowCount = 1
        tlpWebColor.RowStyles.Add(New RowStyle())
        tlpWebColor.Size = New Size(251, 30)
        tlpWebColor.TabIndex = 10
        ' 
        ' rbWebColor
        ' 
        rbWebColor.Anchor = AnchorStyles.None
        rbWebColor.AutoSize = True
        rbWebColor.Checked = True
        rbWebColor.Location = New Point(3, 5)
        rbWebColor.Name = "rbWebColor"
        rbWebColor.Size = New Size(82, 19)
        rbWebColor.TabIndex = 0
        rbWebColor.TabStop = True
        rbWebColor.Text = "Web color:"
        rbWebColor.UseVisualStyleBackColor = True
        ' 
        ' cboxWebColor
        ' 
        cboxWebColor.DrawMode = DrawMode.OwnerDrawFixed
        cboxWebColor.DropDownStyle = ComboBoxStyle.DropDownList
        cboxWebColor.FormattingEnabled = True
        cboxWebColor.Location = New Point(91, 3)
        cboxWebColor.Name = "cboxWebColor"
        cboxWebColor.Size = New Size(157, 24)
        cboxWebColor.TabIndex = 1
        ' 
        ' tlpRGB
        ' 
        tlpRGB.AutoSize = True
        tlpRGB.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tlpRGB.ColumnCount = 9
        tlpRGB.ColumnStyles.Add(New ColumnStyle())
        tlpRGB.ColumnStyles.Add(New ColumnStyle())
        tlpRGB.ColumnStyles.Add(New ColumnStyle())
        tlpRGB.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpRGB.ColumnStyles.Add(New ColumnStyle())
        tlpRGB.ColumnStyles.Add(New ColumnStyle())
        tlpRGB.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        tlpRGB.ColumnStyles.Add(New ColumnStyle())
        tlpRGB.ColumnStyles.Add(New ColumnStyle())
        tlpRGB.Controls.Add(NumericUpDown4, 8, 0)
        tlpRGB.Controls.Add(Label2, 1, 0)
        tlpRGB.Controls.Add(nudR, 2, 0)
        tlpRGB.Controls.Add(nudG, 5, 0)
        tlpRGB.Controls.Add(Label3, 4, 0)
        tlpRGB.Controls.Add(nudB, 7, 0)
        tlpRGB.Controls.Add(rbInvisible0, 0, 1)
        tlpRGB.Dock = DockStyle.Fill
        tlpRGB.Location = New Point(3, 71)
        tlpRGB.Name = "tlpRGB"
        tlpRGB.RowCount = 2
        tlpRGB.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlpRGB.RowStyles.Add(New RowStyle(SizeType.Absolute, 1F))
        tlpRGB.Size = New Size(251, 30)
        tlpRGB.TabIndex = 5
        ' 
        ' NumericUpDown4
        ' 
        NumericUpDown4.AutoSize = True
        NumericUpDown4.Location = New Point(206, 3)
        NumericUpDown4.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        NumericUpDown4.Name = "NumericUpDown4"
        NumericUpDown4.Size = New Size(41, 23)
        NumericUpDown4.TabIndex = 4
        NumericUpDown4.Value = New Decimal(New Integer() {255, 0, 0, 0})
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Location = New Point(23, 7)
        Label2.Name = "Label2"
        Label2.Size = New Size(14, 15)
        Label2.TabIndex = 3
        Label2.Text = "R"
        Label2.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' nudR
        ' 
        nudR.AllowDrop = True
        nudR.AutoSize = True
        nudR.Location = New Point(43, 3)
        nudR.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        nudR.Name = "nudR"
        nudR.Size = New Size(41, 23)
        nudR.TabIndex = 4
        nudR.Value = New Decimal(New Integer() {255, 0, 0, 0})
        ' 
        ' nudG
        ' 
        nudG.AutoSize = True
        nudG.Location = New Point(125, 3)
        nudG.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        nudG.Name = "nudG"
        nudG.Size = New Size(41, 23)
        nudG.TabIndex = 4
        nudG.Value = New Decimal(New Integer() {255, 0, 0, 0})
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Location = New Point(104, 7)
        Label3.Name = "Label3"
        Label3.Size = New Size(15, 15)
        Label3.TabIndex = 3
        Label3.Text = "G"
        Label3.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' nudB
        ' 
        nudB.Anchor = AnchorStyles.None
        nudB.AutoSize = True
        nudB.Location = New Point(186, 7)
        nudB.Name = "nudB"
        nudB.Size = New Size(14, 15)
        nudB.TabIndex = 3
        nudB.Text = "B"
        nudB.TextAlign = ContentAlignment.MiddleRight
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
        tlpLineWeight.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlpLineWeight.RowStyles.Add(New RowStyle())
        tlpLineWeight.RowStyles.Add(New RowStyle())
        tlpLineWeight.Size = New Size(115, 70)
        tlpLineWeight.TabIndex = 5
        ' 
        ' rbLineWeightIn
        ' 
        rbLineWeightIn.AutoSize = True
        rbLineWeightIn.Location = New Point(65, 48)
        rbLineWeightIn.Name = "rbLineWeightIn"
        rbLineWeightIn.Size = New Size(35, 19)
        rbLineWeightIn.TabIndex = 1
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
        nudLineWeight.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        nudLineWeight.Name = "nudLineWeight"
        tlpLineWeight.SetRowSpan(nudLineWeight, 2)
        nudLineWeight.Size = New Size(56, 23)
        nudLineWeight.TabIndex = 0
        nudLineWeight.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        ' 
        ' rbLineWeightMM
        ' 
        rbLineWeightMM.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        rbLineWeightMM.AutoSize = True
        rbLineWeightMM.Checked = True
        rbLineWeightMM.Location = New Point(65, 23)
        rbLineWeightMM.Name = "rbLineWeightMM"
        rbLineWeightMM.Size = New Size(47, 19)
        rbLineWeightMM.TabIndex = 1
        rbLineWeightMM.TabStop = True
        rbLineWeightMM.Text = "mm"
        rbLineWeightMM.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        tlpLineWeight.SetColumnSpan(Label8, 2)
        Label8.Location = New Point(3, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(68, 15)
        Label8.TabIndex = 0
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
        tlpShape.TabIndex = 8
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
        ' tlpMain
        ' 
        tlpMain.AutoSize = True
        tlpMain.AutoSizeMode = AutoSizeMode.GrowAndShrink
        tlpMain.ColumnCount = 1
        tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlpMain.Controls.Add(tlpLineWeight, 0, 2)
        tlpMain.Controls.Add(tlpShape, 0, 0)
        tlpMain.Controls.Add(gbLineColor, 0, 1)
        tlpMain.Location = New Point(12, 12)
        tlpMain.Name = "tlpMain"
        tlpMain.RowCount = 3
        tlpMain.RowStyles.Add(New RowStyle())
        tlpMain.RowStyles.Add(New RowStyle())
        tlpMain.RowStyles.Add(New RowStyle())
        tlpMain.Size = New Size(269, 352)
        tlpMain.TabIndex = 12
        ' 
        ' rbInvisible0
        ' 
        rbInvisible0.AutoSize = True
        rbInvisible0.Location = New Point(3, 32)
        rbInvisible0.Name = "rbInvisible0"
        rbInvisible0.Size = New Size(14, 1)
        rbInvisible0.TabIndex = 5
        rbInvisible0.TabStop = True
        rbInvisible0.UseVisualStyleBackColor = True
        ' 
        ' rbInvisible1
        ' 
        rbInvisible1.AutoSize = True
        rbInvisible1.Location = New Point(3, 32)
        rbInvisible1.Name = "rbInvisible1"
        rbInvisible1.Size = New Size(14, 1)
        rbInvisible1.TabIndex = 14
        rbInvisible1.TabStop = True
        rbInvisible1.UseVisualStyleBackColor = True
        ' 
        ' Console
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(tlpMain)
        Controls.Add(Label6)
        Name = "Console"
        Text = "Print graph paper"
        tlpShapeSize.ResumeLayout(False)
        tlpShapeSize.PerformLayout()
        CType(NumericUpDown5, ComponentModel.ISupportInitialize).EndInit()
        gbLineColor.ResumeLayout(False)
        gbLineColor.PerformLayout()
        tlpLineColor.ResumeLayout(False)
        tlpLineColor.PerformLayout()
        tlpHex.ResumeLayout(False)
        tlpHex.PerformLayout()
        tlpRGBbutton.ResumeLayout(False)
        tlpRGBbutton.PerformLayout()
        tlpWebColor.ResumeLayout(False)
        tlpWebColor.PerformLayout()
        tlpRGB.ResumeLayout(False)
        tlpRGB.PerformLayout()
        CType(NumericUpDown4, ComponentModel.ISupportInitialize).EndInit()
        CType(nudR, ComponentModel.ISupportInitialize).EndInit()
        CType(nudG, ComponentModel.ISupportInitialize).EndInit()
        tlpLineWeight.ResumeLayout(False)
        tlpLineWeight.PerformLayout()
        CType(nudLineWeight, ComponentModel.ISupportInitialize).EndInit()
        tlpShape.ResumeLayout(False)
        tlpShape.PerformLayout()
        tlpMain.ResumeLayout(False)
        tlpMain.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents lbShape As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents gbLineColor As GroupBox
    Friend WithEvents cboxWebColor As ComboBox
    Friend WithEvents rbWebColor As RadioButton
    Friend WithEvents rbLineWeightIn As RadioButton
    Friend WithEvents rbLineWeightMM As RadioButton
    Friend WithEvents nudLineWeight As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents nudB As Label
    Friend WithEvents nudR As NumericUpDown
    Friend WithEvents nudG As NumericUpDown
    Friend WithEvents tlpLineColor As TableLayoutPanel
    Friend WithEvents NumericUpDown4 As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents tlpRGB As TableLayoutPanel
    Friend WithEvents rbSizeIn As RadioButton
    Friend WithEvents rbSizeMM As RadioButton
    Friend WithEvents NumericUpDown5 As NumericUpDown
    Friend WithEvents tlpShapeSize As TableLayoutPanel
    Friend WithEvents tlpLineWeight As TableLayoutPanel
    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents tlpWebColor As TableLayoutPanel
    Friend WithEvents tlpShape As TableLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents panelRGB As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents rbRGB As RadioButton
    Friend WithEvents tlpRGBbutton As TableLayoutPanel
    Friend WithEvents Label7 As Label
    Friend WithEvents tlpHex As TableLayoutPanel
    Friend WithEvents tbHexColor As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents rbInvisible0 As RadioButton
    Friend WithEvents rbInvisible1 As RadioButton

End Class
