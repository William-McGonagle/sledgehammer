using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandBase
{

    public string name;

    public static CommandBase[] findAllCommands()
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

    public CommandBase(string _name)
    {

        name = _name.ToUpper();

    }

    public virtual void Run(string[] args)
    {



    }

}