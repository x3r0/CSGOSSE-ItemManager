using CsgoItemDataType;
using CsgoItemDataType.FriendlyDataType;
using ItemEditor;
using SteamKit2.GC.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValveKvReader;

namespace SseCsgoItemEditorGui.InventoryHelper
{
    class InventoryRetriever
    {
        private List<CSGOItemProto> _inventories;
        private List<CompleteItemInfo> _itemInv;
        private ItemSolver _invSolver;

        public ItemSolver InventorySolver
        {
            get { return _invSolver; }
            set { _invSolver = value; }
        }
        private InventoryFileLoader _inventoryFileLoader;

        public InventoryRetriever(CsgoItemsGameFileParser parser, InventoryFileLoader loader)
        {
            if (parser.IsValid)
            {
                _invSolver = new ItemSolver(parser);
            }

            _itemInv = new List<CompleteItemInfo>();
            _inventoryFileLoader = loader;
        }

        public List<CompleteItemInfo> GetAllInventories()
        {
            _inventories = _inventoryFileLoader.Manager.GetAllInventories();

            var items = from inv in _inventories
                        join itemInfo in _invSolver.CsgoItemList
                        on inv.def_index equals itemInfo.CodedValue
                        join qualityInfo in _invSolver.CsgoQualityList
                        on inv.quality equals qualityInfo.Value
                        join rarityInfo in _invSolver.CsgoRarityList
                        on inv.rarity equals rarityInfo.CodedValue
                        select new CompleteItemInfo
                        {
                            ItemProto = inv,
                            CustomName = inv.custom_name,
                            Item = itemInfo,
                            Quality = qualityInfo,
                            Rarity = rarityInfo,
                            IsChanged = false
                        };

            _itemInv = items.ToList();

            var newInventories = from inv in _inventories
                                 join itemInfo in _invSolver.CsgoItemList
                                 on inv.def_index equals itemInfo.CodedValue
                                 select inv;

            _inventories = newInventories.ToList();

            for (int i = 0; i < _inventories.Count; i++)
            {
                if (_inventories[i].attribute.Count > 0)
                {
                    var attr = from attrInv in _inventories[i].attribute
                               join attrDesc in _invSolver.CsgoSortedAttributeList
                               on Convert.ToInt32(attrInv.def_index) equals attrDesc.Key
                               select new  
                               { 
                                   attrDesc.Value,
                                   attrInv
                               };

                    _itemInv[i].CompleteAttributes = attr.ToDictionary(x => x.Value, y => y.attrInv);
                }
            }

            int value = 0;

            foreach (var item in _itemInv)
            {
                foreach (var attr in item.CompleteAttributes)
                {
                    // weapon skin - aka "set item texture prefab"
                    if (attr.Value.def_index == 6)
                    {
                        value = Convert.ToInt32(BitConverter.ToSingle(attr.Value.value_bytes, 0));

                        var paint = from p in _invSolver.CsgoSortedPaintList
                                    where p.Key == value
                                    select p.Value;

                        item.PaintAttributeLookup = (PaintInfo)paint.FirstOrDefault();
                    }
                    else if (attr.Value.def_index == 113)
                    {
                        value = BitConverter.ToInt32(attr.Value.value_bytes, 0);

                        var sticker = from p in _invSolver.CsgoSortedStickerList
                                    where p.Key == value
                                    select p.Value;

                        item.StickerAttributeLookup.Add((StickerInfo)sticker.FirstOrDefault());
                    }
                    else if (attr.Value.def_index == 117)
                    {
                        value = BitConverter.ToInt32(attr.Value.value_bytes, 0);

                        var sticker = from p in _invSolver.CsgoSortedStickerList
                                      where p.Key == value
                                      select p.Value;

                        item.StickerAttributeLookup.Add((StickerInfo)sticker.FirstOrDefault());
                    }
                    else if (attr.Value.def_index == 121)
                    {
                        value = BitConverter.ToInt32(attr.Value.value_bytes, 0);

                        var sticker = from p in _invSolver.CsgoSortedStickerList
                                      where p.Key == value
                                      select p.Value;

                        item.StickerAttributeLookup.Add((StickerInfo)sticker.FirstOrDefault());
                    }
                    else if (attr.Value.def_index == 125)
                    {
                        value = BitConverter.ToInt32(attr.Value.value_bytes, 0);

                        var sticker = from p in _invSolver.CsgoSortedStickerList
                                      where p.Key == value
                                      select p.Value;

                        item.StickerAttributeLookup.Add((StickerInfo)sticker.FirstOrDefault());
                    }
                    else if (attr.Value.def_index == 129)
                    {
                        value = BitConverter.ToInt32(attr.Value.value_bytes, 0);

                        var sticker = from p in _invSolver.CsgoSortedStickerList
                                      where p.Key == value
                                      select p.Value;

                        item.StickerAttributeLookup.Add((StickerInfo)sticker.FirstOrDefault());
                    }
                    else if (attr.Value.def_index == 133)
                    {
                        value = BitConverter.ToInt32(attr.Value.value_bytes, 0);

                        var sticker = from p in _invSolver.CsgoSortedStickerList
                                      where p.Key == value
                                      select p.Value;

                        item.StickerAttributeLookup.Add((StickerInfo)sticker.FirstOrDefault());
                    }
                    else if (attr.Value.def_index == 166)
                    {
                        for (int i = 0; i < _invSolver.CsgoMusicList.Count; i++)
                        {
                            if (BitConverter.ToInt32(attr.Value.value_bytes, 0) == _invSolver.CsgoMusicList[i].CodedValue)
                            {
                                item.MusicAttributeLookup = _invSolver.CsgoMusicList[i];
                                break;
                            }
                        }
                    }
                }
            }

            return _itemInv;
        }
    }
}
