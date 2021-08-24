using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    class Program
    {
        static void Main(string[] args)
        {

            Dalmanager dalmanager = new Dalmanager();
            
            //only Mai tai and Margarita has been created
            dalmanager.PopulateDB();
            Console.WriteLine("Choose:");
            Console.WriteLine("1} Get a drink");
            Console.WriteLine("2} Delete drink");
            var radnom = Console.ReadKey();
            switch (radnom.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("What drink would you like?:");
                    string drinkToGet = Console.ReadLine();
                    var chosenDrink = dalmanager.GetDrink(drinkToGet);
                    foreach (var drink in chosenDrink)
                    {
                        Console.Clear();
                        Console.WriteLine("Drink:"+drink.Name + "\n");
                        Console.WriteLine("Contains:");
                        foreach (var ing in drink.Ingredients)
                        {
                            Console.WriteLine(ing.Name);
                        }
                        Console.WriteLine("\nRecipe:"+drink.MixAndGarnish);
                    }
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Which drink would you like to remove?:");
                    string drinkToRemove = Console.ReadLine();
                    dalmanager.DeleteDrink(drinkToRemove);
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }
    }
}
