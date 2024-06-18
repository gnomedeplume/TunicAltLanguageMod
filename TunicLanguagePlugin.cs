using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace TunicLanguageMod
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class TunicLanguagePlugin : BasePlugin
    {
        public const string pluginGuid = "gnomedeplume.tunic.languagemod";
        public const string pluginName = "Tunic Language Mod";
        public const string pluginVersion = "0.1";

        public static ManualLogSource Logger;

        public static Texture2D MyTex;

        public override void Load()
        {
            // You can use Logger for console output
            // It's a static property so you can use it anywhere with TunicLanguagePlugin.Logger
            Logger = Log;
            Harmony harmony = new Harmony(pluginGuid);

            MethodInfo original_pc_start = AccessTools.Method(typeof(PlayerCharacter), "Start");
            MethodInfo patched_pc_start = AccessTools.Method(typeof(PageDisplayPatches), "InitializeTextureDictionary");
            //harmony.Patch(original_pc_start, null, new HarmonyMethod(patched_pc_start));

            MethodInfo original_pd_update = AccessTools.Method(typeof(PageDisplay), "updatePageturnData");
            MethodInfo patched_pd_update = AccessTools.Method(typeof(PageDisplayPatches), "MyUpdatePatchV3");
            //harmony.Patch(original_pd_update, new HarmonyMethod(patched_pd_update));

            MethodInfo original_pd2_start = AccessTools.Method(typeof(PageDisplay), "updatePageturnData");
            MethodInfo patched_pd2_start = AccessTools.Method(typeof(TextPatches), "OutputTextIds");
            harmony.Patch(original_pd2_start, null, new HarmonyMethod(patched_pd2_start));

            MethodInfo original_al_start = AccessTools.Method(typeof(AreaLabel), "ShowLabel");
            MethodInfo patched_al_start = AccessTools.Method(typeof(AreaDataPatches), "UseNewMessage");
            harmony.Patch(original_al_start, new HarmonyMethod(patched_al_start));
        }
    }
}
