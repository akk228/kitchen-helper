using FridgeAndRecipesStorage.Fridge;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


namespace FridgeAndRecipesAPI.FridgeAccess;

[ApiController]
[Route("Fridge")]
public class FridgeCommand : ControllerBase
{
    [EnableCors("MyOrigin")]
    [HttpPost]
    [Route("addProduct")]
    public IActionResult Post([FromBody] Product product)
    {
        FridgeAndRecipesAPI.FridgeState.FridgeSession.AddProduct(product);
        var productToReturn = FridgeAndRecipesAPI.FridgeState.FridgeSession.FindProduct(product.Name);
        return Ok(productToReturn);
    }

    [EnableCors("MyOrigin")]
    [HttpDelete]
    [Route("deleteProduct")]
    public IActionResult Delete([FromBody] Product product)
    {
        FridgeAndRecipesAPI.FridgeState.FridgeSession.WithdrawProduct(product.Name);
        return Ok();
    }

    [EnableCors("MyOrigin")]
    [HttpPut]
    [Route("takeProducts")]
    public IActionResult Put([FromBody] IEnumerable<Product> products)
    {
        try
        {
            var leftOverProducts = 
                FridgeAndRecipesAPI.FridgeState.FridgeSession
                .TakeProducts(products);
            return Ok(leftOverProducts);
        }
        catch (Exception e){
            return BadRequest("not enough products");
        }

        
    }
}