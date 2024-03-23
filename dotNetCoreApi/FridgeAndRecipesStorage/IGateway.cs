namespace FridgeAndRecipesStorage;

public interface IGateway<T>
{
    T Select();
}