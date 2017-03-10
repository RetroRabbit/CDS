using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Drawing;

namespace CDS.Client.Desktop.Essential.UTL
{
    public class CustomApplicationSettings : ApplicationSettingsBase
    {
        private static CustomApplicationSettings instance;

        private Point startPosition;
        private Size startSize;
        private String applicationStyle;
        private float fontSize;
        private String fontType;

        private bool isMaximized;

        public static CustomApplicationSettings Instance
        {
            get
            {
                if (instance == null)
                    instance = new CustomApplicationSettings();

                return instance;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("true")]
        public bool IsMaximized
        {
            get
            {

                try
                {
                    isMaximized = (bool)this["isMaximized"];
                    //startPosition = new Point(Convert.ToInt32((startPoint[0])), Convert.ToInt32((startPoint[1])));
                }
                catch (Exception ex)
                {
                    isMaximized = true;
                }

                return (isMaximized);
            }
            set
            {
                this["isMaximized"] = (bool)value;//((Point)value).X + "," + ((Point)value).Y;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("0,0")]
        public Point StartPosition
        {
            get
            {

                try
                {
                    startPosition = (Point)this["startPosition"];
                    if (startPosition.X < 0 || startPosition.Y < 0)
                        startPosition = new Point(0, 0);

                    //startPosition = new Point(Convert.ToInt32((startPoint[0])), Convert.ToInt32((startPoint[1])));
                }
                catch (Exception ex)
                {
                    startPosition = new Point(0, 0);
                }

                return (startPosition);
            }
            set
            {
                if (((Point)value).X < 0 || ((Point)value).Y < 0)
                    this["startPosition"] = new Point(0, 0);
                else
                    this["startPosition"] = (Point)value;//((Point)value).X + "," + ((Point)value).Y;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("1024,768")]
        public Size StartSize
        {
            get
            {

                try
                {
                    //startSize = new Size(1024, 768);
                    startSize = (Size)this["startSize"];
                    //startPosition = new Point(Convert.ToInt32((startPoint[0])), Convert.ToInt32((startPoint[1])));
                }
                catch (Exception ex)
                {
                    startSize = new Size(0, 0);
                }

                return (startSize);
            }
            set
            {
                this["startSize"] = (Size)value;//((Point)value).X + "," + ((Point)value).Y;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("8.25")]
        public float FontSize
        {
            get
            {

                try
                {
                    //startSize = new Size(1024, 768);
                    fontSize = (float)this["fontSize"];
                    //startPosition = new Point(Convert.ToInt32((startPoint[0])), Convert.ToInt32((startPoint[1])));
                }
                catch (Exception ex)
                {
                    fontSize = 8.25f;
                }

                return (fontSize);
            }
            set
            {
                this["fontSize"] = (float)value;//((Point)value).X + "," + ((Point)value).Y;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("Tahoma")]
        public string FontType
        {
            get
            {

                try
                {
                    //startSize = new Size(1024, 768);
                    fontType = (string)this["fontType"];
                    //startPosition = new Point(Convert.ToInt32((startPoint[0])), Convert.ToInt32((startPoint[1])));
                }
                catch (Exception ex)
                {
                    fontType = "Tahoma";
                }

                return (fontType);
            }
            set
            {
                this["fontType"] = (string)value;//((Point)value).X + "," + ((Point)value).Y;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("Office 2013")]
        public String ApplicationStyle
        {
            get
            {

                try
                {
                    applicationStyle = (String)this["applicationStyle"];
                   
                }
                catch (Exception ex)
                {
                    applicationStyle = "Office 2013";
                }

                return (applicationStyle);
            }
            set
            {
                this["applicationStyle"] = (String)value;//((Point)value).X + "," + ((Point)value).Y;
            }
        }
    }
}
