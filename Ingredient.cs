﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocktails
{
    public class Ingredient
    {
        [Key]
        public int IngredientID { get; set; }
        public string Name { get; set; }
        public ICollection<Drink> Drinks { get; set; }
    }
}