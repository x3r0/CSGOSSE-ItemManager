using System;
using System.Collections.Generic;
using ProtoBuf;
using SteamKit2.GC.Internal;
using System.ComponentModel;

namespace CsgoItemDataType
{
    /// <summary>
    ///     Use to store item structure before it gets serialized by protobuf
    /// </summary>
    /// <remarks>
    ///     
    /// </remarks>
    [ProtoContract]
    public class CSGOItemProto
    {
        public CSGOItemProto()
        {
            attribute = new List<CSOEconItemAttribute>();
            equipped_state = new List<CSOEconItemEquipped>();
        }

        /// <summary>
        ///     Item ID, which should be filled as 0 for SSE to be recognized as new item
        /// </summary>
        /// <value>
        ///     <para>
        ///         
        ///     </para>
        /// </value>
        /// <remarks>
        ///     
        /// </remarks>
        [ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(0)]
        public int id { get; set; }

        /// <summary>
        ///     Account ID, 0 as default, will be filled by SSE later
        /// </summary>
        /// <value>
        ///     <para>
        ///         
        ///     </para>
        /// </value>
        /// <remarks>
        ///     
        /// </remarks>
        [ProtoMember(2, IsRequired = false, Name = "account_id", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(0)]
        public int account_id { get; set; }

        [ProtoMember(3, IsRequired = false, Name = "inventory", DataFormat = DataFormat.TwosComplement)]
        public int inventory { get; set; }

        /// <summary>
        ///     Item type, for CSGO see "items" key inside item_games.txt
        /// </summary>
        /// <value>
        ///     <para>
        ///         
        ///     </para>
        /// </value>
        /// <remarks>
        ///     
        /// </remarks>
        [ProtoMember(4, IsRequired = false, Name = "def_index", DataFormat = DataFormat.TwosComplement)]
        public int def_index { get; set; }

        [ProtoMember(5, IsRequired = false, Name = "quantity", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(1)]
        public int quantity { get; set; }

        [ProtoMember(6, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(1)]
        public int level { get; set; }

        [ProtoMember(7, IsRequired = false, Name = "quality", DataFormat = DataFormat.TwosComplement)]
        public int quality { get; set; }

        [ProtoMember(8, IsRequired = false, Name = "flags", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(0)]
        public int flags { get; set; }

        [ProtoMember(9, IsRequired = false, Name = "origin", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(0)]
        public int origin { get; set; }

        /// <summary>
        ///     For CSGO, change name of item using name tag attribute (ID 111)
        /// </summary>
        /// <value>
        ///     <para>
        ///         
        ///     </para>
        /// </value>
        /// <remarks>
        ///     Need change item name using a name tag
        /// </remarks>
        [ProtoMember(10, IsRequired = false, Name = "custom_name", DataFormat = DataFormat.TwosComplement)]
        public string custom_name { get; set; }

        [ProtoMember(11, IsRequired = false, Name = "custom_desc", DataFormat = DataFormat.TwosComplement)]
        public string custom_desc { get; set; }

        /// <summary>
        ///     List of attribute that the item has, see "attributes" key inside item_games.txt
        /// </summary>
        /// <value>
        ///     <para>
        ///         
        ///     </para>
        /// </value>
        /// <remarks>
        ///     
        /// </remarks>
        [ProtoMember(12, Name = "attribute", DataFormat = DataFormat.Default)]
        public List<SteamKit2.GC.Internal.CSOEconItemAttribute> attribute { get; set; }

        [ProtoMember(13, IsRequired = false, Name = "interior_item", DataFormat = DataFormat.Default)]
        public CSGOItemProto interior_item { get; set; }

        [ProtoMember(14, IsRequired = false, Name = "in_use", DataFormat = DataFormat.Default)]
        public bool in_use { get; set; }

        [ProtoMember(15, IsRequired = false, Name = "style", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue(0)]
        public int style { get; set; }

        [ProtoMember(16, IsRequired = false, Name = "original_id", DataFormat = DataFormat.TwosComplement)]
        [DefaultValue("0")]
        public long original_id { get; set; }

        [ProtoMember(18, Name = "equipped_state", DataFormat = DataFormat.Default)]
        public List<CSOEconItemEquipped> equipped_state { get; set; }

        /// <summary>
        ///     Item's rarity type, CSGO only (?), see "rarity" key inside item_games.txt
        /// </summary>
        /// <value>
        ///     <para>
        ///         
        ///     </para>
        /// </value>
        /// <remarks>
        ///     
        /// </remarks>
        [ProtoMember(19, IsRequired = false, Name = "rarity", DataFormat = DataFormat.TwosComplement)]
        public int rarity { get; set; }

    }
}
