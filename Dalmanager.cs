using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    public class Dalmanager
    {
        /// <summary>
        /// Method uses CocktailContext to get all drinks from the db, my looping through ctx.Drinks and adding them to the list named 'drinks',
        /// which we will then return
        /// </summary>
        /// <returns>List with all drink from the DB</returns>
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

        /// <summary>
        /// Method uses CocktailContext to get all ingredients from the db, my looping through ctx.Ingredients and adding them to the list named 'ingredients',
        /// </summary>
        /// <returns>List of all ingredients</returns>
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
        /// <summary>
        /// You put in the name of the drink you want and then it checks for which drink has the same name as the one you wrote
        /// </summary>
        /// <param name="name">name is which drink you want to get</param>
        /// <returns>List<Drink></returns>
        public List<Drink> GetDrink(string name)
        {
            using (var ctx = new CocktailContext())
            {
                var chosenDrink = ctx.Drinks.Where(e => e.Name.Equals(name)).Include(e => e.Ingredients).ToList();
                return chosenDrink.ToList<Drink>();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Name of the drink</param>
        /// <param name="ingredients">List with the ingredients that goes into the drink</param>
        /// <param name="mixAndGarnish">Description on proportions of the ingredients and how the drink is made</param>
        public void CreateDrink(string name, List<CocktailIngredients> ingredients, string mixAndGarnish)
        {
            using (var ctx = new CocktailContext())
            {
                Drink dri = new Drink() { Name = name, Ingredients = ingredients, MixAndGarnish = mixAndGarnish };

                ctx.Drinks.Add(dri);
                ctx.SaveChanges();
            }
        }
        /// <summary>
        /// Takes in a parameter of what drink you want removed,
        /// then gets drink where the name of the drink you want removed is the same as one in the Db,
        /// then if it is, it will remove it from context/db and then save the changes made/update db.
        /// </summary>
        /// <param name="drinkRemove">string of the name of the drink you want to remove</param>
        public void DeleteDrink(string drinkRemove)
        {
            using (var ctx = new CocktailContext())
            {
                IQueryable<Drink> drinkToRemove = ctx.Drinks.Where(e => e.Name.Equals(drinkRemove)).Include(e => e.Ingredients);
                ctx.Drinks.Remove(drinkToRemove.FirstOrDefault());
                ctx.SaveChanges();
            }
        }
        /// <summary>
        /// Take and news all the ingredient you want added to the database,
        /// and is then run to populate the database.
        /// Then it will generate all the 
        /// Populate is only run once, to populate the database
        /// </summary>
        public void PopulateDB()
        {
            using (var ctx = new CocktailContext())
            {
                //Clears the database before its generated again.
                ctx.Database.Delete();
                var ing1 = new Ingredient() { Name = "Tequila" };
                var ing2 = new Ingredient() { Name = "Dark rum" };
                var ing3 = new Ingredient() { Name = "Kahlua" };
                var ing4 = new Ingredient() { Name = "Vodka" };
                var ing5 = new Ingredient() { Name = "Bourbon" };
                var ing6 = new Ingredient() { Name = "Italian sweet vermouth" };
                var ing7 = new Ingredient() { Name = "French dry vermouth" };
                var ing8 = new Ingredient() { Name = "White rum" };
                var ing9 = new Ingredient() { Name = "Cointreau" };
                var ing10 = new Ingredient() { Name = "Cherry brandy" };
                var ing11 = new Ingredient() { Name = "Sloe gin" };
                var ing12 = new Ingredient() { Name = "Gin" };
                var ing13 = new Ingredient() { Name = "Prosecco" };
                var ing14 = new Ingredient() { Name = "Triplesec" };
                var ing15 = new Ingredient() { Name = "Lime juice" };
                var ing16 = new Ingredient() { Name = "Orange curacao" };
                var ing17 = new Ingredient() { Name = "Almond syrup" };
                var ing18 = new Ingredient() { Name = "Prosecco" };
                var ing19 = new Ingredient() { Name = "Cachaca" };
                var ing20 = new Ingredient() { Name = "Orange juice" };
                var ing21 = new Ingredient() { Name = "Tomato juice" };
                ctx.Ingredients.Add(ing1);
                ctx.Ingredients.Add(ing2);
                ctx.Ingredients.Add(ing3);
                ctx.Ingredients.Add(ing4);
                ctx.Ingredients.Add(ing5);
                ctx.Ingredients.Add(ing6);
                ctx.Ingredients.Add(ing7);
                ctx.Ingredients.Add(ing8);
                ctx.Ingredients.Add(ing9);
                ctx.Ingredients.Add(ing10);
                ctx.Ingredients.Add(ing11);
                ctx.Ingredients.Add(ing12);
                ctx.Ingredients.Add(ing13);
                ctx.Ingredients.Add(ing14);
                ctx.Ingredients.Add(ing15);
                ctx.Ingredients.Add(ing16);
                ctx.Ingredients.Add(ing17);
                ctx.Ingredients.Add(ing18);
                ctx.Ingredients.Add(ing19);
                ctx.Ingredients.Add(ing20);
                ctx.Ingredients.Add(ing21);

                CreateDrink("Margarita", new List<CocktailIngredients>() { new CocktailIngredients() { Name = "Lime juice" }, 
                    new CocktailIngredients() { Name = "Triplesec" } }, "Salt rim, crushed ice and a little lime segment");

                CreateDrink("Mai tai", new List<CocktailIngredients>() { new CocktailIngredients() { Name = "Dark rum" },
                    new CocktailIngredients() { Name = "Orange curacao" },
                    new CocktailIngredients{ Name = "Lime juice" },
                    new CocktailIngredients{ Name = "Almond syrup"} }, "Lime section, a maraschino cherry and some lime segment");
                ctx.SaveChanges();
            }
        }

    }
}

