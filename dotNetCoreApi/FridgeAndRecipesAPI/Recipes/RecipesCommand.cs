using FridgeAndRecipesStorage.Recipies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FridgeAndRecipesAPI.Recipes;

[ApiController]
[Route("Recipes")]
public class RecipesCommand : ControllerBase
{
    private readonly RecipesCollection _recipesCollection;

    public RecipesCommand(RecipesCollection recipesCollection)
    {
        _recipesCollection = recipesCollection;
    }
    
    [EnableCors("MyOrigin")]
    [HttpPost]
    [Route("addRecipe")]
    public IActionResult Post([FromBody] Recipe recipe)
    {
        try
        {
            return Ok( _recipesCollection.AddRecipe(recipe));
        }
        catch (Exception e)
        {
            return BadRequest("Product with similar name exists");
        } 
    }
}