using FridgeAndRecipesStorage.Fridge;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


namespace FridgeAndRecipesAPI.FridgeAccess;

[ApiController]
[Route("Fridge")]
public class FridgeCommand : ControllerBase
{
    private readonly Fridge _fridge;
    public FridgeCommand(Fridge fridge)
    {
        _fridge = fridge;
    }

    [EnableCors("MyOrigin")]
    [HttpPost]
    [Route("addProduct")]
    public IActionResult Post([FromBody] Product product)
    {
        return Ok(_fridge.AddProduct(product));
    }

    [EnableCors("MyOrigin")]
    [HttpDelete]
    [Route("deleteProduct")]
    public IActionResult Delete([FromBody] Product product)
    {
        _fridge.WithdrawProduct(product.Name);
        return Ok();
    }

    [EnableCors("MyOrigin")]
    [HttpPut]
    [Route("takeProducts")]
    public IActionResult Put([FromBody] IEnumerable<Product> products)
    {
        try{
            var leftOverProducts = _fridge.TakeProducts(products);
            return Ok(leftOverProducts);
        }
        catch (Exception e){
            return BadRequest("not enough products");
        }

        
    }
}