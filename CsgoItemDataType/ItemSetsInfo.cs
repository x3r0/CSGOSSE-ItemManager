using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsgoItemDataType
{
    public struct ItemSetsInfo
    {
        public static string KeyName = "item_sets";
        public static string SubKeyName = "name";
        public static string SubKeyItems = "items";

        public string Name { get; set; }
        public List<Tuple<PaintInfo, ItemInfo>> ItemSet { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
