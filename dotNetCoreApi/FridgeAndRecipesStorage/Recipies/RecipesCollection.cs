using System.Runtime.InteropServices.JavaScript;

namespace FridgeAndRecipesStorage.Recipies
{
    public class RecipesCollection : IRecipesCollection
    {
        private readonly IDictionary<string, Recipe> _recipes;
        private readonly Object _lock = new Object();

        public RecipesCollection()
        {
            _recipes = RecipesCollectionGateway
                .OpenCollection()
                .ToDictionary(recipe => recipe.Name,
                    recipe => recipe,
                    StringComparer.OrdinalIgnoreCase);
        }
        
        public IEnumerable<Recipe> GetRecipes()
        {
            lock (_lock)
            {
                return _recipes.Select( recipe => recipe.Value);
            }
        }
        
        public Recipe AddRecipe(Recipe recipe)
        {
            lock (_lock)
            {
                if (_recipes.TryAdd(recipe.Name, recipe))
                {
                    RecipesCollectionGateway.UpdateCollection(_recipes.Select(x=>x.Value).ToList());
                    return recipe; 
                } 
                throw new Exception("Recipe with similar name exists");
            }
        }
        
        public IEnumerable<Recipe> GetRecipesByName(string name)
        {
            lock (_lock)
            {
                return _recipes
                    .Where(x => x.Key.Contains(name, StringComparison.OrdinalIgnoreCase))
                    .Select(y=> y.Value);   
            }
        }

        public Recipe ModifyRecipe(Recipe recipe)
        {
            lock (_lock)
            {
                if (_recipes.ContainsKey(recipe.Name))
                {
                    _recipes[recipe.Name] = recipe;
                    RecipesCollectionGateway.UpdateCollection(_recipes.Select(x=>x.Value).ToList());
                    return _recipes[recipe.Name];
                }
            }
            throw new Exception("No such Recipe");   
        }

        public bool RemoveRecipe(string name)
        {
            lock (_lock)
            {
                if (_recipes.Remove(name))
                {
                    RecipesCollectionGateway.UpdateCollection(_recipes.Select(x=>x.Value).ToList());
                    return true;
                }
            }
            return false;
        }
    }
}
