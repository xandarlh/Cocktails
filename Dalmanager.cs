using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    public class Dalmanager
    {
        public List<Drink> GetAllDrinks()
        {
            List<Drink> drinks = new List<Drink>();
            using (var ctx = new CocktailContext())
            {
                foreach (var item in ctx.Drinks)
                {
                    drinks.Add(item);
                }
            }
            return drinks;
        }

        public List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            using (var ctx = new CocktailContext())
            {
                foreach (var item in ctx.Ingredients)
                {
                    ingredients.Add(item);
                }               
            }
            return ingredients;
        }
        public List<Drink> GetDrink(string name)
        {
            List<Drink> drinks = GetAllDrinks();

            using (var ctx = new CocktailContext())
            {
                var chosenDrink = from Drinks in drinks
                                  where Drinks.Name.Equals(name)
                                  select Drinks;
                return chosenDrink.ToList<Drink>();
            }
        }
        public void CreateDrink(string name, List<Ingredient> ingredients, string mixAndGarnish )
        {
            using (var ctx = new CocktailContext())
            {
                var dri = new Drink() { Name = name, Ingredients = ingredients, MixAndGarnish = mixAndGarnish};

                ctx.Drinks.Add(dri);
                ctx.SaveChanges();
            }
        }
    }
}
