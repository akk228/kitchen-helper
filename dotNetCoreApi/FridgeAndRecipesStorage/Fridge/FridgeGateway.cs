namespace FridgeAndRecipesStorage.Fridge;

public static class FridgeGateway
{
    private const string FridgeName = @"Fridge.csv";
    private const string FridgePath = @"..\FridgeStorage\";

    private static string FullPath;

    private static Object _lock = new object();
    public static Fridge OpenFridge()
    {
        lock(_lock)
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
        
            return new Fridge(products);
        }
       
    }

    public static bool FridgeUpdate(IEnumerable<Product> products)
    {
        lock (_lock)
        {
            try
            {
                FullPath = Path.GetFullPath(FridgePath + FridgeName);

                using (var updatedFridge = File.CreateText(FullPath))
                {
                    foreach (var product in products)
                    {
                        var productInfo = new string[] 
                        {
                            product.Name,
                            product.Amount.ToString(),
                            product.MeasurmentUnit.ToString()
                        };

                        updatedFridge.WriteLine(string.Join(',', productInfo));
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }   
        }
    }
}