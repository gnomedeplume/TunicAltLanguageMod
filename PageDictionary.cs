using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace TunicLanguageMod
{
    public static class PageDictionary
    {
        private static Dictionary<string, Sprite> internalDict;

        public static void Initialize()
        {
            TunicLanguagePlugin.Logger.LogInfo("Inside Page Display Patch");

            internalDict = new Dictionary<string, Sprite>();

            string filepathR = "BepInEx/plugins/images/leaf_0r.png";
            Texture2D frontTexture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            ImageConversion.LoadImage(frontTexture, File.ReadAllBytes(filepathR));
            frontTexture.Apply();

            var mySprite = Sprite.Create(frontTexture, new Rect(0, 0, frontTexture.width, frontTexture.height), new Vector2(0, 0));

            internalDict.Add("0r", mySprite);

            /*for (int n = 0; n <= 27; n++)
            {
                string filepathR = "BepInEx/plugins/images/leaf_" + n + "r.png";
                Texture2D frontTexture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                ImageConversion.LoadImage(frontTexture, File.ReadAllBytes(filepathR));
                frontTexture.Apply();
                internalDict.Add(n + "r", frontTexture);

                string filepathV = "BepInEx/plugins/images/leaf_" + n + "v.png";
                Texture2D backTexture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                ImageConversion.LoadImage(backTexture, File.ReadAllBytes(filepathV));
                backTexture.Apply();
                internalDict.Add(n + "v", backTexture);
            }*/
        }

        public static Sprite GetPage(string pageKey)
        {
            return internalDict[pageKey];
        }
    }
}
