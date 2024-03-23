using System.Text.Json;

namespace FridgeAndRecipesStorage.Gateway;

public class Gateway<T>
{
    private static GatewayState State;
    
    private static readonly string Lock = new string(typeof(T).Name.ToCharArray());
    
    private const string StorageRelativePath = @"..\";
    private const string StorageFileExtension = @".json";
    private const string Storage = @"Storage\";
    
    private readonly string _storageDirectoryRelativePath;
    private readonly string _storageRelativePath;
    
    public Gateway()
    {
        var storageName = typeof(T).Name;
        
        _storageDirectoryRelativePath = StorageRelativePath + storageName + Storage;
        _storageRelativePath = _storageDirectoryRelativePath + storageName + StorageFileExtension;
    }

    public IEnumerable<T> OpenFetchClose()
    {
        if (State == GatewayState.Free)
        {
            return OpenFetchCloseGo();
        }

        lock (Lock)
        {
            return OpenFetchCloseGo();
        }
    }
    
    public IEnumerable<T> OpenUpdateClose(IEnumerable<T> data)
    {
        lock (Lock)
        {
            State = GatewayState.Updating;
            var updatedResult = OpenUpdateCloseGo(data);
            State = GatewayState.Free;
            return updatedResult;
        }
    }
    
    private IEnumerable<T> OpenFetchCloseGo()
    {
        if (!Directory.Exists(_storageDirectoryRelativePath))
        {
            Directory.CreateDirectory(_storageDirectoryRelativePath);
        }

        if (!File.Exists(_storageRelativePath))
        {
            File.Create(_storageRelativePath);
            return new List<T>();
        }

        var fullStoragePath = Path.GetFullPath(_storageRelativePath);

        var jsonString = File.ReadAllText(fullStoragePath);

        if (jsonString.Trim() == "")
        {
            return new List<T>();
        }
        
        return JsonSerializer.Deserialize<IEnumerable<T>>(jsonString) ?? new List<T>();
    }

    private IEnumerable<T> OpenUpdateCloseGo(IEnumerable<T> data)
    {
        if (!Directory.Exists(_storageDirectoryRelativePath))
        {
            Directory.CreateDirectory(_storageDirectoryRelativePath);
        }

        if (!File.Exists(_storageRelativePath))
        {
            File.Create(_storageRelativePath);
        }
        
        var fullPath = Path.GetFullPath(_storageRelativePath);

        var dataList = data.ToList();
        
        using var updateDataStream = File.CreateText(fullPath);
        
        updateDataStream.Write(
            JsonSerializer.Serialize(dataList));
        
        return dataList;
    }
}