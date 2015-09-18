using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsgoItemDataType;
using CsgoItemDataType.FriendlyDataType;
using SteamKit2.GC.Internal;

namespace ItemEditor
{
    /// <summary>
    ///     Helper class to search particular string, batch add multiple/random items, etc
    /// </summary>
    /// <remarks>
    ///     
    /// </remarks>
    public class InventoryManager
    {
        private InventoryReader _reader;
        private InventoryWriter _writer;

        private FileStream _stream;

        public InventoryManager(string filePath)
        {
            _stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
            _reader = new InventoryReader(_stream);
            _writer = new InventoryWriter(_stream);
        }

        internal void Close()
        {
            _stream.Close();
        }

        public bool IsClosed
        {
            get 
            {
                return !_stream.CanWrite;
            }
        }

        /// <summary>
        ///     Number of items that is stored inside items_730.bin
        /// </summary>
        /// <value>
        ///     <para>
        ///         
        ///     </para>
        /// </value>
        /// <remarks>
        ///     Value is public, but only this class will be able to edit it
        /// </remarks>
        public int ItemCount
        {
            get
            {
                return _reader.GetItemCount();
            }
        }

        public void WriteItems(List<CompleteItemInfo> itemList)
        {
            foreach (CompleteItemInfo item in itemList)
            {
                if (item.IsChanged)
                {
                    _writer.AddNewItem(item.Item.CodedValue, item.Quality.Value, item.Rarity.CodedValue,
                        0, item.CustomName, item.CompleteAttributes);
                }
                else
                {
                    _writer.AddNewItem(item.ItemProto, item.CompleteAttributes);
                }
            }

            _writer.WriteChangesToFile();
        }

        public List<CSGOItemProto> GetAllInventories()
        {
            return _reader.ItemCsgoList;
        }
    }
}
