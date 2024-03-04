using FridgeAndRecipesStorage.Fridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeAndRecipesStorage.Recipies
{
    public class RecipesCollection : IRecipesCollection
    {
        private IList<Recipe> _recipes;

        public RecipesCollection() { 
            _recipes = new List<Recipe>();
            _recipes.Add(
                new Recipe()
                {
                    Name = "Omlet",
                    Description = "Don't u know how cook a fucking omlet???",
                    Ingredients = new List<Product>(
                        new Product[]
                        {
                            new Product()
                            {
                                Name = "Eggs",
                                Amount = 3,
                                MeasurmentUnit = Units.unit
                            },
                            new Product()
                            {
                                Name = "Milk",
                                Amount = 150,
                                MeasurmentUnit= Units.ml
                            }
                        })
                });
        }
        public IList<Recipe> GetRecipes()
        {
            return _recipes;
        }
        public bool AddRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Recipe GetRecipeByName(string name)
        {
            throw new NotImplementedException();
        }

        public Recipe ModifyRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
