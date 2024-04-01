using FridgeAndRecipesStorage.KitchenHelper;
using FridgeAndRecipesStorage.Recipies;
using Microsoft.AspNetCore.Mvc;

namespace FridgeAndRecipesAPI.CookingHelper;
[ApiController]
[Route("Cooking")]
public class CookingQuery : ControllerBase
{
    private readonly KitchenHelper _kitchenHelper;

    public CookingQuery(KitchenHelper kitchenHelper)
    {
        _kitchenHelper = kitchenHelper;
    }

    [HttpGet]
    [Route("ReadyToGo")]
    public IEnumerable<Recipe> GetReadyToGoRecipes()
    {
        return _kitchenHelper.FindReadyToGoRecipes();
    }
}