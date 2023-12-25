using System.ComponentModel;
using System.Data;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;
using System.Linq;

namespace SharkInSeine
{
    namespace Settings
    {
        /// <summary>
        /// User or application settings stored in an XML file.
        /// </summary>
        public class Settings
        {
            public string FullPath;
            private DataSet Dataset = new DataSet();
            /// <summary>
            /// ctor
            /// </summary>
            /// <param name="name">Name of the settings file. Will be written as [name].xml.</param>
            /// <param name="path">Directory of the settings file.</param>
            public Settings(string name, string path)
            {
                FullPath = System.IO.Path.Combine(path, name + ".xml");
                if (System.IO.File.Exists(FullPath))
                {
                    Dataset.ReadXml(FullPath);
                    foreach (DataTable dt in Dataset.Tables)
                    {
                        Tables.Add(dt.TableName, dt);
                    }
                }
            }

            #region "DataTables"
            Dictionary<string, DataTable> Tables = new Dictionary<string, DataTable>();
            private void AddTable(DataTable dt)
            {
                Dataset.Tables.Add(dt);
                Tables.Add(dt.TableName, dt);
            }
            private DataTable? DataTableFromSection(string section)
            {
                if (Tables.ContainsKey(section))
                    return Tables[section];
                return null;
            }
            #endregion
            #region "GetValue"
            /// <summary>
            /// Retrieve the value of a string from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, a blank string is used as the default.</param>
            /// <returns>The string value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException">Duplicate entry - more than one entry found in the same section with the same name.</exception>
            public string GetValueString(string section, string name, string def = "")
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        return drs[0]["Value"].ToString() ?? def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }
            /// <summary>
            /// Retrieve the value of a boolean from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, False is used as the default.</param>
            /// <returns>The boolean value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public bool GetValueBoolean(string section, string name, bool def = false)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            bool result;
                            if (bool.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of a byte from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The byte value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public byte GetValueByte(string section, string name, byte def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            byte result;
                            if (byte.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of an sbyte from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The sbyte value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public sbyte GetValueSByte(string section, string name, sbyte def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            sbyte result;
                            if (sbyte.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of a char from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, '\0' is used as the default.</param>
            /// <returns>The char value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public char GetValueChar(string section, string name, char def = '\0')
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            char result;
                            if (char.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of a short from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The short value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public short GetValueShort(string section, string name, short def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            short result;
                            if (short.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of a ushort from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The ushort value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public ushort GetValueUShort(string section, string name, ushort def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            ushort result;
                            if (ushort.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of an int from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The int value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public int GetValueInt(string section, string name, int def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            int result;
                            if (int.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of a uint from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The uint value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public uint GetValueUInt(string section, string name, uint def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            uint result;
                            if (uint.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of an Int16 from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The Int16 value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public Int16 GetValueInt16(string section, string name, Int16 def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            Int16 result;
                            if (Int16.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }
            /// <summary>
            /// Retrieve the value of a UInt16 from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The UInt16 value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public UInt16 GetValueUInt16(string section, string name, UInt16 def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            UInt16 result;
                            if (UInt16.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of an Int32 from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The Int32 value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public Int32 GetValueInt32(string section, string name, Int32 def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            Int32 result;
                            if (Int32.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }
            /// <summary>
            /// Retrieve the value of a UInt32 from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The UInt32 value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public UInt32 GetValueUInt32(string section, string name, UInt32 def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            UInt32 result;
                            if (UInt32.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of an Int64 from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The Int64 value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public Int64 GetValueInt64(string section, string name, Int64 def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            Int64 result;
                            if (Int64.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of a UInt64 from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The UInt64 value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public UInt64 GetValueUInt64(string section, string name, UInt64 def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            UInt64 result;
                            if (UInt64.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of a long from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The long value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public long GetValueLong(string section, string name, long def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            long result;
                            if (long.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of a ulong from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The ulong value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public ulong GetValueULong(string section, string name, ulong def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            ulong result;
                            if (ulong.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of an decimal from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The decimal value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public decimal GetValueDecimal(string section, string name, decimal def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            decimal result;
                            if (decimal.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of an float from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The float value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public float GetValueFloat(string section, string name, float def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            float result;
                            if (float.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of an double from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The double value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public double GetValueDouble(string section, string name, double def = 0)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            double result;
                            if (double.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of an DateTime from Settings.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings. If the default is not specified in this call, 0 is used as the default.</param>
            /// <returns>The DateTime value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public DateTime? GetValueDateTime(string section, string name, DateTime? def = null)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        break;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            DateTime result;
                            if (DateTime.TryParse(dr["Value"].ToString(), out result))
                                return result;
                        }
                        break;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
                return def ?? DateTime.MinValue;
            }

        /// <summary>
        /// Retrieve the value of a Color from Settings.
        /// </summary>
        /// <param name="section">Main partition in the Settings.</param>
        /// <param name="name">Name of the setting.</param>
        /// <param name="def">Default value if none specified in Settings.</param>
        /// <returns>The Color value previously stored in Settings, or the default if none.</returns>
        /// <exception cref="DuplicateNameException"></exception>
            public Color? GetValueColor(string section, string name, Color? def = null)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        break;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            string cs = dr["Value"].ToString();
                            Color c = Color.FromName(cs);
                            if (c.ToArgb() == 0)
                            {
                                c = Color.FromArgb(GetValueInt(section, name, 0));
                            }
                            return c;
                        }
                        break;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
                return def;
            }

            /// <summary>
            /// Retrieve the value of an enum from Settings.
            /// </summary>
            /// <typeparam name="T">The type of the enum.</typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings.</param>
            /// <returns>The enum value previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public T GetValueEnum<T>(string section, string name, T def)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        DataRow dr = drs[0];
                        if (dr["Value"] != null)
                        {
                            string? value = dr["Value"].ToString();
                            if (value != null)
                            {
                                object? result = def;
                                if (typeof(T).GetCustomAttributes(typeof(System.FlagsAttribute), false).FirstOrDefault() == null)
                                {
                                    if (Enum.IsDefined(typeof(T), value ?? "") && Enum.TryParse(typeof(T), value, out result) && result != null)
                                        return (T)result;
                                }
                                else
                                {
                                    /*
                                     * IsDefined doesn't work for [Flags] enums.
                                     * However if the string is massaged into Split(',') then Trim(), each component can be parsed.
                                     */
                                    List<string> parts = new List<string>(value.Split(',').Select(s => s.Trim()));
                                    int sum = 0; // BUG: Should this be ULong?)

                                    for (int i = 0; i < parts.Count(); i++)
                                    {
                                        if (Enum.IsDefined(typeof(T), parts[i]) && Enum.TryParse(typeof(T), parts[i], out result))
                                        {
                                            if (result == null)
                                                return def;
                                            sum += (int)result; // BUG: Should this be |= with ULong?
                                        }
                                        else
                                            return def;
                                    }
                                    object? newsum = sum;
                                    return (T)newsum;
                                }
                            }
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }

            /// <summary>
            /// Retrieve the value of an object from Settings.
            /// </summary>
            /// <typeparam name="T">The type of the object that has a TypeConverter for string.</typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="def">Default value if none specified in Settings.</param>
            /// <returns>The object previously stored in Settings, or the default if none.</returns>
            /// <exception cref="DuplicateNameException"></exception>
            public T? GetValueObject<T>(string section, string name, T? def)
            {
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
                if (tc == null)
                    throw new TypeConverterException($"GetValueObject: Type {typeof(T).ToString()} has no type converter.");
                if (!tc.CanConvertFrom(typeof(string)))
                    throw new TypeConverterException($"GetValueObject: Type {typeof(T).ToString()} cannot be converted from string.");

                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return def;
                DataRow[] drs = dt.Select($"Name = \'{name}\'");
                switch (drs.Count())
                {
                    case 0:
                        return def;
                    case 1:
                        if (drs != null)
                        {
                            return (T)tc.ConvertFromString(drs[0]["Value"].ToString());
                        }
                        return def;
                    default:
                        throw new DuplicateNameException($"Duplicate entry {section}/{name}");
                }
            }
            #endregion
            #region "GetList"
            /// <summary>
            /// Retrieve a list of an object that supports IConvertible and conversion to and from strings.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of objects of the specified type.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<T>? GetList<T>(string section, string name)
            {
                TypeConverter? tc = TypeDescriptor.GetConverter(typeof(T));
                if (tc == null)
                    throw new TypeConverterException($"GetValue: Type {typeof(T).ToString()} has no type converter.");
                if (!tc.CanConvertFrom(null, typeof(string)))
                    throw new TypeConverterException($"GetValue: Type {typeof(T).ToString()} cannot be converted from string.");

                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<T> list = new List<T>();
                try
                {
                    foreach (DataRow dr in rows)
                    {
                        list.Add((T?)tc.ConvertTo(dr["Value"].ToString(), typeof(T)));
                    }
                }
                catch
                {
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of strings.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of strings.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<string>? GetListString(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int namelength = name.Length;
                List<string> list = new List<string>();
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                foreach (DataRow dr in rows)
                {
                    list.Add(dr["Value"].ToString() ?? "");
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of bytes.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of bytes.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<byte>? GetListByte(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<byte> list = new List<byte>();
                foreach (DataRow dr in rows)
                {
                    list.Add(byte.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of sbytes (signed bytes).
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of sbytes.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<sbyte>? GetListSByte(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<sbyte> list = new List<sbyte>();
                foreach (DataRow dr in rows)
                {
                    list.Add(sbyte.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of char.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of char.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<char>? GetListChar(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<char> list = new List<char>();
                foreach (DataRow dr in rows)
                {
                    list.Add(char.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of bool.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of bool.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<bool>? GetListBoolean(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<bool> list = new List<bool>();
                foreach (DataRow dr in rows)
                {
                    list.Add(bool.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of short.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of short.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<short>? GetListShort(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<short> list = new List<short>();
                foreach (DataRow dr in rows)
                {
                    list.Add(short.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of ushort.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of ushort.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<ushort>? GetListUShort(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<ushort> list = new List<ushort>();
                foreach (DataRow dr in rows)
                {
                    list.Add(ushort.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of int.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of int.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<int>? GetListInt(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<int> list = new List<int>();
                foreach (DataRow dr in rows)
                {
                    list.Add(int.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of uint.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of uint.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<uint>? GetListUInt(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<uint> list = new List<uint>();
                foreach (DataRow dr in rows)
                {
                    list.Add(uint.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of Int16.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of Int16.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<Int16>? GetListInt16(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<Int16> list = new List<Int16>();
                foreach (DataRow dr in rows)
                {
                    list.Add(Int16.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of UInt16.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of UInt16.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<UInt16>? GetListUInt16(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<UInt16> list = new List<UInt16>();
                foreach (DataRow dr in rows)
                {
                    list.Add(UInt16.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of Int32.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of Int32.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<Int32>? GetListInt32(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<Int32> list = new List<Int32>();
                foreach (DataRow dr in rows)
                {
                    list.Add(Int32.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of UInt32.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of UInt32.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<UInt32>? GetListUInt32(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<UInt32> list = new List<UInt32>();
                foreach (DataRow dr in rows)
                {
                    list.Add(UInt32.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of Int64.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of Int64.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<Int64>? GetListInt64(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<Int64> list = new List<Int64>();
                foreach (DataRow dr in rows)
                {
                    list.Add(Int64.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of UInt64.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of UInt64.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<UInt64>? GetListUInt64(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<UInt64> list = new List<UInt64>();
                foreach (DataRow dr in rows)
                {
                    list.Add(UInt64.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of long.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of long.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<long>? GetListLong(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<long> list = new List<long>();
                foreach (DataRow dr in rows)
                {
                    list.Add(long.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of ulong.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of ulong.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<ulong>? GetListULong(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<ulong> list = new List<ulong>();
                foreach (DataRow dr in rows)
                {
                    list.Add(ulong.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of decimal.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of decimal.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<decimal>? GetListDecimal(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<decimal> list = new List<decimal>();
                foreach (DataRow dr in rows)
                {
                    list.Add(decimal.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of float.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of float.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<float>? GetListFloat(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<float> list = new List<float>();
                foreach (DataRow dr in rows)
                {
                    list.Add(float.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of double.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of double.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<double>? GetListDouble(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<double> list = new List<double>();
                foreach (DataRow dr in rows)
                {
                    list.Add(double.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of DateTime.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of DateTime.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<DateTime>? GetListDateTime(string section, string name, DateTime? def = null)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<DateTime> list = new List<DateTime>();
                foreach (DataRow dr in rows)
                {
                    list.Add(DateTime.Parse(dr["Value"].ToString() ?? ""));
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of Color.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of Color.</returns>
            public IEnumerable<Color>? GetListColor(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<Color> list = new List<Color>();
                foreach (DataRow dr in rows)
                {
                    Color c = Color.FromName(dr["Value"].ToString());
                    if (c.ToArgb () == 0)
                    {
                        list.Add(Color.FromArgb(GetValueInt(section, dr["Name"].ToString(), 0)));
                    }
                    else
                    {
                        list.Add(c);
                    }
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of an Enum.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of the specified Enum.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<T>? GetListEnum<T>(string section, string name)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));
                List<T> list = new List<T>();
                string value;
                bool hasFlagsAttribute  = typeof(T).GetCustomAttributes(typeof(FlagsAttribute), false).Any();
                foreach (DataRow dr in rows)
                {
                    value = dr["Value"].ToString() ?? "";
                    if (hasFlagsAttribute)
                    {
                        List<string> parts = new List<string>(value.Split(',').Select(s => s.Trim()));
                        int sum = 0;    // BUG: Should this be ULong?
                        object? rslt = 0;

                        for (int i = 0; i < parts.Count(); i++)
                        {
                            if (Enum.IsDefined(typeof(T), parts[i]) && Enum.TryParse(typeof(T), parts[i], out rslt))
                            {
                                if (rslt == null)
                                {
                                    sum = 0;
                                    break;
                                }
                                sum += (int)rslt;   // BUG: Should this be bitwise OR and ULong?
                            }
                            else 
                                sum = 0;
                        }
                        object? newsum = sum;
                        list.Add((T)newsum);
                    }
                    else
                    {
                        if (Enum.IsDefined(typeof(T), value))
                        {
                            list.Add((T)Enum.Parse(typeof(T), value));
                        }
                    }
                }
                return list;
            }

            /// <summary>
            /// Retrieve a list of the specified type of object.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of the specified type of object.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public IEnumerable<T>? GetListObject<T>(string section, string name)
            {
                TypeConverter? tc = TypeDescriptor.GetConverter(typeof(T));
                if (tc == null)
                    throw new TypeConverterException($"GetListObject: Type {typeof(T).ToString()} has no type converter.");
                if (!tc.CanConvertFrom(null, typeof(string)))
                    throw new TypeConverterException($"GetListObject: Type {typeof(T).ToString()} cannot be converted from string.");

                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                    return null;
                int result;
                int namelength = name.Length;
                IEnumerable<DataRow> rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(namelength), out result)).
                    OrderBy(dr0 => int.Parse((dr0["Name"].ToString() ?? "").Substring(namelength)));

                // sanity check needs to be enforced: check for duplicate names and throw exception for them

                List<T> list = new List<T>();
                string value;
                foreach (DataRow dr in rows)
                {
                    value = dr["Value"].ToString() ?? "";
                    list.Add((T)tc.ConvertFromString(value));
                }
                return list;
            }
            #endregion
            #region "SetValue"
            /// <summary>
            /// Set the value of a singleton, creating it if necessary.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="value">New value of the setting.</param>
            /// <exception cref="DuplicateNameException"></exception>
            public void SetValue(string section, string name, object value)
            {
                DataTable? dt = DataTableFromSection(section);
                DataRow? dr = null;
                if (dt == null)
                {
                    dt = new DataTable(section);
                    dt.Columns.Add(new DataColumn("Name", typeof(string)));
                    dt.Columns.Add(new DataColumn("Value", typeof(object)));
                    AddTable(dt);
                }
                else
                {
                    DataRow[] drs = dt.Select($"Name = \'{name}\'");
                    switch (drs.Count())
                    {
                        case 0:
                            break;
                        case 1:
                            dr = drs[0];
                            break;
                        default:
                            throw new DuplicateNameException($"SetValue: Duplicate entry {section}/{name}");
                    }
                }
                if (dr == null)
                {
                    dr = dt.NewRow();
                    dr["Name"] = name;
                    dt.Rows.Add(dr);
                }
                dr["Value"] = value.ToString();
            }

            /// <summary>
            /// Set the value of a single Color, creating it if necessary.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="value">New value of the setting.</param>
            /// <exception cref="DuplicateNameException"></exception>
            public void SetValueColor(string section, string name, Color value )
            {
                DataTable? dt = DataTableFromSection(section);
                DataRow? dr = null;
                if (dt == null)
                {
                    dt = new DataTable(section);
                    dt.Columns.Add(new DataColumn("Name", typeof(string)));
                    dt.Columns.Add(new DataColumn("Value", typeof(object)));
                    AddTable(dt);
                }
                else
                {
                    DataRow[] drs = dt.Select($"Name = \'{name}\'");
                    switch (drs.Count())
                    {
                        case 0:
                            break;
                        case 1:
                            dr = drs[0];
                            break;
                        default:
                            throw new DuplicateNameException($"SetValue: Duplicate entry {section}/{name}");
                    }
                }
                if (dr == null)
                {
                    dr = dt.NewRow();
                    dr["Name"] = name;
                    dt.Rows.Add(dr);
                }
                if (value.IsNamedColor)
                {
                    dr["Value"] = value.Name;
                }
                else
                {
                    dr["Value"] = value.ToArgb().ToString();
                }
            }

            /// <summary>
            /// Set the value of a single object that supports IEnumerable and conversion to and from string.
            /// </summary>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <param name="value">New value of the setting.</param>
            /// <exception cref="DuplicateNameException"></exception>
            public void SetValueObject<T>(string section, string name, T value) // where T : class
            {
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(T));
                if (tc == null)
                    throw new TypeConverterException($"SetValue<T>: Type {typeof(T).ToString()} has no type converter.");
                if (!tc.CanConvertTo(typeof(string)))
                    throw new TypeConverterException($"SetValue<T>: Type {typeof(T).ToString()} cannot be converted to string.");

                DataTable? dt = DataTableFromSection(section);
                DataRow? dr = null;
                if (dt == null)
                {
                    dt = new DataTable(section);
                    dt.Columns.Add(new DataColumn("Name", typeof(string)));
                    dt.Columns.Add(new DataColumn("Value", typeof(object)));
                    AddTable(dt);
                }
                else
                {
                    DataRow[] drs = dt.Select($"Name = \'{name}\'");
                    switch (drs.Count())
                    {
                        case 0:
                            break;
                        case 1:
                            dr = drs[0];
                            break;
                        default:
                            throw new DuplicateNameException($"SetValue<T>: Duplicate entry {section}/{name}");
                    }
                }
                if (dr == null)
                {
                    dr = dt.NewRow();
                    dr["Name"] = name;
                    dt.Rows.Add(dr);
                }
                dr["Value"] = tc.ConvertToString(value);
            }
            #endregion
            #region "SetList"
            /// <summary>
            /// Create or update a list of items of a specified type.
            /// </summary>
            /// <typeparam name="T">The type of objects to store in a list.</typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of objects of the specified type.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public void SetList<T>(string section, string name, IEnumerable<T> list)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                {
                    dt = new DataTable(section);
                    dt.Columns.Add(new DataColumn("Name", typeof(string)));
                    dt.Columns.Add(new DataColumn("Value", typeof(object)));
                    AddTable(dt);
                }
                int result;
                IEnumerable<DataRow>? rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(name.Length), out result));
                if (rows is not null)
                {
                    int currentRowCount = rows.Count();

                    // update existing rows
                    for (int i = 0; i < Math.Min(currentRowCount, list.Count()); i++)
                    {
                        rows.ElementAt(i)["Value"] = list.ElementAt<T>(i)?.ToString();
                    }
                    // add new rows
                    DataRow dr;
                    for (int i = rows.Count(); i < list.Count(); i++)
                    {
                        dr = dt.NewRow();
                        dr["Name"] = name + i.ToString();
                        dr["Value"] = list.ElementAt(i)?.ToString();
                        dt.Rows.Add(dr);
                    }
                    // delete extraneous rows
                    while (currentRowCount-- > list.Count())
                    {
                        dt.Rows.Remove(rows.ElementAt(currentRowCount));
                    }
                    dt.AcceptChanges();
                }
            }

            /// <summary>
            /// Create Or update a list of Colors.
            /// </summary>
            /// <typeparam name="T">The type of objects to store in a list.</typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of Colors of the specified type.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public void SetListColor(string section, string name, IEnumerable<Color> list)
            {
                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                {
                    dt = new DataTable(section);
                    dt.Columns.Add(new DataColumn("Name", typeof(string)));
                    dt.Columns.Add(new DataColumn("Value", typeof(object)));
                    AddTable(dt);
                }
                var ConvertColorToString = (Color c) =>
                {
                    if (c.IsNamedColor)
                        return c.Name;
                    else
                        return c.ToArgb().ToString();
                };
                int result;
                IEnumerable<DataRow>? rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(name.Length), out result));
                if (rows is not null)
                {
                    int currentRowCount = rows.Count();

                    // update existing rows
                    for (int i = 0; i < Math.Min(currentRowCount, list.Count()); i++)
                    {
                        rows.ElementAt(i)["Value"] = ConvertColorToString(list.ElementAt(i)).ToString();
                    }
                    // add new rows
                    DataRow dr;
                    for (int i = rows.Count(); i < list.Count(); i++)
                    {
                        dr = dt.NewRow();
                        dr["Name"] = name + i.ToString();
                        dr["Value"] = ConvertColorToString(list.ElementAt(i));
                        dt.Rows.Add(dr);
                    }
                    // delete extraneous rows
                    while (currentRowCount-- > list.Count())
                    {
                        dt.Rows.Remove(rows.ElementAt(currentRowCount));
                    }
                    dt.AcceptChanges();
                }
            }

            /// <summary>
            /// Create or update a list of items of a specified type that supports IConvertible to and from string.
            /// </summary>
            /// <typeparam name="T">The type of objects to store in a list. Each entry will be represented by a string that the object uses to clone itself.</typeparam>
            /// <param name="section">Main partition in the Settings.</param>
            /// <param name="name">Name of the setting.</param>
            /// <returns>A list of objects of the specified type.</returns>
            /// <exception cref="TypeConverterException"></exception>
            public void SetListObject<T>(string section, string name, IEnumerable<T> list)
            {
                TypeConverter? tc = TypeDescriptor.GetConverter(typeof(T));
                if (tc == null)
                    throw new TypeConverterException($"AddListObject: Type {typeof(T).ToString()} has no type converter.");
                if (!tc.CanConvertFrom(null, typeof(string)))
                    throw new TypeConverterException($"AddListObject: Type {typeof(T).ToString()} cannot be converted from string.");

                DataTable? dt = DataTableFromSection(section);
                if (dt == null)
                {
                    dt = new DataTable(section);
                    dt.Columns.Add(new DataColumn("Name", typeof(string)));
                    dt.Columns.Add(new DataColumn("Value", typeof(object)));
                    AddTable(dt);
                }
                int result;
                int nameLength = name.Length;
                IEnumerable<DataRow>? rows = dt.Select($"Name LIKE \'{name}*\'").
                    Where(dr0 => int.TryParse((dr0["Name"].ToString() ?? "").Substring(nameLength), out result));
                if (rows is not null)
                {
                    int currentRowCount = rows.Count();

                    // update existing rows
                    for (int i = 0; i < Math.Min(currentRowCount, list.Count()); i++)
                    {
                        rows.ElementAt(i)["Value"] = tc.ConvertToString(list.ElementAt<T>(i));
                    }

                    // add new rows
                    DataRow dr;
                    for (int i = currentRowCount; i < list.Count(); i++)
                    {
                        dr = dt.NewRow();
                        dr["Name"] = name + i.ToString();
                        dr["Value"] = tc.ConvertToString(list.ElementAt(i));
                        dt.Rows.Add(dr);
                    }

                    // delete extraneous rows
                    while (currentRowCount-- > list.Count())
                    {
                        dt.Rows.Remove(rows.ElementAt(currentRowCount));
                    }
                    dt.AcceptChanges();
                }
            }
            #endregion

            /// <summary>
            /// Write all the Settings to the XML.
            /// </summary>
            public void Write()
            {
                Dataset.WriteXml(FullPath, XmlWriteMode.WriteSchema);
            }

            /// <summary>
            /// Exception thrown when an object to be stored or retrieved does not have a TypeConverter for string.
            /// </summary>
            public class TypeConverterException : Exception
            {
                public TypeConverterException() : base() { }
                public TypeConverterException(string Message) : base(Message) { }
                public TypeConverterException(string Message, Exception InnerException) : base(Message, InnerException) { }
            }

            #region "forms"
            /// <summary>
            /// Track a Form's position and size, and whether it's maximized, so that it can be restored upon restart.
            /// Also tracks the positions of all SplitterControls.
            /// </summary>
            /// <param name="form">The Form to be tracked.</param>
            public void AddForm(Form form)
            {
                int left = GetValueInt(form.Name, "left", form.Left);
                int top = GetValueInt(form.Name, "top", form.Top);
                int width, height;
                bool maximized = GetValueBoolean(form.Name, "maximized", false);

                switch (form.FormBorderStyle)
                {
                    case FormBorderStyle.Sizable:
                    case FormBorderStyle.SizableToolWindow:
                        width = GetValueInt(form.Name, "width", form.Width);
                        height = GetValueInt(form.Name, "height", form.Height);
                        break;
                    default:
                        width = form.Width;
                        height = form.Height;
                        break;
                }

                // make sure the window title bar is visible
                bool visible = false;
                Rectangle bounds;
                Point pt = new Point(left, top);
                foreach (Screen s in Screen.AllScreens)
                {
                    bounds = new Rectangle(s.Bounds.Left, s.Bounds.Top, s.Bounds.Width - SystemInformation.MenuHeight, s.Bounds.Height - SystemInformation.MenuHeight);
                    if (bounds.Contains(pt))
                    {
                        visible = true;
                        break;
                    }
                }
                if (!visible)
                {
                    left = form.Left;
                    top = form.Top;
                }

                // restore window size and position
                form.Left = left;
                form.Top = top;
                form.Width = width;
                form.Height = height;
                if (maximized)
                {
                    form.WindowState = FormWindowState.Maximized;
                }

                form.Move += Form_Move;
                form.Resize += Form_Resize;

                PrepareSplitContainers(form.Controls);
            }

            private void Form_Move(object? sender, EventArgs e)
            {
                Form form = (Form)sender;
                switch (form.WindowState)
                {
                    case FormWindowState.Normal:
                        SetValue(form.Name, "maximized", false);
                        SetValue(form.Name, "left", form.Left);
                        SetValue(form.Name, "top", form.Top);
                        Write();
                        break;
                    case FormWindowState.Maximized:
                        SetValue(form.Name, "maximized", true);
                        Write();
                        break;
                    default:
                        break;
                }
            }

            private void Form_Resize(object? sender, EventArgs e)
            {
                Form form = (Form)sender;
                switch (form.WindowState)
                {
                    case FormWindowState.Normal:
                        SetValue(form.Name, "maximized", false);
                        SetValue(form.Name, "left", form.Left);
                        SetValue(form.Name, "top", form.Top);
                        SetValue(form.Name, "width", form.Width);
                        SetValue(form.Name, "height", form.Height);
                        Write();
                        break;
                    case FormWindowState.Maximized:
                        SetValue(form.Name, "maximized", true);
                        Write();
                        break;
                    default:
                        break;
                }
            }

            private void PrepareSplitContainers(Control.ControlCollection controls)
            {
                foreach (Control control in controls)
                {
                    if (control is SplitContainer sc)
                    {
                        ((Panel)sc.Panel1).VisibleChanged += SplitContainerPanel_VisibleChanged;
                        ((Panel)sc.Panel2).VisibleChanged += SplitContainerPanel_VisibleChanged;
                        sc.SplitterMoving += SplitContainer_SplitterMoving;
                    }
                    PrepareSplitContainers(control.Controls);
                }
            }

            private void SplitContainerPanel_VisibleChanged(object? sender, EventArgs e)
            {
                SplitContainer sc = (SplitContainer)((Panel)sender).Parent;
                if (sc != null)
                {
                    int splitterDistance = GetValueInt(sc.ParentForm.Name, sc.Name, sc.SplitterDistance);
                    if ((sc.Orientation == Orientation.Horizontal && splitterDistance > sc.Height) || (sc.Orientation == Orientation.Vertical && splitterDistance > sc.Width))
                    {
                        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer() { Interval = 40, Tag = sc, Enabled = false };
                        timer.Tick += SplitterTimer_Elapsed;
                        // BUG: not enabling the Timer, but it seems to work fine ...
                    }
                    else
                    {
                        sc.SplitterDistance = GetValueInt(sc.ParentForm.Name, sc.Name, sc.SplitterDistance);
                    }
                }
            }

            private void SplitterTimer_Elapsed(object? sender, EventArgs e)
            {
                System.Windows.Forms.Timer? timer = (System.Windows.Forms.Timer?)sender;
                if (timer != null)
                {
                    timer.Enabled = false;
                    timer.Tick -= SplitterTimer_Elapsed;

                    SplitContainer sc = (SplitContainer)timer.Tag;
                    sc.SplitterDistance = GetValueInt(sc.ParentForm.Name, sc.Name, sc.SplitterDistance);

                    timer.Dispose();
                    timer = null;
                }
            }

            private void SplitContainer_SplitterMoving(object? sender, SplitterCancelEventArgs e)
            {
                SplitContainer sc = (SplitContainer)sender;
                int SplitterDistance = Math.Max(e.SplitX, e.SplitY);
                SetValue(sc.ParentForm.Name, sc.Name, SplitterDistance);
                Write();
            }
            #endregion
        }
    }
}

// Articles used as reference:
// DataTable.Select: https://learn.microsoft.com/en-us/dotnet/api/system.data.datacolumn.expression?view=net-8.0
// ?? operator: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
