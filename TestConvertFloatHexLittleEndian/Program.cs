using System;
using System.Text;
namespace Text
{
    class Program
    {
        static void Main()
        {
            float f = 2.0f;

            byte[] result = BitConverter.GetBytes(f);

            Console.WriteLine(BitConverter.IsLittleEndian);

            string hex = ByteArrayToString(BitConverter.GetBytes(f));

            Console.WriteLine(hex);

            Console.ReadLine();
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}