using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeAndRecipesStorage.Recipies
{
    public interface IRecipesCollection
    {
        IEnumerable<Recipe> GetRecipes();
        IEnumerable<Recipe> GetRecipesByName(string name);
        Recipe AddRecipe(Recipe recipe);
        bool RemoveRecipe(string name);
        Recipe ModifyRecipe(Recipe recipe);
    }
}
