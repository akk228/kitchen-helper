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
    
    [EnableCors("MyOrigin")]
    [HttpPut]
    public IActionResult Put([FromBody] Recipe recipe)
    {
        try
        {
            return Ok( _recipesCollection.ModifyRecipe(recipe));
        }
        catch (Exception e)
        {
            return BadRequest("Can't modify recipe that is not in the list");
        } 
    }
    
    [EnableCors("MyOrigin")]
    [HttpDelete]
    [Route("{name}")]
    public IActionResult Delete([FromRoute] string name)
    {
        try
        {
            return Ok( _recipesCollection.RemoveRecipe(name));
        }
        catch (Exception e)
        {
            return BadRequest("Cant find recipe with such name");
        } 
    }
}