using System;
using ValveKvReader;
using System.IO;
using System.Collections.Generic;
using CsgoItemDataType;

namespace TestReadKvFile
{
    class Program
    {
        static void Main(string[] args)
        {
            CsgoItemsGameFileParser test = new CsgoItemsGameFileParser(@"c:\items_game.txt");

            if (test.IsValid)
            {
                foreach (var item in test.GetOfficialItems())
                {
                    Console.WriteLine("Item = {0} : Paint = {1}", item.Item1.CodedName, item.Item2.Name);
                }
            }
            else
            {
                Console.WriteLine("Invalid file!");
            }

            Console.ReadLine();
        }
    }
}
