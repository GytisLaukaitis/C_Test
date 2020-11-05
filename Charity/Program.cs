using System;
using System.Collections.Generic;
using System.Linq;
using Charity.Models;
using Charity.Enums;

namespace Charity
{
    internal static class Program
    {
        // Paths to all charities
        private const string FirstFilePath = @"C:\Users\gytis\RiderProjects\Solution1\Charity\Charity.csv";
        private const string SecondFilePath = @"C:\Users\gytis\RiderProjects\Solution1\Charity\Charity2.csv";
        private const string ThirdFilePath = @"C:\Users\gytis\RiderProjects\Solution1\Charity\Charity3.csv";


        public static void Main(string[] args)
        {
            var firstCharity = new Organization();
            var secondCharity = new Organization();


            // Displaying all shoes in both charities
            
            firstCharity.ParseFile(FirstFilePath);
            secondCharity.ParseFile(SecondFilePath);


            // Initialize list for kids winter shoes
            var winterShoes = new List<Shoe>();


            Console.WriteLine("Choose from the options below:");
            Menu();
            while (true)
            {
                Console.WriteLine("------------------------------------------------");
                var option = Console.ReadLine();
                switch (option)
                {
                    // Option 1
                    case "1":
                        var adultShoeCountInFirst =
                            firstCharity.GetAdultShoes().Count;
                        var adultShoeCountInSecond = secondCharity.GetAdultShoes().Count();

                        if (adultShoeCountInFirst > adultShoeCountInSecond)
                        {
                            Console.WriteLine("First charity has more shoes for adults");
                        }
                        else if (adultShoeCountInSecond > adultShoeCountInFirst)
                        {
                            Console.WriteLine("Second charity has more shoes for adults");
                        }
                        else if (adultShoeCountInFirst == 0 && adultShoeCountInSecond == 0)
                        {
                            Console.WriteLine("There are no shoes for adults at the moment");
                        }
                        else
                        {
                            Console.WriteLine("Both Charities has same amount of shoes for adults");
                        }

                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;

                    // Option 2
                    case "2":

                        winterShoes.AddRange(firstCharity.Shoes.Where(x =>
                            x.Season == Season.Winter && x.Type == ShoeType.Child));

                        winterShoes.AddRange(secondCharity.Shoes.Where(x =>
                            x.Season == Season.Winter && x.Type == ShoeType.Child));

                        Console.WriteLine("Done! Check option 6 for full list");
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;

                    // Option 3
                    case "3":
                        Console.WriteLine("Done! Here's a new sorted list");
                        Console.WriteLine();

                        firstCharity.OrderShoesBySize();
                        secondCharity.OrderShoesBySize();
                        winterShoes.OrderBy(x => x.Size);


                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;

                    // Option 4
                    case "4":
                        firstCharity.ClearShoes(Condition.Decent);
                        secondCharity.ClearShoes(Condition.Decent);
                        winterShoes.RemoveAll(x => x.Condition == Condition.Decent);

                        Console.WriteLine("Done! Here is a new list without shitty shoes in it");
                        Console.WriteLine();
                        firstCharity.ShowShoes();
                        secondCharity.ShowShoes();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;

                    // Option 5
                    case "5":

                        firstCharity.ParseFile(ThirdFilePath);
                        firstCharity.ShowShoes();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;

                    // Option 6
                    case "6":
                        foreach (var shoe in winterShoes)
                        {
                            Console.WriteLine(shoe.ToString());
                        }

                        Menu();
                        break;
                    
                    // Any other option evalutes to exit
                    default:
                        Exit();
                        break;
                }
            }

            // ReSharper disable once FunctionNeverReturns
        }

        // Show menu
        private static void Menu()
        {
            Console.WriteLine("1:Find out which charity has more shoes for adults");
            Console.WriteLine("2:Find a separate set of children's winter shoes from both charities");
            Console.WriteLine("3:Arrange the formed lists according to the size of the shoe");
            Console.WriteLine("4:Remove from the result shoes that are in satisfactory condition");
            Console.WriteLine("5:Add a new charity from the file to the list of results");
            Console.WriteLine("6:Show a list of children's winter boots");
            Console.WriteLine("Anything else:Exit");
        }


        // Exit program
        private static void Exit()
        {
            Environment.Exit(0);
        }
    }
}