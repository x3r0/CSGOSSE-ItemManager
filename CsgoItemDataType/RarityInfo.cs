using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsgoItemDataType
{
    public struct RarityInfo
    {
        public static string KeyName = "rarities";
        public static string SubKeyValue = "value";
        public static string SubKeyCommonItemCodedDesc = "loc_key";
        public static string SubKeyWeaponCodedDesc = "loc_key_weapon";

        public string Name
        {
            get;
            set;
        }

        public int CodedValue
        {
            get;
            set;
        }

        public string CommonItemCodedDesc
        {
            get;
            set;
        }

        public string WeaponCodedDesc
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
