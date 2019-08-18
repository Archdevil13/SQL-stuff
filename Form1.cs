using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Create_SQL_Database_button
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            String str;
            //Change Server Name if needed
            SqlConnection myConn = new SqlConnection("Server=USER-PC;Integrated security=SSPI;database=master");
            //change DB Name and other names
            str = "CREATE DATABASE TolioDB ON PRIMARY " +
                "(NAME = TolioDB_Data, " +
                "FILENAME = 'C:\\Program Files\\Microsoft SQL Server\\MSSQL10_50.MSSQLSERVER\\MSSQL\\DATA\\TolioDB.mdf', " +
                "SIZE = 3MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = TolioDB_Log, " +
                "FILENAME = 'C:\\Program Files\\Microsoft SQL Server\\MSSQL10_50.MSSQLSERVER\\MSSQL\\DATA\\TolioDB.ldf', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }
    }
}
