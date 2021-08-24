using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    public class CocktailContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }


        public CocktailContext() : base()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CocktailContext>());
        }
        
    }
}
