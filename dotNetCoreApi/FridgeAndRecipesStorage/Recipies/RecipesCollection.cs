using System.Runtime.InteropServices.JavaScript;
using FridgeAndRecipesStorage.Gateway;

namespace FridgeAndRecipesStorage.Recipies
{
    public class RecipesCollection
    {
        private IDictionary<string, Recipe> _recipes;
        private readonly Gateway<Recipe> _recipeGateway;
        
        public RecipesCollection(Gateway<Recipe> recipeGateway)
        {
            _recipeGateway = recipeGateway;
            _recipes = new Dictionary<string, Recipe>(StringComparer.OrdinalIgnoreCase);
        }
        
        public IEnumerable<Recipe> GetRecipes()
        {
            return _recipeGateway.Select();
        }
        
        public Recipe AddRecipe(Recipe recipe)
        {
            _recipes = _recipeGateway
                .Select()
                .ToDictionary(
                    x=> x.Name,
                    x=> x,
                    StringComparer.OrdinalIgnoreCase);
            
            if (_recipes.TryAdd(recipe.Name, recipe))
            {
                _recipeGateway.Update(_recipes.Select(x=> x.Value));
                return recipe; 
            } 
            throw new Exception("Recipe with similar name exists");
        }
        
        public IEnumerable<Recipe> GetRecipesByName(string name)
        {
            return _recipeGateway
                .Select()
                .Where(x =>
                    x.Name.Contains(name,
                        StringComparison.OrdinalIgnoreCase));
        }

        public Recipe ModifyRecipe(Recipe recipe)
        {
            _recipes = _recipeGateway
                .Select()
                .ToDictionary(
                    x=> x.Name,
                    x=> x,
                    StringComparer.OrdinalIgnoreCase);
            
            {
                if (_recipes.ContainsKey(recipe.Name))
                {
                    _recipes[recipe.Name] = recipe;
                    _recipeGateway.Update(_recipes.Select(x=>x.Value));
                    return _recipes[recipe.Name];
                }
            }
            throw new Exception("No such Recipe");   
        }

        public bool RemoveRecipe(string name)
        {
            _recipes = _recipeGateway
                .Select()
                .ToDictionary(
                    x=> x.Name,
                    x=> x,
                    StringComparer.OrdinalIgnoreCase);
            
            if (_recipes.Remove(name))
            {
                _recipeGateway.Update(_recipes.Select(x=>x.Value));
                return true;
            }
            return false;
        }
    }
}
