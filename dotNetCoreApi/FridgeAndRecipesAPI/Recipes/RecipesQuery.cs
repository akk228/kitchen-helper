using FridgeAndRecipesStorage.Recipies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
namespace FridgeAndRecipesAPI.Recipes
{
    [ApiController]
    [Route("Recipes")]
    public class RecipesQuery : ControllerBase
    {
        private readonly RecipesCollection _recipesCollection;

        public RecipesQuery(RecipesCollection recipesCollection)
        {
            _recipesCollection = recipesCollection;
        }

        [EnableCors("MyOrigin")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_recipesCollection.GetRecipes());
        }
    }
}
