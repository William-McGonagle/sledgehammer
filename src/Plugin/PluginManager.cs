using System;
using System.Collections.Generic;
using System.IO;
using Sledge;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Text;
using System.Diagnostics;
using System.Net;


namespace Sledge.Plugin
{

    public class PluginManager
    {

        public static PluginConfigData[] pluginManifests;

        public static void Load()
        {

            // Load Plugin Manifests
            pluginManifests = LoadPluginManifests();

            // Load Plugin Code
            // for (int i = 0; i < pluginManifests.Length; i++)
            // {

            // }

            // string fullPath = Application.PersistentDataPath() + "/" + pluginManifests[0].path;
            // string pluginCode = File.ReadAllText(fullPath);

        }

        public static void LoadPlugin(int i)
        {



        }

        public static PluginConfigData[] LoadPluginManifests()
        {

            // Instantiate Files
            string[] folderNames = Directory.GetDirectories(Application.PersistentDataPath() + "/plugins");
            PluginConfigData[] _plugins = new PluginConfigData[folderNames.Length];

            // Loop Through All Files
            for (int i = 0; i < _plugins.Length; i++)
            {

                _plugins[i] = new PluginConfigData(folderNames[i] + "/package.cfg");

            }

            // Return Files
            return _plugins;

        }

    }

}