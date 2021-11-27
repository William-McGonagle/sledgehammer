using Sledge.Windows;

public class ClearCommand : CommandBase
{

    public ClearCommand() : base("clear")
    {



    }

    public override void Run(string[] args)
    {

        ConsoleWindow.output = new string[0];

    }

}