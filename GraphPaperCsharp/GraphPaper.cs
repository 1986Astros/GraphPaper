using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SharkInSeine
{
    public class GraphPaper
    {
        const string CatAppearance = "Appearance";
        public enum Shapes : ulong
        {
            Triangles,
            Diamonds,
            Squares,
            Hexagons
        }
        [DefaultValue(DefaultShape)]
        [Category(CatAppearance)]
        [Description("Shape of the grid drawn on the page.")]
        public Shapes Shape
        {
            get
            {
                return Globals.Settings.GetValueEnum<Shapes>("Main", "Shape", DefaultShape);
            }
            set
            {
                if (value != Shape)
                {
                    Globals.Settings.SetValue("Main", "Shape", value);
                    Globals.WriteSettings();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Shape"));
                }
            }
        }
        const Shapes DefaultShape = Shapes.Squares;

        public enum Units
        {
            Millimeters,
            Inches
        }
        [DefaultValue(DefaultLineWidth)]
        [Category(CatAppearance)]
        [Description("Width in mm or inches of the outlines and dividers.")]
        public float LineWidth
        {
            get
            {
                return Globals.Settings.GetValueFloat("Main", "LineWidth", DefaultLineWidth);
            }
            set
            {
                if (value != LineWidth)
                {
                    Globals.Settings.SetValue("Main", "LineWidth", value);
                    Globals.WriteSettings();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LineWidth"));
                }
            }
        }
        private const float DefaultLineWidth = 0.25F;

        [DefaultValue(DefaultLineWidthUnits)]
        [Category(CatAppearance)]
        [Description("Units of measurement for line widths.")]
        public Units LineWidthUnits
        {
            get
            {
                return Globals.Settings.GetValueEnum<Units>("Main", "LineWidthUnits", DefaultLineWidthUnits);
            }
            set
            {
                if (value != LineWidthUnits)
                {
                    Globals.Settings.SetValue("Main", "LineWidthUnits", value);
                    Globals.WriteSettings();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LineWidthUnits"));
                }
            }
        }
        private const Units DefaultLineWidthUnits = Units.Millimeters;

        [DefaultValue(typeof(Color), DefaultLineColorOfGraphPaper)]
        [Category(CatAppearance)]
        [Description("Units of measurement for line widths.")]
        public Color? LineColor
        {
            get
            {
                return Globals.Settings.GetValueColor("Main", "LineColor", Color.FromName(DefaultLineColorOfGraphPaper));
            }
            set
            {
                if (!value.Equals(LineColor))
                {
                    Globals.Settings.SetValueColor("Main", "LineColor", value ?? Color.Black);
                    Globals.WriteSettings();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LineColor"));
                }
            }
        }
        private const string DefaultLineColorOfGraphPaper = "LightBlue";

        [DefaultValue(DefaultShapeWidth)]
        [Category(CatAppearance)]
        [Description("Distance in mm or inches between gridlines.")]
        public float ShapeWidth
        {
            get
            {
                return Globals.Settings.GetValueFloat("Main", "ShapeWidth", DefaultShapeWidth);
            }
            set
            {
                if (value != ShapeWidth)
                {
                    Globals.Settings.SetValue("Main", "ShapeWidth", value);
                    Globals.WriteSettings();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ShapeWidth"));
                }
            }
        }
        private const float DefaultShapeWidth = 0.25F;

        [DefaultValue(DefaultShapeWidthUnits)]
        [Category(CatAppearance)]
        [Description("Units of measurement for shape widths.")]
        public Units ShapeWidthUnits
        {
            get
            {
               return  Globals.Settings.GetValueEnum<Units>("Main", "ShapeWidthUnits", DefaultShapeWidthUnits);
            }
            set
            {
                if (value != ShapeWidthUnits)
                {
                    Globals.Settings.SetValue("Main", "ShapeWidthUnits", DefaultShapeWidthUnits);
                    Globals.WriteSettings();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ShapeWidthUnits"));
                }
            }
        }
        private const Units DefaultShapeWidthUnits = Units.Inches;

        public class PropertyChangedEventArgs : EventArgs
        {
           public PropertyChangedEventArgs(string Name)
            {
                this.Name = Name;
            }
            public readonly string Name;
        }
        public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
