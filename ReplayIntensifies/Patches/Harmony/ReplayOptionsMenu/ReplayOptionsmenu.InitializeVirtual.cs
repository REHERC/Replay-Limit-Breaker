using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Harmony;

namespace ReplayIntensifies
{
    public partial class Photon
    {
        [HarmonyPatch(typeof(ReplayOptionsMenu), "InitializeVirtual")]
        internal class ReplayOptionsMenu_InitializeVirtual_Patch : ReplayOptionsMenu
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var codes = new List<CodeInstruction>(instructions);
                for (int i = 0; i < codes.Count; i++)
                {
                    if ((i > 5) &&
                        (codes[i    ].opcode == OpCodes.Ldc_I4_S && codes[i    ].operand.ToString() == "20") && 
                        (codes[i - 5].opcode == OpCodes.Ldstr    && codes[i - 5].operand.ToString().ToUpperInvariant() == "GHOSTS IN ARCADE COUNT"))
                    {
                        codes[i].opcode = OpCodes.Ldc_I4;
                        codes[i].operand = Math.Max(Photon.MaxReplaysAtAll, 20);
                    }
                }
                return codes;
            }
        }
    }
}
