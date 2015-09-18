using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsgoItemDataType
{
    public struct KvTokenInfo
    {
        public static string KeyName = "Tokens";
        public static string PaintTokenRegex = @"\bPaintKit_\w+_tag\b";
        public static string StickerToken = "StickerKit_";
        public static string MusicToken = "musickit_";

        public string CodedName { get; set; }
        public string RealName { get; set; }
    }
}
