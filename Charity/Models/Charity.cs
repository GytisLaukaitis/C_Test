using System;
using Charity.Enums;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Charity.Models
{
    public class Organization
    {
        private string _title { get; set; }
        private List<Shoe> _shoes { get; set; }

        public Organization()
        {
        }

        public List<Shoe> Shoes
        {
            get => _shoes ?? (_shoes = new List<Shoe>());
            set => _shoes = value;
        }

        private string Title
        {
            get => _title;
            set => _title = value;
        }

        public List<Shoe> GetAdultShoes()
        {
            var result = Shoes.Where(x => x.Type == ShoeType.Men).ToList();
            result.AddRange(Shoes.Where(x => x.Type == ShoeType.Women));

            return result;
        }

        public void OrderShoesBySize()
        {
            var orderedEnumerable = Shoes.OrderBy(x => x.Size).ToList();

            Console.WriteLine("-------------------------");
            Console.WriteLine(Title);
            foreach (var shoe in orderedEnumerable)
            {
                Console.WriteLine(shoe.ToString());
            }
        }

        public void ClearShoes(Condition condition)
        {
            Shoes.RemoveAll(x => x.Condition == condition);
        }

        public void ShowShoes()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine(Title);
            foreach (var shoe in Shoes)
            {
                Console.WriteLine(shoe.ToString());
            }
        }

        public void ParseFile(string pathToFile)
        {
            const char csvSplitBy = ',';
            const int bufferSize = 128;
            using (var fileStream = File.OpenRead(pathToFile))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, bufferSize))
            {
                string line;

                Title = streamReader.ReadLine(); //reading first line and assigning the value to Title

                while ((line = streamReader.ReadLine()) != null)
                {
                    var chunks = line.Split(csvSplitBy);

                    if (chunks.Length < 5)
                    {
                        line = Title;
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine(line);
                        continue;
                    }

                    var parsedType = ParseType(chunks[0].Trim()).GetValueOrDefault();
                    var parsedSeason = ParseSeason(chunks[1].Trim()).GetValueOrDefault();
                    var parsedSize = int.Parse(chunks[2].Trim());
                    var parsedColor = chunks[3].Trim();
                    var parsedCondition = ParseCondition(chunks[4].Trim()).GetValueOrDefault();

                    var newShoe = new Shoe(parsedType, parsedSeason, parsedSize, parsedColor, parsedCondition);

                    Shoes.Add(newShoe);
                    Console.WriteLine(newShoe);
                }
            }
        }

        private static Condition? ParseCondition(string condition)
        {
            switch (condition.ToLower())
            {
                case "veryGood":
                    return Condition.VeryGood;

                case "good":
                    return Condition.Good;

                case "decent":
                    return Condition.Decent;

                default:
                    return null;
            }
        }

        private static Season? ParseSeason(string season)
        {
            switch (season.ToLower())
            {
                case "winter":
                    return Season.Winter;

                case "spring":
                    return Season.Spring;

                case "summer":
                    return Season.Summer;

                case "autumn":
                    return Season.Autumn;

                default:
                    return null;
            }
        }

        private static ShoeType? ParseType(string type)
        {
            switch (type.ToLower())
            {
                case "men":
                    return ShoeType.Men;

                case "women":
                    return ShoeType.Women;

                case "child":
                    return ShoeType.Child;

                default:
                    return null;
            }
        }
    }
}