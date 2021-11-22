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

        public string iconColor = "333333";
        public string highlightIconColor = "555555";

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