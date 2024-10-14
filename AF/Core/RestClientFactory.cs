using AF.Utils;
using RestSharp;

namespace AF.Core;

public class RestClientFactory
{
    public static RestClient CreateClient()
    {
        return new RestClient(Configurator.ReadConfiguration().ApiUrl);
    }
}