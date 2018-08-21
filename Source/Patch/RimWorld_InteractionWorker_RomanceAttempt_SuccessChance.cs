﻿using Harmony;
using PawnRules.Data;
using RimWorld;
using Verse;

namespace PawnRules.Patch
{
    [HarmonyPatch(typeof(InteractionWorker_RomanceAttempt), nameof(InteractionWorker_RomanceAttempt.SuccessChance))]
    internal static class RimWorld_InteractionWorker_RomanceAttempt_SuccessChance
    {
        private static bool Prefix(ref float __result, Pawn initiator, Pawn recipient)
        {
            if (!Registry.IsActive) { return true; }

            var initiatorCanCourt = Registry.GetRules(initiator)?.AllowCourting ?? true;
            var recipientCanCourt = Registry.GetRules(recipient)?.AllowCourting ?? true;

            if (initiatorCanCourt && recipientCanCourt) { return true; }

            __result = 0f;
            return false;
        }
    }
}