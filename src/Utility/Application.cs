using Sledge;
using System.Runtime.InteropServices;
using System.IO;

public class Application
{

    public static string version = "1.0.0";

    public static void ConfigureSystem()
    {

        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {

            // Check Directories Exist
            if (!Directory.Exists("./Library/Application Support/amvc")) Directory.CreateDirectory("./Library/Application Support/amvc");
            if (!Directory.Exists("./Library/Application Support/amvc/sledge")) Directory.CreateDirectory("./Library/Application Support/amvc/sledge");

            // Check that Settings Object Exists
            if (!File.Exists(PersistentDataPath() + "/settings.cfg")) new SettingsData().Save(PersistentDataPath() + "/settings.cfg");

            // Check that Styles Exist
            if (!Directory.Exists(PersistentDataPath() + "/styles")) Directory.CreateDirectory(PersistentDataPath() + "/styles");
            if (!File.Exists(PersistentDataPath() + "/styles/original.cfg")) new StyleSettingsData().Save(PersistentDataPath() + "/styles/original.cfg");

            // Check that Fonts Exist
            if (!Directory.Exists(PersistentDataPath() + "/fonts")) Directory.CreateDirectory(PersistentDataPath() + "/fonts");

        }

    }

    public static string PersistentDataPath()
    {

        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) return $"./Library/Application Support/amvc/sledge";
        return "";

    }

}