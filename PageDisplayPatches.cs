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
        public static int currentFrontPage;
        public static bool shouldCache01 = true;
        public static bool takeTwo = false;

        private static Dictionary<string, GameObject> internalDict;

        private static Texture GetPageTexture(PageDisplay.cachedPageData page)
        {
            string dictIndex = "" + page.pageIndex + (page.front ? "r" : "v");
            GameObject pageObject0r = internalDict[dictIndex];
            return pageObject0r.GetComponent<RawImage>().texture;
        }

        public static void MyUpdatePatchV3(PageDisplay __instance)
        {
            PageDisplay instance = __instance;
            PageDisplay.cachedPageData[] pages = instance.cachedPages;

            //TunicLanguagePlugin.Logger.LogInfo(instance.focusedOnRight);
            //TunicLanguagePlugin.Logger.LogInfo(instance.shownPage);

            int newFrontPage = instance.focusedOnRight ? instance.shownPage : instance.shownPage + 1;
            if (newFrontPage == currentFrontPage)
            {
                return;
            }

            TunicLanguagePlugin.Logger.LogWarning(pages[0].pageIndex);// Log. pages[0].pageIndex
            TunicLanguagePlugin.Logger.LogWarning(pages[0].front);
            TunicLanguagePlugin.Logger.LogWarning(pages[1].pageIndex);// Log. pages[0].pageIndex
            TunicLanguagePlugin.Logger.LogWarning(pages[1].front);
            TunicLanguagePlugin.Logger.LogWarning(pages[2].pageIndex);// Log. pages[0].pageIndex
            TunicLanguagePlugin.Logger.LogWarning(pages[2].front);
            TunicLanguagePlugin.Logger.LogWarning(pages[3].pageIndex);// Log. pages[0].pageIndex
            TunicLanguagePlugin.Logger.LogWarning(pages[3].front);

            pages[0].material.mainTexture = GetPageTexture(pages[0]);
            pages[1].material.mainTexture = GetPageTexture(pages[1]);
            pages[2].material.mainTexture = GetPageTexture(pages[2]);
            pages[3].material.mainTexture = GetPageTexture(pages[3]);

            //GameObject pageObject0v = internalDict["0v"];
            //var texture0v = pageObject0v.GetComponent<RawImage>().texture;
            //pages[1].material.mainTexture = texture0v;

            //GameObject pageObject1r = internalDict["1r"];
            //var texture1r = pageObject1r.GetComponent<RawImage>().texture;
            //pages[2].material.mainTexture = texture1r;

            //GameObject pageObject1v = internalDict["1v"];
            //var texture1v = pageObject1v.GetComponent<RawImage>().texture;
            //pages[3].material.mainTexture = texture1v;
        }

//            foreach (var o in Resources.FindObjectsOfTypeAll<Texture2D>())
//            {
//                if (o.name.Contains("leaf")) // || o.name.Contains("page"))
//                {
//                    TunicLanguagePlugin.Logger.LogInfo(o.name);
//                    TunicLanguagePlugin.Logger.LogInfo(o.width);
//                    TunicLanguagePlugin.Logger.LogInfo(o.height);
//                }
//}

        public static void Update_PostPatch(PageDisplay __instance)
        {
            PageDisplay instance = __instance;

            int newFrontPage = instance.focusedOnRight ? instance.shownPage : instance.shownPage + 1;
            if (newFrontPage == currentFrontPage && !takeTwo)
            {
                return;
            }

            var pages = instance.cachedPages;

            

            TunicLanguagePlugin.Logger.LogInfo("Inside Page Display Patch");
            TunicLanguagePlugin.Logger.LogInfo(instance.pageRenderers.Length);

            /*
            var pixels = internalDict["5r"];
            TunicLanguagePlugin.Logger.LogInfo(pixels[1000]);
            TunicLanguagePlugin.Logger.LogInfo(pixels[5000]);

            Texture2D frontTexture = new Texture2D(2048, 1560, TextureFormat.RGBA32, false);
            frontTexture.SetPixels(pixels);
            frontTexture.Apply(); 
            */

            //            pages[1].material.mainTexture = PageDictionary.GetPage("0r").texture;
            //TunicLanguagePlugin.Logger.LogInfo(PageDictionary.GetPage("0r").texture.GetPixel(24, 70));

            //            pages[1].material.mainTexture = PageDictionary.GetPage("0r");

            //pages[1].material = internalDict["5r"];

            currentFrontPage = newFrontPage;
            shouldCache01 = !shouldCache01;
            //takeTwo = true;
            
            int backIndex = shouldCache01 ? 0 : 2;
            int frontIndex = shouldCache01 ? 1 : 3;

            /*foreach (var k in InitializationPatches.textureDictionary.Keys)
            {
                TunicLanguagePlugin.Logger.LogInfo("\"" + k + "\"");
                TunicLanguagePlugin.Logger.LogInfo(InitializationPatches.textureDictionary[k].name);
            }*/


            //var dic = new Dictionary<string, Texture2D>();


            //internalDict = new Dictionary<string, Texture2D>();

            
            string filepathR = "BepInEx/plugins/images/leaf_0r_small.png";
            Texture2D frontTexture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            ImageConversion.LoadImage(frontTexture, File.ReadAllBytes(filepathR));
            frontTexture.Apply();

            pages[1].material.mainTexture = frontTexture;

            
            string filepathV = "BepInEx/plugins/images/leaf_0r_small.png";
            Texture2D backTexture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            ImageConversion.LoadImage(backTexture, File.ReadAllBytes(filepathV));
            backTexture.Apply();

            pages[0].material.mainTexture = backTexture;
            



            /*
            string filepathR2 = "BepInEx/plugins/images/leaf_6r.png";
            Texture2D frontTexture2 = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            ImageConversion.LoadImage(frontTexture2, File.ReadAllBytes(filepathR2));
            frontTexture2.Apply();
            dic.Add("6r", frontTexture2);

            string filepathV2 = "BepInEx/plugins/images/leaf_5v.png";
            Texture2D backTexture2 = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            ImageConversion.LoadImage(backTexture2, File.ReadAllBytes(filepathV2));
            backTexture2.Apply();
            dic.Add("5v", backTexture2);*/

            //Texture2D frontTexture = InitializationPatches.textureDictionary["5v"];



            //Texture2D backTexture = InitializationPatches.textureDictionary["5v"];


            /*
            //Texture2D frontTexture2 = InitializationPatches.textureDictionary["5v"];
            pages[3].material.mainTexture = PageDictionary.GetPage("6r");



            //Texture2D backTexture1 = InitializationPatches.textureDictionary["5v"];
            pages[2].material.mainTexture = PageDictionary.GetPage("5v");
            */


            /*
            Texture2D backTexture = InitializationPatches.textureDictionary[(newFrontPage - 1) + "v"];
            pages[backIndex].material.mainTexture = backTexture;

            Texture2D frontTexture = InitializationPatches.textureDictionary[newFrontPage + "r"];
            pages[frontIndex].material.mainTexture = frontTexture;
            */



            //TunicLanguagePlugin.Logger.LogInfo(PageDisplay.instance.shownPage);
            //TunicLanguagePlugin.Logger.LogInfo(PageDisplay.instance.focusedOnRight);

            /*for (var n = 0; n < 4; n++)
            {
                var cachedPage = pages[n];

                //TunicLanguagePlugin.Logger.LogInfo(cachedPage.material.mainTexture);
                //TunicLanguagePlugin.Logger.LogInfo(cachedPage.pageIndex);
                //TunicLanguagePlugin.Logger.LogInfo(cachedPage.assigned);
                //TunicLanguagePlugin.Logger.LogInfo(cachedPage.front);
                //TunicLanguagePlugin.Logger.LogInfo(cachedPage.WasCollected);
                //TunicLanguagePlugin.Logger.LogInfo(cachedPage.renderTexture);

                //cachedPage.material.mainTexture = texture2D;   
            }*/
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
            TunicLanguagePlugin.Logger.LogInfo(leafPath);
            Texture2D leafTex = new Texture2D(2048, 1560, TextureFormat.RGBA32, false);
            ImageConversion.LoadImage(leafTex, GetBytesForResource(leafPath));
            TunicLanguagePlugin.Logger.LogInfo("hi1");

            string grungePath = String.Format("TunicLanguageMod.grungifiers.page grungifier ({0}{1}).png", pageNumber, side);
            TunicLanguagePlugin.Logger.LogInfo(grungePath);
            Texture2D grungeTex = new Texture2D(2048, 1560, TextureFormat.RGBA32, false);
            ImageConversion.LoadImage(grungeTex, GetBytesForResource(grungePath));
            TunicLanguagePlugin.Logger.LogInfo("hi2");

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
            TunicLanguagePlugin.Logger.LogInfo("Inside Dictionary Initialization");

            TunicLanguagePlugin.Logger.LogInfo(Assembly.GetExecutingAssembly().GetManifestResourceNames().Length);
            foreach (string name in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                TunicLanguagePlugin.Logger.LogInfo(name);
            }

            internalDict = new Dictionary<string, GameObject>();
            for (int pageNum = 0; pageNum <= 27; pageNum += 1)
            {
                LoadLeafTexture(pageNum, "r");
                LoadLeafTexture(pageNum, "v");
            }




            //internalDict = new Dictionary<string, Texture2D>();
            //string filepathR = "BepInEx/plugins/images/leaf_0r.png";
            //Texture2D frontTexture = new Texture2D(2048, 1560, TextureFormat.RGBA32, false);

            //ImageConversion.LoadImage(frontTexture, File.ReadAllBytes(filepathR));
            //frontTexture.Apply();
            //Texture2D.DontDestroyOnLoad(frontTexture);

            //Color[] pixels = frontTexture.GetPixels(0, 0, 2048, 1560);

            //TunicLanguagePlugin.Logger.LogInfo(pixels[1000]);
            //TunicLanguagePlugin.Logger.LogInfo(pixels[5000]);

            //internalDict.Add("5r", frontTexture);

            /*
            for (int n = 0; n <= 27; n++)
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
    }
}

/// --- OLD CODE --- ///


// 2048, 1560

/*foreach (var renderer in instance.pageRenderers)
            {
                renderer.material.mainTexture = texture2D;
                //TunicLanguagePlugin.Logger.LogInfo(renderer.material.mainTexture);
            }*/
//TunicLanguagePlugin.Logger.LogInfo(__instance.pageRenderers.First().gameObject.name);

//TunicLanguagePlugin.Logger.LogInfo(__result);

/*var gameObjects = Resources.FindObjectsOfTypeAll<Sprite>();
foreach (var gameObject in gameObjects)
{
    TunicLanguagePlugin.Logger.LogInfo(gameObject.name);
}*/

//page rear L
//Plane
//Plane
//page rear R

/*foreach (var c in __instance.continueButton.GetComponents<GameObject>())
            {
                TunicLanguagePlugin.Logger.LogInfo(c.name);
                TunicLanguagePlugin.Logger.LogInfo(c.GetType());
            }*/

/*Texture2D square = new Texture2D(200, 200, TextureFormat.RGB24, false);
for (int n = 0; n< 200; n++)
{
    for (int m = 0; m< 200; m++)
    {
        square.SetPixel(m, n, Color.red);
    }
}
square.Apply();*/

//RenderTexture.active = page.renderTexture;
//RenderTexture.active = null;

//var objs = Resources.FindObjectsOfTypeAll<GameObject>();
// numbers
// page rear R
// page rear L
// page R
// page L