using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    class Contract_Goods
    {
        string idContract = "111-2021/CUVT-ANSV/DTRR-KHMS";
        string origin = "Việt Nam";
        string manufacturer = "VNPT Technology";
        string code = "iGate GW020-H";
        string name = "Thiết bị đầu cuối ONT loại  (2FE/GE + Wifi Dualband) tương thích hệ thống GPON cùng đầy đủ license và phụ kiện kèm theo (không bao gồm dây nhảy quang, bản quyền Multicast)";
        string unit = "Bộ";
        double priceUnit = 0;
        int quantity = 0;
        //double pricePreTax = 0;
        //double tax=0;
        //double priceAfterTax = 0;
        public string IdContract { get => idContract; set => idContract = value; }
        public string Name { get => name; set => name = value; }
        public string Origin { get => origin; set => origin = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Code { get => code; set => code = value; }
        public string Unit { get => unit; set => unit = value; }
        public double PriceUnit { get => priceUnit; set => priceUnit = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double PricePreTax { get => priceUnit * quantity; }
        public double Tax { get => 0.1 * priceUnit * quantity; }
        public double PriceAfterTax { get => 1.1 * priceUnit * quantity; }

        public Contract_Goods() { }
        public Contract_Goods(string idContract, string name, string origin = "Việt Nam", string manufacturer = "VNPT Technology", string code = "iGate GW020-H", string unit = "Bộ", double priceUnit = 0, int quantity = 0)
        {
            IdContract = idContract;
            Name = name;
            Origin = origin;
            Manufacturer = manufacturer;
            Code = code;
            Unit = unit;
            PriceUnit = priceUnit;
            Quantity = quantity;
        }
        public Contract_Goods(DataRow row)
        {
            if (row == null) return;
            IdContract = row["idContract"].ToString();
            Name = row["name"].ToString();
            Origin = row["Origin"].ToString();
            Manufacturer = row["Manufacturer"].ToString();
            Code = row["Code"].ToString();
            Unit = row["unit"].ToString();
            PriceUnit = (double)row["priceUnit"];
            Quantity = (int)row["quantity"];
        }
        public Contract_Goods(int id)
        {
            string query = string.Format("SELECT * FROM dbo.Contract_Goods WHERE id = {0}", id);
            try
            {
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    IdContract = row["idContract"].ToString();
                    Name = row["name"].ToString();
                    Origin = row["Origin"].ToString();
                    Manufacturer = row["Manufacturer"].ToString();
                    Code = row["Code"].ToString();
                    Unit = row["unit"].ToString();
                    PriceUnit = (double)row["priceUnit"];
                    Quantity = (int)row["quantity"];
                }
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu từ bảng dbo.Contract_Goods!");
            }
        }
        public Contract_Goods(string idContract, string name)
        {
            string query = string.Format("SELECT * FROM dbo.Contract_Goods WHERE idContract = '{0}' and name = N'{1}'", idContract, name);
            try
            {
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    IdContract = idContract;
                    Name = name;
                    Origin = row["Origin"].ToString();
                    Manufacturer = row["Manufacturer"].ToString();
                    Code = row["Code"].ToString();
                    Unit = row["unit"].ToString();
                    PriceUnit = (double)row["priceUnit"];
                    Quantity = (int)row["quantity"];
                }
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu từ bảng dbo.Contract_Goods!");
            }
        }
        public bool Exist()
        {
            string query = string.Format("SELECT * FROM dbo.Contract_Goods WHERE idContract = '{0}' and name = N'{1}'", idContract, name);
            try
            {
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                return table.Rows.Count > 0;
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu từ bảng dbo.Contract_Goods!");
                return false;
            }
        }
        public static bool Exist(string idContract, string name)
        {
            string query = string.Format("SELECT * FROM dbo.Contract_Goods WHERE idContract = '{0}' and name = N'{1}'", idContract, name);
            try
            {
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                return table.Rows.Count > 0;
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu từ bảng dbo.Contract_Goods!");
                return false;
            }
        }
        public static int GetId(string idContract, string name)
        {
            string query = string.Format("SELECT id FROM dbo.Contract_Goods WHERE idContract = '{0}' and name = N'{1}'", idContract, name);
            try
            {
                return (int)OPMDBHandler.ExecuteScalar(query);
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu từ bảng dbo.Contract_Goods!");
                return 0;
            }
        }
        public static List<Contract_Goods> GetList()
        {
            List<Contract_Goods> list = new List<Contract_Goods>();
            string query = string.Format("SELECT * FROM dbo.Contract_Goods");
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                Contract_Goods contract_Goods = new Contract_Goods(row);
                list.Add(contract_Goods);
            }
            return list;
        }
        public static List<Contract_Goods> GetListByIdContract(string idContract)
        {
            List<Contract_Goods> list = new List<Contract_Goods>();
            //string query = string.Format("SELECT * FROM dbo.Contract_Goods where idContract = '{0}' ORDER BY code", idContract);
            string query = string.Format("SELECT * FROM dbo.Contract_Goods where idContract = '{0}'", idContract);
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                Contract_Goods contract_Goods = new Contract_Goods(row);
                list.Add(contract_Goods);
            }
            return list;
        }
        public static DataTable GetTableByIdContract(string idContract)
        {
            string query = string.Format("SELECT * FROM dbo.Contract_Goods where idContract = '{0}'", idContract);
            return OPMDBHandler.ExecuteQuery(query);
        }
        public static DataTable GetTable()
        {
            string query = string.Format("SELECT * FROM dbo.Contract_Goods");
            return OPMDBHandler.ExecuteQuery(query);
        }
        public void Insert()
        {
            string query = string.Format(@"INSERT INTO dbo.Contract_Goods(idContract,name, origin, manufacturer, code, unit, priceUnit, quantity) VALUES('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',{6},{7})", idContract, name, origin, manufacturer, code, unit, priceUnit, quantity);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public void Delete()
        {
            string query = string.Format(@"DELETE FROM dbo.Contract_Goods WHERE idContract = '{0}' and name = N'{1}'", idContract, name);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static void Delete(string idContract, string name)
        {
            string query = string.Format(@"DELETE FROM dbo.Contract_Goods WHERE idContract = '{0}' and name = N'{1}'", idContract, name);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static double TotalPricePreTax(string idContract)
        {
            string query = string.Format("SELECT SUM(priceUnit*quantity) FROM dbo.Contract_Goods where idContract = '{0}'", idContract);
            object tam = OPMDBHandler.ExecuteScalar(query);
            double ret = (tam == null || tam == DBNull.Value) ? 0 : (double)tam;
            return ret;
        }
        public void Update()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.Contract_Goods SET origin = N'{2}', manufacturer = N'{3}', code = N'{4}', unit = N'{5}', priceUnit = {6}, quantity = {7} WHERE idContract = '{0}' and name = N'{1}'", idContract, name, origin, manufacturer, code, unit, priceUnit, quantity);
            OPMDBHandler.ExecuteNonQuery(query);
        }

    }
}
