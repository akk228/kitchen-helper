using FridgeAndRecipesStorage.Gateway;

namespace FridgeAndRecipesStorage.Fridge;

public class Fridge
{
    private readonly Gateway<Product> _fridgeGateway;
    private Dictionary<string, Product> _products;
    
    public Fridge(Gateway<Product> fridgeGateway)
    {
        _fridgeGateway = fridgeGateway;
        _products = new Dictionary<string, Product>();
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _fridgeGateway.Select();
    }
    public IEnumerable<Product> FindProducts(string name)
    {
        return _fridgeGateway
            .Select()
            .Where(x =>
                x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }
    public Product AddProduct(Product product)
    {
        _products = _fridgeGateway.Select()
            .ToDictionary(
                x=> x.Name,
                x => x,
                StringComparer.OrdinalIgnoreCase);
        
        AddProductInternal(product);
        
        _fridgeGateway.Update(_products.Select(x=> x.Value));
        
        return _products[product.Name];
    }
    
    public void WithdrawProduct(string productName)
    {
        var products = _fridgeGateway.Select()
            .ToDictionary(
                x=> x.Name,
                x => x,
                StringComparer.OrdinalIgnoreCase);

        if (!products.Remove(productName))
        {
            throw new Exception("No such product");
        }

        _fridgeGateway.Update(products.Select(x => x.Value));
    }

    public IEnumerable<Product> AddProducts(IEnumerable<Product> productsToAdd)
    {
        _products = _fridgeGateway.Select()
            .ToDictionary(
                x=> x.Name,
                x => x,
                StringComparer.OrdinalIgnoreCase);
        
        foreach (var product in productsToAdd)
        {
            AddProductInternal(product);
        }

        var newProductList = _products.Select(x => x.Value).ToList();
        
        _fridgeGateway.Update(newProductList);
        
        return newProductList;
    }

    public IEnumerable<Product> TakeProducts(IEnumerable<Product> products)
    {
        _products = _fridgeGateway.Select()
            .ToDictionary(
                x=> x.Name,
                x => x,
                StringComparer.OrdinalIgnoreCase);
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

            _fridgeGateway.Update(_products.Select(x => x.Value));
            
            return productsList;
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
    
    private void AddProductInternal(Product product)
    {
        if (!_products.TryAdd(product.Name, product))
        {
            if (_products[product.Name].MeasurmentUnit == product.MeasurmentUnit)
            {
                _products[product.Name].Amount += product.Amount;
            }
            else
            {
                throw new Exception("Incorrect units");
            }
        }
    }
}