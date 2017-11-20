using System.Configuration;

namespace StopwatchService.Infrasctructure.Config
{
    /// <summary>
    /// Responsible for provide configurations from Web.config.
    /// </summary>
    public class ConfigurationProvider
    {
        public static string GetConfiguration(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}