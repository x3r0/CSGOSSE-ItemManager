using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsgoItemDataType
{
    public struct StickerInfo
    {
        public static string KeyName = "sticker_kits";
        public static string SubKeyName = "name";
        public static string SubKeyDesc = "item_name";

        public int CodedValue
        {
            get;
            set;
        }

        public string CodedName
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string RealName { get; set; }

        public override string ToString()
        {
            return CodedName;
        }
    }
}
