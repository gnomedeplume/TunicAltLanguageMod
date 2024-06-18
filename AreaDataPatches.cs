using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunicLanguageMod
{
    class AreaDataPatches
    {
        public static void UseNewMessage(PageDisplay __instance, AreaData area)
        {
            TunicLanguagePlugin.Logger.LogWarning("Inside the area data thingy");
            TunicLanguagePlugin.Logger.LogWarning(area.topLine.text);
            area.topLine.text = "hi";
            area.bottomLine.text = "bi";
        }
    }
}
