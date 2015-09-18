using CsgoItemDataType;
using ProtoBuf;
using SteamKit2.GC.Internal;
using System;
using System.Collections.Generic;
using System.IO;

namespace ItemEditor
{
    internal class InventoryReader
    {
        private SSEHeader _header;
        private FileStream _stream;

        internal InventoryReader(FileStream stream)
        {
            _stream = stream;
            DataHeaderList = new List<ItemData>();
        }

        /// <summary>
        ///     List of ItemData that are read from items_730.bin
        /// </summary>
        /// <value>
        ///     <para>
        ///         
        ///     </para>
        /// </value>
        /// <remarks>
        ///     Value is public, but only this class will be able to edit it
        /// </remarks>
        internal List<ItemData> DataHeaderList
        {
            get;
            private set;
        }

        /// <summary>
        ///     List of CSGOItemProto that are read from items_730.bin
        /// </summary>
        /// <value>
        ///     <para>
        ///         
        ///     </para>
        /// </value>
        /// <remarks>
        ///     Value is public, but only this class will be able to edit it
        /// </remarks>
        internal List<CSGOItemProto> ItemCsgoList
        {
            get
            {
                return ReadItemHeaderAndData();
            }
        }

        internal int GetItemCount()
        {
            int itemCount = 0;

            if (_stream.CanRead)
            {
                _stream.Position = 0;
            }

            _header = (SSEHeader)BinaryFileHelper.Read(_stream, typeof(SSEHeader));

            if (_header.ItemCount > 0)
            {
                return itemCount = Convert.ToInt32(_header.ItemCount);
            }

            return itemCount;
        }

        /// <summary>
        ///     Read stream of items_730.bin from Items730 stream into DataHeaderList and ItemCsgoList
        ///     To be used after calling VerifyHeader()
        /// </summary>
        internal List<CSGOItemProto> ReadItemHeaderAndData()
        {
            List<CSGOItemProto> returnValue = new List<CSGOItemProto>();
            BinaryReader reader;
            int itemCount = this.GetItemCount();
            ItemData dataHeader;
            CSGOItemProto csgoItem;
            
            for (int i = 0; i < itemCount; i++)
            {
                dataHeader = (ItemData)BinaryFileHelper.Read(_stream, typeof(ItemData));

                if (this.IsDataHeaderValid(dataHeader))
                {
                    DataHeaderList.Add(dataHeader);

                    csgoItem = new CSGOItemProto();

                    byte[] bufferByte = new byte[dataHeader.Length];

                    reader = new BinaryReader(_stream);

                    int byteToRead = Convert.ToInt32(dataHeader.Length);
                    int startingPosition = Convert.ToInt32(_stream.Position);

                    reader.Read(bufferByte, 0, byteToRead);

                    MemoryStream tempMemStream = new MemoryStream(bufferByte);

                    csgoItem = Serializer.Deserialize<CSGOItemProto>(tempMemStream);
                    returnValue.Add(csgoItem);
                }
            }

            return returnValue;
        }

        /// <summary>
        ///     Verify read dataheader
        /// </summary>
        /// <param name="dataHeader" type="ItemEditor.ItemData">
        ///     <para>
        ///         A ItemData struct to be verified
        ///     </para>
        /// </param>
        /// <returns>
        ///     True if it's valid, false otherwise
        /// </returns>
        private bool IsDataHeaderValid(ItemData dataHeader)
        {
            if (dataHeader.Type != 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
