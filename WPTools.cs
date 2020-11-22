using MySql.Data.MySqlClient;
using System;
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
    
        public static Dictionary<string, string> getWpOptions(DBConnection dbCon)
        {
            // store options in a dictionary
            Dictionary<string, string> wpOptions = new Dictionary<string, string>();

            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM wp_options";
                var cmd = new MySqlCommand(query, dbCon.GetConnection());
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    wpOptions.Add(reader.GetString(1), reader.GetString(2));
                }
                reader.Close();
            }

            return wpOptions;
        }

        public static Boolean updateLinks(DBConnection dbCon, string newUrl)
        {
            try
            {
                if (dbCon.IsConnect())
                {
                    // get wp options
                    Dictionary<string, string> wpOptions = WpTools.getWpOptions(dbCon);

                    // replace site url in otpions
                    MySqlConnection conn = dbCon.GetConnection();

                    string query = String.Format("UPDATE wp_options SET option_value = '{0}' WHERE option_name='siteurl'", newUrl);
                    MySqlCommand mysqlCommand = new MySqlCommand(query, conn);
                    mysqlCommand.ExecuteNonQuery();

                    query = String.Format("UPDATE wp_options SET option_value = '{0}' WHERE option_name='home'", newUrl);
                    mysqlCommand = new MySqlCommand(query, conn);
                    mysqlCommand.ExecuteNonQuery();

                    // replace urls in posts (image urls, videos, etc)
                    query = String.Format("UPDATE wp_posts SET post_content = REPLACE(post_content, '{0}', '{1}')", wpOptions["siteurl"], newUrl);
                    Console.WriteLine(query);
                    mysqlCommand = new MySqlCommand(query, conn);
                    mysqlCommand.ExecuteNonQuery();

                    return true;
                } else
                {
                    return false;
                }
            } catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return false;
            }
        }

        public static Boolean updateConfigFile(string wpConfigPath, Dictionary<string, string> newWpConfig)
        {
            try
            {
                string configStr = File.ReadAllText(wpConfigPath);
                configStr = Regex.Replace(configStr, @"define\( 'DB_NAME', '(.*)' \)", String.Format("define( 'DB_NAME', '{0}' )", newWpConfig["DB_NAME"]));
                configStr = Regex.Replace(configStr, @"define\( 'DB_USER', ', '(.*)' \)", String.Format("define( 'DB_USER', '{0}' )", newWpConfig["DB_USER"]));
                configStr = Regex.Replace(configStr, @"define\( 'DB_PASSWORD', '(.*)' \)", String.Format("define( 'DB_PASSWORD', '{0}' )", newWpConfig["DB_PASSWORD"]));
                configStr = Regex.Replace(configStr, @"define\( 'DB_HOST', ', '(.*)' \)", String.Format("define( 'DB_HOST', '{0}' )", newWpConfig["DB_HOST"]));
                File.WriteAllText(wpConfigPath, configStr);
                return true;
            } catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return false;
            }
        }
    }
}
