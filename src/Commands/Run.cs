using System.IO;
using Sledge.Windows;

public class RunCommand : CommandBase
{

    public RunCommand() : base("run")
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
        string fileData = File.ReadAllText(filePath);

        // Run File as Script 
        CommandBase.ParseCommandString(fileData);

    }

}