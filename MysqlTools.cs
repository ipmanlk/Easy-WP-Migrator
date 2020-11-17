using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPMigrator
{
    class MysqlTools
    {
        public static Boolean createDump(DBConnection dbCon, string mysqlDir, string outputDir)
        {
            string mysqlDumpExe = mysqlDir + "\\bin\\mysqldump.exe";
            string outputFilePath = outputDir + "\\" + dbCon.DatabaseName + "_dump.sql";

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = mysqlDumpExe;
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = String.Format("--host={0} --port={1} --user={2} --password={3} {4} -r {5}",
                    dbCon.DatabaseHost, dbCon.DatabasePort, dbCon.DatabaseUser, dbCon.DatabasePass, dbCon.DatabaseName, outputFilePath);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);
                process.WaitForExit();
                process.Close();
                return true;
            } catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return false;
            }
        }

        public static Boolean cloneDb(DBConnection dbCon, string mysqlDir)
        {
            try
            {
                // name of the cloned db
                string cloneDbName = "wpmclone_" + dbCon.DatabaseName;

                // create new mysql command to execute queries
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.GetConnection();

                // drop cloned db if exists
                cmd.CommandText = "DROP DATABASE IF EXISTS " + cloneDbName;
                cmd.ExecuteNonQuery();

                // create empty cloned db 
                cmd.CommandText = "CREATE DATABASE " + cloneDbName;
                cmd.ExecuteNonQuery();

                // exes for mysql command
                string mysqlDumpExe = mysqlDir + @"\bin\mysqldump.exe";
                string mysqlExe = mysqlDir + @"\bin\mysql.exe";

                // create a copy of the db
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "cmd";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;

                string args = String.Format("\"{0}\" --host={1} --port={2} --user={3} --password={4} {5} | \"{6}\" --host={7} --port={8} --user={9} --password={10} {11}",
                   mysqlDumpExe, dbCon.DatabaseHost, dbCon.DatabasePort, dbCon.DatabaseUser, dbCon.DatabasePass, dbCon.DatabaseName, mysqlExe,
                   dbCon.DatabaseHost, dbCon.DatabasePort, dbCon.DatabaseUser, dbCon.DatabasePass, cloneDbName);

                psi.Arguments = "/C " + args;
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);
                process.WaitForExit();
                process.Close();
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return false;
            }
        }
    }
}
