using Sledge.Windows;

public class RunCommand : CommandBase
{

    public RunCommand() : base("run")
    {



    }

    public override void Run(string[] args)
    {

        ConsoleWindow.output = new string[0];

    }

}