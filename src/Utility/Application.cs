using Sledge;
using System.Runtime.InteropServices;
using System.IO;
using System;

public class Application
{

    public static bool reload = false;

    public static void ConfigureSystem()
    {

        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {

            // Check Directories Exist
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Library/Application Support/amvc")) Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Library/Application Support/amvc");
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Library/Application Support/amvc/sledge")) Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Library/Application Support/amvc/sledge");

            // Check that Settings Object Exists
            if (!File.Exists(PersistentDataPath() + "/settings.cfg")) new SettingsData().Save(PersistentDataPath() + "/settings.cfg");

            // Check that Styles Exist
            if (!Directory.Exists(PersistentDataPath() + "/styles")) Directory.CreateDirectory(PersistentDataPath() + "/styles");
            if (!File.Exists(PersistentDataPath() + "/styles/original.cfg")) new StyleSettingsData().Save(PersistentDataPath() + "/styles/original.cfg");

            // Check that Fonts Exist
            if (!Directory.Exists(PersistentDataPath() + "/fonts")) Directory.CreateDirectory(PersistentDataPath() + "/fonts");

            // Check that Plugins Exist
            if (!Directory.Exists(PersistentDataPath() + "/plugins")) Directory.CreateDirectory(PersistentDataPath() + "/plugins");

        }

    }

    public static string GetVersion()
    {

        return "1.2.13";
        // https://api.github.com/repos/william-mcgonagle/sledgehammer/releases/latest

    }

    public static string PersistentDataPath()
    {

        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) return $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}/Library/Application Support/amvc/sledge";
        return "";

    }

}