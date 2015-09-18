using CsgoItemDataType;
using ProtoBuf;
using SteamKit2.GC.Internal;
using System;
using System.Collections.Generic;
using System.IO;

namespace ItemEditor
{
    internal class InventoryWriter
    {
        private FileStream _stream;
        private SSEHeader _header = new SSEHeader();
        private List<Tuple<ItemData, CSGOItemProto>> _itemList = new List<Tuple<ItemData, CSGOItemProto>>();

        internal InventoryWriter(FileStream stream)
        {
            _stream = stream;
        }

        internal void AddNewItem(CSGOItemProto itemProto, Dictionary<AttributeInfo, CSOEconItemAttribute> attributeAndValue)
        {
            CSGOItemProto econItem = new CSGOItemProto();

            econItem = itemProto;

            foreach (var attrib in attributeAndValue)
            {
                econItem.attribute.Add(attrib.Value);
            }

            ItemData dataHeader = new ItemData();

            dataHeader.Type = 1;
            dataHeader.Length = CalcProtoBufSize(econItem);

            _itemList.Add(new Tuple<ItemData, CSGOItemProto>(dataHeader, econItem));
        }

        /// <summary>
        ///     Add new item into items_730.bin
        /// </summary>
        /// <param name="itemType" type="KvFileReader.ItemInfo">
        ///     <para>
        ///         Type of item to be added
        ///     </para>
        /// </param>
        /// <param name="quality" type="KvFileReader.QualityInfo">
        ///     <para>
        ///         Quality of the item
        ///     </para>
        /// </param>
        /// <param name="rarity" type="KvFileReader.RarityInfo">
        ///     <para>
        ///         Rarity of the item
        ///     </para>
        /// </param>
        /// <param name="level" type="int">
        ///     <para>
        ///         Level of the item
        ///     </para>
        /// </param>
        /// <param name="attributeAndValue" type="System.Collections.Generic.Dictionary<KvFileReader.AttributeInfo,dynamic>">
        ///     <para>
        ///         Dictionary of item's attributes and their values
        ///     </para>
        /// </param>
        internal void AddNewItem(int codedValueItemType, int codedValueQuality,
            int codedValueRarity, int level, string customName, Dictionary<AttributeInfo, CSOEconItemAttribute> attributeAndValue)
        {
            CSGOItemProto econItem = new CSGOItemProto();

            //NOTE: must be filled with 0 as SSE will fill it later
            econItem.id = 0;
            econItem.inventory = 0;
            econItem.flags = 0;
            econItem.origin = 0;

            econItem.custom_name = customName;
            econItem.def_index = codedValueItemType;
            econItem.level = level;
            econItem.rarity = codedValueRarity;
            econItem.quality = codedValueQuality;

            foreach (var attrib in attributeAndValue)
            {
                econItem.attribute.Add(attrib.Value);
            }

            ItemData dataHeader = new ItemData();

            dataHeader.Type = 1;
            dataHeader.Length = CalcProtoBufSize(econItem);

            _itemList.Add(new Tuple<ItemData, CSGOItemProto>(dataHeader, econItem));
        }

        /// <summary>
        ///     Proto Buf Calculation
        /// </summary>
        /// <param name="o" type="object">
        ///     <para>
        ///         Protobuf Serialized data
        ///     </para>
        /// </param>
        /// <returns>
        ///     Serialized data length
        /// </returns>
        private int CalcProtoBufSize(object o)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, o);
                return ms.ToArray().Length;
            }
        }

        internal void WriteChangesToFile()
        {
            _header.FileHeader = "SSEItem";
            _header.ItemCount = _itemList.Count;

            _stream.Position = 0;

            BinaryFileHelper.Write(_stream, _header);

            foreach (var item in _itemList)
            {
                BinaryFileHelper.Write(_stream, item.Item1);
                Serializer.Serialize<CSGOItemProto>(_stream, item.Item2);
            }

            _stream.Close();
        }
    }
}
