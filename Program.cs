using System;
using System.Collections.Generic;
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
            //using (var ctx = new CocktailContext())
            //{
            //    var stud = new Ingredient() { Name = "Vodka" };
            //    ctx.Ingredients.Add(stud);
            //    ctx.SaveChanges();
            //}
            
            var ingredients = dalmanager.GetAllIngredients();
            dalmanager.CreateDrink("Ny drink", ingredients, "Hello");
            Console.WriteLine();
            /*
            dalmanager.CreateDrink("Hello", ingredients, "hellodrink, meget lækker");
            List<Drink> chosenDrink = dalmanager.GetDrink("Hello");
            foreach (var item in chosenDrink)
            {
                Console.WriteLine(item.MixAndGarnish);
                Console.WriteLine(item.Ingredients);
            }
            */
            /*
            foreach (var item in ingredients)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();

            foreach (var item in drinks)
            {
                Console.WriteLine(item.Name);
            }
            */
            Console.ReadLine();
        }
    }
}
