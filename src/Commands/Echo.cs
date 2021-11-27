using Sledge.Windows;

public class EchoCommand : CommandBase
{

    public EchoCommand() : base("echo")
    {



    }

    public override void Run(string[] args)
    {

        string output = "";

        for (int i = 0; i < args.Length; i++)
            output += args[i] + ' ';

        ConsoleWindow.WriteLine(output);

    }

}