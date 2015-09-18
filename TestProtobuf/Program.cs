using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ProtoBuf;

namespace TestProtobuf
{
    [Serializable]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }

    [Serializable]
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
    }

    [ProtoContract]
    public class ProtoPerson
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public ProtoAddress Address { get; set; }
    }

    [ProtoContract]
    public class ProtoAddress
    {
        [ProtoMember(1)]
        public string Line1 { get; set; }
        [ProtoMember(2)]
        public string Line2 { get; set; }
    }


    class Program
    {
        /// <summary>
        /// Standard Size Calc
        /// </summary>
        /// <param name="oObj"></param>
        /// <returns></returns>
        private static int CalcSize(object oObj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, oObj);
                return ms.ToArray().Length;
            }
        }

        /// <summary>
        /// Standard Serialization
        /// </summary>
        /// <param name="oObj"></param>
        /// <param name="sFile"></param>
        private static void SerializeData(object oObj, string sFile)
        {
            using (var file = File.Create(sFile))
            {
                new BinaryFormatter().Serialize(file, oObj);
                file.Close();
            }
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

        /// <summary>
        /// Proto Buf Serialization
        /// </summary>
        /// <param name="oObj"></param>
        /// <param name="sFile"></param>
        private static void SerializeProtoData(object oObj, string sFile)
        {
            using (var file = File.Create(sFile))
            {
                ProtoBuf.Serializer.Serialize(file, oObj);
            }
        }

        static void Main(string[] args)
        {
            Address oAddress = new Address { Line1 = "Street No. 5, Goes Here", Line2 = "Area, City, State Zip" };
            Person oPerson = new Person { Id = 1, Name = "Test Name Goes Here", Address = oAddress };

            ProtoAddress oPAddress = new ProtoAddress { Line1 = "Street No. 5, Goes Here", Line2 = "Area, City, State Zip" };
            ProtoPerson oPPerson = new ProtoPerson { Id = 1, Name = "Test Name Goes Here", Address = oPAddress };

            Console.WriteLine(" ");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Object Size Without Google Protocol Buffers");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Person Object Size - " + CalcSize(oPerson));
            Console.WriteLine("Person Object Size Without Address - " + (CalcSize(oPerson) - CalcSize(oAddress)));
            Console.WriteLine("Address Object Size - " + CalcSize(oAddress));
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Serializing Without Google Protocol Buffers");
            Console.WriteLine("------------------------------------------------------------------");
            SerializeData(oPerson, "person.bin");
            SerializeData(oAddress, "address.bin");

            Console.WriteLine(" ");

            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Object Size using Google Protocol Buffers");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Person Object Size - " + CalcProtoBufSize(oPPerson));
            Console.WriteLine("Person Object Size Without Address - " + (CalcProtoBufSize(oPPerson) - CalcProtoBufSize(oPAddress)));
            Console.WriteLine("Address Object Size - " + CalcProtoBufSize(oPAddress));

            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Serializing With Google Protocol Buffers");
            Console.WriteLine("------------------------------------------------------------------");
            SerializeProtoData(oPPerson, "person.proto.bin");
            SerializeProtoData(oPAddress, "address.proto.bin");
            Console.WriteLine(" ");

            Console.ReadLine();
            return;
        }
    }
}