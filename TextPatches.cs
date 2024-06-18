using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GUI;

namespace TunicLanguageMod
{
    class TextPatches
    {
        public static void OutputTextIds(PageDisplay __instance)
        {
            var signs = UnityEngine.Object.FindObjectsOfType<Signpost>();
            foreach (var sign in signs)
            {
                TunicLanguagePlugin.Logger.LogWarning(sign.message.text);
                sign.message.text = "#is is good";
                TunicLanguagePlugin.Logger.LogWarning(sign.message.text);
            }
        }
    }
}
