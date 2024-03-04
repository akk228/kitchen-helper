using FridgeAndRecipesStorage.Fridge;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FridgeAndRecipesAPI.FridgeAccess;

[ApiController]
[Route("Fridge")]
public class FridgeQuery : ControllerBase
{
    [EnableCors("MyOrigin")]
    [HttpGet("Content")]
    public IEnumerable<Product> Get()
    {
        return FridgeState.FridgeSession.GetAllProducts(); ;
    }

    [EnableCors("MyOrigin")]
    [HttpGet]
    [Route("Product")]
    public Product Get(string name)
    {
        return FridgeState.FridgeSession.FindProduct(name);
    }
}