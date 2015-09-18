using CsgoItemDataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValveKvReader;

namespace SseCsgoItemEditorGui.InventoryHelper
{
    public class ItemSolver
    {
        private CsgoItemsGameFileParser _parser;

        public ItemSolver(CsgoItemsGameFileParser parser)
        {
            _parser = parser;
        }

        public SortedList<int, StickerInfo> CsgoSortedStickerList
        {
            get
            {
                return _parser.GetSortedAllStickerInfo();
            }
        }

        public SortedList<int, AttributeInfo> CsgoSortedAttributeList
        {
            get 
            {
                return _parser.GetSortedAllAttributeInfo();
            }
        }

        public SortedList<int, PaintInfo> CsgoSortedPaintList
        {
            get
            {
                return _parser.GetSortedAllPaintInfo();
            }
        }

        public List<QualityInfo> CsgoQualityList
        {
            get
            {
                return _parser.GetAllQualityInfo();
            }
        }

        public List<RarityInfo> CsgoRarityList
        {
            get
            {
                return _parser.GetAllRarityInfo();
            }
        }

        public List<ItemInfo> CsgoItemList
        {
            get
            {
                return _parser.GetAllItemInfo();
            }
        }

        public List<AttributeInfo> CsgoAttributeList
        {
            get 
            {
                return _parser.GetAllAttributeInfo();
            }
        }

        public List<PaintInfo> CsgoPaintList
        {
            get
            {
                return _parser.GetAllPaintKits();
            }
        }

        public List<StickerInfo> CsgoStickerList
        {
            get
            {
                return _parser.GetAllStickerKits();
            }
        }

        public List<MusicInfo> CsgoMusicList
        {
            get
            {
                return _parser.GetAllMusics();
            }
        }

        public ItemInfo GetItem(string itemName)
        {
            return CsgoItemList.FirstOrDefault(x => x.CodedName.Equals(itemName, StringComparison.CurrentCultureIgnoreCase));
        }

        public List<ItemInfo> FindItems(string name)
        {
            return CsgoItemList.FindAll(x => x.CodedName.Contains(name));
        }

        public ItemInfo GetItem(int codedValue)
        {
            return CsgoItemList.FirstOrDefault(x => x.CodedValue == codedValue);
        }

        public PaintInfo GetPaint(string paintName)
        {
            return CsgoPaintList.FirstOrDefault(x => x.Name == paintName);
        }

        public QualityInfo GetQuality(string quality)
        {
            return CsgoQualityList.FirstOrDefault(x => x.Name == quality);
        }

        public QualityInfo GetQuality(int codedValue)
        {
            return CsgoQualityList.FirstOrDefault(x => x.Value == codedValue);
        }

        public RarityInfo GetRarity(string rarity)
        {
            return CsgoRarityList.FirstOrDefault(x => x.Name == rarity);
        }

        public AttributeInfo GetAttribute(int codedValue)
        {
            return CsgoAttributeList.FirstOrDefault(x => x.CodedValue == codedValue);
        }
    }
}
