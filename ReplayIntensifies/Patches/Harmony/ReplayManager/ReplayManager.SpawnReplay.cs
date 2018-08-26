using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Harmony;

namespace ReplayIntensifies
{
    partial class Photon
    {
        [HarmonyPatch(typeof(ReplayManager), "SpawnReplay")]
        internal class ReplayManager_SpawnReplay_Patch : ReplayManager
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (int i = 0; i < codes.Count; i++)
                {
                    if (codes[i].opcode == OpCodes.Ldc_I4_S && codes[i].operand.ToString() == "20")
                    {
                        codes[i].opcode = OpCodes.Ldc_I4;
                        codes[i].operand = Math.Max(Math.Min(Photon.MaxReplaysAtAll, G.Sys.OptionsManager_.Replay_.GhostsInArcadeCount_), 20);
                    }
                }
                return codes;
            }
        }
    }
}
