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

namespace TunicLanguageMod
{
    class PageDisplayPatches
    {
        private static Dictionary<string, GameObject> internalDict;

        private static Texture GetPageTexture(PageDisplay.cachedPageData page)
        {
            // Looks like pageIndex is coming back -1 when manual is loading
            // This causes an exception but everything runs fine anyway
            string dictIndex = "" + page.pageIndex + (page.front ? "r" : "v");
            GameObject pageObject = internalDict[dictIndex];
            return pageObject.GetComponent<RawImage>().texture;
        }

        public static void MyUpdatePatchV3(PageDisplay __instance)
        {
            PageDisplay instance = __instance;
            PageDisplay.cachedPageData[] pages = instance.cachedPages;

            pages[0].material.mainTexture = GetPageTexture(pages[0]);
            pages[1].material.mainTexture = GetPageTexture(pages[1]);
            pages[2].material.mainTexture = GetPageTexture(pages[2]);
            pages[3].material.mainTexture = GetPageTexture(pages[3]);
        }

        private static byte[] GetBytesForResource(string filename)
        {
            using (Stream sourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(filename))
            {
                using (var memoryStream = new MemoryStream())
                {
                    sourceStream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }

        private static void LoadLeafTexture(int pageNumber, string side) 
        {
            string leafPath = String.Format("TunicLanguageMod.leaves.leaf_{0}{1}.png", pageNumber, side);
            TunicLanguagePlugin.Logger.LogInfo("Loading " + leafPath);
            Texture2D leafTex = new Texture2D(2048, 1560, TextureFormat.RGBA32, false);
            ImageConversion.LoadImage(leafTex, GetBytesForResource(leafPath));

            string grungePath = String.Format("TunicLanguageMod.grungifiers.page grungifier ({0}{1}).png", pageNumber, side);
            TunicLanguagePlugin.Logger.LogInfo("Loading " + grungePath);
            Texture2D grungeTex = new Texture2D(2048, 1560, TextureFormat.RGBA32, false);
            ImageConversion.LoadImage(grungeTex, GetBytesForResource(grungePath));

            TunicLanguagePlugin.Logger.LogInfo("Combining textures...");

            Color[] leafPixels = leafTex.GetPixels();
            Color[] grungePixels = grungeTex.GetPixels();
            Color[] combinedPixels = new Color[leafPixels.Length];

            for (int index = 0; index < leafPixels.Length; index += 1)
            {
                Color leafColor = leafPixels[index];
                Color grungeColor = grungePixels[index];
                combinedPixels[index] = new Color(leafColor.r * grungeColor.r, leafColor.g * grungeColor.g, leafColor.b * grungeColor.b);
            }

            leafTex.SetPixels(combinedPixels);
            leafTex.Apply();

            GameObject pageImage = new GameObject(String.Format("translated page {0}{1}", pageNumber, side));
            pageImage.AddComponent<RawImage>().texture = leafTex;
            GameObject.DontDestroyOnLoad(pageImage);

            internalDict.Add("" + pageNumber + side, pageImage);
        }

        public static void InitializeTextureDictionary()
        {
            // You can use Assembly.GetExecutingAssembly().GetManifestResourceNames() to get the pathname for resources stored in the DLL

            TunicLanguagePlugin.Logger.LogInfo("Preloading all translated pages...");

            internalDict = new Dictionary<string, GameObject>();
            for (int pageNum = 0; pageNum <= 27; pageNum += 1)
            {
                LoadLeafTexture(pageNum, "r");
                LoadLeafTexture(pageNum, "v");
            }

            TunicLanguagePlugin.Logger.LogInfo("Finished loading all translated pages");
        }
    }
}
