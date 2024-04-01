using FridgeAndRecipesStorage.Fridge;
using System.ComponentModel.DataAnnotations;
using FridgeAndRecipesStorage.Recipies.CustomValidations;

namespace FridgeAndRecipesStorage.Recipies
{
    public class Recipe
    {
        [Required]
        public string Name { get; set; }
        
        public string? Description { get; set; }
        
        [NonEmptyCollection(ErrorMessage = "You can't create recipes out of thin air!")]
        public IList<Product> Ingredients { get; set; }
    }
}
