using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FridgeAndRecipesStorage.Enums;

namespace FridgeAndRecipesStorage.Fridge;

public class Product
{
    [Required]
    public string Name { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public int Amount { get; set; }
    
    [Required, EnumDataType(typeof(Units))]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Units MeasurmentUnit { get; set; }
}