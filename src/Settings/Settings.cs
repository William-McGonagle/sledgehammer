using Sledge.Utility;

namespace Sledge
{

    public class SettingsData : CFGObject
    {

        public static SettingsData singleton;

        public string styleScheme = "./styles/original.cfg";

        // Constructors

        public SettingsData()
        {

            if (singleton == null) singleton = this;

        }

        public SettingsData(string path) : base(path)
        {

            if (singleton == null) singleton = this;

        }

    }

}