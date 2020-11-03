using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Charity
{
    internal class Program
    {
        private static List<Shoe> shoes = new List<Shoe>();


        public static void Main(string[] args)
        {
            readShoesFromFile();
            foreach (var shoe in shoes)
            {
                Console.WriteLine(shoe.ToString());
            }
        }

        private static void readShoesFromFile()
        {
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead("C:/Users/gytis/RiderProjects/Solution1/Charity/Charity.csv"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                char csvSplitBy = Convert.ToChar(",".Trim());
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] chunks = line.Split(csvSplitBy);


                    shoes.Add(new Shoe(chunks[0].Trim(), chunks[1].Trim(), int.Parse(chunks[2].Trim()),
                        chunks[3].Trim(),
                        chunks[4].Trim()));
                }
            }
        }
    }
}