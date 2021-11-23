using System;
using System.IO;
using Sledge;

namespace Sledge.Plugin
{

    public class PluginManager
    {

        public static PluginConfigData[] GetPlugins()
        {

            // Instantiate Files
            string[] folderNames = Directory.GetDirectories(Application.PersistentDataPath() + "/plugins");
            PluginConfigData[] plugins = new PluginConfigData[folderNames.Length];

            // Loop Through All Files
            for (int i = 0; i < plugins.Length; i++)
            {

                Console.WriteLine(folderNames[i]);
                plugins[i] = new PluginConfigData(folderNames[i] + "/package.cfg");

            }

            // Return Files
            return plugins;

        }

    }

}