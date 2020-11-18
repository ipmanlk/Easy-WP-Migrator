using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace WPMigrator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnSetMysqlPath_Click(object sender, EventArgs e)
        {

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtMysqlDir.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (!testWpDbConnection())
            {
                MessageBox.Show("Unable to contact the MySQL server. Please start it first!.", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnSetWpDir_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtWpDir.Text = folderBrowserDialog.SelectedPath;

                // after path is selected, try pharsing the config and making the db connection
               if (!testWpDbConnection())
                {
                    MessageBox.Show("Unable to contact the MySQL server. Please start it first!.", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSetOutputDir_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtOutputDir.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void btnStartMigration_Click(object sender, EventArgs e)
        {

            // TODO: Validation

            // 1: Create a clone of the existing database
            var dbCon = DBConnection.Instance();
            MysqlTools.cloneDb(dbCon, txtMysqlDir.Text);

            // 2: Update existing values
            string clonedDbName = "wpmclone_" + dbCon.DatabaseName;

            // parse
            Dictionary<string, string> wpConfig = WpTools.parseWpConfig(txtWpDir.Text);

            // close existing connection first
            dbCon.CloseConnection();

            // make new connection to the cloned db
            dbCon.DatabaseHost = wpConfig["DB_HOST"];
            dbCon.DatabaseUser = wpConfig["DB_USER"];
            dbCon.DatabasePass = wpConfig["DB_PASSWORD"];
            dbCon.DatabaseName = clonedDbName;
            dbCon.DatabasePort = 3306;

            if (dbCon.IsConnect())
            {
                // get wp options
                Dictionary<string, string> wpOptions = WpTools.getWpOptions(dbCon);

                // replace site url in otpions
                MySqlConnection conn = dbCon.GetConnection();

                string query = String.Format("UPDATE wp_options SET option_value = '{0}' WHERE option_name='siteurl'", txtWhDomain.Text);
                MySqlCommand mysqlCommand = new MySqlCommand(query, conn);
                mysqlCommand.ExecuteNonQuery();

                query = String.Format("UPDATE wp_options SET option_value = '{0}' WHERE option_name='home'", txtWhDomain.Text);
                mysqlCommand = new MySqlCommand(query, conn);
                mysqlCommand.ExecuteNonQuery();

                // replace urls in posts (image urls, videos, etc)
                query = String.Format("UPDATE wp_posts SET post_content = REPLACE(post_content, '{0}', '{1}')", wpOptions["siteurl"], txtWhDomain.Text);
                Console.WriteLine(query);
                mysqlCommand = new MySqlCommand(query, conn);
                mysqlCommand.ExecuteNonQuery();
            }

            // 3: Create directory structure for output
            string outputDir = txtOutputDir.Text + @"\WPMigrator-Output";
            string outputWpDir = outputDir + @"\public";
            string outputMysqlDbDir = outputDir + @"\database";

            // delete if exists
            if (Directory.Exists(outputDir))
            {
                var dir = new DirectoryInfo(outputDir);
                dir.Delete(true);
            }

            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(outputWpDir);
            Directory.CreateDirectory(outputMysqlDbDir);

            // 4: Copy wordpress files from given dir to output dir
            FileTools.Copy(txtWpDir.Text, outputWpDir);

            // 5: Update wp-config file in output dir
            string wpConfigPath = outputWpDir + @"\wp-config.php";

            string configStr = File.ReadAllText(wpConfigPath);
            configStr = Regex.Replace(configStr, @"define\( 'DB_NAME', '(.*)' \)", String.Format("define( 'DB_NAME', '{0}' )", txtWhMysqlDb.Text));
            configStr = Regex.Replace(configStr, @"define\( 'DB_USER', ', '(.*)' \)", String.Format("define( 'DB_USER', '{0}' )", txtWhMysqlUser.Text));
            configStr = Regex.Replace(configStr, @"define\( 'DB_PASSWORD', '(.*)' \)", String.Format("define( 'DB_PASSWORD', '{0}' )", txtWhMysqlPass.Text));
            configStr = Regex.Replace(configStr, @"define\( 'DB_HOST', ', '(.*)' \)", String.Format("define( 'DB_HOST', '{0}' )", txtWhMysqlHost.Text));

            File.WriteAllText(wpConfigPath, configStr);


            // 6: Create a dump of updated database
            MysqlTools.createDump(dbCon, txtMysqlDir.Text, outputMysqlDbDir);
        }

        private Boolean testWpDbConnection()
        {

            try
            {
                // parse
                Dictionary<string, string> wpConfig = WpTools.parseWpConfig(txtWpDir.Text);

                // make db connection
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseHost = wpConfig["DB_HOST"];
                dbCon.DatabaseUser = wpConfig["DB_USER"];
                dbCon.DatabasePass = wpConfig["DB_PASSWORD"];
                dbCon.DatabaseName = wpConfig["DB_NAME"];
                dbCon.DatabasePort = 3306;

                if (dbCon.IsConnect())
                {
                    string query = "SHOW TABLES;";
                    var cmd = new MySqlCommand(query, dbCon.GetConnection());
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        string someStringFromColumnZero = reader.GetString(0);
                        listWpTables.Items.Add(someStringFromColumnZero);
                    }
                    reader.Close();
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine("MySQL Connection Error");
                    return false;
                }

                return true;

            } catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return false;
            }


   
        }
    }
}
