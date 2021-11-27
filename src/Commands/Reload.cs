using System.IO;
using Sledge.Windows;

public class ReloadCommand : CommandBase
{

    public ReloadCommand() : base("reload")
    {



    }

    public override void Run(string[] args)
    {

        ConsoleWindow.WriteLine("Reload command not currently supported.");

    }

}