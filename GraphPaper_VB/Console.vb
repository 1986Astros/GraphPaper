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
        lbShape.Items.Add(GraphPaper.Shapes.Triangles)
        lbShape.Items.Add(GraphPaper.Shapes.Squares)
        lbShape.Items.Add(GraphPaper.Shapes.Diamonds)
        lbShape.Items.Add(GraphPaper.Shapes.Hexagons)
        lbShape.SelectedItem = Details.Shape
        GraphPaperControl1.Details = Details
        nudSize.Value = Details.ShapeWidth
        If Details.ShapeWidthUnits = GraphPaper.Units.Millimeters Then
            rbSizeMM.Checked = True
        Else
            rbSizeIn.Checked = True
        End If
        nudLineWeight.Value = Details.LineWidth
        If Details.LineWidthUnits = GraphPaper.Units.Millimeters Then
            rbLineWeightMM.Checked = True
        Else
            rbLineWeightIn.Checked = True
        End If

        Dim ColorName As String
        For Each ColorName In System.Enum.GetNames(GetType(System.Drawing.KnownColor)).
            OrderBy(Function(kc) Color.FromName(kc).GetHue).
            ThenBy(Function(kc) Color.FromName(kc).GetSaturation).
            ThenBy(Function(kc) Color.FromName(kc).GetBrightness)
            Dim Syscolor As Color = Color.FromName(ColorName)
            If Not Syscolor.IsSystemColor AndAlso Not Syscolor.Equals(Color.Transparent) Then
                cboxWebColor.Items.Add(Color.FromName(ColorName))
            End If
        Next
        If Details.LineColor.IsKnownColor Then
            rbWebColor.Checked = True
            cboxWebColor.SelectedItem = Details.LineColor
        Else
            rbRGB.Checked = True
        End If
        tbHexColor.Text = Strings.Right(Details.LineColor.ToArgb.ToString("x"), 6)

        Initialized = True
    End Sub

    Private Details As GraphPaper = New GraphPaper
    Private Initialized As Boolean = False

    Private Sub Console_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Settings.AddForm(Me)
    End Sub

    Private Sub lbShape_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbShape.SelectedIndexChanged
        If Initialized Then
            Details.Shape = lbShape.SelectedItems(0)
            GraphPaperControl1.Invalidate()
        End If
    End Sub

    Private Sub nudSize_ValueChanged(sender As Object, e As EventArgs) Handles nudSize.ValueChanged
        If Initialized Then
            Details.ShapeWidth = nudSize.Value
            GraphPaperControl1.Invalidate()
        End If
    End Sub

    Private Sub rbSizeMM_CheckedChanged(sender As Object, e As EventArgs) Handles rbSizeMM.CheckedChanged
        If Initialized Then
            If rbSizeMM.Checked Then
                Details.ShapeWidthUnits = GraphPaper.Units.Millimeters
                GraphPaperControl1.Invalidate()
            End If
        End If
    End Sub

    Private Sub rbSizeIn_CheckedChanged(sender As Object, e As EventArgs) Handles rbSizeIn.CheckedChanged
        If Initialized Then
            If rbSizeIn.Checked Then
                Details.ShapeWidthUnits = GraphPaper.Units.Inches
                GraphPaperControl1.Invalidate()
            End If
        End If
    End Sub

    Private Sub rbWebColor_CheckedChanged(sender As Object, e As EventArgs) Handles rbWebColor.CheckedChanged
        If Initialized Then
            If rbWebColor.Checked = rbRGB.Checked Then
                rbRGB.Checked = Not rbWebColor.Checked
                cboxWebColor.Enabled = True
                tlpRGB.Enabled = False
                tlpHex.Enabled = False
                GraphPaperControl1.Invalidate()
            End If
        End If
    End Sub

    Private Sub cboxWebColor_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cboxWebColor.DrawItem
        If e.Index >= 0 Then
            Dim r As Rectangle
            Using gp As GraphicsPath = New GraphicsPath
                r = New Rectangle(e.Bounds.Left + 5, e.Bounds.Top + 2, 20, e.Bounds.Height - 4)
                gp.AddRectangle(r)
                Using br As Brush = New SolidBrush(CType(cboxWebColor.Items(e.Index), Color))
                    e.Graphics.FillPath(br, gp)
                End Using
                e.Graphics.DrawPath(Pens.Black, gp)
            End Using
            r = New Rectangle(e.Bounds.Left + 30, e.Bounds.Top, e.Bounds.Width - 30, e.Bounds.Height)
            e.Graphics.DrawString(CType(cboxWebColor.Items(e.Index), Color).Name, e.Font, Brushes.Black, r, StringFormat.GenericDefault)
            If e.State = DrawItemState.Selected Then

            End If
            If e.State = DrawItemState.Focus Then

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
            If rbWebColor.Checked = rbRGB.Checked Then
                rbWebColor.Checked = Not rbRGB.Checked
                cboxWebColor.Enabled = False
                tlpRGB.Enabled = True
                tlpHex.Enabled = True
                GraphPaperControl1.Invalidate()
            End If
        End If
    End Sub

    Private ChangingHex As Boolean = False
    Private Sub nudR_ValueChanged(sender As Object, e As EventArgs) Handles nudR.ValueChanged
        If Initialized Then
            If Not ChangingHex Then
                tbHexColor.Text = (nudR.Value << 16 Or nudG.Value << 8 Or nudB.Value).ToString("x")
            End If
            GraphPaperControl1.Invalidate()
            panelRGB.Invalidate()
        End If
    End Sub

    Private Sub nudG_ValueChanged(sender As Object, e As EventArgs) Handles nudG.ValueChanged
        If Initialized Then
            GraphPaperControl1.Invalidate()
        End If
    End Sub

    Private Sub nudB_ValueChanged(sender As Object, e As EventArgs) Handles nudB.ValueChanged
        If Initialized Then
            GraphPaperControl1.Invalidate()
        End If
    End Sub

    Private Sub tbHexColor_TextChanged(sender As Object, e As EventArgs) Handles tbHexColor.TextChanged
        If Initialized Then
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
            End Try
            nudR.Value = r
            nudG.Value = g
            nudB.Value = b
            GraphPaperControl1.Invalidate()
            ChangingHex = False
            panelRGB.Invalidate()
        End If
    End Sub

    Private Sub nudLineWeight_ValueChanged(sender As Object, e As EventArgs) Handles nudLineWeight.ValueChanged
        If Initialized Then
            Details.LineWidth = nudLineWeight.Value
            GraphPaperControl1.Invalidate()
        End If
    End Sub

    Private Sub rbLineWeightMM_CheckedChanged(sender As Object, e As EventArgs) Handles rbLineWeightMM.CheckedChanged
        If Initialized Then
            If rbLineWeightMM.Checked Then
                Details.LineWidthUnits = GraphPaper.Units.Millimeters
                GraphPaperControl1.Invalidate()
            End If
        End If
    End Sub

    Private Sub rbLineWeightIn_CheckedChanged(sender As Object, e As EventArgs) Handles rbLineWeightIn.CheckedChanged
        If Initialized Then
            If rbLineWeightIn.Checked Then
                Details.LineWidthUnits = GraphPaper.Units.Inches
                GraphPaperControl1.Invalidate()
            End If
        End If
    End Sub

    Private Sub panelRGB_Paint(sender As Object, e As PaintEventArgs) Handles panelRGB.Paint
        ' paint the color specified by RGB
        Using brush As SolidBrush = New SolidBrush(Color.FromArgb(nudR.Value << 16 Or nudG.Value << 8 Or nudB.Value))
            e.Graphics.FillRectangle(brush, panelRGB.Bounds())
        End Using
    End Sub
End Class
