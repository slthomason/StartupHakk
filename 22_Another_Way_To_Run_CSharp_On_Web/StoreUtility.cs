public class StoreUtility
{
    [JSImport("storeData", "./view.js")]
    public static partial void storeData(string data);
    [JSExport]
    public static string GetProductUrl()
    {
          
    }
    
}   