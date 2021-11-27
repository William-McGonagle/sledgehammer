using System.IO;
using Sledge;
using Sledge.Windows;

public class ColorSchemeCommand : CommandBase
{

    public ColorSchemeCommand() : base("cscheme")
    {



    }

    public override void Run(string[] args)
    {

        string path = args[0];

        SettingsData.singleton.styleScheme = "./styles/" + Path.GetFileName(path);
        SettingsData.singleton.Save(Application.PersistentDataPath() + "/settings.cfg");

        StyleSettingsData.singleton = new StyleSettingsData(Application.PersistentDataPath() + "/styles/" + Path.GetFileName(path));

        ConsoleWindow.WriteLine($"Set Color Scheme to '{"./styles/" + Path.GetFileName(path)}'");

    }

}