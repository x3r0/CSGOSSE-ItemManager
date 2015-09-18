using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using CsgoItemDataType;
using System.Text.RegularExpressions;

namespace ValveKvReader
{
    /// <summary>
    ///     Read item_games.txt and put certain keys information into List
    /// </summary>
    /// <remarks>
    ///     
    /// </remarks>
    public class CsgoItemsGameFileParser
    {
        private FileStream _csgoKvFile;
        private FileStream _locKvFile;
        private KeyValue _itemGamesKv;
        private KeyValue _locFile;

        public CsgoItemsGameFileParser(string filePath)
        {
            _csgoKvFile = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            
            _itemGamesKv = new KeyValue(String.Empty, String.Empty);

            IsValid = _itemGamesKv.ReadAsText(_csgoKvFile);
        }


        public CsgoItemsGameFileParser(string itemsGameFilePath, string localizationTextFilePath)
        {
            _csgoKvFile = new FileStream(itemsGameFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            _locKvFile = new FileStream(localizationTextFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            _itemGamesKv = new KeyValue(string.Empty, string.Empty);
            _locFile = new KeyValue(string.Empty, string.Empty);

            IsValid = _itemGamesKv.ReadAsText(_csgoKvFile);
            _locFile.ReadAsText(_locKvFile);
        }

        public bool IsValid
        {
            get;
            private set;
        }

        public bool IsClosed
        {
            get
            {
                return !_csgoKvFile.CanRead;
            }
        }

        public List<Tuple<ItemInfo, PaintInfo>> GetOfficialItems()
        {
            List<Tuple<ItemInfo, PaintInfo>> officialItems = new List<Tuple<ItemInfo, PaintInfo>>();

            KeyValue result = this.Read("alternate_icons2");

            List<PaintInfo> paintInfos = this.GetAllPaintKits();
            List<ItemInfo> itemInfos = this.GetAllItemInfo();

            ItemInfo item = new ItemInfo();
            PaintInfo paint = new PaintInfo();

            string econPath;

            List<string> econPathList = new List<string>();
            if (result != null)
            {
                foreach (var subChildKey in result.Children[0].Children)
                {
                    econPath = subChildKey.Children[0].Value;
                    econPathList.Add(econPath);
                }
            }

            string[] splittedEconPath;
            string[] removeList = new string[] { "_medium", "_heavy" };

            string itemPaint;

            foreach (var strRemove in removeList)
            {
                econPathList.RemoveAll(p => p.Contains(strRemove));
            }

            foreach (var str in econPathList)
            {
                splittedEconPath = str.Split('/');

                if (splittedEconPath[2].Contains("_light"))
                {
                    itemPaint = splittedEconPath[2].Replace("_light", string.Empty);

                    foreach (var paintInfo in paintInfos)
                    {
                        if (itemPaint.Contains(paintInfo.Name))
                        {
                            paint = paintInfo;
                            itemPaint = itemPaint.Replace("_" + paintInfo.Name, string.Empty);
                            break;
                        }
                    }

                    foreach (var itemInfo in itemInfos)
                    {
                        if (itemPaint.Equals(itemInfo.CodedName))
                        {
                            item = itemInfo;
                            break;
                        }
                    }
                }

                if ((string.IsNullOrEmpty(item.CodedName) == false) && (string.IsNullOrEmpty(paint.Name) == false))
                {
                    officialItems.Add(new Tuple<ItemInfo, PaintInfo>(item, paint));
                }
            }

            return officialItems;
        }

        public List<ItemSetsInfo> GetItemSets()
        {
            List<ItemSetsInfo> list = new List<ItemSetsInfo>();
            List<string> tempListString = new List<string>();
            
            KeyValue result = this.Read(ItemSetsInfo.KeyName);
            ItemSetsInfo def;

            List<PaintInfo> paintInfos = this.GetAllPaintKits();
            List<ItemInfo> itemInfos = this.GetAllItemInfo();

            List<Tuple<PaintInfo, ItemInfo>> itemSetDic;

            if (result != null)
            {
                foreach (var subChildKey in result.Children)
                {
                    def = new ItemSetsInfo();
                    itemSetDic = new List<Tuple<PaintInfo, ItemInfo>>();

                    foreach (var itemSubChildKey in subChildKey.Children)
                    {
                        if (itemSubChildKey.Name.Equals(ItemSetsInfo.SubKeyName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.Name = itemSubChildKey.Value;
                        }

                        foreach (var itemSubSubChildKey in itemSubChildKey.Children)
                        {
                            Match paintMatch = Regex.Match(itemSubSubChildKey.Name, @"(?<=\[)[^]]+(?=\])");
                            Match itemMatch = Regex.Match(itemSubSubChildKey.Name, @"(.*?)(?:\[.*?\]|$)");

                            itemSetDic.Add(new Tuple<PaintInfo,ItemInfo>
                                (paintInfos.Find(p => p.Name == paintMatch.Value), 
                                itemInfos.Find(p => p.CodedName == itemMatch.NextMatch().Value)));
                        }

                        def.ItemSet = itemSetDic;
                    }

                    list.Add(def);
                }
            }

            return list;
        }

        public List<KvTokenInfo> GetPaintKitsRealName()
        {
            List<KvTokenInfo> list = new List<KvTokenInfo>();

            KeyValue result = this.ReadToken(KvTokenInfo.KeyName);
            KvTokenInfo def;

            if (result != null)
            {
                foreach (var subChildKey in result.Children)
                {
                    def = new KvTokenInfo();

                    foreach (var itemSubChildKey in subChildKey.Children)
                    {
                        if (Regex.Match(itemSubChildKey.Name, KvTokenInfo.PaintTokenRegex).Success)
                        {
                            def.CodedName = itemSubChildKey.Name;
                            def.RealName = itemSubChildKey.Value;
                        }
                    }

                    list.Add(def);
                }
            }

            return list;
        }

        internal KeyValue Read(string key)
        {
            if (IsValid)
            {
                foreach (var childKey in _itemGamesKv.Children)
                {
                    if (childKey.Name.Equals(key, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return childKey;
                    }
                }
            }
            else
            {
                return null;
            }

            return null;
        }

        internal KeyValue ReadToken(string key)
        {
            if (IsValid)
            {
                foreach (var childKey in _locFile.Children)
                {
                    if (childKey.Name.Equals(key, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return childKey;
                    }
                }
            }
            else
            {
                return null;
            }

            return null;
        }

        public SortedList<int, PaintInfo> GetSortedAllPaintInfo()
        {
            SortedList<int, PaintInfo> list = new SortedList<int, PaintInfo>();

            KeyValue paintKitsRarity = this.Read("paint_kits_rarity");
            Dictionary<string, string> paintKitsRarityDic = new Dictionary<string, string>();

            if (paintKitsRarity != null)
            {
                foreach (var subChildKey in paintKitsRarity.Children)
                {
                    paintKitsRarityDic.Add(subChildKey.Name, subChildKey.Value);
                }
            }

            KeyValue result = this.Read(PaintInfo.KeyName);
            PaintInfo def;

            if (result != null)
            {
                foreach (var subChildKey in result.Children)
                {
                    def = new PaintInfo();
                    def.CodedValue = int.Parse(subChildKey.Name);

                    foreach (var itemSubChildKey in subChildKey.Children)
                    {
                        if (itemSubChildKey.Name.Equals(PaintInfo.SubKeyName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.Name = itemSubChildKey.Value;
                        }
                        else if (itemSubChildKey.Name.Equals(PaintInfo.SubKeyWearDefault, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.WearDefaultLevel = float.Parse(itemSubChildKey.Value, CultureInfo.InvariantCulture);
                        }
                        else if (itemSubChildKey.Name.Equals(PaintInfo.SubKeyWearMin, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.WearMinLevel = float.Parse(itemSubChildKey.Value, CultureInfo.InvariantCulture);
                        }
                        else if (itemSubChildKey.Name.Equals(PaintInfo.SubKeyWearMax, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.WearMaxLevel = float.Parse(itemSubChildKey.Value, CultureInfo.InvariantCulture);
                        }
                    }

                    foreach (var itemDict in paintKitsRarityDic)
                    {
                        if (def.Name.Equals(itemDict.Key))
                        {
                            def.Rarity = itemDict.Value;
                            break;
                        }
                    }
                    list.Add(def.CodedValue, def);
                }
            }

            return list;
        }

        /// <summary>
        ///     Store "rarities" and its all subkeys info to List
        /// </summary>
        /// <returns>
        ///     List containing Rarities with their info
        /// </returns>
        public List<RarityInfo> GetAllRarityInfo()
        {
            KeyValue result = this.Read(RarityInfo.KeyName);
            List<RarityInfo> returnValue = new List<RarityInfo>();
            RarityInfo def;

            if (result != null)
            {
                foreach (var subChildKey in result.Children)
                {
                    def = new RarityInfo();
                    def.Name = subChildKey.Name;

                    foreach (var itemSubChildKey in subChildKey.Children)
                    {
                        if (itemSubChildKey.Name.Equals(RarityInfo.SubKeyValue, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.CodedValue = int.Parse(itemSubChildKey.Value);
                        }
                        else if (itemSubChildKey.Name.Equals(RarityInfo.SubKeyCommonItemCodedDesc, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.CommonItemCodedDesc = itemSubChildKey.Value;
                        }
                        else if (itemSubChildKey.Name.Equals(RarityInfo.SubKeyWeaponCodedDesc, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.WeaponCodedDesc = itemSubChildKey.Value;
                        }
                    }
                    returnValue.Add(def);
                }
            }

            return returnValue;
        }

        public List<QualityInfo> GetAllQualityInfo()
        {
            KeyValue result = this.Read(QualityInfo.KeyName);
            List<QualityInfo> returnValue = new List<QualityInfo>();
            QualityInfo def;

            if (result != null)
            {
                foreach (var subChildKey in result.Children)
                {
                    def = new QualityInfo();
                    def.Name = subChildKey.Name;

                    foreach (var itemSubChildKey in subChildKey.Children)
                    {
                        if (itemSubChildKey.Name.Equals(QualityInfo.SubKeyValue, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.Value = int.Parse(itemSubChildKey.Value);
                        }
                        else if (itemSubChildKey.Name.Equals(QualityInfo.SubKeyCodedHexColor, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.CodedHexColor = itemSubChildKey.Value;
                        }
                    }
                    returnValue.Add(def);
                }
            }

            return returnValue;
        }

        public List<ItemInfo> GetAllItemInfo()
        {
            KeyValue result = this.Read(ItemInfo.KeyName);
            List<ItemInfo> returnValue = new List<ItemInfo>();
            ItemInfo def;

            if (result != null)
            {
                foreach (var subChildKey in result.Children)
                {
                    def = new ItemInfo();

                    //skip the first "default" subkey
                    if (subChildKey.Name.Equals("default", StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }
                    else
                        def.CodedValue = int.Parse(subChildKey.Name);

                    foreach (var itemSubChildKey in subChildKey.Children)
                    {
                        if (itemSubChildKey.Name.Equals(ItemInfo.SubKeyName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.CodedName = itemSubChildKey.Value;
                        }
                        else if (itemSubChildKey.Name.Equals(ItemInfo.SubKeyDesc, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.Description = itemSubChildKey.Value;
                        }
                        else if (itemSubChildKey.Name.Equals(ItemInfo.SubKeyPrefab, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (itemSubChildKey.Value.Contains("weapon_"))
                            {
                                def.IsWeapon = true;
                            }
                        }
                    }
                    returnValue.Add(def);
                }
            }

            return returnValue;
        }

        public List<AttributeInfo> GetAllAttributeInfo()
        {
            KeyValue result = this.Read(AttributeInfo.KeyName);
            List<AttributeInfo> returnValue = new List<AttributeInfo>();
            AttributeInfo def;

            if (result != null)
            {
                foreach (var subChildKey in result.Children)
                {
                    def = new AttributeInfo();

                    //skip the first "default" subkey
                    if (subChildKey.Name.Equals("default", StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }
                    else
                        def.CodedValue = int.Parse(subChildKey.Name);

                    foreach (var itemSubChildKey in subChildKey.Children)
                    {
                        if (itemSubChildKey.Name.Equals(AttributeInfo.SubKeyCodedName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.CodedName = itemSubChildKey.Value;
                        }
                        else if (itemSubChildKey.Name.Equals(AttributeInfo.SubKeyRealName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.RealName = itemSubChildKey.Value;
                        }
                        else if (itemSubChildKey.Name.Equals(AttributeInfo.IsIntegerStr, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (itemSubChildKey.Value.Equals("1", StringComparison.CurrentCultureIgnoreCase))
                            {
                                def.IsInteger = true;
                            }
                            else
                            {
                                def.IsInteger = false;
                            }
                        }
                    }
                    returnValue.Add(def);
                }
            }

            return returnValue;
        }

        public List<StickerInfo> GetAllStickerKits()
        {
            KeyValue result = this.Read(StickerInfo.KeyName);
            List<StickerInfo> returnValue = new List<StickerInfo>();
            StickerInfo def;

            if (result != null)
            {
                foreach (var subChildKey in result.Children)
                {
                    def = new StickerInfo();
                    def.CodedValue = int.Parse(subChildKey.Name);

                    foreach (var itemSubChildKey in subChildKey.Children)
                    {
                        if (itemSubChildKey.Name.Equals(StickerInfo.SubKeyName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.CodedName = itemSubChildKey.Value;
                        }
                        else if (itemSubChildKey.Name.Equals(StickerInfo.SubKeyDesc, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.Description = itemSubChildKey.Value;
                        }
                    }
                    returnValue.Add(def);
                }
            }

            return returnValue;
        }

        public List<PaintInfo> GetAllPaintKits()
        {
            KeyValue paintKitsRarity = this.Read("paint_kits_rarity");
            Dictionary<string, string> paintKitsRarityDic = new Dictionary<string, string>();

            if (paintKitsRarity != null)
            {
                foreach (var subChildKey in paintKitsRarity.Children)
                {
                    paintKitsRarityDic.Add(subChildKey.Name, subChildKey.Value);
                }
            }

            KeyValue result = this.Read(PaintInfo.KeyName);
            List<PaintInfo> returnValue = new List<PaintInfo>();
            PaintInfo def;

            if (result != null)
            {
                foreach (var subChildKey in result.Children)
                {
                    def = new PaintInfo();
                    def.CodedValue = int.Parse(subChildKey.Name);
                    
                    foreach (var itemSubChildKey in subChildKey.Children)
                    {
                        if (itemSubChildKey.Name.Equals(PaintInfo.SubKeyName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.Name = itemSubChildKey.Value;
                        }
                        else if (itemSubChildKey.Name.Equals(PaintInfo.SubKeyWearDefault, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.WearDefaultLevel = float.Parse(itemSubChildKey.Value, CultureInfo.InvariantCulture);
                        }
                        else if (itemSubChildKey.Name.Equals(PaintInfo.SubKeyWearMin, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.WearMinLevel = float.Parse(itemSubChildKey.Value, CultureInfo.InvariantCulture);
                        }
                        else if (itemSubChildKey.Name.Equals(PaintInfo.SubKeyWearMax, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.WearMaxLevel = float.Parse(itemSubChildKey.Value, CultureInfo.InvariantCulture);
                        }
                    }

                    foreach (var itemDict in paintKitsRarityDic)
                    {
                        if (def.Name.Equals(itemDict.Key))
                        {
                            def.Rarity = itemDict.Value;
                            break;
                        }
                    }
                    returnValue.Add(def);
                }
            }

            return returnValue;
        }

        public List<MusicInfo> GetAllMusics()
        {
            KeyValue result = this.Read(MusicInfo.KeyName);
            List<MusicInfo> returnValue = new List<MusicInfo>();
            MusicInfo def;

            if (result != null)
            {
                foreach (var subChildKey in result.Children)
                {
                    def = new MusicInfo();
                    def.CodedValue = int.Parse(subChildKey.Name);

                    foreach (var itemSubChildKey in subChildKey.Children)
                    {
                        if (itemSubChildKey.Name.Equals(MusicInfo.SubKeyName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.Name = itemSubChildKey.Value;
                        }
                        else if (itemSubChildKey.Name.Equals(MusicInfo.SubKeyDesc, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.Description = itemSubChildKey.Value;
                        }
                    }
                    returnValue.Add(def);
                }
            }

            return returnValue;
        }

        public void Close()
        {
            _csgoKvFile.Close();
        }

        public SortedList<int, StickerInfo> GetSortedAllStickerInfo()
        {
            KeyValue result = this.Read(StickerInfo.KeyName);
            SortedList<int, StickerInfo> returnValue = new SortedList<int, StickerInfo>();
            StickerInfo def;

            if (result != null)
            {
                foreach (var subChildKey in result.Children)
                {
                    def = new StickerInfo();
                    def.CodedValue = int.Parse(subChildKey.Name);

                    foreach (var itemSubChildKey in subChildKey.Children)
                    {
                        if (itemSubChildKey.Name.Equals(StickerInfo.SubKeyName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.CodedName = itemSubChildKey.Value;
                        }
                        else if (itemSubChildKey.Name.Equals(StickerInfo.SubKeyDesc, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.Description = itemSubChildKey.Value;
                        }
                    }
                    returnValue.Add(def.CodedValue, def);
                }
            }

            return returnValue;
        }

        public SortedList<int, AttributeInfo> GetSortedAllAttributeInfo()
        {
            KeyValue result = this.Read(AttributeInfo.KeyName);
            SortedList<int, AttributeInfo> returnValue = new SortedList<int, AttributeInfo>();
            AttributeInfo def;

            if (result != null)
            {
                foreach (var subChildKey in result.Children)
                {
                    def = new AttributeInfo();

                    //skip the first "default" subkey
                    if (subChildKey.Name.Equals("default", StringComparison.CurrentCultureIgnoreCase))
                    {
                        continue;
                    }
                    else
                    {
                        def.CodedValue = int.Parse(subChildKey.Name);
                    }

                    foreach (var itemSubChildKey in subChildKey.Children)
                    {
                        if (itemSubChildKey.Name.Equals(AttributeInfo.SubKeyCodedName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.CodedName = itemSubChildKey.Value;
                        }
                        else if (itemSubChildKey.Name.Equals(AttributeInfo.SubKeyRealName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            def.RealName = itemSubChildKey.Value;
                        }
                        else if (itemSubChildKey.Name.Equals(AttributeInfo.IsIntegerStr, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (itemSubChildKey.Value.Equals("1", StringComparison.CurrentCultureIgnoreCase))
                            {
                                def.IsInteger = true;
                            }
                            else
                            {
                                def.IsInteger = false;
                            }
                        }
                        else if (itemSubChildKey.Name.Equals(AttributeInfo.IsStringStr, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (itemSubChildKey.Value.Equals("string", StringComparison.CurrentCultureIgnoreCase))
                            {
                                def.IsString = true;
                            }
                            else
                            {
                                def.IsString = false;
                            }
                        }
                    }
                    returnValue.Add(def.CodedValue, def);
                }
            }

            return returnValue;
        }
    }
}
