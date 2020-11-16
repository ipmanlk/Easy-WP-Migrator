using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WPMigrator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnectionTest_Click(object sender, EventArgs e)
        {
            var dbCon = new DBConnection("wordpress", "root", "", "localhost", 3306);

            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT post_author, post_date FROM wp_posts";
                var cmd = new MySqlCommand(query, dbCon.GetConnection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetString(0);
                    string someStringFromColumnOne = reader.GetString(1);
                    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                }
                dbCon.CloseConnection();
            } else
            {
                System.Diagnostics.Trace.WriteLine("MySQL Connection Error");
            }
        }
    }
}
