using FridgeAndRecipesStorage.Fridge;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FridgeAndRecipesAPI.FridgeAccess;

[ApiController]
[Route("Fridge")]
public class FridgeQuery : ControllerBase
{
    private readonly Fridge _fridge;
    public FridgeQuery(Fridge fridge)
    { 
        _fridge = fridge;
    }

    [EnableCors("MyOrigin")]
    [HttpGet("Content")]
    public IEnumerable<Product> Get()
    {
        return _fridge.GetAllProducts(); ;
    }

    [EnableCors("MyOrigin")]
    [HttpGet]
    [Route("Product")]
    public IEnumerable<Product> Get(string name)
    {
        return _fridge.FindProducts(name);
    }
}