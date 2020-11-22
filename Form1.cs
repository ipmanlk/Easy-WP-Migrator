using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

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
                    listLog.Items.Add("Unable to connect to MySQL server.");
                }
            }
        }

        private void btnSetOutputDir_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtOutputDir.Text = folderBrowserDialog.SelectedPath;
                listLog.Items.Add("Output directory selected.");
            }

        }

        private void btnStartMigration_Click(object sender, EventArgs e)
        {
            listLog.Items.Add("Migration process started.");

            // reset validation colors
            txtWpDir.BackColor = txtMysqlDir.BackColor = txtWhDomain.BackColor = txtWhMysqlHost.BackColor = txtWhMysqlUser.BackColor = txtWhMysqlPass.BackColor = txtWhMysqlDb.BackColor = Color.White;

            // TODO: Validation
            if (txtWpDir.Text.Trim() == "")
            {
                txtWpDir.BackColor = Color.Red;
                MessageBox.Show("Please select your local WordPress development directory!.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtMysqlDir.Text.Trim() == "")
            {
                txtMysqlDir.BackColor = Color.Red;
                MessageBox.Show("Please select your MySQL directory!.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtWhDomain.Text.Trim() == "")
            {
                txtWhDomain.BackColor = Color.Red;
                MessageBox.Show("Please enter your domain name!.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtWhMysqlHost.Text.Trim() == "")
            {
                txtWhMysqlHost.BackColor = Color.Red;
                MessageBox.Show("Please enter your mysql host!.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtWhMysqlUser.Text.Trim() == "")
            {
                txtWhMysqlUser.BackColor = Color.Red;
                MessageBox.Show("Please enter your mysql username!.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtWhMysqlPass.Text.Trim() == "")
            {
                txtWhMysqlPass.BackColor = Color.Red;
                MessageBox.Show("Please enter your mysql user password!.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtWhMysqlDb.Text.Trim() == "")
            {
                txtWhMysqlDb.BackColor = Color.Red;
                MessageBox.Show("Please enter your mysql database name!.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 1: Create a clone of the existing database
            listLog.Items.Add("Creating clone of the database.");
            var dbCon = DBConnection.Instance();
            MysqlTools.cloneDb(dbCon, txtMysqlDir.Text);

            // 2: Update existing values
            string clonedDbName = "wpmclone_" + dbCon.DatabaseName;

            // parse
            listLog.Items.Add("Parsing wordpress configurations.");
            Dictionary<string, string> wpConfig = WpTools.parseWpConfig(txtWpDir.Text);


            // close existing connection first
            dbCon.CloseConnection();

            // make new connection to the cloned db
            listLog.Items.Add("Connecting to the cloned database.");
            dbCon.DatabaseHost = wpConfig["DB_HOST"];
            dbCon.DatabaseUser = wpConfig["DB_USER"];
            dbCon.DatabasePass = wpConfig["DB_PASSWORD"];
            dbCon.DatabaseName = clonedDbName;
            dbCon.DatabasePort = 3306;

            // update old urls
            listLog.Items.Add("Updating cloned database.");
            WpTools.updateLinks(dbCon, txtWhDomain.Text);

            // 3: Create directory structure for output
            listLog.Items.Add("Creating output directories.");

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
            listLog.Items.Add("Copying wordpress files.");
            FileTools.Copy(txtWpDir.Text, outputWpDir);

            // 5: Update wp-config file in output dir
            string wpConfigPath = outputWpDir + @"\wp-config.php";

            Dictionary<string, string> newWpOptions = new Dictionary<string, string>();
            newWpOptions.Add("DB_NAME", txtWhMysqlDb.Text);
            newWpOptions.Add("DB_USER", txtWhMysqlUser.Text);
            newWpOptions.Add("DB_PASSWORD", txtWhMysqlPass.Text);
            newWpOptions.Add("DB_HOST", txtWhMysqlHost.Text);

            listLog.Items.Add("Updating configuration files.");
            WpTools.updateConfigFile(wpConfigPath, newWpOptions);


            // 6: Create a dump of updated database
            listLog.Items.Add("Creating a dump of the database.");
            MysqlTools.createDump(dbCon, txtMysqlDir.Text, outputMysqlDbDir);


            listLog.Items.Add("Migration process completed.");
        }

        private Boolean testWpDbConnection()
        {

            try
            {
                listLog.Items.Add("Parsing configuration files.");
                // parse
                Dictionary<string, string> wpConfig = WpTools.parseWpConfig(txtWpDir.Text);

                // make db connection
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseHost = wpConfig["DB_HOST"];
                dbCon.DatabaseUser = wpConfig["DB_USER"];
                dbCon.DatabasePass = wpConfig["DB_PASSWORD"];
                dbCon.DatabaseName = wpConfig["DB_NAME"];
                dbCon.DatabasePort = 3306;


                listLog.Items.Add("Testing database connection.");

                if (dbCon.IsConnect())
                {
                    string query = "SHOW TABLES;";
                    var cmd = new MySqlCommand(query, dbCon.GetConnection());
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        string tableName = reader.GetString(0);
                        listWpTables.Items.Add(tableName);
                    }
                    reader.Close();
                    listLog.Items.Add("Database connection successful.");
                }
                else
                {
                    System.Diagnostics.Trace.WriteLine("MySQL Connection Error");
                    listLog.Items.Add("Database connection failed.");
                    return false;
                }

                return true;

            } catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return false;
            }


   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listLog.Items.Add("WPMigrator started");
        }
    }
}
