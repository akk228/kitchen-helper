using FridgeAndRecipesStorage.Fridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeAndRecipesStorage.Recipies
{
    public class Recipe
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public IList<Product> Ingredients { get; set; }
    }
}
