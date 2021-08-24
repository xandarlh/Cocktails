using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    public class Drink
    {
        [Key]
        public int DrinkID { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string MixAndGarnish { get; set; }
        
    }
}
