using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Charity
{
    internal static class Program
    {
        private static readonly List<Shoe> Shoes = new List<Shoe>();

        private static readonly List<Shoe> Shoes2 = new List<Shoe>();


        public static void Main()
        {
            ReadShoesFromFiles();
            ReadShoesFromFiles2();

            Console.WriteLine("Welcome to our charity. Choose from your options below:");
            Menu();
            while (true)
            {
                Console.WriteLine("------------------------------------------------");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ShowShoesInCharities();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;
                    case "2":
                        KidsShoes();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;
                    case "3":
                        AddShoesToCharity();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;
                    case "4":
                        AddShoesToCharity2();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;
                    case "5":
                        MoreShoesForAdults();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;
                    case "6":
                        RemoveSatisfyableShoes();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;
                    case "7":
                        SortingShoes();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;
                    case "8":
                        Exit();
                        break;
                }
            }

            // ReSharper disable once FunctionNeverReturns
        }


        // Reading all shoes from a file 1
        private static void ReadShoesFromFiles()
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

                    if (chunks.Length != 5) continue;

                    var type = chunks[0].Trim();
                    var season = chunks[1].Trim();
                    var size = int.Parse(chunks[2].Trim());
                    var color = chunks[3].Trim();
                    var condition = chunks[4].Trim();

                    Shoes.Add(new Shoe(type, season, size, color, condition));
                }
            }
        }

        // Reading all shoes from a file 2
        private static void ReadShoesFromFiles2()
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

                    if (chunks.Length != 5) continue;

                    var type = chunks[0].Trim();
                    var season = chunks[1].Trim();
                    var size = int.Parse(chunks[2].Trim());
                    var color = chunks[3].Trim();
                    var condition = chunks[4].Trim();

                    Shoes2.Add(new Shoe(type, season, size, color, condition));
                }
            }
        }

        // Display all shoes in both Charities
        private static void ShowShoesInCharities()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Charity 1");
            foreach (var shoe in Shoes)
            {
                Console.WriteLine(shoe.ToString());
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine("Charity 2");
            foreach (var shoe in Shoes2)
            {
                Console.WriteLine(shoe.ToString());
            }
        }

        // Checking which charity has more shoes for adults
        private static void MoreShoesForAdults()
        {
            var shoes = from shoe in Shoes
                where shoe.Type.ToLower().Contains("woman") || shoe.Type.ToLower().Contains("man")
                select shoe;

            var shoes2 = from shoe2 in Shoes2
                where shoe2.Type.ToLower().Contains("woman") || shoe2.Type.ToLower().Contains("man")
                select shoe2;

            Console.WriteLine(shoes.Count() > shoes2.Count()
                ? "Charity 1 has more shoes for adults"
                : "Charity 2 has more shoes for adults");
        }

        // Kids shoes for winter from both charities

        private static void KidsShoes()
        {
            var kidsShoes = Shoes.Union(Shoes2)
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
            var sortedBy = Shoes.OrderBy(shoe => shoe.Size).ToList();
            var sortedBy2 = Shoes2.OrderBy(shoe2 => shoe2.Size).ToList();
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
            Shoes.RemoveAll(shoe => shoe.Condition.ToLower().Contains("satisfiable"));
            Shoes2.RemoveAll(shoe2 => shoe2.Condition.ToLower().Contains("satisfiable"));
        }

        // Lets donate some more shoes to Charity 1
        private static void AddShoesToCharity()
        {
            Console.WriteLine(
                "So nice of you, what type of shoes you would like to donate? Choose from man,woman,kids");

            var type = Console.ReadLine();
            Console.WriteLine("Which season it fits the most? Choose from spring,summer,autumn,winter");
            var season = Console.ReadLine();
            Console.WriteLine("What size is it?");
            var size = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("What color is it?");
            var color = Console.ReadLine();
            Console.WriteLine("Choose condition from: very good,good,satisfyable");
            var condition = Console.ReadLine();
            var batai = new Shoe(type, season, size, color, condition);
            Shoes.Add(batai);
        }

        // Lets donate some more shoes to Charity 2
        private static void AddShoesToCharity2()
        {
            Console.WriteLine(
                "So nice of you, what type of shoes you would like to donate? Choose from man,woman,kids");

            var type = Console.ReadLine();
            Console.WriteLine("Which season it fits the most? Choose from spring,summer,autumn,winter");
            var season = Console.ReadLine();
            Console.WriteLine("What size is it?");
            var size = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.WriteLine("What color is it?");
            var color = Console.ReadLine();
            Console.WriteLine("Choose condition from: very good,good,satisfyable");
            var condition = Console.ReadLine();
            Shoe batai = new Shoe(type, season, size, color, condition);
            Shoes2.Add(batai);
        }

        // Show menu
        private static void Menu()
        {
            Console.WriteLine("1:Show all shoes of both charities");
            Console.WriteLine("2:Show all Winter shoes for Kids");
            Console.WriteLine("3:Donate shoes to Charity 1");
            Console.WriteLine("4:Donate shoes to Charity 2");
            Console.WriteLine("5:Show which charity has more shoes for Adults");
            Console.WriteLine("6:Remove shoes with 'Satisfyable' quality ");
            Console.WriteLine("7:Sort shoes by their size");
            Console.WriteLine("8:Exit program");
        }

        // Exit program
        private static void Exit()
        {
            Environment.Exit(0);
        }
    }
}