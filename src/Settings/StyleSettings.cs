using Sledge.Utility;

namespace Sledge
{

    public class StyleSettingsData : CFGObject
    {

        // Singleton
        public static StyleSettingsData singleton;

        // Style Settings Data
        public string background0 = "FFFFFF";
        public string background1 = "F5F5F5";
        public string background2 = "EEEEEE";
        public string background3 = "DDDDDD";
        public string background4 = "999999";
        public string background5 = "666666";
        public string background6 = "333333";
        public string background7 = "000000";

        public string yellow = "ffff00";
        public string orange = "ff5f00";
        public string red = "ff0000";
        public string magenta = "ff00ff";
        public string violet = "5f00ff";
        public string blue = "0000ff";
        public string cyan = "00ffff";
        public string green = "00ff00";

        // Constructors

        public StyleSettingsData()
        {

            if (singleton == null) singleton = this;

        }

        public StyleSettingsData(string path) : base(path)
        {

            if (singleton == null) singleton = this;

        }

    }

}