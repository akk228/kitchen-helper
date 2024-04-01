using FridgeAndRecipesStorage.Recipies;

namespace FridgeAndRecipesStorage.KitchenHelper;

public class KitchenHelper
{
    private readonly Fridge.Fridge _fridge;
    private readonly RecipesCollection _recipesCollection;

    public KitchenHelper(Fridge.Fridge fridge, RecipesCollection recipesCollection)
    {
        _fridge = fridge;
        _recipesCollection = recipesCollection;
    }

    public IEnumerable<Recipe> FindReadyToGoRecipes()
    {
        var products = _fridge
            .GetAllProducts()
            .ToDictionary(
                product => product.Name,
                product => product,
                StringComparer.OrdinalIgnoreCase);

        var readyToGoRecipes = _recipesCollection
            .GetRecipes()
            .ToDictionary(
                recipe => recipe.Name,
                recipe => recipe,
                StringComparer.OrdinalIgnoreCase);

        foreach (var recipe in readyToGoRecipes)
        {
            foreach (var ingredient in recipe.Value.Ingredients)
            {
                if (!products.ContainsKey(ingredient.Name))
                {
                    readyToGoRecipes.Remove(recipe.Value.Name);
                }else if (ingredient.Amount > products[ingredient.Name].Amount)
                {
                    readyToGoRecipes.Remove(recipe.Value.Name);
                }
            }
        }

        return readyToGoRecipes.Select(recipe => recipe.Value);
    }
}