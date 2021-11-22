using Sledge.Utility;

namespace Sledge
{

    public class SettingsData : CFGObject
    {

        public static SettingsData singleton;

        public string styleScheme = "./stored/styles/original.cfg";

        public SettingsData(string path) : base(path)
        {

            if (singleton == null) singleton = this;

        }

    }

}