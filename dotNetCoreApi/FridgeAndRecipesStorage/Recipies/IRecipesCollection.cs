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
        IList<Recipe> GetRecipes();
        Recipe GetRecipeByName(string name);
        bool AddRecipe(Recipe recipe);
        bool RemoveRecipe(Recipe recipe);
        Recipe ModifyRecipe(Recipe recipe);
    }
}
