using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace TestTC.Framework.Utils
{
    public class GetData
    {
        public static ISettingsFile TestData => new JsonSettingsFile("testdata.json");
        public static ISettingsFile Config => new JsonSettingsFile("config.json");
    }
}
