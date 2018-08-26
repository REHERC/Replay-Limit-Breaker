using System.Collections.Generic;
using Spectrum.API.Configuration;
using Spectrum.API.Logging;
using Spectrum.API.Storage;

namespace ReplayIntensifies
{
    public static class CurrentPlugin
    {
        public static void Initialize()
        {
            Log = new Logger("ReplayIntensifies.log");
            Log.WriteToConsole = true;
            Config = new Settings("Config");
            InitConfig();
        }

        public static void InitConfig()
        {
            var DefaultConfig = new Dictionary<string, object>
            {
                {"LanguageFile", ":default:"},
                {"Rainbow", false},
                {"Dump", false}
            };

            foreach (var entry in DefaultConfig)
            {
                if (!Config.ContainsKey(entry.Key))
                {
                    Config.Add(entry.Key, entry.Value);
                }
            }

            FileSystem Files = new FileSystem();

            Config.Save();
        }

        public static Logger Log;
        public static Settings Config;
    }
}
