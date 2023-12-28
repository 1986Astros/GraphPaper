Imports System.ComponentModel
Imports System.Reflection
Imports System.Runtime.CompilerServices

Public Class GraphPaper
    Const CatAppearance = "Appearance"
    Public Enum Shapes As ULong
        Circles
        Triangles
        Diamonds
        Squares
        Hexagons
    End Enum
    <DefaultValue(DefaultShape)>
    <Category(CatAppearance)>
    <Description("Shape of the grid drawn on the page.")>
    Public Property Shape As Shapes
        Get
            Return Settings.GetValueEnum(Of Shapes)("Main", "Shape", DefaultShape)
        End Get
        Set(value As Shapes)
            If Settings.GetValueEnum(Of Shapes)("Main", "Shape", DefaultShape) <> value Then
                Settings.SetValue("Main", "Shape", value)
                WriteSettings()
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Shape"))
            End If
        End Set
    End Property
    Private Const DefaultShape As Shapes = Shapes.Squares

    Public Enum Units
        Millimeters
        Inches
    End Enum
    <DefaultValue(DefaultLineWidth)>
    <Category(CatAppearance)>
    <Description("Width in mm or inches of the outlines and dividers.")>
    Public Property LineWidth As Single
        Get
            Return Settings.GetValueDouble("Main", "LineWidth", DefaultLineWidth)
        End Get
        Set(value As Single)
            If value <> LineWidth Then
                Settings.SetValue("Main", "LineWidth", value)
                WriteSettings()
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("LineWidth"))
            End If
        End Set
    End Property
    Private Const DefaultLineWidth = 0.25

    <DefaultValue(DefaultLineWidthUnits)>
    <Category(CatAppearance)>
    <Description("Units of measurement for line widths.")>
    Public Property LineWidthUnits As Units
        Get
            Return Settings.GetValueEnum(Of Units)("Main", "LineWidthUnits", DefaultLineWidthUnits)
        End Get
        Set(value As Units)
            If value <> LineWidthUnits Then
                Settings.SetValue("Main", "LineWidthUnits", value)
                WriteSettings()
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("LineWidthUnits"))
            End If
        End Set
    End Property
    Private Const DefaultLineWidthUnits As Units = Units.Millimeters

    ' shadow to change the default and description
    <DefaultValue(GetType(Color), DefaultLineColorOfGraphPaper)>
    <Category(CatAppearance)>
    <Description("Color of the gridlines.")>
    Public Property LineColor As Color
        Get
            Return Settings.GetValueColor("Main", "LineColor", Color.FromName(DefaultLineColorOfGraphPaper))
        End Get
        Set(value As Color)
            If Not value.Equals(LineColor) Then
                Settings.SetValueColor("Main", "LineColor", value)
                WriteSettings()
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("LineColor"))
            End If
        End Set
    End Property
    Protected Const DefaultLineColorOfGraphPaper As String = "LightBlue"

    <DefaultValue(DefaultShapeWidth)>
    <Category(CatAppearance)>
    <Description("Distance in mm or inches between gridlines.")>
    Public Property ShapeWidth As Single
        Get
            Return Settings.GetValueFloat("Main", "ShapeWidth", DefaultShapeWidth)
        End Get
        Set(value As Single)
            If value <> ShapeWidth Then
                Settings.SetValue("Main", "ShapeWidth", value)
                WriteSettings()
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("ShapeWidth"))
            End If
        End Set
    End Property
    Private Const DefaultShapeWidth As Single = 0.25!

    <DefaultValue(DefaultShapeWidthUnits)>
    <Category(CatAppearance)>
    <Description("Units of measurement for shape widths.")>
    Public Property ShapeWidthUnits As Units
        Get
            Return Settings.GetValueEnum(Of Units)("Main", "ShapeWidthUnits", DefaultShapeWidthUnits)
        End Get
        Set(value As Units)
            If value <> ShapeWidthUnits Then
                Settings.SetValue("Main", "ShapeWidthUnits", value)
                WriteSettings()
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("ShapeWidthUnits"))
                'NotifyPropertyChanged(value)
            End If
        End Set
    End Property
    Private Const DefaultShapeWidthUnits As Units = Units.Inches

    Public Class PropertyChangedEventArgs
        Inherits EventArgs

        Public Sub New(Name As String)
            Me.Name = Name
        End Sub

        Public ReadOnly Name As String
    End Class
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs)

End Class
