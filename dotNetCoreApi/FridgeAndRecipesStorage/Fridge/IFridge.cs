namespace FridgeAndRecipesStorage.Fridge;

public interface IFridge
{
    IEnumerable<Product> GetAllProducts();
    Product AddProduct(Product product);
    Product FindProduct(string product);
    void WithdrawProduct(string productName);
    IEnumerable<Product> AddProducts(IEnumerable<Product> product);
    IEnumerable<Product> TakeProducts(IEnumerable<Product> products);
}