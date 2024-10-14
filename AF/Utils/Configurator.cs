using System.Reflection;
using Newtonsoft.Json;

namespace AF.Utils;

/// <summary>
///     Configurator class is responsible for reading
///     the application settings from the appsettings.json file and GitHub secrets.
/// </summary>
public abstract class Configurator
{
    public static AppSettings ReadConfiguration()
    {
        var appSettingPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
            "appsettings.json");
        var appSettingsText = File.ReadAllText(appSettingPath);

        var appSettings = JsonConvert.DeserializeObject<AppSettings>(appSettingsText) ??
                          throw new FileNotFoundException();

        return appSettings;
    }
}