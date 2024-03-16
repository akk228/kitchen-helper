namespace FridgeAndRecipesStorage.Recipies
{
    public class RecipesCollection : IRecipesCollection
    {
        private readonly IDictionary<string, Recipe> _recipes;

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
            return _recipes.Select( recipe => recipe.Value);
        }
        
        public Recipe AddRecipe(Recipe recipe)
        {
            if (!_recipes.TryAdd(recipe.Name, recipe))
            {
                throw new Exception("Recipe with similar name exists");
            }
            RecipesCollectionGateway.UpdateCollection(_recipes.Select(x=>x.Value).ToList());
            return recipe;
        }
        
        public IEnumerable<Recipe> GetRecipesByName(string name)
        {
            return _recipes
                .Where(x => x.Key.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Select(y=> y.Value);
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
