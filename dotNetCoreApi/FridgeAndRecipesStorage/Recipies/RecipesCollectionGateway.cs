using System.Text.Json;

namespace FridgeAndRecipesStorage.Recipies
{
    public class RecipesCollectionGateway
    {
        private const string RecipesCollectionStoragePath = @"..\RecipesCollectionStorage\";
        private const string RecipesCollectionName = @"RecipesCollection.json";
        private const string RelativePath = RecipesCollectionStoragePath + RecipesCollectionName;
        
        public static IList<Recipe> OpenCollection()
        {
            if (!Directory.Exists(RecipesCollectionStoragePath))
            {
                Directory.CreateDirectory(RecipesCollectionStoragePath);
            }
            
            if (!File.Exists(RelativePath))
            {
                UpdateCollection(new List<Recipe>());
                
                return new List<Recipe>();
            }

            var fullPath = Path.GetFullPath(RelativePath);
            
            var recipeCollectionJSONstring = File.ReadAllText(fullPath);
            
            return JsonSerializer.Deserialize<IList<Recipe>>(recipeCollectionJSONstring) ?? new List<Recipe>();
        }

        public static void UpdateCollection(IList<Recipe> recipeCollection)
        {
            var fullPath = Path.GetFullPath(RelativePath);

            using var updateRecipeCollection = File.CreateText(fullPath);
            var JSONRecipeCollection = JsonSerializer.Serialize(recipeCollection);
            updateRecipeCollection.Write(JSONRecipeCollection);
        }
    }
}
