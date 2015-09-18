using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using ItemEditor;
using ProtoBuf;
using SteamKit2.GC.CSGO.Internal;
using SteamKit2.GC.Internal;

namespace TestBinaryReader
{
    class Program
    {
        const string fileName = "items_730s.bin";
        static SSEHeader header = new SSEHeader();
        static List<ItemData> dataHeaderList = new List<ItemData>();
        static List<CSOEconItem> itemCsgoList = new List<CSOEconItem>();

        static void Main()
        {
            ReadFile();
            DisplayValues();
        }

        private static void ReadFile()
        {
            BinaryReader reader;
            using (Stream stream = File.OpenRead(fileName))
            {
                header = (SSEHeader) Read(stream, typeof(SSEHeader));

                for (int i = 0; i < header.ItemCount; i++)
                {
                    ItemData dataHeader;

                    dataHeader = (ItemData)Read(stream, typeof(ItemData));
                    dataHeaderList.Add(dataHeader);

                    CSOEconItem csgoItem = new CSOEconItem();
                    //csgoItem.attribute = new List<CSOEconItemAttribute>();

                    byte[] bufferByte = new byte[dataHeader.Length];

                    reader = new BinaryReader(stream);
                    
                    int byteToRead = Convert.ToInt32(dataHeader.Length);
                    int startingPosition = Convert.ToInt32(stream.Position);

                    reader.Read(bufferByte, 0, byteToRead);

                    MemoryStream tmpMemStream = new MemoryStream(bufferByte);

                    csgoItem = Serializer.Deserialize<CSOEconItem>(tmpMemStream);
                    itemCsgoList.Add(csgoItem);
                }
            }
        }
        
        static object Read(Stream stream, Type t)
        {
            byte[] buffer = new byte[Marshal.SizeOf(t)];
            for (int read = 0; read < buffer.Length; read += stream.Read(buffer, read, buffer.Length)) ;
                GCHandle gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            object o = Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject(), t);
            gcHandle.Free();
            return o;
        }

        public static void DisplayValues()
        {
            dynamic attributeValue;

            if (File.Exists(fileName))
            {
                Console.WriteLine("Header set to: " + header.FileHeader);
                Console.WriteLine("Item count is: " + header.ItemCount);

                for (int i = 0; i < dataHeaderList.Count; i++)
                {
                    Console.WriteLine("Item binary length: " + dataHeaderList[i].Length);
                    Console.WriteLine("Item def_index: " + itemCsgoList[i].def_index);
                    Console.WriteLine("Item quality: " + itemCsgoList[i].quality);
                    Console.WriteLine("Item rarity: " + itemCsgoList[i].style);
                    Console.WriteLine("Item level: " + itemCsgoList[i].level);

                    if (itemCsgoList[i].attribute != null)
                    {
                        foreach (var attrib in itemCsgoList[i].attribute)
                        {
                            Console.WriteLine("Item attribute def_index: " + attrib.def_index);

                            switch (attrib.def_index)
                            {
                                case 6:
                                    attributeValue = BitConverter.ToSingle(attrib.value_bytes, 0);
                                    break;
                                case 80:
                                    attributeValue = BitConverter.ToUInt32(attrib.value_bytes, 0);
                                    break;
                                case 81:
                                    attributeValue = BitConverter.ToUInt32(attrib.value_bytes, 0);
                                    break;
                                case 113:
                                    attributeValue = BitConverter.ToUInt32(attrib.value_bytes, 0);
                                    break;
                                case 166:
                                    attributeValue = BitConverter.ToUInt32(attrib.value_bytes, 0);
                                    break;
                                default:
                                    attributeValue = BitConverter.ToUInt32(attrib.value_bytes, 0);
                                    break;
                            }
                            Console.WriteLine("Item attribute value_bytes: " + attributeValue);
                        }
                    }
                    Console.WriteLine("============================\n");
                }

                Console.ReadLine();
            }
        }

    }
}
