using FridgeAndRecipesStorage.Gateway;

namespace FridgeAndRecipesStorage;

public static class Test
{
    public static void Main()
    {
        var stringGateway = new Gateway<string>();

        stringGateway.OpenFetchClose();
        stringGateway.OpenUpdateClose(new[] { "LOL", "KEK" });

        var intGateway = new Gateway<int>();

        intGateway.OpenUpdateClose(new[] { 1, 2, 3 });
    }
}