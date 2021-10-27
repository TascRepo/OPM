using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;

namespace OPM.DBHandler
{
    public static class OPMDBHandler
    {
        //static string connectionSTR = @"Data Source=DESKTOP-APVL37V\SQLEXPRESS;Initial Catalog=OpmDB_Dev1;Persist Security Info=True;Connect Timeout = 30;User ID=sa;Password=111111";
        //static string connectionSTR = @"Data Source = LEXUANTHANH\SQLEXPRESS;Initial Catalog = OpmDB1; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //static string connectionSTR = @"Data Source=10.2.8.92;Initial Catalog=OpmDB;User ID=sa;Password=Pa$$w0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static readonly string connectionSTR = @"Data Source = LEXUANTHANH\SQLEXPRESS;Initial Catalog = OpmDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //static readonly string connectionSTR = @"Data Source=THANH\SQLEXPRESS;Initial Catalog=OpmDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                    connection.Close();
                }
                catch (Exception e)
                {
                    connection.Close();
                    MessageBox.Show("Không kết nối được CSDL vì lỗi " + e.Message);
                }
            }
            return data;
        }
        public static object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    data = command.ExecuteScalar();
                    connection.Close();
                }
                catch (Exception e)
                {
                    connection.Close();
                    MessageBox.Show("Không kết nối được CSDL vì lỗi " + e.Message);
                }
            }
            return data;
        }
        public static int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    if (parameter != null)
                    {
                        string[] listPara = query.Split(' ');
                        int i = 0;
                        foreach (string item in listPara)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                    data = command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception e)
                {
                    connection.Close();

                    MessageBox.Show("Không kết nối được CSDL vì lỗi " + e.Message);
                }
            }
            return data;
        }
        public static int fInsertData(string strSqlCommand)
        {
            SqlConnection con = new SqlConnection(connectionSTR);
            try
            {
                con.Open();
                using (SqlCommand insertCommand = con.CreateCommand())
                {
                    insertCommand.CommandText = strSqlCommand;
                    var row = insertCommand.ExecuteNonQuery();
                }
                CloseConnection(con);
                return 1;
            }
            catch (Exception e)
            {
                CloseConnection(con);
                MessageBox.Show("Không kết nối được CSDL vì lỗi " + e.Message);
                return 0;
            }
        }
        public static int fQuerryData(string strQuerry, ref DataSet ds)
        {
            SqlConnection con = new SqlConnection(connectionSTR);
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command;

            try
            {
                con.Open();
                command = new SqlCommand(strQuerry, con);
                adapter.SelectCommand = command;
                adapter.Fill(ds, "SQL Temp");

                adapter.Dispose();
                command.Dispose();
                CloseConnection(con);
                if (0 == ds.Tables[0].Rows.Count)
                {
                    return 0;
                }
                return 1;

            }
            catch (Exception e)
            {
                adapter.Dispose();
                CloseConnection(con);
                MessageBox.Show("Không kết nối được CSDL vì lỗi " + e.Message);
                return 0;
            }
        }
        public static int CloseConnection(SqlConnection con)
        {
            con.Close();
            con.Dispose();
            con = null;
            return 1;
        }
        //Chuyển đổi từ 1 List sang DataTable
        public static DataTable ListToDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            dataTable.TableName = typeof(T).FullName;
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
