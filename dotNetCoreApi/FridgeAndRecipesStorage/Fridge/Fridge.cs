namespace FridgeAndRecipesStorage.Fridge;

public class Fridge : IFridge
{
    private Dictionary<string, Product> _products;
    private readonly Object _lock = new object();
    
    public Fridge()
    {
        _products = FridgeGateway
            .OpenFridge()
            .GetAllProducts()
            .ToDictionary(
                item => item.Name,
                item => item,
                StringComparer.OrdinalIgnoreCase);

    }
    
    public Fridge(IEnumerable<Product> products)
    {
        _products = products.ToDictionary(
            item => item.Name,
            item => item,
            StringComparer.OrdinalIgnoreCase);
    }

    public IEnumerable<Product> GetAllProducts()
    {
        lock (_lock)
        {
            return _products.Select(x => x.Value);   
        }
    }

    public Product? FindProduct(string name)
    {
        lock (_lock)
        {
            _products.TryGetValue(name, out Product? product);
            return product;   
        }
    }
    public Product AddProduct(Product product)
    {
        lock (_lock)
        {
            var updatedProduct =  AddProductInternal(product);

            FridgeGateway.FridgeUpdate(_products.Select(x => x.Value));
            
            return updatedProduct;
        }
    }
    
    public void WithdrawProduct(string productName)
    {
        lock (_lock)
        {
            if (!_products.Remove(productName))
            {
                throw new Exception("Can't remove product that isn't in the Fridge");
            }

            FridgeGateway.FridgeUpdate(_products.Select(x => x.Value));
        }
    }

    public IEnumerable<Product> AddProducts(IEnumerable<Product> products)
    {
        lock (_lock)
        {
            var productsList = new List<Product>();
        
            foreach (var product in products)
            {
                productsList.Add(AddProductInternal(product));
            }
        
            FridgeGateway.FridgeUpdate(_products.Select(x => x.Value));
        
            return productsList;   
        }
    }

    public IEnumerable<Product> TakeProducts(IEnumerable<Product> products)
    {
        lock (_lock)
        {
            var productsList = new List<Product>();

            foreach(var product in products)
            {
                productsList.Add(TakeProduct(product));
            }

            foreach (var product in productsList)
            {
                if (product.Amount == 0)
                {
                    _products.Remove(product.Name);
                }
                else
                {
                    _products[product.Name] = product;
                }
            }
            FridgeGateway.FridgeUpdate(_products.Select(x => x.Value));

            return productsList;   
        }
    }
    
    private Product TakeProduct(Product productToUse)
    {
        if (_products.TryGetValue(productToUse.Name, out var product))
        {
            var remindingAmount = product.Amount - productToUse.Amount;

            if (remindingAmount >= 0)
            {
                return new Product()
                {
                    Name = productToUse.Name,
                    Amount = remindingAmount,
                    MeasurmentUnit = productToUse.MeasurmentUnit
                };
            }
        }
        throw new Exception("No such product, or not enough");
    }
    
    private Product AddProductInternal(Product product)
    {
        if (!_products.TryAdd(product.Name, product))
        {
            _products[product.Name].Amount += product.Amount;
        }
        return _products[product.Name];
    }

}