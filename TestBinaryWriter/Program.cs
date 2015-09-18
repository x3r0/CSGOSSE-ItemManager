using System;
using System.IO;
using ItemEditor;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using ProtoBuf;
using SteamKit2.GC.Internal;

namespace TestBinaryWriter
{
    class Program
    {
        const string fileName = "test.bin";

        static void Main()
        {
            WriteDefaultValues();
            //DisplayValues();
        }

        public static void WriteDefaultValues()
        {
            SSEHeader header = new SSEHeader();
            ItemData dataHeader = new ItemData();

            header.FileHeader = "SSEItem";
            header.ItemCount = 4;

            List<ItemAttribute> attribsWeapon1 = new List<ItemAttribute>();

            ItemAttribute attribWeapon1 = new ItemAttribute();

            attribWeapon1.Id = 6;
            attribWeapon1.ValueByte = 266.0f;

            attribsWeapon1.Add(attribWeapon1);

            attribWeapon1 = new ItemAttribute();

            attribWeapon1.Id = 80;
            attribWeapon1.ValueByte = 0;

            attribsWeapon1.Add(attribWeapon1);

            attribWeapon1 = new ItemAttribute();

            attribWeapon1.Id = 81;
            attribWeapon1.ValueByte = 0;

            attribsWeapon1.Add(attribWeapon1);


            List<ItemAttribute> attribsWeapon2 = new List<ItemAttribute>();

            ItemAttribute attribWeapon2 = new ItemAttribute();

            attribWeapon2.Id = 6;
            attribWeapon2.ValueByte = BitConverter.ToSingle(new byte[] { 0x00, 0x00, 0x16, 0x42 }, 0);

            attribsWeapon2.Add(attribWeapon2);

            attribWeapon2 = new ItemAttribute();

            attribWeapon2.Id = 80;
            attribWeapon2.ValueByte = 0;

            attribsWeapon2.Add(attribWeapon2);

            attribWeapon2 = new ItemAttribute();

            attribWeapon2.Id = 82;
            attribWeapon2.ValueByte = 0;

            attribsWeapon2.Add(attribWeapon2);

            List<ItemAttribute> attribsMusic = new List<ItemAttribute>();

            ItemAttribute attribMusic = new ItemAttribute();

            attribMusic.Id = 113;
            attribMusic.ValueByte = 5;

            attribsMusic.Add(attribMusic);

            List<ItemAttribute> attribsSticker = new List<ItemAttribute>();

            ItemAttribute attribSticker = new ItemAttribute();

            attribSticker.Id = 166;
            attribSticker.ValueByte = 3;

            attribsSticker.Add(attribSticker);
            
            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                // id, inventory, quality, rarity, level, def_index, {attrs}
                Write(stream, header);
                // weapons 0 0 4 2 1 4 6=00008543 80=00000000 81=00000000
                CreateItem(4, 4, 2, 1, attribsWeapon1, stream, dataHeader);

                // weapon 0 0 4 2 1 16 6=00001642 80=00000000 81=00000000
                CreateItem(16, 4, 2, 1, attribsWeapon2, stream, dataHeader);

                // sticker 0 0 0 0 0 1209 113=02000000
                CreateItem(1209, 0, 0, 0, attribsMusic, stream, dataHeader);

                // music kit 0 0 0 0 0 1314 166=03000000
                CreateItem(1314, 0, 0, 0, attribsSticker, stream, dataHeader);
            }
        }

        public static void CreateItem(uint def_index, uint quality,
            uint rarity, uint level, List<ItemAttribute> attribs, Stream file, ItemData dataHeader)
        {
            CSGOItemProto econItem = new CSGOItemProto();
            
            econItem.id = 0;
            econItem.inventory = 0;
            econItem.def_index = def_index;
            econItem.level = level;
            econItem.rarity = rarity;
            econItem.quality = quality;
            econItem.flags = 0;
            econItem.origin = 0;

            econItem.attribute = new List<CSOEconItemAttribute>();

            foreach (var attrib in attribs)
            {
                CSOEconItemAttribute itemAttribute = new CSOEconItemAttribute();

                itemAttribute.def_index = attrib.Id;
                itemAttribute.value_bytes = BitConverter.GetBytes(attrib.ValueByte);

                econItem.attribute.Add(itemAttribute);
            }

            dataHeader.Type = 1;
            dataHeader.Length = CalcProtoBufSize(econItem);

            Write(file, dataHeader);

            Serializer.Serialize<CSGOItemProto>(file, econItem);
        }

        /// <summary>
        /// Proto Buf Calculation
        /// </summary>
        /// <param name="oObj"></param>
        /// <returns></returns>
        private static int CalcProtoBufSize(object oObj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(ms, oObj);
                return ms.ToArray().Length;
            }
        }

        static void Write(Stream stream, object o)
        {
            int objectSize = Marshal.SizeOf(o.GetType());
            byte[] buffer = new byte[objectSize];
            GCHandle gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(o, gcHandle.AddrOfPinnedObject(), true);
            stream.Write(buffer, 0, buffer.Length);
            gcHandle.Free();
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
            char[] fileHeader;
            UInt32 itemCount;

            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    fileHeader = reader.ReadChars(8);
                    itemCount = reader.ReadUInt32();
                }

                string strFileHeader = new string(fileHeader);

                Console.WriteLine("Header set to: " + strFileHeader);
                Console.WriteLine("Item count is: " + itemCount);

                Console.ReadLine();
            }
        }
    }
}
