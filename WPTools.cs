using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WPMigrator
{
    class WpTools
    {
        public static Dictionary<string,string> parseWpConfig(string wpDir)
        {
            // worpdress configuration path
            string configFile = wpDir + @"\wp-config.php";

            // read wordpress config
            string config = File.ReadAllText(configFile);

            // extract data using regex
            Dictionary<string, Regex> wpRegexes = new Dictionary<string, Regex>();

            wpRegexes.Add("DB_NAME", new Regex(@"define\( 'DB_NAME', '(.*)' \)"));
            wpRegexes.Add("DB_USER", new Regex(@"define\( 'DB_USER', '(.*)' \)"));
            wpRegexes.Add("DB_PASSWORD", new Regex(@"define\( 'DB_PASSWORD', '(.*)' \)"));
            wpRegexes.Add("DB_HOST", new Regex(@"define\( 'DB_HOST', '(.*)' \)"));

            // store config data in a dictionary
            Dictionary<string, string> wpConfig = new Dictionary<string, string>();

            foreach (var wpr in wpRegexes)
            {
                Match match = wpr.Value.Match(config);
                if (match.Success)
                {
                    wpConfig.Add(wpr.Key, match.Groups[1].ToString());
                }
            }

            return wpConfig;
        }
    }
}
