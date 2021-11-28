using Sledge.Utility;

namespace Sledge
{

    public class SettingsData : CFGObject
    {

        public static SettingsData singleton;

        public string styleScheme = "./styles/original.cfg";
        public bool useLaunchScreen = true;
        public bool topbarFPS = true;

        // Console
        public int consoleFontSize = 8;
        public string userKarat = "$~ ";
        public string computerKarat = "!~ ";

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