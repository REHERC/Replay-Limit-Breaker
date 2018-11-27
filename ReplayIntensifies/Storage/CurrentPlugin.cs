using Spectrum.API.Logging;

namespace ReplayIntensifies
{
    public static class CurrentPlugin
    {
        public static void Initialize()
        {
            Log = new Logger("ReplayIntensifies.log")
            {
                WriteToConsole = true
            };
        }

        public static Logger Log;
    }
}
