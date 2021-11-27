using System.IO;
using Sledge.Windows;

public class CatCommand : CommandBase
{

    public CatCommand() : base("cat")
    {



    }

    public override void Run(string[] args)
    {

        // Find File Path
        string filePath = Application.PersistentDataPath() + "/" + args[0];

        // Check If File Exists
        if (!File.Exists(filePath))
        {

            ConsoleWindow.WriteLine($"Script Not Found at '{filePath}'");
            return;

        }

        // Read File Data
        string[] fileData = File.ReadAllLines(filePath);

        // Log File Data
        for (int i = 0; i < fileData.Length; i++)
            ConsoleWindow.WriteLine(fileData[i]);

    }

}