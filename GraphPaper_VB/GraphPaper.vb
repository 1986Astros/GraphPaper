Imports System.ComponentModel
Imports System.Reflection
Imports System.Runtime.CompilerServices

Public Class GraphPaper
    Const CatAppearance = "Appearance"
    Public Enum Shapes As ULong
        Triangles = 1
        Diamonds
        Squares
        Hexagons
    End Enum
    <DefaultValue(DefaultShape)> <Category(CatAppearance)> <Description("Shape of the grid drawn on the page.")>
    Public Property Shape As Shapes
        Get
            'Return _shape
            'Return Shapes.Triangles
            Return Settings.GetValueEnum(Of Shapes)("Main", "Shape", DefaultShape)
        End Get
        Set(value As Shapes)
            _shape = value
            If Settings.GetValueEnum(Of Shapes)("Main", "Shape", DefaultShape) <> value Then
                Settings.SetValue("Main", "Shape", value)
                WriteSettings()
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Shape"))
                'NotifyPropertyChanged(value)
            End If
        End Set
    End Property
    Friend Const DefaultShape As Shapes = Shapes.Squares
    Private _shape As Shapes = DefaultShape

    Public Enum Units
        Millimeters
        Inches
    End Enum
    ' overload to change the description to include inches
    <DefaultValue(DefaultLineWidth)> <Category(CatAppearance)> <Description("Width in mm or inches of the outlines and dividers.")>
    Public Property LineWidth As Single
        Get
            Return Settings.GetValueDouble("Main", "LineWidth", DefaultLineWidth)
        End Get
        Set(value As Single)
            If value <> LineWidth Then
                Settings.SetValue("Main", "LineWidth", value)
                WriteSettings()
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("LineWidth"))
                'NotifyPropertyChanged(value)
            End If
        End Set
    End Property
    Private Const DefaultLineWidth = 0.25

    <DefaultValue(DefaultLineWidthUnits)> <Category(CatAppearance)> <Description("Units of measurement for line widths.")>
    Public Property LineWidthUnits As Units
        Get
            Return Settings.GetValueEnum(Of Units)("Main", "LineWidthUnits", DefaultLineWidthUnits)
        End Get
        Set(value As Units)
            If value <> LineWidthUnits Then
                Settings.SetValue("Main", "LineWidthUnits", value)
                WriteSettings()
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("LineWidthUnits"))
                'NotifyPropertyChanged(value)
            End If
        End Set
    End Property
    Friend Const DefaultLineWidthUnits As Units = Units.Millimeters

    ' shadow to change the default and description
    <DefaultValue(GetType(Color), DefaultLineColorOfGraphPaper)> <Category(CatAppearance)> <Description("Color of the gridlines.")>
    Public Property LineColor As Color
        Get
            Return Settings.GetValueObject("Main", "LineColor", Color.FromName(DefaultLineColorOfGraphPaper))
        End Get
        Set(value As Color)
            If Not value.Equals(LineColor) Then
                Settings.SetValue("Main", "LineColor", value)
                WriteSettings()
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("LineColor"))
                'NotifyPropertyChanged(value)
            End If
        End Set
    End Property
    Protected Const DefaultLineColorOfGraphPaper As String = "LightBlue"

    <DefaultValue(DefaultShapeWidth)> <Category(CatAppearance)> <Description("Distance in mm or inches between gridlines.")>
    Public Property ShapeWidth As Single
        Get
            Return Settings.GetValueFloat("Main", "ShapeWidth", DefaultShapeWidth)
        End Get
        Set(value As Single)
            If value <> ShapeWidth Then
                Settings.SetValue("Main", "ShapeWidth", value)
                WriteSettings()
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("ShapeWidth"))
                'NotifyPropertyChanged(value)
            End If
        End Set
    End Property
    Friend Const DefaultShapeWidth As Single = 0.25!

    <DefaultValue(DefaultShapeWidthUnits)> <Category(CatAppearance)> <Description("Units of measurement for shape widths.")>
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
    Friend Const DefaultShapeWidthUnits As Units = Units.Inches

    Public Parent As Object = Nothing

    ''' <summary>
    ''' Bubble change to the inherting Class.
    ''' </summary>
    ''' <param name="NewValue">New value of this Property.</param>
    ''' <param name="propertyName">If named Property does not exist in inherting class, this Sub does nothing.</param>
    'Protected Sub NotifyPropertyChanged(NewValue As Object, <CallerMemberName()> Optional ByVal propertyName As String = Nothing, Optional Index As Object = Nothing)
    '    If Parent IsNot Nothing Then
    '        Dim pi As PropertyInfo = Parent.GetType().GetProperty(propertyName)
    '        If pi IsNot Nothing Then
    '            If Index Is Nothing Then
    '                Parent.GetType.InvokeMember(propertyName, BindingFlags.SetProperty, Nothing, Parent, New Object() {NewValue})
    '            Else
    '                Parent.GetType.InvokeMember(propertyName, BindingFlags.SetProperty, Nothing, Parent, New Object() {Index, NewValue})
    '            End If
    '        Else
    '            ' Uncomment the line below to help debugging; this could be on purpose and if done on purpose, should not be reported.
    '            'Trace.WriteLine($"MontessoriInfo.NotifyPropertyChanged: Unknown Field or Property ""{propertyName}"".")
    '        End If
    '    End If
    'End Sub

    'Private Sub Write()
    '    If Not DesignMode Then
    '        Settings.Write()
    '    End If
    'End Sub
    Public Class PropertyChangedEventArgs
        Inherits EventArgs

        Public Sub New(Name As String)
            Me.Name = Name
        End Sub

        Public ReadOnly Name As String
    End Class
    Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs)

End Class
