Imports System.ComponentModel

Namespace SharkInSeine
    ''' <summary>
    ''' User or application settings stored in an XML file.
    ''' </summary>
    Public Class Settings
        Public FullPath As String
        Private Dataset As DataSet = New DataSet()

        ''' <summary>
        ''' ctor
        ''' </summary>
        ''' <param name="name">Name of the settings file. Will be written as [name].xml.</param>
        ''' <param name="path">Directory of the settings file.</param>
        Public Sub New(name As String, path As String)
            FullPath = System.IO.Path.Combine(path, name & ".xml")
            If System.IO.File.Exists(FullPath) Then
                Dataset.ReadXml(FullPath)
                For Each dt As DataTable In Dataset.Tables
                    Tables.Add(dt.TableName, dt)
                Next
            End If
        End Sub

#Region "DataTables"
        Private Tables As Dictionary(Of String, DataTable) = New Dictionary(Of String, DataTable)
        Private Sub AddTable(dt As DataTable)
            Dataset.Tables.Add(dt)
            Tables.Add(dt.TableName, dt)
        End Sub
        Private Function DataTableFromSection(section As String) As DataTable
            If Tables.ContainsKey(section) Then
                Return Tables(section)
            End If
            Return Nothing
        End Function
#End Region
#Region "GetValue"
        ''' <summary>
        ''' Retrieve the value of a string from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default is not specified in this call, a blank string is used as the default.</param>
        ''' <returns>The string value previously stored in Settings, or the default if none.</returns>
        ''' <exception cref="DuplicateNameException">Duplicate entry - more than one entry found in the same section with the same name.</exception>
        Public Function GetValueString(section As String, name As String, Optional def As String = "") As String
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Return drs(0)("Value").ToString()
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of a boolean from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, False Is used as the default.</param>
        ''' <returns>The boolean value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueBoolean(section As String, name As String, Optional def As Boolean = False) As Boolean
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As Boolean
                    If Boolean.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of a byte from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The byte value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueByte(section As String, name As String, Optional def As Byte = 0) As Byte
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As Byte
                    If Byte.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of an sbyte from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The sbyte value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueSByte(section As String, name As String, Optional def As SByte = 0) As SByte
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As SByte
                    If SByte.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of a char from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, '\0' is used as the default.</param>
        ''' <returns>The char value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueChar(section As String, name As String, Optional def As Char = "") As Char
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As Char
                    If Char.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of a short from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The short value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueShort(section As String, name As String, Optional def As Short = 0) As Short
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As Short
                    If Short.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of a ushort from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The ushort value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueUShort(section As String, name As String, Optional def As UShort = 0) As UShort
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As UShort
                    If UShort.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of an int from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The int value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueInt(section As String, name As String, Optional def As Integer = 0) As Integer
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As Integer
                    If Integer.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of a uint from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The uint value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueUInt(section As String, name As String, Optional def As UInteger = 0) As UInteger
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As UInteger
                    If UInteger.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of an Int16 from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The Int16 value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueInt16(section As String, name As String, Optional def As Int64 = 0) As Int64
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As Int16
                    If Int16.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of a UInt16 from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The UInt16 value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueUInt16(section As String, name As String, Optional def As UInt16 = 0) As UInt16
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As UInt16
                    If UInt16.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of an Int32 from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The Int32 value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueInt32(section As String, name As String, Optional def As Int32 = 0) As Int32
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As Int32
                    If Int32.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of a UInt32 from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The UInt32 value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueUInt32(section As String, name As String, Optional def As UInt32 = 0) As UInt32
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As UInt32
                    If UInt32.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of an Int64 from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The Int64 value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueInt64(section As String, name As String, Optional def As Int64 = 0) As Int64
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As Int64
                    If Int64.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of a UInt64 from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The UInt64 value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueUint64(section As String, name As String, Optional def As UInt64 = 0) As UInt64
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As UInt64
                    If UInt64.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of a long from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The long value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueLong(section As String, name As String, Optional def As Long = 0) As Long
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As Long
                    If Long.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of a ulong from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The ulong value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueULong(section As String, name As String, Optional def As ULong = 0) As ULong
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As ULong
                    If ULong.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of an decimal from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The decimal value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueDecimal(section As String, name As String, Optional def As UShort = 0) As Decimal
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As Decimal
                    If Decimal.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of an float from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The float value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueFloat(section As String, name As String, Optional def As Single = 0) As Single
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As Single
                    If Single.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of an double from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The double value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueDouble(section As String, name As String, Optional def As Double = 0) As Double
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As Double
                    If Double.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function

        ''' <summary>
        ''' Retrieve the value of an DateTime from Settings.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings. If the default Is Not specified in this call, 0 Is used as the default.</param>
        ''' <returns>The DateTime value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueDateTime(section As String, name As String, Optional def As DateTime = Nothing) As DateTime
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim result As DateTime
                    If DateTime.TryParse(drs(0)("Value").ToString(), result) Then
                        Return result
                    End If
                    Return def
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
            If def = Nothing Then
                Return DateTime.MinValue
            Else
                Return def
            End If
        End Function

        Public Function GetValueColor(section As String, name As String, Optional def As Color = Nothing) As Color
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return Nothing
                Case 1
                    Dim cs As String = drs(0)("Value").ToString()
                    Dim c As Color = Color.FromName(cs)
                    If c.ToArgb = 0 Then
                        c = Color.FromArgb(GetValueInt(section, name, 0))
                    End If
                    Return c
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
            Return def
        End Function

        ''' <summary>
        ''' Retrieve the value of an enum from Settings.
        ''' </summary>
        ''' <typeparam name="T">The type of the enum.</typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings.</param>
        ''' <returns>The enum value previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Function GetValueEnum(Of T)(section As String, name As String, def As T) As T
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Dim value As String = drs(0)("Value")
                    Dim result As Object = def
                    If GetType(T).GetCustomAttributes(GetType(System.FlagsAttribute), False).FirstOrDefault() Is Nothing Then
                        If [Enum].IsDefined(GetType(T), value) AndAlso [Enum].TryParse(GetType(T), value, result) AndAlso result <> Nothing Then
                            Return result
                        End If
                    Else
                        ' IsDefined doesn't work for [Flags] enums.
                        ' However if the string Is massaged into Split(',') then Trim(), each component can be parsed.
                        Dim parts As List(Of String) = New List(Of String)(value.Split(",").Select(Function(s) s.Trim()))
                        Dim sum As ULong

                        For i As Integer = 0 To parts.Count() - 1
                            If [Enum].IsDefined(GetType(T), parts(i)) AndAlso [Enum].TryParse(GetType(T), parts(i), result) Then
                                If result = Nothing Then
                                    Return def
                                End If
                                sum = sum Or CULng(result)
                            End If
                        Next
                        Dim newsum As Object = sum
                        Return CType(newsum, T)
                    End If
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
            Return def
        End Function

        ''' <summary>
        ''' Retrieve the value of an object from Settings.
        ''' </summary>
        ''' <typeparam name="T">The type of the object that has a TypeConverter for string.</typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="def">Default value if none specified in Settings.</param>
        ''' <returns>The object previously stored in Settings, Or the default if none.</returns>
        ''' <exception cref="DuplicateNameException"></exception>
        Function GetValueObject(Of T)(section As String, name As String, def As T) As T
            Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(T))
            If tc Is Nothing Then
                Throw New TypeConverterException($"GetValueObject: Type { GetType(T).ToString()} has no type converter.")
            End If
            If Not tc.CanConvertFrom(GetType(String)) Then
                Throw New TypeConverterException($"GetValueObject: Type { GetType(T).ToString()} cannot be converted from string.")
            End If

            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return def
            End If
            Dim drs As DataRow() = dt.Select($"Name = '{name}'")
            Select Case drs.Count()
                Case 0
                    Return def
                Case 1
                    Return CType(tc.ConvertFromString(drs(0)("Value").ToString()), T)
                Case Else
                    Throw New DuplicateNameException($"Duplicate entry {section}/{name}")
            End Select
        End Function
#End Region
#Region "GetList"
        ''' <summary>
        ''' Retrieve a list of an object that supports IConvertible And conversion to And from strings.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of objects of the specified type.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetList(Of T)(section As String, name As String) As IEnumerable(Of T)
            Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(T))
            If tc Is Nothing Then
                Throw New TypeConverterException($"GetValue: Type {GetType(T).ToString()} has no type converter.")
            End If
            If Not tc.CanConvertFrom(GetType(String)) Then
                Throw New TypeConverterException($"GetValue: Type {GetType(T).ToString()} cannot be converted from string.")
            End If

            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of T) = New List(Of T)
            Try
                For Each dr As DataRow In rows
                    list.Add(CType(tc.ConvertTo(dr("Value").ToString(), GetType(T)), T))
                Next
            Catch ex As Exception

            End Try
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of strings.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of strings.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListString(section As String, name As String) As IEnumerable(Of String)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim namelength As Integer = name.Length
            Dim list As List(Of String) = New List(Of String)
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            For Each dr As DataRow In rows
                list.Add(dr("Value").ToString())
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of bytes.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of bytes.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListByte(section As String, name As String) As IEnumerable(Of Byte)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of Byte) = New List(Of Byte)
            For Each dr As DataRow In rows
                list.Add(Byte.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of sbytes (signed bytes).
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of sbytes.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListSByte(section As String, name As String) As IEnumerable(Of SByte)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of SByte) = New List(Of SByte)
            For Each dr As DataRow In rows
                list.Add(SByte.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of char.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of char.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListChar(section As String, name As String) As IEnumerable(Of Char)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of Char) = New List(Of Char)
            For Each dr As DataRow In rows
                list.Add(Char.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of bool.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of bool.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListBoolean(section As String, name As String) As IEnumerable(Of Boolean)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of Boolean) = New List(Of Boolean)
            For Each dr As DataRow In rows
                list.Add(Boolean.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of short.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of short.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListShort(section As String, name As String) As IEnumerable(Of Short)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of Short) = New List(Of Short)
            For Each dr As DataRow In rows
                list.Add(Short.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of ushort.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of ushort.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListUShort(section As String, name As String) As IEnumerable(Of UShort)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of UShort) = New List(Of UShort)
            For Each dr As DataRow In rows
                list.Add(UShort.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of int.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of int.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListInteger(section As String, name As String) As IEnumerable(Of Integer)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of Integer) = New List(Of Integer)
            For Each dr As DataRow In rows
                list.Add(Integer.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of uint.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of uint.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListUInteger(section As String, name As String) As IEnumerable(Of UInteger)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of UInteger) = New List(Of UInteger)
            For Each dr As DataRow In rows
                list.Add(UInteger.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of Int16.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of Int16.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListInt16(section As String, name As String) As IEnumerable(Of Int16)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of Int16) = New List(Of Int16)
            For Each dr As DataRow In rows
                list.Add(Int16.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of UInt16.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of UInt16.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListUInt16(section As String, name As String) As IEnumerable(Of UInt16)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of UInt16) = New List(Of UInt16)
            For Each dr As DataRow In rows
                list.Add(UInt16.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of Int32.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of Int32.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListInt32(section As String, name As String) As IEnumerable(Of Int32)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of Int32) = New List(Of Int32)
            For Each dr As DataRow In rows
                list.Add(Int32.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of UInt32.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of UInt32.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListUInt32(section As String, name As String) As IEnumerable(Of UInt32)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of UInt32) = New List(Of UInt32)
            For Each dr As DataRow In rows
                list.Add(UInt32.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of Int64.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of Int64.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListInt64(section As String, name As String) As IEnumerable(Of Int64)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of Int64) = New List(Of Int64)
            For Each dr As DataRow In rows
                list.Add(Int64.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of UInt64.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of UInt64.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListUInt64(section As String, name As String) As IEnumerable(Of UInt64)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of UInt64) = New List(Of UInt64)
            For Each dr As DataRow In rows
                list.Add(UInt64.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of long.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of long.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListLong(section As String, name As String) As IEnumerable(Of Long)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of Long) = New List(Of Long)
            For Each dr As DataRow In rows
                list.Add(Long.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of ulong.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of ulong.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListULong(section As String, name As String) As IEnumerable(Of ULong)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of ULong) = New List(Of ULong)
            For Each dr As DataRow In rows
                list.Add(ULong.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of decimal.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of decimal.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListDecimal(section As String, name As String) As IEnumerable(Of Decimal)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of Decimal) = New List(Of Decimal)
            For Each dr As DataRow In rows
                list.Add(Decimal.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of float.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of float.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListSingle(section As String, name As String) As IEnumerable(Of Single)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of Single) = New List(Of Single)
            For Each dr As DataRow In rows
                list.Add(Single.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of double.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of double.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListDouble(section As String, name As String) As IEnumerable(Of Double)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of Double) = New List(Of Double)
            For Each dr As DataRow In rows
                list.Add(Double.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of DateTime.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of DateTime.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListDateTime(section As String, name As String) As IEnumerable(Of DateTime)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of DateTime) = New List(Of DateTime)
            For Each dr As DataRow In rows
                list.Add(DateTime.Parse(dr("Value").ToString()))
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of an Enum.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of the specified Enum.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListEnum(Of T)(section As String, name As String) As IEnumerable(Of T)
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))
            Dim list As List(Of T) = New List(Of T)
            Dim value As String
            Dim hasFlagsAttribute As Boolean = GetType(T).GetCustomAttributes(GetType(System.FlagsAttribute), False).Any()
            For Each dr As DataRow In rows
                value = dr("Value").ToString()
                If hasFlagsAttribute Then
                    Dim parts As List(Of String) = New List(Of String)(value.Split(",").Select(Function(s) s.Trim()))
                    Dim sum As ULong
                    Dim rslt As Object = Nothing

                    For i As Integer = 0 To parts.Count() - 1
                        If [Enum].IsDefined(GetType(T), parts(i)) AndAlso [Enum].TryParse(GetType(T), parts(i), rslt) Then
                            If rslt Is Nothing Then
                                sum = 0
                                Exit For
                            End If
                            sum = sum Or CULng(rslt)
                        Else
                            sum = 0
                        End If
                    Next
                    Dim newsum As Object = sum
                    list.Add(CType(newsum, T))
                Else
                    If [Enum].IsDefined(GetType(T), value) Then
                        list.Add(CType([Enum].Parse(GetType(T), value), T))
                    End If
                End If
            Next
            Return list
        End Function

        ''' <summary>
        ''' Retrieve a list of the specified type of object.
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of the specified type of object.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Function GetListObject(Of T)(section As String, name As String) As IEnumerable(Of T)
            Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(T))
            If tc Is Nothing Then
                Throw New TypeConverterException($"GetListObject: Type {GetType(T).ToString()} has no type converter.")
            End If
            If Not tc.CanConvertFrom(GetType(String)) Then
                Throw New TypeConverterException($"GetListObject: Type {GetType(T).ToString()} cannot be converted from string.")
            End If

            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                Return Nothing
            End If
            Dim result As Integer
            Dim namelength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(namelength), result)).
                OrderBy(Function(dr0) Integer.Parse(dr0("Name").ToString().Substring(namelength)))

            ' sanity check needs to be enforced: check for duplicate names

            Dim list As List(Of T) = New List(Of T)
            Dim value As String
            For Each dr As DataRow In rows
                value = dr("Value").ToString()
                list.Add(CType(tc.ConvertFromString(value), T))
            Next
            Return list
        End Function
#End Region
#Region "SetValue"
        ''' <summary>
        ''' Set the value of a singleton, creating it if necessary.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="value">New value of the setting.</param>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Sub SetValue(section As String, name As String, value As Object)
            Dim dt As DataTable = DataTableFromSection(section)
            Dim dr As DataRow = Nothing
            If dt Is Nothing Then
                dt = New DataTable(section)
                dt.Columns.Add(New DataColumn("Name", GetType(String)))
                dt.Columns.Add(New DataColumn("Value", GetType(Object)))
                AddTable(dt)
            Else
                Dim drs As DataRow() = dt.Select($"Name = '{name}'")
                Select Case drs.Count()
                    Case 0
                    Case 1
                        dr = drs(0)
                    Case Else
                        Throw New DuplicateNameException($"SetValue: Duplicate entry {section}/{name}")
                End Select
            End If
            If dr Is Nothing Then
                dr = dt.NewRow()
                dr("Name") = name
                dt.Rows.Add(dr)
            End If
            dr("Value") = value.ToString()
        End Sub

        Public Sub SetValueColor(section As String, name As String, value As Color)
            Dim dt As DataTable = DataTableFromSection(section)
            Dim dr As DataRow = Nothing
            If dt Is Nothing Then
                dt = New DataTable(section)
                dt.Columns.Add(New DataColumn("Name", GetType(String)))
                dt.Columns.Add(New DataColumn("Value", GetType(Object)))
                AddTable(dt)
            Else
                Dim drs As DataRow() = dt.Select($"Name = '{name}'")
                Select Case drs.Count()
                    Case 0
                    Case 1
                        dr = drs(0)
                    Case Else
                        Throw New DuplicateNameException($"SetValue: Duplicate entry {section}/{name}")
                End Select
            End If
            If dr Is Nothing Then
                dr = dt.NewRow()
                dr("Name") = name
                dt.Rows.Add(dr)
            End If
            If value.IsNamedColor Then
                dr("value") = value.Name
            Else
                dr("value") = value.ToArgb.ToString()
            End If
        End Sub

        ''' <summary>
        ''' Set the value of a single object that supports IEnumerable And conversion to And from string.
        ''' </summary>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <param name="value">New value of the setting.</param>
        ''' <exception cref="DuplicateNameException"></exception>
        Public Sub SetValueObject(Of T)(section As String, name As String, value As T)
            Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(T))
            If tc Is Nothing Then
                Throw New TypeConverterException($"GetListObject: Type {GetType(T).ToString()} has no type converter.")
            End If
            If Not tc.CanConvertTo(GetType(String)) Then
                Throw New TypeConverterException($"GetListObject: Type {GetType(T).ToString()} cannot be converted to string.")
            End If

            Dim dt As DataTable = DataTableFromSection(section)
            Dim dr As DataRow = Nothing
            If dt Is Nothing Then
                dt = New DataTable(section)
                dt.Columns.Add(New DataColumn("Name", GetType(String)))
                dt.Columns.Add(New DataColumn("Value", GetType(Object)))
                AddTable(dt)
            Else
                Dim drs As DataRow() = dt.Select($"Name = '{name}'")
                Select Case drs.Count()
                    Case 0
                    Case 1
                        dr = drs(0)
                    Case Else
                        Throw New DuplicateNameException($"SetValue: Duplicate entry {section}/{name}")
                End Select
            End If
            If dr Is Nothing Then
                dr = dt.NewRow()
                dr("Name") = name
                dt.Rows.Add(dr)
            End If
            dr("Value") = tc.ConvertToString(value)
        End Sub
#End Region
#Region "SetList"
        ''' <summary>
        ''' Create Or update a list of items of a specified type.
        ''' </summary>
        ''' <typeparam name="T">The type of objects to store in a list.</typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of objects of the specified type.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Sub SetList(Of T)(section As String, name As String, list As IEnumerable(Of T))
            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                dt = New DataTable(section)
                dt.Columns.Add(New DataColumn("Name", GetType(String)))
                dt.Columns.Add(New DataColumn("Value", GetType(Object)))
                AddTable(dt)
            End If
            Dim result As Integer
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(name.Length), result))
            If rows IsNot Nothing Then
                Dim currentRowCount As Integer = rows.Count()

                ' update existing rows
                For i As Integer = 0 To Math.Min(currentRowCount, list.Count()) - 1
                    rows(i)("Value") = list(i).ToString()
                Next

                ' add new rows
                Dim dr As DataRow
                For i As Integer = currentRowCount To list.Count() - 1
                    dr = dt.NewRow()
                    dr("Name") = name & i.ToString()
                    dr("Value") = list(i).ToString()
                    dt.Rows.Add(dr)
                Next

                ' delete extraneous rows
                While currentRowCount > list.Count()
                    currentRowCount -= 1
                    dt.Rows.Remove(rows(currentRowCount))
                End While
                dt.AcceptChanges()
            End If
        End Sub

        ''' <summary>
        ''' Create Or update a list of items of a specified type that supports IConvertible to And from string.
        ''' </summary>
        ''' <typeparam name="T">The type of objects to store in a list. Each entry will be represented by a string that the object uses to clone itself.</typeparam>
        ''' <param name="section">Main partition in the Settings.</param>
        ''' <param name="name">Name of the setting.</param>
        ''' <returns>A list of objects of the specified type.</returns>
        ''' <exception cref="TypeConverterException"></exception>
        Public Sub SetListObject(Of T)(section As String, name As String, list As IEnumerable(Of T))
            Dim tc As TypeConverter = TypeDescriptor.GetConverter(GetType(T))
            If tc Is Nothing Then
                Throw New TypeConverterException($"GetListObject: Type {GetType(T).ToString()} has no type converter.")
            End If
            If Not tc.CanConvertTo(GetType(String)) Then
                Throw New TypeConverterException($"GetListObject: Type {GetType(T).ToString()} cannot be converted to string.")
            End If

            Dim dt As DataTable = DataTableFromSection(section)
            If dt Is Nothing Then
                dt = New DataTable(section)
                dt.Columns.Add(New DataColumn("Name", GetType(String)))
                dt.Columns.Add(New DataColumn("Value", GetType(Object)))
                AddTable(dt)
            End If
            Dim result As Integer
            Dim nameLength As Integer = name.Length
            Dim rows As IEnumerable(Of DataRow) = dt.Select($"Name LIKE '{name}*'").
                Where(Function(dr0) Integer.TryParse(dr0("Name").ToString().Substring(nameLength), result))
            If rows IsNot Nothing Then
                Dim currentRowCount As Integer = rows.Count()

                ' update existing rows
                For i As Integer = 0 To Math.Min(currentRowCount, list.Count()) - 1
                    rows(i)("Value") = tc.ConvertToString(list(i))
                Next

                ' add new rows
                Dim dr As DataRow
                For i As Integer = currentRowCount To list.Count() - 1
                    dr = dt.NewRow()
                    dr("Name") = name & i.ToString()
                    dr("Value") = tc.ConvertToString(list(i))
                    dt.Rows.Add(dr)
                Next

                ' delete extraneous rows
                While (currentRowCount > list.Count())
                    currentRowCount -= 1
                    dt.Rows.Remove(rows(currentRowCount))
                End While
                dt.AcceptChanges()
            End If
        End Sub
#End Region

        ''' <summary>
        ''' Write all the Settings to the XML.
        ''' </summary>
        Public Sub Write()
            Dataset.WriteXml(FullPath, XmlWriteMode.WriteSchema)
        End Sub

        Public Class TypeConverterException
            Inherits Exception
            Public Sub New()
                MyBase.New()
            End Sub
            Public Sub New(Message As String)
                MyBase.New(Message)
            End Sub
            Public Sub New(Message As String, InnerException As Exception)
                MyBase.New(Message, InnerException)
            End Sub
        End Class

#Region "forms"
        ''' <summary>
        ''' Track a Form's position and size, and whether it's maximized, so that it can be restored upon restart.
        ''' Also tracks the positions of all SplitterControls.
        ''' </summary>
        ''' <param name="form">The Form to be tracked.</param>
        Public Sub AddForm(form As Form)
            Dim left As Integer = GetValueInt(form.Name, "left", form.Left)
            Dim top As Integer = GetValueInt(form.Name, "top", form.Top)
            Dim width, height As Integer
            Dim maximized As Boolean = GetValueBoolean(form.Name, "maximized", False)

            Select Case form.FormBorderStyle
                Case FormBorderStyle.Sizable, FormBorderStyle.SizableToolWindow
                    width = GetValueInt(form.Name, "width", form.Width)
                    height = GetValueInt(form.Name, "height", form.Height)
                Case Else
                    width = form.Width
                    height = form.Height
            End Select

            ' make sure the window title bar is visible
            Dim visible As Boolean = False
            Dim bounds As Rectangle
            Dim pt As Point = New Point(left, top)
            For Each s As Screen In Screen.AllScreens
                bounds = New Rectangle(s.Bounds.Left, s.Bounds.Top, s.Bounds.Width - SystemInformation.MenuHeight, s.Bounds.Height - SystemInformation.MenuHeight)
                If bounds.Contains(pt) Then
                    visible = True
                    Exit For
                End If
            Next
            If Not visible Then
                left = form.Left
                top = form.Top
            End If

            ' restore window size and position
            form.Left = left
            form.Top = top
            form.Width = width
            form.Height = height
            If maximized Then
                form.WindowState = FormWindowState.Maximized
            End If

            AddHandler form.Move, AddressOf Form_Move
            AddHandler form.Resize, AddressOf Form_Resize

            PrepareSplitContainers(form.Controls)
        End Sub

        Private Sub Form_Move(sender As Object, e As EventArgs)
            Dim form As Form = sender
            Select Case form.WindowState
                Case FormWindowState.Normal
                    SetValue(form.Name, "maximized", False)
                    SetValue(form.Name, "left", form.Left)
                    SetValue(form.Name, "top", form.Top)
                    Write()
                Case FormWindowState.Maximized
                    SetValue(form.Name, "maximized", True)
                    Write()
            End Select
        End Sub

        Private Sub Form_Resize(sender As Object, e As EventArgs)
            Dim form As Form = sender
            Select Case form.WindowState
                Case FormWindowState.Normal
                    SetValue(form.Name, "maximized", False)
                    SetValue(form.Name, "left", form.Left)
                    SetValue(form.Name, "top", form.Top)
                    SetValue(form.Name, "width", form.Width)
                    SetValue(form.Name, "height", form.Height)
                    Write()
                Case FormWindowState.Maximized
                    SetValue(form.Name, "maximized", True)
                    Write()
            End Select
        End Sub

        Private Sub PrepareSplitContainers(controls As Control.ControlCollection)
            For Each c As Control In controls
                If c.GetType = GetType(SplitContainer) Then
                    Dim sc As SplitContainer = c
                    AddHandler CType(sc.Panel1, Panel).VisibleChanged, AddressOf SplitContainerPanel_VisibleChanged
                    AddHandler CType(sc.Panel2, Panel).VisibleChanged, AddressOf SplitContainerPanel_VisibleChanged
                    AddHandler sc.SplitterMoving, AddressOf SplitContainer_SplitterMoving
                End If
                PrepareSplitContainers(c.Controls)
            Next
        End Sub

        Private Sub SplitContainerPanel_VisibleChanged(sender As Object, e As EventArgs)
            Dim sc As SplitContainer = (CType(sender, Panel)).Parent
            If sc IsNot Nothing Then
                Dim splitterDistance As Integer = GetValueInt(sc.ParentForm.Name, sc.Name, sc.SplitterDistance)
                If (sc.Orientation = Orientation.Horizontal AndAlso splitterDistance > sc.Height) OrElse (sc.Orientation = Orientation.Vertical AndAlso splitterDistance > sc.Width) Then
                    Dim timer As System.Windows.Forms.Timer = New Timer With {.Interval = 40, .Tag = sc, .Enabled = False}
                    AddHandler timer.Tick, AddressOf SplitterTimer_Elapsed
                    timer.Enabled = True    ' fixed
                Else
                    sc.SplitterDistance = GetValueInt(sc.ParentForm.Name, sc.Name, sc.SplitterDistance)
                End If
            End If
        End Sub

        Private Sub SplitterTimer_Elapsed(sender As Object, e As EventArgs)
            Dim timer As Timer = sender
            timer.Enabled = False
            RemoveHandler timer.Tick, AddressOf SplitterTimer_Elapsed

            Dim sc As SplitContainer = timer.Tag
            sc.SplitterDistance = GetValueInt(sc.ParentForm.Name, sc.Name, sc.SplitterDistance)

            timer.Dispose()
            timer = Nothing
        End Sub

        Private Sub SplitContainer_SplitterMoving(sender As Object, e As SplitterCancelEventArgs)
            Dim sc As SplitContainer = sender
            Dim SplitterDistance As Integer = Math.Max(e.SplitX, e.SplitY)
            SetValue(sc.ParentForm.Name, sc.Name, SplitterDistance)
            Write()
        End Sub
#End Region
    End Class
End Namespace
