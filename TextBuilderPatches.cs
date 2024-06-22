using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace TunicLanguageMod
{
    class TextBuilderPatches
    {
        public static void BuildTokiPonaGlyphs(MixedTextBuilder __instance, string inputString)
        {
            TunicLanguagePlugin.Logger.LogWarning("Finished building sprites for: " + inputString);
            TunicLanguagePlugin.Logger.LogWarning("Number of sprite builders: " + __instance.spriteBuilders.Count);



            foreach (var builder in __instance.spriteBuilders)
            {
                TunicLanguagePlugin.Logger.LogWarning("Number of sub-objects: " + builder.gameObjects.Count);
                foreach (var gameObject in builder.gameObjects)
                {
                    TunicLanguagePlugin.Logger.LogWarning("Name of sub object: " + gameObject.name);
                    var components = gameObject.GetComponents<Component>();
                    foreach (var comp in components)
                    {
                        TunicLanguagePlugin.Logger.LogWarning(comp.name);
                        TunicLanguagePlugin.Logger.LogWarning(comp.GetType());
                        TunicLanguagePlugin.Logger.LogWarning(comp.ToString());
                    }
                }

                //TunicLanguagePlugin.Logger.LogWarning(SpriteBuilder.spriteResources.Count);
                //foreach (var sprite in SpriteBuilder.spriteResources)
                //{
                //    TunicLanguagePlugin.Logger.LogWarning(sprite.name);
                //}
            }
        }

        //System.IO.File.WriteAllBytes("tunicImage" + RandomString(7) + ".png", ImageConversion.EncodeToPNG(SpriteBuilder.glyphMaterial.mainTexture as Texture2D));

        public static string RandomString(int length)
        {
            const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder outputBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                outputBuilder.Append(glyphs[UnityEngine.Random.Range(0, glyphs.Length)]);
            }
            return outputBuilder.ToString();
        }
    }
}
