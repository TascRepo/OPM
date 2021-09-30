using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace OPM.ExcelHandler
{
    public class ExcelHandler_Thanh
    {
        string connectionSTR = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\OPM\Template\Thanh.xlsx; Extended Properties = 'Excel 8.0;HDR=YES'";
        public DataTable ExecuteQuery(string query)
        {
            DataTable data = new DataTable();
            //set up connection string
            using (OleDbConnection connection = new OleDbConnection(connectionSTR))
            {
                try
                {
                    OleDbCommand command = new OleDbCommand("select * from [$Sheet1]", connection);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    adapter.Fill(data);
                    MessageBox.Show("Kết nối được CSDL Excel!");
                    //OleDbParameter param0 = new OleDbParameter("@login", OleDbType.VarChar);
                }
                catch
                {
                    MessageBox.Show("Không kết nối được CSDL Excel!");
                }
            }
            return data;
        }
    }
}
