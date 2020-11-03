using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Charity
{
    internal class Program
    {
        private static List<Shoe> _shoes = new List<Shoe>();

        private static List<Shoe> _shoes2 = new List<Shoe>();
        
        


        public static void Main(string[] args)
        {
            ReadShoesFromFile1();
            ShowShoes();
            Console.WriteLine("------------------------------------------------");
            ReadShoesFromFile2();
            ShowShoes2();
            MoreShoesForAdults();
          
        }

        // Reading all shoes from a file 1
        private static void ReadShoesFromFile1()
        {
            const int bufferSize = 128;
            using (var fileStream = File.OpenRead("C:/Users/gytis/RiderProjects/Solution1/Charity/Charity.csv"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize))
            {
                string line;
                var csvSplitBy = Convert.ToChar(",".Trim());
                while ((line = streamReader.ReadLine()) != null)
                {
                    var chunks = line.Split(csvSplitBy);

                    if (chunks.Length < 4)
                    {
                        var title = line;
                        Console.WriteLine(title);
                    }
                    else
                    {
                        _shoes.Add(new Shoe(chunks[0].Trim(), chunks[1].Trim(), int.Parse(chunks[2].Trim()),
                            chunks[3].Trim(),
                            chunks[4].Trim()));
                    }
                }
            }
        }

        // Reading all shoes from a file 2
        private static void ReadShoesFromFile2()
        {
            const int bufferSize = 128;
            using (var fileStream = File.OpenRead("C:/Users/gytis/RiderProjects/Solution1/Charity/Charity2.csv"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize))
            {
                string line;
                var csvSplitBy = Convert.ToChar(",".Trim());
                while ((line = streamReader.ReadLine()) != null)
                {
                    var chunks = line.Split(csvSplitBy);

                    if (chunks.Length < 4)
                    {
                        var title = line;
                        Console.WriteLine(title);
                    }
                    else
                    {
                        _shoes2.Add(new Shoe(chunks[0].Trim(), chunks[1].Trim(), int.Parse(chunks[2].Trim()),
                            chunks[3].Trim(),
                            chunks[4].Trim()));
                    }
                }
            }
        }

        // Display all shoes in charity 1
        private static void ShowShoes()
        {
            foreach (var shoe in _shoes)
            {
                Console.WriteLine(shoe.ToString());
            }
        }


        // Display all shoes in charity 2
        private static void ShowShoes2()
        {
            foreach (var shoe in _shoes2)
            {
                Console.WriteLine(shoe.ToString());
            }
        }

        // Checking which charity has more shoes for adults
        private static void MoreShoesForAdults()
        {
            var shoes = from shoe in _shoes
                where shoe.Type.ToLower().Contains("woman") || shoe.Type.ToLower().Contains("man")
                select shoe;
            
            
            var shoes2 = from shoe2 in _shoes2
                where shoe2.Type.ToLower().Contains("woman") || shoe2.Type.ToLower().Contains("man")
                select shoe2;

            
            Console.WriteLine(shoes.Count() > shoes2.Count()
                ? "Charity 1 has more shoes for adults"
                : "Charity 2 has more shoes for adults");
        }
        
        // Kids shoes for winter from both charities

        private static List<Shoe> KidsShoes()
        {
            var kidsShoes = from kidsShoe in _shoes
                where kidsShoe.Type.ToLower().Contains("kids") && kidsShoe.Season.ToLower().Contains("winter")
                    select kidsShoe;

            return kidsShoes.ToList();
        }
    }
}