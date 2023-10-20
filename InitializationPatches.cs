using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;


using UnityEngine;

namespace TunicLanguageMod
{
    class InitializationPatches
    {
        public static Dictionary<string, Texture2D> textureDictionary;

        public static void PC_Start_PostPatch()
        {
            TunicLanguagePlugin.Logger.LogInfo("Inside Page Display Patch");
            // Resources.Load<Texture2D>("BepInEx/plugins/images/leaf_4v.png");

            foreach (var o in Resources.FindObjectsOfTypeAll<Texture2D>())
            {
                if (o.name.Contains("leaf") || o.name.Contains("page"))
                {
                    TunicLanguagePlugin.Logger.LogInfo(o.name);
                }
            }

            //foreach (var o in Resources.FindObjectsOfTypeAll<PageDisplay>())
            //{
            //    TunicLanguagePlugin.Logger.LogInfo(o.currentCachedIndices.Length);
            //    TunicLanguagePlugin.Logger.LogInfo(o.currentCachedIndices[0]); 
            //    TunicLanguagePlugin.Logger.LogInfo(o.currentCachedIndices[1]); 
            //    TunicLanguagePlugin.Logger.LogInfo(o.currentCachedIndices[2]); 
            //    TunicLanguagePlugin.Logger.LogInfo(o.currentCachedIndices[3]); 
            //}

            // Page Rear L
            // Plane
            // Plane
            // Page Rear R

            TunicLanguagePlugin.Logger.LogInfo("Inside Page Display Patch 2");

            /*TunicLanguagePlugin.Logger.LogInfo("Inside Page Display Patch");

            textureDictionary = new Dictionary<string, Texture2D>();

            for (int n = 0; n <= 27; n++)
            {
                string filepathR = "BepInEx/plugins/images/leaf_" + n + "r.png";
                Texture2D frontTexture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                ImageConversion.LoadImage(frontTexture, File.ReadAllBytes(filepathR));
                frontTexture.Apply();
                textureDictionary.Add(n + "r", frontTexture);

                string filepathV = "BepInEx/plugins/images/leaf_" + n + "v.png";
                Texture2D backTexture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                ImageConversion.LoadImage(frontTexture, File.ReadAllBytes(filepathV));
                backTexture.Apply();
                textureDictionary.Add(n + "v", backTexture);
            }*/

            /*
            string filepathR = "BepInEx/plugins/images/leaf_" + 5 + "r.png";
            TunicLanguagePlugin.MyTex = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            ImageConversion.LoadImage(TunicLanguagePlugin.MyTex, File.ReadAllBytes(filepathR));
            TunicLanguagePlugin.MyTex.Apply();
            */
        }
    }
}
