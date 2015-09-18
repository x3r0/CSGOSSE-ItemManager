using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsgoItemDataType
{
    public struct MusicInfo
    {
        public static string KeyName = "music_definitions";
        public static string SubKeyName = "name";
        public static string SubKeyDesc = "loc_name";

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

        public string Description
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
