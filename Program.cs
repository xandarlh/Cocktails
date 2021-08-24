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
            /*
            using (var ctx = new CocktailContext())
            {
                var test = ctx.Drinks.Where(e => e.Name.Equals("Ny drink2")).Include(e => e.Ingredients).ToList();
                var stud = new Ingredient() { Name = "Rum" };
                ctx.Ingredients.Add(stud);
                ctx.SaveChanges();
            }
            */
            //dalmanager.CreateDrink("Ny drink2",new List<Test>(){new Test(){Name="Vodka"},new Test(){Name="Rum"}} , "Hello");
            /*
            var drinks = dalmanager.GetAllDrinks();
            foreach (var item in drinks)
            {
                Console.WriteLine(item.Name);
            }
            */
            //dalmanager.PopulateDB();
            Console.WriteLine("Choose:");
            Console.WriteLine("1} Get a drink");
            Console.WriteLine("2} ");
            var radnom = Console.ReadKey();
            switch (radnom.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("What drink would you like?:");
                    string choice = Console.ReadLine();
                    var chosenDrink = dalmanager.GetDrink(choice);
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
                default:
                    break;
            }

            Console.ReadLine();
        }
    }
}
