using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Windows.Forms;

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

            /*        DialogResult result = folderBrowserDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        txtMysqlDir.Text = folderBrowserDialog.SelectedPath;
                    }*/

            var dbCon = DBConnection.Instance();
            MysqlTools.cloneDb(dbCon, @"G:\Program Files\xampp\mysql");

        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseHost = "localhost";
            dbCon.DatabaseUser = "root";
            dbCon.DatabasePass = "";
            dbCon.DatabaseName = "wordpress";
            dbCon.DatabasePort = 3306;

            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SHOW TABLES;";
                var cmd = new MySqlCommand(query, dbCon.GetConnection());
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    string someStringFromColumnZero = reader.GetString(0);
                    listWpTables.Items.Add(someStringFromColumnZero);
                    Console.WriteLine(someStringFromColumnZero);
                }
                reader.Close();
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("MySQL Connection Error");
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
    }
}
