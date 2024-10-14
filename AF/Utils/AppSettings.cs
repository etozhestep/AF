namespace AF.Utils;

/// <summary>
///     Contains the application settings.
/// </summary>
/// <param name="browserType"></param>
/// <param name="timeOut"></param>
/// <param name="url"></param>
/// <param name="email"></param>
/// <param name="password"></param>
public class AppSettings(string? browserType, double timeOut, string url, string email, string password, string apiUrl)
{
    public string? BrowserType { get; } = browserType;
    public double TimeOut { get; } = timeOut;

    public string Url { get; set; } = url;
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
    public string ApiUrl { get; set; } = apiUrl;
}