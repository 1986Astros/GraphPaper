Imports System.Drawing.Drawing2D
Imports System.Reflection

Public Class Console
    Public Sub New()
        InitializeComponent()

        Dim path As String = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Shark In Seine")
        If Not System.IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If
        path = System.IO.Path.Combine(path, "Settings")
        If Not System.IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If
        Settings = New SharkInSeine.Settings("GraphPaper", path)

        ' add Enum items to the listbox
        lbShape.Items.Clear()
        For Each Shape As GraphPaper.Shapes In [Enum].GetValues(GetType(GraphPaper.Shapes))
            lbShape.Items.Add(Shape)
        Next
        lbShape.SelectedItem = Details.Shape
        GraphPaperControl1.Details = Details
        nudShapeWidth.Value = Details.ShapeWidth
        If Details.ShapeWidthUnits = GraphPaper.Units.Millimeters Then
            rbShapeWidthMM.Checked = True
        Else
            rbShapeWidthIn.Checked = True
        End If
        nudLineWidth.Value = Details.LineWidth
        If Details.LineWidthUnits = GraphPaper.Units.Millimeters Then
            rbLineWidthMM.Checked = True
        Else
            rbLineWidthIn.Checked = True
        End If

        Using g As Graphics = cboxWebColor.CreateGraphics()
            Dim ColorName As String
            Dim MaxWidth = 0
            For Each ColorName In System.Enum.GetNames(GetType(System.Drawing.KnownColor)).
            OrderBy(Function(kc) Color.FromName(kc).GetHue).
            ThenBy(Function(kc) Color.FromName(kc).GetSaturation).
            ThenBy(Function(kc) Color.FromName(kc).GetBrightness)
                Dim c As Color = Color.FromName(ColorName)
                If Not c.IsSystemColor AndAlso Not c.Equals(Color.Transparent) Then
                    cboxWebColor.Items.Add(c)
                    MaxWidth = Math.Max(MaxWidth, Math.Round(g.MeasureString(ColorName, cboxWebColor.Font).Width))
                End If
            Next
            cboxWebColor.DropDownWidth = MaxWidth + 35 + SystemInformation.VerticalScrollBarWidth
        End Using
        If Details.LineColor.IsKnownColor Then
            rbWebColor.Checked = True
            cboxWebColor.Enabled = True
            tlpRGB.Enabled = False
            cboxWebColor.SelectedItem = Details.LineColor
        Else
            rbRGB.Checked = True
            cboxWebColor.Enabled = False
            tlpRGB.Enabled = True
            cboxWebColor.SelectedItem = Color.Black
        End If
        tbHexColor.Text = Strings.Right(Details.LineColor.ToArgb.ToString("x"), 6)
        UpdateRGBFromHex()

        Initialized = True
    End Sub

    Private Details As GraphPaper = New GraphPaper
    Private Initialized As Boolean = False
    Private GridlineColor As Color

    Private Sub Console_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Settings.AddForm(Me)
    End Sub

    Private Sub lbShape_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbShape.SelectedIndexChanged
        If Initialized Then
            Details.Shape = lbShape.SelectedItems(0)
            GraphPaperControl1.Invalidate()
        End If
    End Sub

    Private Sub nudSize_ValueChanged(sender As Object, e As EventArgs) Handles nudShapeWidth.ValueChanged
        If Initialized Then
            Details.ShapeWidth = nudShapeWidth.Value
            GraphPaperControl1.Invalidate()
        End If
    End Sub

    Private Sub rbSizeMM_CheckedChanged(sender As Object, e As EventArgs) Handles rbShapeWidthMM.CheckedChanged
        If Initialized Then
            If rbShapeWidthMM.Checked Then
                Details.ShapeWidthUnits = GraphPaper.Units.Millimeters
                GraphPaperControl1.Invalidate()
            End If
        End If
    End Sub

    Private Sub rbSizeIn_CheckedChanged(sender As Object, e As EventArgs) Handles rbShapeWidthIn.CheckedChanged
        If Initialized Then
            If rbShapeWidthIn.Checked Then
                Details.ShapeWidthUnits = GraphPaper.Units.Inches
                GraphPaperControl1.Invalidate()
            End If
        End If
    End Sub

    Private Sub rbWebColor_CheckedChanged(sender As Object, e As EventArgs) Handles rbWebColor.CheckedChanged
        If Initialized Then
            If rbWebColor.Checked Then
                cboxWebColor.Enabled = True
                tlpRGB.Enabled = False
                If cboxWebColor.SelectedItem <> Nothing Then
                    Details.LineColor = cboxWebColor.SelectedItem
                Else
                    Details.LineColor = Color.Black
                    cboxWebColor.SelectedItem = Details.LineColor
                End If
                GraphPaperControl1.Invalidate()
            End If
        End If
    End Sub

    Private Sub cboxWebColor_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cboxWebColor.DrawItem
        If e.Index >= 0 Then
            Dim r As Rectangle
            Using gp As GraphicsPath = New GraphicsPath
                If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                    e.Graphics.FillRectangle(SystemBrushes.Menu, e.Bounds)
                ElseIf ((e.State And DrawItemState.Disabled) = DrawItemState.Disabled) Then
                    e.Graphics.FillRectangle(SystemBrushes.Control, e.Bounds)
                Else
                    e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds)
                End If
                r = New Rectangle(e.Bounds.Left + 5, e.Bounds.Top + 2, 20, e.Bounds.Height - 4)
                gp.AddRectangle(r)
                Using br As Brush = New SolidBrush(CType(cboxWebColor.Items(e.Index), Color))
                    e.Graphics.FillPath(br, gp)
                End Using
                e.Graphics.DrawPath(Pens.Black, gp)
            End Using
            r = New Rectangle(e.Bounds.Left + 30, e.Bounds.Top, e.Bounds.Width - 30, e.Bounds.Height)
            e.Graphics.DrawString(CType(cboxWebColor.Items(e.Index), Color).Name, e.Font, Brushes.Black, r, StringFormat.GenericDefault)
            If (e.State And DrawItemState.Focus) = DrawItemState.Focus Then
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds)
            End If
        Else
        End If
    End Sub

    Private Sub cboxWebColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxWebColor.SelectedIndexChanged
        If Initialized Then
            Details.LineColor = cboxWebColor.SelectedItem
            GraphPaperControl1.Invalidate()
        End If
    End Sub

    Private Sub rbRGB_CheckedChanged(sender As Object, e As EventArgs) Handles rbRGB.CheckedChanged
        If Initialized Then
            If rbRGB.Checked Then
                cboxWebColor.Enabled = False
                tlpRGB.Enabled = True
                Details.LineColor = GridlineColor
                GraphPaperControl1.Invalidate()
            End If
        End If
    End Sub

    Private ChangingHex As Boolean = False
    Private Sub nudR_ValueChanged(sender As Object, e As EventArgs) Handles nudR.ValueChanged, nudR.ValueChanged
        If Initialized Then
            UpdateHexFromRGB()
            GraphPaperControl1.Invalidate()
        End If
    End Sub

    Private Sub nudG_ValueChanged(sender As Object, e As EventArgs) Handles nudG.ValueChanged, nudG.ValueChanged
        If Initialized Then
            UpdateHexFromRGB()
            GraphPaperControl1.Invalidate()
        End If
    End Sub

    Private Sub nudB_ValueChanged(sender As Object, e As EventArgs) Handles nudB.ValueChanged, nudB.ValueChanged
        If Initialized Then
            UpdateHexFromRGB()
            GraphPaperControl1.Invalidate()
        End If
    End Sub

    Private Sub UpdateHexFromRGB()
        If Not ChangingHex Then
            ChangingHex = True
            tbHexColor.Text = (nudR.Value << 16 Or nudG.Value << 8 Or nudB.Value).ToString("x")
            GridlineColor = Details.LineColor
            GraphPaperControl1.Invalidate()
            ChangingHex = False
        End If
    End Sub

    Private Sub tbHexColor_TextChanged(sender As Object, e As EventArgs) Handles tbHexColor.TextChanged, tbHexColor.TextChanged
        If Initialized Then
            UpdateRGBFromHex()
        End If
    End Sub
    Private Sub UpdateRGBFromHex(Optional UpdateLineColor As Boolean = True)
        ChangingHex = True

        Dim s As String = tbHexColor.Text.Trim()
        Dim result As Integer
        Dim r, b, g As Integer
        Try
            result = Convert.ToInt32(0 & tbHexColor.Text, 16)
            r = (result And &HFF0000) >> 16
            g = (result And &HFF00) >> 8
            b = result And &HFF
        Catch ex As FormatException
            result = 0
            r = 0
            g = 0
            b = 0
        Catch ex As Exception
            result = 0
            r = 0
            g = 0
            b = 0
        End Try
        nudR.Value = r
        nudG.Value = g
        nudB.Value = b
        If UpdateLineColor Then
            Details.LineColor = Color.FromArgb(255, r, g, b)
        End If
        GraphPaperControl1.Invalidate()
        GridlineColor = Details.LineColor

        ChangingHex = False
    End Sub

    Private Sub nudLineWeight_ValueChanged(sender As Object, e As EventArgs) Handles nudLineWidth.ValueChanged
        If Initialized Then
            Details.LineWidth = nudLineWidth.Value
            GraphPaperControl1.Invalidate()
        End If
    End Sub

    Private Sub rbLineWeightMM_CheckedChanged(sender As Object, e As EventArgs) Handles rbLineWidthMM.CheckedChanged
        If Initialized Then
            If rbLineWidthMM.Checked Then
                Details.LineWidthUnits = GraphPaper.Units.Millimeters
                GraphPaperControl1.Invalidate()
            End If
        End If
    End Sub

    Private Sub rbLineWeightIn_CheckedChanged(sender As Object, e As EventArgs) Handles rbLineWidthIn.CheckedChanged
        If Initialized Then
            If rbLineWidthIn.Checked Then
                Details.LineWidthUnits = GraphPaper.Units.Inches
                GraphPaperControl1.Invalidate()
            End If
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        GraphPaperControl1.PrintWithDialog()
    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PageSetupToolStripMenuItem.Click
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub IgnorePageMarginsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IgnorePageMaringsToolStripMenuItem.Click
        UsePrintMargins = Not IgnorePageMaringsToolStripMenuItem.Checked
    End Sub
End Class
