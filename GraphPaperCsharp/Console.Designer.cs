namespace GraphPaperCsharp
{
    partial class Console
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Console));
            MenuStrip1 = new MenuStrip();
            PrintingToolStripMenuItem = new ToolStripMenuItem();
            PrintToolStripMenuItem = new ToolStripMenuItem();
            PageSetupToolStripMenuItem = new ToolStripMenuItem();
            IgnorePageMarginsToolStripMenuItem = new ToolStripMenuItem();
            tlpMain = new TableLayoutPanel();
            tlpDetails = new TableLayoutPanel();
            tlpShape = new TableLayoutPanel();
            tlpShapeSize = new TableLayoutPanel();
            rbShapeWidthIn = new RadioButton();
            nudShapeWidth = new NumericUpDown();
            rbShapeWidthMM = new RadioButton();
            lbShape = new ListBox();
            Label1 = new Label();
            Label5 = new Label();
            gbGridlines = new GroupBox();
            tlpGridLines = new TableLayoutPanel();
            TableLayoutPanel4 = new TableLayoutPanel();
            cboxWebColor = new ComboBox();
            tlpLineWidth = new TableLayoutPanel();
            rbLineWidthIn = new RadioButton();
            nudLineWidth = new NumericUpDown();
            rbLineWidthMM = new RadioButton();
            Label12 = new Label();
            rbWebColor = new RadioButton();
            rbRGB = new RadioButton();
            tlpRGB = new TableLayoutPanel();
            Label11 = new Label();
            Label4 = new Label();
            tbHexColor = new TextBox();
            nudR = new NumericUpDown();
            Label9 = new Label();
            nudG = new NumericUpDown();
            Label10 = new Label();
            nudB = new NumericUpDown();
            graphPaperControl1 = new SharkInSeine.GraphPaperControl();
            pageSetupDialog1 = new PageSetupDialog();
            MenuStrip1.SuspendLayout();
            tlpMain.SuspendLayout();
            tlpDetails.SuspendLayout();
            tlpShape.SuspendLayout();
            tlpShapeSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudShapeWidth).BeginInit();
            gbGridlines.SuspendLayout();
            tlpGridLines.SuspendLayout();
            TableLayoutPanel4.SuspendLayout();
            tlpLineWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudLineWidth).BeginInit();
            tlpRGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudB).BeginInit();
            SuspendLayout();
            // 
            // MenuStrip1
            // 
            MenuStrip1.Items.AddRange(new ToolStripItem[] { PrintingToolStripMenuItem });
            MenuStrip1.Location = new Point(0, 0);
            MenuStrip1.Name = "MenuStrip1";
            MenuStrip1.Size = new Size(800, 24);
            MenuStrip1.TabIndex = 14;
            MenuStrip1.Text = "MenuStrip1";
            // 
            // PrintingToolStripMenuItem
            // 
            PrintingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { PrintToolStripMenuItem, PageSetupToolStripMenuItem, IgnorePageMarginsToolStripMenuItem });
            PrintingToolStripMenuItem.Name = "PrintingToolStripMenuItem";
            PrintingToolStripMenuItem.Size = new Size(61, 20);
            PrintingToolStripMenuItem.Text = "Printing";
            // 
            // PrintToolStripMenuItem
            // 
            PrintToolStripMenuItem.Name = "PrintToolStripMenuItem";
            PrintToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            PrintToolStripMenuItem.Size = new Size(183, 22);
            PrintToolStripMenuItem.Text = "Print";
            PrintToolStripMenuItem.Click += PrintToolStripMenuItem_Click;
            // 
            // PageSetupToolStripMenuItem
            // 
            PageSetupToolStripMenuItem.Name = "PageSetupToolStripMenuItem";
            PageSetupToolStripMenuItem.Size = new Size(183, 22);
            PageSetupToolStripMenuItem.Text = "Page setup";
            PageSetupToolStripMenuItem.Click += PageSetupToolStripMenuItem_Click;
            // 
            // IgnorePageMarginsToolStripMenuItem
            // 
            IgnorePageMarginsToolStripMenuItem.Checked = true;
            IgnorePageMarginsToolStripMenuItem.CheckState = CheckState.Checked;
            IgnorePageMarginsToolStripMenuItem.Name = "IgnorePageMarginsToolStripMenuItem";
            IgnorePageMarginsToolStripMenuItem.Size = new Size(183, 22);
            IgnorePageMarginsToolStripMenuItem.Text = "Ignore page margins";
            IgnorePageMarginsToolStripMenuItem.Click += IgnorePageMarginsToolStripMenuItem_Click;
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 3;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpMain.ColumnStyles.Add(new ColumnStyle());
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpMain.Controls.Add(tlpDetails, 1, 0);
            tlpMain.Controls.Add(graphPaperControl1, 2, 0);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 24);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(800, 426);
            tlpMain.TabIndex = 15;
            // 
            // tlpDetails
            // 
            tlpDetails.AutoSize = true;
            tlpDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpDetails.ColumnCount = 1;
            tlpDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpDetails.Controls.Add(tlpShape, 0, 0);
            tlpDetails.Controls.Add(gbGridlines, 0, 1);
            tlpDetails.Location = new Point(23, 3);
            tlpDetails.Name = "tlpDetails";
            tlpDetails.RowCount = 3;
            tlpDetails.RowStyles.Add(new RowStyle());
            tlpDetails.RowStyles.Add(new RowStyle());
            tlpDetails.RowStyles.Add(new RowStyle());
            tlpDetails.Size = new Size(249, 292);
            tlpDetails.TabIndex = 0;
            // 
            // tlpShape
            // 
            tlpShape.AutoSize = true;
            tlpShape.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpShape.ColumnCount = 2;
            tlpShape.ColumnStyles.Add(new ColumnStyle());
            tlpShape.ColumnStyles.Add(new ColumnStyle());
            tlpShape.Controls.Add(tlpShapeSize, 1, 1);
            tlpShape.Controls.Add(lbShape, 0, 1);
            tlpShape.Controls.Add(Label1, 0, 0);
            tlpShape.Controls.Add(Label5, 1, 0);
            tlpShape.Location = new Point(3, 3);
            tlpShape.Name = "tlpShape";
            tlpShape.RowCount = 2;
            tlpShape.RowStyles.Add(new RowStyle());
            tlpShape.RowStyles.Add(new RowStyle());
            tlpShape.Size = new Size(208, 100);
            tlpShape.TabIndex = 1;
            // 
            // tlpShapeSize
            // 
            tlpShapeSize.AutoSize = true;
            tlpShapeSize.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpShapeSize.ColumnCount = 2;
            tlpShapeSize.ColumnStyles.Add(new ColumnStyle());
            tlpShapeSize.ColumnStyles.Add(new ColumnStyle());
            tlpShapeSize.Controls.Add(rbShapeWidthIn, 1, 1);
            tlpShapeSize.Controls.Add(nudShapeWidth, 0, 0);
            tlpShapeSize.Controls.Add(rbShapeWidthMM, 1, 0);
            tlpShapeSize.Location = new Point(90, 18);
            tlpShapeSize.Name = "tlpShapeSize";
            tlpShapeSize.RowCount = 2;
            tlpShapeSize.RowStyles.Add(new RowStyle());
            tlpShapeSize.RowStyles.Add(new RowStyle());
            tlpShapeSize.Size = new Size(115, 50);
            tlpShapeSize.TabIndex = 5;
            // 
            // rbShapeWidthIn
            // 
            rbShapeWidthIn.AutoSize = true;
            rbShapeWidthIn.Checked = true;
            rbShapeWidthIn.Location = new Point(65, 28);
            rbShapeWidthIn.Name = "rbShapeWidthIn";
            rbShapeWidthIn.Size = new Size(35, 19);
            rbShapeWidthIn.TabIndex = 7;
            rbShapeWidthIn.TabStop = true;
            rbShapeWidthIn.Text = "in";
            rbShapeWidthIn.UseVisualStyleBackColor = true;
            rbShapeWidthIn.CheckedChanged += rbSizeIn_CheckedChanged;
            // 
            // nudShapeWidth
            // 
            nudShapeWidth.Anchor = AnchorStyles.Right;
            nudShapeWidth.AutoSize = true;
            nudShapeWidth.DecimalPlaces = 2;
            nudShapeWidth.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            nudShapeWidth.Location = new Point(3, 13);
            nudShapeWidth.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            nudShapeWidth.Name = "nudShapeWidth";
            tlpShapeSize.SetRowSpan(nudShapeWidth, 2);
            nudShapeWidth.Size = new Size(56, 23);
            nudShapeWidth.TabIndex = 5;
            nudShapeWidth.Value = new decimal(new int[] { 25, 0, 0, 131072 });
            nudShapeWidth.ValueChanged += nudShapeWidth_ValueChanged;
            // 
            // rbShapeWidthMM
            // 
            rbShapeWidthMM.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            rbShapeWidthMM.AutoSize = true;
            rbShapeWidthMM.Location = new Point(65, 3);
            rbShapeWidthMM.Name = "rbShapeWidthMM";
            rbShapeWidthMM.Size = new Size(47, 19);
            rbShapeWidthMM.TabIndex = 6;
            rbShapeWidthMM.TabStop = true;
            rbShapeWidthMM.Text = "mm";
            rbShapeWidthMM.UseVisualStyleBackColor = true;
            rbShapeWidthMM.CheckedChanged += rbSizeMM_CheckedChanged;
            // 
            // lbShape
            // 
            lbShape.FormattingEnabled = true;
            lbShape.ItemHeight = 15;
            lbShape.Items.AddRange(new object[] { "Circles", "Squares", "Hexagons", "Triangles", "Diamonds" });
            lbShape.Location = new Point(3, 18);
            lbShape.Name = "lbShape";
            lbShape.Size = new Size(81, 79);
            lbShape.TabIndex = 3;
            lbShape.SelectedIndexChanged += lbShape_SelectedIndexChanged;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(3, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(39, 15);
            Label1.TabIndex = 2;
            Label1.Text = "Shape";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Location = new Point(90, 0);
            Label5.Name = "Label5";
            Label5.Size = new Size(27, 15);
            Label5.TabIndex = 4;
            Label5.Text = "Size";
            // 
            // gbGridlines
            // 
            gbGridlines.AutoSize = true;
            gbGridlines.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gbGridlines.Controls.Add(tlpGridLines);
            gbGridlines.Dock = DockStyle.Fill;
            gbGridlines.Location = new Point(3, 126);
            gbGridlines.Margin = new Padding(3, 20, 3, 3);
            gbGridlines.Name = "gbGridlines";
            gbGridlines.Size = new Size(243, 163);
            gbGridlines.TabIndex = 8;
            gbGridlines.TabStop = false;
            gbGridlines.Text = "Gridlines";
            // 
            // tlpGridLines
            // 
            tlpGridLines.AutoSize = true;
            tlpGridLines.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpGridLines.ColumnCount = 2;
            tlpGridLines.ColumnStyles.Add(new ColumnStyle());
            tlpGridLines.ColumnStyles.Add(new ColumnStyle());
            tlpGridLines.Controls.Add(TableLayoutPanel4, 0, 1);
            tlpGridLines.Controls.Add(rbWebColor, 0, 0);
            tlpGridLines.Controls.Add(rbRGB, 1, 0);
            tlpGridLines.Controls.Add(tlpRGB, 1, 1);
            tlpGridLines.Dock = DockStyle.Fill;
            tlpGridLines.Location = new Point(3, 19);
            tlpGridLines.Name = "tlpGridLines";
            tlpGridLines.RowCount = 2;
            tlpGridLines.RowStyles.Add(new RowStyle());
            tlpGridLines.RowStyles.Add(new RowStyle());
            tlpGridLines.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpGridLines.Size = new Size(237, 141);
            tlpGridLines.TabIndex = 0;
            // 
            // TableLayoutPanel4
            // 
            TableLayoutPanel4.AutoSize = true;
            TableLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TableLayoutPanel4.ColumnCount = 1;
            TableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            TableLayoutPanel4.Controls.Add(cboxWebColor, 0, 0);
            TableLayoutPanel4.Controls.Add(tlpLineWidth, 0, 1);
            TableLayoutPanel4.Dock = DockStyle.Fill;
            TableLayoutPanel4.Location = new Point(0, 25);
            TableLayoutPanel4.Margin = new Padding(0);
            TableLayoutPanel4.Name = "TableLayoutPanel4";
            TableLayoutPanel4.RowCount = 2;
            TableLayoutPanel4.RowStyles.Add(new RowStyle());
            TableLayoutPanel4.RowStyles.Add(new RowStyle());
            TableLayoutPanel4.Size = new Size(136, 116);
            TableLayoutPanel4.TabIndex = 1;
            // 
            // cboxWebColor
            // 
            cboxWebColor.DrawMode = DrawMode.OwnerDrawFixed;
            cboxWebColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxWebColor.FormattingEnabled = true;
            cboxWebColor.Location = new Point(3, 3);
            cboxWebColor.Name = "cboxWebColor";
            cboxWebColor.Size = new Size(130, 24);
            cboxWebColor.TabIndex = 16;
            cboxWebColor.DrawItem += cboxWebColor_DrawItem;
            cboxWebColor.SelectedIndexChanged += cboxWebColor_SelectedIndexChanged;
            // 
            // tlpLineWidth
            // 
            tlpLineWidth.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tlpLineWidth.AutoSize = true;
            tlpLineWidth.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpLineWidth.ColumnCount = 2;
            tlpLineWidth.ColumnStyles.Add(new ColumnStyle());
            tlpLineWidth.ColumnStyles.Add(new ColumnStyle());
            tlpLineWidth.Controls.Add(rbLineWidthIn, 1, 2);
            tlpLineWidth.Controls.Add(nudLineWidth, 0, 1);
            tlpLineWidth.Controls.Add(rbLineWidthMM, 1, 1);
            tlpLineWidth.Controls.Add(Label12, 0, 0);
            tlpLineWidth.Location = new Point(0, 46);
            tlpLineWidth.Margin = new Padding(0);
            tlpLineWidth.Name = "tlpLineWidth";
            tlpLineWidth.RowCount = 3;
            tlpLineWidth.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpLineWidth.RowStyles.Add(new RowStyle());
            tlpLineWidth.RowStyles.Add(new RowStyle());
            tlpLineWidth.Size = new Size(115, 70);
            tlpLineWidth.TabIndex = 27;
            // 
            // rbLineWidthIn
            // 
            rbLineWidthIn.AutoSize = true;
            rbLineWidthIn.Location = new Point(65, 48);
            rbLineWidthIn.Name = "rbLineWidthIn";
            rbLineWidthIn.Size = new Size(35, 19);
            rbLineWidthIn.TabIndex = 30;
            rbLineWidthIn.Text = "in";
            rbLineWidthIn.UseVisualStyleBackColor = true;
            rbLineWidthIn.CheckedChanged += rbLineWidthIn_CheckedChanged;
            // 
            // nudLineWidth
            // 
            nudLineWidth.Anchor = AnchorStyles.Right;
            nudLineWidth.AutoSize = true;
            nudLineWidth.DecimalPlaces = 2;
            nudLineWidth.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            nudLineWidth.Location = new Point(3, 33);
            nudLineWidth.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            nudLineWidth.Name = "nudLineWidth";
            tlpLineWidth.SetRowSpan(nudLineWidth, 2);
            nudLineWidth.Size = new Size(56, 23);
            nudLineWidth.TabIndex = 28;
            nudLineWidth.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            nudLineWidth.ValueChanged += nudLineWidth_ValueChanged;
            // 
            // rbLineWidthMM
            // 
            rbLineWidthMM.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            rbLineWidthMM.AutoSize = true;
            rbLineWidthMM.Checked = true;
            rbLineWidthMM.Location = new Point(65, 23);
            rbLineWidthMM.Name = "rbLineWidthMM";
            rbLineWidthMM.Size = new Size(47, 19);
            rbLineWidthMM.TabIndex = 29;
            rbLineWidthMM.TabStop = true;
            rbLineWidthMM.Text = "mm";
            rbLineWidthMM.UseVisualStyleBackColor = true;
            rbLineWidthMM.CheckedChanged += rbLineWidthMM_CheckedChanged;
            // 
            // Label12
            // 
            Label12.AutoSize = true;
            tlpLineWidth.SetColumnSpan(Label12, 2);
            Label12.Location = new Point(3, 0);
            Label12.Name = "Label12";
            Label12.Size = new Size(61, 15);
            Label12.TabIndex = 27;
            Label12.Text = "LineWidth";
            // 
            // rbWebColor
            // 
            rbWebColor.Anchor = AnchorStyles.Left;
            rbWebColor.AutoSize = true;
            rbWebColor.Checked = true;
            rbWebColor.Location = new Point(3, 3);
            rbWebColor.Name = "rbWebColor";
            rbWebColor.Size = new Size(79, 19);
            rbWebColor.TabIndex = 12;
            rbWebColor.TabStop = true;
            rbWebColor.Text = "Web color";
            rbWebColor.UseVisualStyleBackColor = true;
            rbWebColor.CheckedChanged += rbWebColor_CheckedChanged;
            // 
            // rbRGB
            // 
            rbRGB.AutoSize = true;
            rbRGB.Location = new Point(139, 3);
            rbRGB.Name = "rbRGB";
            rbRGB.Size = new Size(47, 19);
            rbRGB.TabIndex = 15;
            rbRGB.TabStop = true;
            rbRGB.Text = "RGB";
            rbRGB.UseVisualStyleBackColor = true;
            rbRGB.CheckedChanged += rbRGB_CheckedChanged;
            // 
            // tlpRGB
            // 
            tlpRGB.AutoSize = true;
            tlpRGB.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpRGB.ColumnCount = 2;
            tlpRGB.ColumnStyles.Add(new ColumnStyle());
            tlpRGB.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpRGB.Controls.Add(Label11, 0, 3);
            tlpRGB.Controls.Add(Label4, 0, 0);
            tlpRGB.Controls.Add(tbHexColor, 1, 3);
            tlpRGB.Controls.Add(nudR, 1, 0);
            tlpRGB.Controls.Add(Label9, 0, 1);
            tlpRGB.Controls.Add(nudG, 1, 1);
            tlpRGB.Controls.Add(Label10, 0, 2);
            tlpRGB.Controls.Add(nudB, 1, 2);
            tlpRGB.Enabled = false;
            tlpRGB.Location = new Point(136, 25);
            tlpRGB.Margin = new Padding(0);
            tlpRGB.Name = "tlpRGB";
            tlpRGB.RowCount = 4;
            tlpRGB.RowStyles.Add(new RowStyle());
            tlpRGB.RowStyles.Add(new RowStyle());
            tlpRGB.RowStyles.Add(new RowStyle());
            tlpRGB.RowStyles.Add(new RowStyle());
            tlpRGB.Size = new Size(101, 116);
            tlpRGB.TabIndex = 17;
            // 
            // Label11
            // 
            Label11.Anchor = AnchorStyles.Right;
            Label11.AutoSize = true;
            Label11.Location = new Point(16, 94);
            Label11.Margin = new Padding(16, 0, 3, 0);
            Label11.Name = "Label11";
            Label11.Size = new Size(21, 15);
            Label11.TabIndex = 24;
            Label11.Text = "##";
            // 
            // Label4
            // 
            Label4.Anchor = AnchorStyles.Right;
            Label4.AutoSize = true;
            Label4.Location = new Point(20, 7);
            Label4.Name = "Label4";
            Label4.Size = new Size(17, 15);
            Label4.TabIndex = 17;
            Label4.Text = "R:";
            Label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbHexColor
            // 
            tbHexColor.Anchor = AnchorStyles.Left;
            tbHexColor.Location = new Point(43, 90);
            tbHexColor.MaxLength = 6;
            tbHexColor.Name = "tbHexColor";
            tbHexColor.Size = new Size(55, 23);
            tbHexColor.TabIndex = 25;
            tbHexColor.TextChanged += tbHexColor_TextChanged;
            // 
            // nudR
            // 
            nudR.AllowDrop = true;
            nudR.Anchor = AnchorStyles.Left;
            nudR.AutoSize = true;
            nudR.Location = new Point(43, 3);
            nudR.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudR.Name = "nudR";
            nudR.Size = new Size(41, 23);
            nudR.TabIndex = 18;
            nudR.Value = new decimal(new int[] { 255, 0, 0, 0 });
            nudR.ValueChanged += nudR_ValueChanged;
            // 
            // Label9
            // 
            Label9.Anchor = AnchorStyles.Right;
            Label9.AutoSize = true;
            Label9.Location = new Point(19, 36);
            Label9.Name = "Label9";
            Label9.Size = new Size(18, 15);
            Label9.TabIndex = 19;
            Label9.Text = "G:";
            Label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nudG
            // 
            nudG.Anchor = AnchorStyles.Left;
            nudG.AutoSize = true;
            nudG.Location = new Point(43, 32);
            nudG.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudG.Name = "nudG";
            nudG.Size = new Size(41, 23);
            nudG.TabIndex = 20;
            nudG.Value = new decimal(new int[] { 255, 0, 0, 0 });
            nudG.ValueChanged += nudG_ValueChanged;
            // 
            // Label10
            // 
            Label10.Anchor = AnchorStyles.Right;
            Label10.AutoSize = true;
            Label10.Location = new Point(20, 65);
            Label10.Name = "Label10";
            Label10.Size = new Size(17, 15);
            Label10.TabIndex = 21;
            Label10.Text = "B:";
            Label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nudB
            // 
            nudB.Anchor = AnchorStyles.Left;
            nudB.AutoSize = true;
            nudB.Location = new Point(43, 61);
            nudB.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudB.Name = "nudB";
            nudB.Size = new Size(41, 23);
            nudB.TabIndex = 22;
            nudB.Value = new decimal(new int[] { 255, 0, 0, 0 });
            nudB.ValueChanged += nudB_ValueChanged;
            // 
            // graphPaperControl1
            // 
            graphPaperControl1.BackColor = SystemColors.Window;
            graphPaperControl1.Dock = DockStyle.Fill;
            graphPaperControl1.Location = new Point(278, 3);
            graphPaperControl1.Name = "graphPaperControl1";
            graphPaperControl1.Size = new Size(519, 420);
            graphPaperControl1.TabIndex = 1;
            // 
            // Console
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tlpMain);
            Controls.Add(MenuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Console";
            Text = "Print graph paper";
            Load += Console_Load;
            MenuStrip1.ResumeLayout(false);
            MenuStrip1.PerformLayout();
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            tlpDetails.ResumeLayout(false);
            tlpDetails.PerformLayout();
            tlpShape.ResumeLayout(false);
            tlpShape.PerformLayout();
            tlpShapeSize.ResumeLayout(false);
            tlpShapeSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudShapeWidth).EndInit();
            gbGridlines.ResumeLayout(false);
            gbGridlines.PerformLayout();
            tlpGridLines.ResumeLayout(false);
            tlpGridLines.PerformLayout();
            TableLayoutPanel4.ResumeLayout(false);
            TableLayoutPanel4.PerformLayout();
            tlpLineWidth.ResumeLayout(false);
            tlpLineWidth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudLineWidth).EndInit();
            tlpRGB.ResumeLayout(false);
            tlpRGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudR).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudG).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal MenuStrip MenuStrip1;
        internal ToolStripMenuItem PrintingToolStripMenuItem;
        internal ToolStripMenuItem PrintToolStripMenuItem;
        internal ToolStripMenuItem PageSetupToolStripMenuItem;
        internal ToolStripMenuItem IgnorePageMarginsToolStripMenuItem;
        internal TableLayoutPanel tlpMain;
        internal TableLayoutPanel tlpDetails;
        internal TableLayoutPanel tlpShape;
        internal TableLayoutPanel tlpShapeSize;
        internal RadioButton rbShapeWidthIn;
        internal NumericUpDown nudShapeWidth;
        internal RadioButton rbShapeWidthMM;
        internal ListBox lbShape;
        internal Label Label1;
        internal Label Label5;
        internal GroupBox gbGridlines;
        internal TableLayoutPanel tlpGridLines;
        internal TableLayoutPanel TableLayoutPanel4;
        internal ComboBox cboxWebColor;
        internal TableLayoutPanel tlpLineWidth;
        internal RadioButton rbLineWidthIn;
        internal NumericUpDown nudLineWidth;
        internal RadioButton rbLineWidthMM;
        internal Label Label12;
        internal RadioButton rbWebColor;
        internal RadioButton rbRGB;
        internal TableLayoutPanel tlpRGB;
        internal Label Label11;
        internal Label Label4;
        internal TextBox tbHexColor;
        internal NumericUpDown nudR;
        internal Label Label9;
        internal NumericUpDown nudG;
        internal Label Label10;
        internal NumericUpDown nudB;
        private SharkInSeine.GraphPaperControl graphPaperControl1;
        private PageSetupDialog pageSetupDialog1;
    }
}
