using static modifier;
using System.Collections.Generic;
using Harmony;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection.Emit;

namespace ReplayIntensifies
{
    partial class Photon
    {
        [HarmonyPatch(typeof(ReplayManager), "PlayPickedReplays")]
        internal class ReplayManager_PlayPickedReplays_Patch : ReplayManager
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (int i = 0; i < codes.Count; i++)
                {
                    if (codes[i].opcode == OpCodes.Ldc_I4_S && codes[i].operand.ToString() == "20")
                    {
                        codes[i].opcode = OpCodes.Ldc_I4;
                        codes[i].operand = (int)Math.Max((int)Math.Min(Photon.MaxReplaysAtAll,G.Sys.OptionsManager_.Replay_.GhostsInArcadeCount_),20);
                        //codes[i].operand = 600;

                        //codes[i + 2].opcode = OpCodes.Nop;
                        //codes[i + 2].operand = null;
                    }
                }
                return codes.AsEnumerable();
            }
        }
    }
}
