using System;
using System.Reflection;
using Harmony;
using Spectrum.API.Interfaces.Plugins;
using Spectrum.API.Interfaces.Systems;

namespace ReplayIntensifies
{
    public partial class Photon : IPlugin
    {
        public const int MaxReplaysAtAll = 1000;


        public void Initialize(IManager manager, string ipcIdentifier)
        {
            Console.WriteLine($"Initializing ... ({ipcIdentifier})");
            CurrentPlugin.Initialize();
            try
            {
                CurrentPlugin.Log.Info("Instantiating Harmony Patcher ...");
                HarmonyInstance Harmony = HarmonyInstance.Create("com.REHERC.ReplayIntensifies");
                CurrentPlugin.Log.Info("Harmony patcher instantiated!");
                CurrentPlugin.Log.Info("Patching assemblies ...");
                Harmony.PatchAll(Assembly.GetExecutingAssembly());
                CurrentPlugin.Log.Info("Assemblies patched!");
            }
            catch (Exception VirusSpirit)
            {
                CurrentPlugin.Log.Error("Failed to patch the assemblies!");
                CurrentPlugin.Log.Exception(VirusSpirit);

            }
        }
    }
}
