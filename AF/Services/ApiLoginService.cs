using System.Net;
using AF.Core;
using AF.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AF.Services;

public class ApiLoginService
{
    private readonly RestClient _client = RestClientFactory.CreateClient();

    public string AuthenticateUser(UserModel model)
    {
        var request = new RestRequest("/uat/sso/oauth/token", Method.Post);
        request.AddJsonBody(new
        {
            grant_type = "password",
            login = model.Email,
            password = model.Pass
        });

        var response = _client.Execute(request);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new InvalidOperationException($"Failed to authenticate user. Status code: {response.StatusCode}");

        if (response.Content == null) return string.Empty;
        var responseData = JsonConvert.DeserializeObject<JObject>(response.Content);
        if (responseData == null || !responseData.TryGetValue("token", out var value))
            throw new InvalidOperationException("Failed to retrieve token from response.");

        return value.ToString();
    }

    public RestResponse AuthenticateUserWithInvalidData(UserModel model)
    {
        var request = new RestRequest("user/login", Method.Post);
        request.AddJsonBody(new
        {
            login = model.Email,
            password = model.Pass
        });

        return _client.Execute(request);
    }
}