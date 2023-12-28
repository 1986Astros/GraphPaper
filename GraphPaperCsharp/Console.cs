using Microsoft.VisualBasic;
using SharkInSeine;
using SharkInSeine.Settings;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace GraphPaperCsharp
{
    public partial class Console : Form
    {
        public Console()
        {
            InitializeComponent();

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Shark In Seine");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, "Graph paper");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Globals.Settings = new SharkInSeine.Settings.Settings("GraphPaperCS", path);

            // add Enum items to the listbox
            lbShape.Items.Clear();  // text items inserted at design time
            foreach (GraphPaper.Shapes shape in Enum.GetValues(typeof(GraphPaper.Shapes)))
            {
                lbShape.Items.Add(shape);
            }
            lbShape.SelectedItem = Details.Shape;
            graphPaperControl1.Details = Details;
            nudShapeWidth.Value = (decimal)Details.ShapeWidth;
            if (Details.ShapeWidthUnits == GraphPaper.Units.Millimeters)
            {
                rbShapeWidthMM.Checked = true;
            }
            else
            {
                rbShapeWidthIn.Checked = true;
            }
            if (Details.LineWidthUnits == GraphPaper.Units.Millimeters)
            {
                rbLineWidthMM.Checked = true;
            }
            else
            {
                rbLineWidthIn.Checked = true;
            }

            using Graphics g = cboxWebColor.CreateGraphics();
            int MaxWidth = 0;
            foreach (string ColorName in Enum.GetNames(typeof(KnownColor)).
                OrderBy(kc => Color.FromName(kc).GetHue()).
                ThenBy(kc => Color.FromName(kc).GetSaturation()).
                ThenBy(kc => Color.FromName(kc).GetBrightness())
                )
            {
                Color c = Color.FromName(ColorName);
                if (!c.IsSystemColor && !c.Equals(Color.Transparent))
                {
                    cboxWebColor.Items.Add(c);
                    MaxWidth = Math.Max(MaxWidth, (int)Math.Round(g.MeasureString(ColorName, cboxWebColor.Font).Width));
                }
            }
            cboxWebColor.DropDownWidth = MaxWidth;
            if (Details.LineColor?.IsKnownColor ?? false)
            {
                rbWebColor.Checked = true;
                cboxWebColor.Enabled = true;
                tlpRGB.Enabled = false;
                cboxWebColor.SelectedItem = Details.LineColor;
            }
            else
            {
                rbRGB.Checked = true;
                cboxWebColor.Enabled = false;
                tlpRGB.Enabled = true;
                cboxWebColor.SelectedItem = Color.Black;
            }
            tbHexColor.Text = Strings.Right((Details.LineColor ?? Color.Black).ToArgb().ToString("x"), 6);
            UpdateRGBFromHex(false);
            IgnorePageMarginsToolStripMenuItem.Checked = !Globals.UsePrintMargins;

            Initialized = true;
        }

        private GraphPaper Details = new GraphPaper();
        private bool Initialized = false;
        private Color GridLineColor;

        private void Console_Load(object sender, EventArgs e)
        {
            Globals.Settings.AddForm(this);
        }

        private void lbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Initialized)
            {
                Details.Shape = (GraphPaper.Shapes)lbShape.SelectedItems[0];
                graphPaperControl1.Invalidate();
            }
        }

        private void nudShapeWidth_ValueChanged(object sender, EventArgs e)
        {
            if (Initialized)
            {
                Details.ShapeWidth = (float)nudShapeWidth.Value;
                graphPaperControl1.Invalidate();
            }
        }

        private void rbSizeMM_CheckedChanged(object sender, EventArgs e)
        {
            if (Initialized)
            {
                if (rbShapeWidthMM.Checked)
                {
                    Details.ShapeWidthUnits = GraphPaper.Units.Millimeters;
                    graphPaperControl1.Invalidate();
                }
            }
        }

        private void rbSizeIn_CheckedChanged(object sender, EventArgs e)
        {
            if (Initialized)
            {
                if (rbShapeWidthIn.Checked)
                {
                    Details.ShapeWidthUnits = GraphPaper.Units.Inches;
                    graphPaperControl1.Invalidate();
                }
            }
        }

        private void rbWebColor_CheckedChanged(object sender, EventArgs e)
        {
            if (Initialized)
            {
                if (rbWebColor.Checked)
                {
                    cboxWebColor.Enabled = true;
                    tlpRGB.Enabled = false;
                    if (cboxWebColor.SelectedItem != null)
                        Details.LineColor = (Color)cboxWebColor.SelectedItem;
                    else
                    {
                        Details.LineColor = Color.Black;
                        cboxWebColor.SelectedItem = Details.LineColor;
                    }
                    graphPaperControl1.Invalidate();
                }
            }
        }

        private void cboxWebColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Rectangle r;
                using GraphicsPath gp = new GraphicsPath();
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(SystemBrushes.Menu, e.Bounds);
                }
                else if ((e.State & DrawItemState.Disabled) == DrawItemState.Disabled)
                {
                    e.Graphics.FillRectangle(SystemBrushes.Control, e.Bounds);
                }
                else
                {
                    e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                }
                r = new Rectangle(e.Bounds.Left + 5, e.Bounds.Top + 2, 20, e.Bounds.Height - 4);
                gp.AddRectangle(r);
                using Brush br = new SolidBrush((Color)(cboxWebColor.Items[e.Index]));
                e.Graphics.FillPath(br, gp);
                e.Graphics.DrawPath(Pens.Black, gp);
                r = new Rectangle(e.Bounds.Left + 30, e.Bounds.Top, e.Bounds.Width - 30, e.Bounds.Height);
                e.Graphics.DrawString(((Color)cboxWebColor.Items[e.Index]).Name, e.Font ?? SystemFonts.DefaultFont, Brushes.Black, r, StringFormat.GenericDefault);
                if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                {
                    ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds);
                }
            }
        }

        private void cboxWebColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Initialized)
            {
                Details.LineColor = (Color)cboxWebColor.SelectedItem;
                graphPaperControl1.Invalidate();
            }
        }

        private void rbRGB_CheckedChanged(object sender, EventArgs e)
        {
            if (Initialized)
            {
                if (rbRGB.Checked)
                {
                    cboxWebColor.Enabled = false;
                    tlpRGB.Enabled = true;
                    Details.LineColor = GridLineColor;
                    graphPaperControl1.Invalidate();
                }
            }
        }

        private bool ChangingHex = false;

        private void nudR_ValueChanged(object sender, EventArgs e)
        {
            if (Initialized)
            {
                UpdateHexFromRGB();
                graphPaperControl1.Invalidate();
            }
        }

        private void nudG_ValueChanged(object sender, EventArgs e)
        {
            if (Initialized)
            {
                UpdateHexFromRGB();
                graphPaperControl1.Invalidate();
            }
        }

        private void nudB_ValueChanged(object sender, EventArgs e)
        {
            if (Initialized)
            {
                UpdateHexFromRGB();
                graphPaperControl1.Invalidate();
            }
        }

        private void UpdateHexFromRGB()
        {
            if (!ChangingHex)
            {
                ChangingHex = true;
                tbHexColor.Text = ((uint)nudR.Value << 16 | (uint)nudG.Value << 8 | (uint)nudB.Value).ToString("x");
                GridLineColor = Details.LineColor ?? Color.Black;
                graphPaperControl1.Invalidate();
                ChangingHex = false;
            }
        }
        private void tbHexColor_TextChanged(object sender, EventArgs e)
        {
            if (Initialized)
            {
                UpdateRGBFromHex();
            }
        }

        private void UpdateRGBFromHex(bool UpdateLineColor = true)
        {
            ChangingHex = true;

            string s = tbHexColor.Text.Trim();
            int result;
            int r, g, b;
            try
            {
                result = Convert.ToInt32(s, 16);
                r = (result & 0xFF0000) >> 16;
                g = (result & 0x00FF00) >> 8;
                b = (result & 0x0000FF);
            }
            catch (FormatException)
            {
                result = 0;
                r = 0;
                g = 0;
                b = 0;
            }
            catch
            {
                result = 0;
                r = 0;
                g = 0;
                b = 0;
            }
            nudR.Value = r;
            nudG.Value = g;
            nudB.Value = b;
            if (UpdateLineColor)
            {
                Details.LineColor = Color.FromArgb(255, r, g, b);
            }
            graphPaperControl1.Invalidate();
            GridLineColor = Details?.LineColor ?? Color.Black;

            ChangingHex = false;
        }

        private void nudLineWidth_ValueChanged(object sender, EventArgs e)
        {
            if (Initialized)
            {
                Details.LineWidth = (float)nudLineWidth.Value;
                graphPaperControl1.Invalidate();
            }
        }

        private void rbLineWidthMM_CheckedChanged(object sender, EventArgs e)
        {
            if (Initialized)
            {
                if (rbLineWidthMM.Checked)
                {
                    Details.LineWidthUnits = GraphPaper.Units.Millimeters;
                    graphPaperControl1.Invalidate();
                }
            }
        }

        private void rbLineWidthIn_CheckedChanged(object sender, EventArgs e)
        {
            if (Initialized)
            {
                if (rbLineWidthIn.Checked)
                {
                    Details.LineWidthUnits = GraphPaper.Units.Inches;
                    graphPaperControl1.Invalidate();
                }
            }
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphPaperControl1.PrintWithDialog();
        }

        private void PageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void IgnorePageMarginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.UsePrintMargins = IgnorePageMarginsToolStripMenuItem.Checked;
            IgnorePageMarginsToolStripMenuItem.Checked = !Globals.UsePrintMargins;
        }
    }
}
