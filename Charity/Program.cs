using System;
using System.Collections.Generic;
using System.Linq;
using Charity.Models;
using Charity.Enums;

namespace Charity
{
    internal static class Program
    {
        private const string FirstFilePath = @"C:\Users\gytis\RiderProjects\Solution1\Charity\Charity.csv";
        private const string SecondFilePath = @"C:\Users\gytis\RiderProjects\Solution1\Charity\Charity2.csv";
        private const string ThirdFilePath = @"C:\Users\gytis\RiderProjects\Solution1\Charity\Charity3.csv";


        public static void Main(string[] args)
        {
            var firstCharity = new Organization();
            var secondCharity = new Organization();


            firstCharity.ParseFile(FirstFilePath);
            secondCharity.ParseFile(SecondFilePath);


            var winterShoes = new List<Shoe>();


            Console.WriteLine("Choose from your options below:");
            Menu();
            while (true)
            {
                Console.WriteLine("------------------------------------------------");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        var adultShoeCountInFirst =
                            firstCharity.GetAdultShoes().Count; //su antra tapati ir poto palyginsi kuris didesnis
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

                    case "2":

                        winterShoes.AddRange(firstCharity.Shoes.Where(x =>
                            x.Season == Season.Winter && x.Type == ShoeType.Child));

                        winterShoes.AddRange(secondCharity.Shoes.Where(x =>
                            x.Season == Season.Winter && x.Type == ShoeType.Child));

                        Console.WriteLine("Done! Check option 6 for full list");
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;

                    case "3":
                        Console.WriteLine("Done! Here's a new sorted list");
                        Console.WriteLine();

                        firstCharity.OrderShoesBySize();
                        secondCharity.OrderShoesBySize();
                        winterShoes.OrderBy(x => x.Size);


                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;

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

                    case "5":

                        firstCharity.ParseFile(ThirdFilePath);
                        firstCharity.ShowShoes();
                        Console.WriteLine("------------------------------------------------");
                        Menu();
                        break;

                    case "6":
                        foreach (var shoe in winterShoes)
                        {
                            Console.WriteLine(shoe.ToString());
                        }

                        Menu();
                        break;
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
            Console.WriteLine("1:Raskite kurioje labdaros organizacijoje yra daugiau batu skirtu suaugusiems");
            Console.WriteLine(
                "2:Surasykite i atskira rinkini vaikams ziemai skirtus batus is abieju labdaros organizaciju");
            Console.WriteLine("3:Surikiuokite suformuotus sarasus pagal batu dydi");
            Console.WriteLine("4:Pasalinkite is rezultatu batus, kuriu bukle yra patenkinama");
            Console.WriteLine("5:Papildytio viena is rezultatu sarasu nauja labdara is failo");
            Console.WriteLine("6:Parodyti vaiku zieminiu batu sarasa");
            Console.WriteLine("Anything else:Exit");
        }


        // Exit program
        private static void Exit()
        {
            Environment.Exit(0);
        }
    }
}