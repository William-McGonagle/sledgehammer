using Sledge.Windows;

public class CwdCommand : CommandBase
{

    public CwdCommand() : base("cwd")
    {



    }

    public override void Run(string[] args)
    {

        ConsoleWindow.WriteLine(Application.PersistentDataPath());

    }

}