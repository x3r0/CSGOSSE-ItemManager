using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsgoItemDataType
{
    /// <summary>
    /// Store a parsed item information from KeyValue file
    /// </summary>
    public struct ItemInfo
    {
        public static string KeyName = "items";
        public static string SubKeyName = "name";
        public static string SubKeyDesc = "item_name";
        public static string SubKeyPrefab = "prefab";

        /// <summary>
        /// Subkey of "items" - recognized string "items"
        /// </summary>
        public int CodedValue
        {
            get;
            set;
        }

        /// <summary>
        /// Subkey of CodedValue - recognized string "name"
        /// </summary>
        public string CodedName
        {
            get;
            set;
        }

        /// <summary>
        /// Subkey of CodedValue - recognized string "item_name"
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        public bool IsWeapon
        {
            get;
            set;
        }

        public override string ToString()
        {
            return CodedName;
        }
    }
}
