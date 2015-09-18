using SteamKit2.GC.Internal;
using System;
using System.Collections.Generic;

namespace CsgoItemDataType.FriendlyDataType
{
    public class CompleteItemInfo
    {
        public CompleteItemInfo()
        {
            CompleteAttributes = new Dictionary<AttributeInfo, CSOEconItemAttribute>();
            StickerAttributeLookup = new List<StickerInfo>();
        }

        public bool IsChanged { get; set; }
        public CSGOItemProto ItemProto { get; set; }
        public string CustomName { get; set; }
        public ItemInfo Item { get; set; }
        public QualityInfo Quality { get; set; }
        public RarityInfo Rarity { get; set; }
        public Dictionary<AttributeInfo, CSOEconItemAttribute> CompleteAttributes { get; set; }
        public PaintInfo PaintAttributeLookup { get; set; }
        public List<StickerInfo> StickerAttributeLookup { get; set; }
        public MusicInfo MusicAttributeLookup { get; set; }

        public override string ToString()
        {
            return Item.CodedName;
        }
    }
}
