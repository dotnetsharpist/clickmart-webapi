using ClickMart.Service.Interfaces.Common;

namespace ClickMart.Service.Services.Common;

public class ShortStorageService : IShortStorageService
{
    public IDictionary<string, string> KeyValuePairs { get; set; }
    public ShortStorageService()
    {
        KeyValuePairs = new Dictionary<string, string>();
    }
}
