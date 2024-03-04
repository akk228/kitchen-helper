namespace FridgeAndRecipesStorage.Fridge;

public class Fridge : IFridge
{
    private FridgeState _state;
    private Object _fridgeLock = new Object();

    private Dictionary<string, Product> _products;
    public Fridge()
    {
        _products = new Dictionary<string, Product>(StringComparer.OrdinalIgnoreCase);
        _state = FridgeState.Ready;
    }

    public Fridge(IEnumerable<Product> products)
    {
        _products = products.ToDictionary(
            item => item.Name,
            item => item,
            StringComparer.OrdinalIgnoreCase);
        _state = FridgeState.Ready;

    }

    public IEnumerable<Product> GetAllProducts()
    {
            lock(_fridgeLock)
            {
                return _products.Select(x => x.Value);
            }
    }

    public Product FindProduct(string name)
    {
            lock (_fridgeLock)
            {
                _products.TryGetValue(name, out Product? product);
                return product;
            }
    }
    public Product AddProduct(Product product)
    {
        lock (_fridgeLock)
        {
            if (!_products.TryAdd(product.Name, product))
            {
                _products[product.Name].Amount += product.Amount;
            }
        }

        return _products[product.Name];
    }

    public void WithdrawProduct(string productName)
    {
        lock (_fridgeLock)
        {
            if (!_products.Remove(productName))
            {
                throw new Exception("Can't remove product that isn't in the Fridge");
            };
        }
    }

    public IEnumerable<Product> AddProducts(IEnumerable<Product> products)
    {
        var productsList = new List<Product>();
        lock (_fridgeLock)
        {
            foreach (var product in products)
            {
                productsList.Add(AddProduct(product));
            }
        }

        return productsList;
    }

    public IEnumerable<Product> TakeProducts(IEnumerable<Product> products)
    {
        var productsList = new List<Product>();

        lock (_fridgeLock)
        {
            foreach(var product in products)
            {
                var productUsed = TakeProduct(product);

                if(productUsed != null)
                {
                    productsList.Add(productUsed);
                }
            }
        }
        return productsList;
    }
    
    private Product TakeProduct(Product productToUse)
    {
        lock (_fridgeLock)
        {
            if (_products.TryGetValue(productToUse.Name, out var product))
            {
                var remindingAmount = product.Amount - productToUse.Amount;

                if (remindingAmount > 0)
                {
                    _products[product.Name].Amount = remindingAmount;
                    return _products[product.Name];
                }
                else if (remindingAmount == 0)
                {
                    _products.Remove(product.Name);
                    return null;
                }
            }

            throw new Exception("No such product");
        }
        
    }
    
    
    public static Fridge OpenFridge()
    {
        throw new NotImplementedException();
    }
}