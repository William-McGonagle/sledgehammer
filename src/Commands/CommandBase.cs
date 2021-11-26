using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandBase
{

    public string name;

    public static CommandBase[] FindAllCommands()
    {

        Type commandType = typeof(CommandBase);
        Type[] types = Assembly.GetExecutingAssembly().GetTypes();
        List<CommandBase> outputTypes = new List<CommandBase>();

        for (int i = 0; i < types.Length; i++)
        {

            if (!types[i].IsClass) continue;
            if (types[i] == commandType) continue;
            if (commandType.IsAssignableFrom(types[i])) continue;

            CommandBase output = (CommandBase)Activator.CreateInstance(types[i]);

            outputTypes.Add(output);

        }

        return outputTypes.ToArray();

    }

    public static CommandBase FindCommandOfName(string name)
    {

        CommandBase[] commands = FindAllCommands();

        for (int i = 0; i < commands.Length; i++)
        {

            if (commands[i].name.ToUpper() == name.ToUpper()) return commands[i];

        }

        return null;

    }

    public static void ExecuteCommand(string input)
    {

        string[] commandParts = input.Split(" ");

        if (commandParts.Length == 0) return;

        string commandName = commandParts[0];
        CommandBase command = FindCommandOfName(commandName);

        string[] args = new string[commandParts.Length - 1];

        for (int i = 0; i < args.Length; i++)
            args[i] = commandParts[i + 1];

        command.Run(args);

    }

    public CommandBase(string _name)
    {

        name = _name.ToUpper();

    }

    public virtual void Run(string[] args)
    {



    }

}