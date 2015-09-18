using System;
using System.Drawing;

namespace CsgoItemDataType
{
    public struct QualityInfo
    {
        public static string KeyName = "qualities";
        public static string SubKeyValue = "value";
        public static string SubKeyCodedHexColor = "hexColor";

        public string Name
        {
            get;
            set;
        }

        public int Value
        {
            get;
            set;
        }

        private Color _color;

        public string CodedHexColor
        {
            get;
            set;
        }

        public Color Color
        {
          	get
            {
                return _color = ColorTranslator.FromHtml(CodedHexColor);
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
