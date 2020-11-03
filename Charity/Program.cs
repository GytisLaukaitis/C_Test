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
            ReadShoesFromFile2();

            const bool exit = false;
            
            Console.WriteLine("Welcome to our charity. Choose from your options below:");
            Menu();
            while (true)
            {
                Console.WriteLine("------------------------------------------------");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ShowShoes();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;
                    case "2":
                        ShowShoes2();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;
                    case "3":
                        KidsShoes();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;
                    case "4":
                        AddShoesToCharity();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;
                    case "5":
                        AddShoesToCharity2();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;
                    case "6":
                        MoreShoesForAdults();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;
                    case "7":
                        RemoveSatisfyableShoes();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;
                    case "8":
                        SortingShoes();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;
                    case "9":
                        Exit();
                        break;
                }
            }


            SortingShoes();
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

        private static void KidsShoes()
        {
            var kidsShoes = _shoes.Union(_shoes2)
                .Where(shoe => shoe.Type.ToLower().Contains("kids") && shoe.Season.ToLower().Contains("winter"))
                .OrderBy(shoe => shoe.Size)
                .ToList();

            Console.WriteLine();
            Console.WriteLine("Winter shoes for kids list:");
            Console.WriteLine();
            foreach (var shoe in kidsShoes)
            {
                Console.WriteLine(shoe);
            }
        }

        private static void SortingShoes()
        {
            var sortedBy = _shoes.OrderBy(shoe => shoe.Size).ToList();
            var sortedBy2 = _shoes2.OrderBy(shoe2 => shoe2.Size).ToList();

            Console.WriteLine("Sorted by shoe size Charity 1 list");
            foreach (var shoe in sortedBy)
            {
                Console.WriteLine(shoe);
            }

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Sorted by shoe size Charity 2 list");
            foreach (var shoe2 in sortedBy2)
            {
                Console.WriteLine(shoe2);
            }
        }

        // Removes all shoes with satisfyable condition
        private static void RemoveSatisfyableShoes()
        {
            _shoes.RemoveAll(shoe => shoe.Condition.ToLower().Contains("satisfyable"));
            _shoes2.RemoveAll(shoe2 => shoe2.Condition.ToLower().Contains("satisfyable"));
        }

        // Lets donate some more shoes to Charity 1
        private static void AddShoesToCharity()
        {
            Console.WriteLine(
                "So nice of you, what type of shoes you would like to donate? Choose from man,woman,kids");
            string type = Console.ReadLine();
            Console.WriteLine("Which season it fits the most? Choose from spring,summer,autumn,winter");
            string season = Console.ReadLine();
            Console.WriteLine("What size is it?");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("What color is it?");
            string color = Console.ReadLine();
            Console.WriteLine("Choose condition from: very good,good,satisfyable");
            string condition = Console.ReadLine();
            Shoe batai = new Shoe(type, season, size, color, condition);
            _shoes.Add(batai);
        }

        // Lets donate some more shoes to Charity 2
        private static void AddShoesToCharity2()
        {
            Console.WriteLine(
                "So nice of you, what type of shoes you would like to donate? Choose from man,woman,kids");
            string type = Console.ReadLine();
            Console.WriteLine("Which season it fits the most? Choose from spring,summer,autumn,winter");
            string season = Console.ReadLine();
            Console.WriteLine("What size is it?");
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("What color is it?");
            string color = Console.ReadLine();
            Console.WriteLine("Choose condition from: very good,good,satisfyable");
            string condition = Console.ReadLine();
            Shoe batai = new Shoe(type, season, size, color, condition);
            _shoes2.Add(batai);
        }

        // Show menu
        private static void Menu()
        {
            Console.WriteLine("1:Show all shoes in Charity 1");
            Console.WriteLine("2:Show all shoes in Charity 2");
            Console.WriteLine("3:Show all Winter shoes for Kids");
            Console.WriteLine("4:Donate shoes to Charity 1");
            Console.WriteLine("5:Donate shoes to Charity 2");
            Console.WriteLine("6:Show which charity has more shoes for Adults");
            Console.WriteLine("7:Remove shoes with 'Satisfyable' quality ");
            Console.WriteLine("8:Sort shoes by their size");
            Console.WriteLine("9:Exit program");
        }

        // Exit program
        private static void Exit()
        {
            Environment.Exit(0);
        }
    }
}