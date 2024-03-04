using FridgeAndRecipesStorage.Recipies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
namespace FridgeAndRecipesAPI.Recipes
{
    [ApiController]
    [Route("Recipes")]
    public class RecipesQuery : ControllerBase
    {
        public RecipesQuery() { }

        [EnableCors("MyOrigin")]
        [HttpGet]
        public IList<Recipe> Get()
        {
            return FridgeAndRecipesAPI.RecipeState.RecipesSession.GetRecipes();
        }
    }
}
