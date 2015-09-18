using System;

namespace CsgoItemDataType
{
    public struct PaintInfo
    {
        public static string KeyName = "paint_kits";
        public static string SubKeyName = "name";
        public static string SubKeyDesc = "description_string";
        public static string SubKeyDescTag = "description_tag";
        public static string SubKeyWearDefault = "wear_default";
        public static string SubKeyWearMin = "wear_remap_min";
        public static string SubKeyWearMax = "wear_remap_max";

        public int CodedValue
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string CodedDescription
        {
            get;
            set;
        }

        public string CodedDescriptionTag
        {
            get;
            set;
        }

        public float WearDefaultLevel
        {
            get;
            set;
        }

        public float WearMinLevel
        {
            get;
            set;
        }

        public float WearMaxLevel
        {
            get;
            set;
        }

        public string Rarity { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
