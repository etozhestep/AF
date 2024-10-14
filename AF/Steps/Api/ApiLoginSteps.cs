using AF.Models;
using AF.Services;
using RestSharp;

namespace AF.Steps.Api;

public class ApiLoginSteps
{
    private readonly ApiLoginService _loginService = new();

    public string AuthenticateUser(UserModel model)
    {
        return _loginService.AuthenticateUser(model);
    }

    public RestResponse AuthenticateUserWithInvalidData(UserModel model)
    {
        return _loginService.AuthenticateUserWithInvalidData(model);
    }
}