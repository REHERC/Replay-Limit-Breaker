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
        }

        public static Logger Log;
    }
}
