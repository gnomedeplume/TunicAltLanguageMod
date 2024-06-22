using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunicLanguageMod
{
    class TextBuilderPatches
    {
        public static void BuildTokiPonaGlyphs(MixedTextBuilder __instance, string inputString)
        {
            TunicLanguagePlugin.Logger.LogWarning("Oh HAI there");
            TunicLanguagePlugin.Logger.LogWarning(__instance.spriteBuilders.Count);

            foreach (var builder in __instance.spriteBuilders)
            {
                TunicLanguagePlugin.Logger.LogWarning(builder.ParsableSymbolText);
                TunicLanguagePlugin.Logger.LogWarning(builder._localizedText);
                TunicLanguagePlugin.Logger.LogWarning(builder.gameObjects.Count);
            }
        }
    }
}
