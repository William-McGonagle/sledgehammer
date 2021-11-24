using Sledge.Utility;

namespace Sledge
{

    public class PluginConfigData : CFGObject
    {

        // Plugin Data
        public string name = "New Plugin";
        public string path = "plugin/src/Window.cs";

        // Constructors
        public PluginConfigData() { }
        public PluginConfigData(string path) : base(path) { }

    }

}