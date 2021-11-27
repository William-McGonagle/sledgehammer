using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sledge.Windows;

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
            if (!types[i].IsSubclassOf(commandType)) continue;

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

    public static void ExecuteCommand(string commandName, string[] args)
    {

        CommandBase command = FindCommandOfName(commandName);

        if (command == null)
        {

            ConsoleWindow.WriteLine($"Command '{commandName.ToLower()}' not found.");
            return;

        }

        command.Run(args);

    }

    public static void ParseCommandString(string input)
    {

        int index = 0;

        while (index < input.Length)
        {

            string commandName = "";
            List<string> args = new List<string>();
            int state = 0;
            int argIndex = 0;

            while (index < input.Length && input[index] != ';')
            {

                switch (state)
                {

                    case 0:

                        if (input[index] == ' ')
                        {

                            if (commandName == "")
                            {

                                break;

                            }

                            state = 1;
                            args.Add("");
                            break;

                        }

                        commandName += input[index];

                        break;

                    case 1:

                        if (input[index] == ' ')
                        {

                            args.Add("");
                            argIndex++;
                            state = 1;
                            break;

                        }

                        args[argIndex] = args[argIndex] + input[index];

                        break;

                }

                index++;

            }

            ExecuteCommand(commandName, args.ToArray());

            index++;

        }

    }

    public CommandBase(string _name)
    {

        name = _name.ToUpper();

    }

    public virtual void Run(string[] args)
    {



    }

}