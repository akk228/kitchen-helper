using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FridgeAndRecipesStorage.Fridge;

public enum Units
{
    gr,
    ml,
    unit
}

public class Product
{
    public string Name { get; set; }
    public int Amount { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Units MeasurmentUnit { get; set; }

    public bool UseSomeAmountOfProduct(int amount)
    {
        var newAmount = Amount - amount;
        if (newAmount < 0)
        {
            return false;
        } else if (newAmount == 0)
        {
            
        }
        
        Amount -= amount;
        return true;
    }
}