using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    class Contract_Goods
    {
        string idContract= "111-2021/CUVT-ANSV/DTRR-KHMS";
        string code = "Việt Nam/VNPT Technology/iGate GW020-H";
        string name = "Thiết bị đầu cuối ONT loại  (2FE/GE + Wifi Dualband) tương thích hệ thống GPON cùng đầy đủ license và phụ kiện kèm theo (không bao gồm dây nhảy quang, bản quyền Multicast)";
        string unit = "Bộ";
        double priceUnit = 0;
        int quantity = 0;
        double pricePreTax = 0;
        double tax=0;
        double priceAfterTax = 0;
        public string IdContract { get => idContract; set => idContract = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Unit { get => unit; set => unit = value; }
        public double PriceUnit { get => priceUnit; set => priceUnit = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double PricePreTax { get => pricePreTax; set => pricePreTax = value; }
        public double Tax { get => tax; set => tax = value; }
        public double PriceAfterTax { get => priceAfterTax; set => priceAfterTax = value; }
        public Contract_Goods() { }
        public Contract_Goods(string idContract,string code, string name, string unit = "Bộ", double priceUnit = 0, int quantity=0)
        {
            IdContract = idContract;
            Code = code;
            Name = name;
            Unit = unit;
            PriceUnit = priceUnit;
            Quantity = quantity;
            PricePreTax = quantity * priceUnit;
            Tax = quantity * priceUnit * 0.1;
            PriceAfterTax = quantity * priceUnit * 1.1;
        }
        public Contract_Goods(DataRow row) 
        {
            IdContract = row["idContract"].ToString(); 
            Code = row["code"].ToString();
            Name = row["name"].ToString();
            Unit = row["unit"].ToString();
            PriceUnit = (double)row["priceUnit"];
            Quantity = (int)row["quantity"];
            PricePreTax = quantity * priceUnit;
            Tax = quantity * priceUnit * 0.1;
            PriceAfterTax = quantity * priceUnit * 1.1;
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
                    Code = row["code"].ToString();
                    Name = row["name"].ToString();
                    Unit = row["unit"].ToString();
                    PriceUnit = (double)row["priceUnit"];
                    Quantity = (int)row["quantity"];
                    PricePreTax = quantity * priceUnit;
                    Tax = quantity * priceUnit * 0.1;
                    PriceAfterTax = quantity * priceUnit * 1.1;
                }
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu từ bảng dbo.Contract_Goods!");
            }
        }
        public Contract_Goods(string idContract, string code, string name)
        {
            string query = string.Format("SELECT * FROM dbo.Contract_Goods WHERE idContract = '{0}' and code = N'{1}' and name = N'{2}'", idContract, code, name);
            try
            {
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    IdContract = row["idContract"].ToString();
                    Code = row["code"].ToString();
                    Name = row["name"].ToString();
                    Unit = row["unit"].ToString();
                    PriceUnit = (double)row["priceUnit"];
                    Quantity = (int)row["quantity"];
                    PricePreTax = quantity * priceUnit;
                    Tax = quantity * priceUnit * 0.1;
                    PriceAfterTax = quantity * priceUnit * 1.1;
                }
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu từ bảng dbo.Contract_Goods!");
            }
        }
        public bool Exist()
        {
            string query = string.Format("SELECT * FROM dbo.Contract_Goods WHERE idContract = '{0}' and code = N'{1}' and name = N'{2}'", idContract, code, name);
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
        public static bool Exist(string idContract, string code, string name)
        {
            string query = string.Format("SELECT * FROM dbo.Contract_Goods WHERE idContract = '{0}' and code = N'{1}' and name = N'{2}'", idContract, code, name);
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
        public static int GetId(string idContract, string code, string name)
        {
            string query = string.Format("SELECT id FROM dbo.Contract_Goods WHERE idContract = '{0}' and code = N'{1}' and name = N'{2}'", idContract, code, name);
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
            string query = string.Format("SELECT * FROM dbo.Contract_Goods where idContract = '{0}' ORDER BY code", idContract);
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
            string query = string.Format(@"INSERT INTO dbo.Contract_Goods(idContract,code,name,unit,priceUnit,quantity) VALUES('{0}',N'{1}',N'{2}',N'{3}',{4},{5})", idContract, code, name, unit, priceUnit, quantity);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public void Delete()
        {
            string query = string.Format(@"DELETE FROM dbo.Contract_Goods WHERE idContract = '{0}' and code = N'{1}' and name = N'{2}'", idContract, code, name);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static double TotalPricePreTax(string idContract)
        {
            string query = string.Format("SELECT SUM(priceUnit*quantity) FROM dbo.Contract_Goods where idContract = '{0}'", idContract);
            object tam = OPMDBHandler.ExecuteScalar(query);
            double ret = (tam == null||tam==DBNull.Value) ? 0 : (double)tam;
            return ret;
        }
    }
}
