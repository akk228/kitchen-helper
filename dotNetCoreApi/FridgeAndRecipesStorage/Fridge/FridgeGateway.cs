namespace FridgeAndRecipesStorage.Fridge;

public static class FridgeGateway
{
    private const string FridgeName = @"Fridge.csv";
    private const string FridgePath = @"..\FridgeStorage\";

    private static string FullPath;
    private static bool FridgeIsOpened;

    public static Fridge OpenFridge()
    {
        if (!Directory.Exists(FridgePath))
        {
            Directory.CreateDirectory(FridgePath);
        }

        if (!File.Exists(FridgePath + FridgeName))
        {
            File.Create(FridgePath + FridgeName);
            return new Fridge();
        };

        FullPath = Path.GetFullPath(FridgePath + FridgeName);
        
        var products = new List<Product>();
        var fridgeContent = File.ReadAllLines(FullPath);

        foreach (var item in fridgeContent)
        {
            var product = item.Split(',');
            products.Add(new Product()
            {
                Name = product[0],
                Amount = Int32.Parse(product[1]),
                MeasurmentUnit = (Units) Enum.Parse(typeof(Units), product[2], true)
            });
        }
        
        FridgeIsOpened = true;
        return new Fridge(products);
    }

    public static bool FridgeUpdate(Fridge fridge)
    {
        var updatedFridge = File.OpenWrite(FridgePath);

        foreach(var product in fridge.GetAllProducts())
        {
            
        }
        return true;
    }
}