using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public class Goods_Thanh
    {
        string idContract = "111-2021/CUVT-ANSV/DTRR-KHMS";
        string origin = "Việt Nam";
        string manufacturer = "VNPT Technology";
        string code = "iGate GW020-H";
        string name = "Thiết bị đầu cuối ONT loại  (2FE/GE + Wifi Dualband) tương thích hệ thống GPON cùng đầy đủ license và phụ kiện kèm theo (không bao gồm dây nhảy quang, bản quyền Multicast)";
        string unit = "Bộ";
        string note = "";
        string license = "Bản quyền ONT VNPT Techlonogy";
        string name1 = "Thiết bị đầu cuối ONT loại  (2FE/GE + Wifi Dualband)";
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
        public string Name1 { get => name1; set => name1 = value; }
        public string Unit { get => unit; set => unit = value; }
        public string Note { get => note; set => note = value; }
        public string License { get => license; set => license = value; }
        public double PriceUnit { get => priceUnit; set => priceUnit = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double PricePreTax { get => priceUnit * quantity; }
        public double Tax { get => 0.1 * priceUnit * quantity; }
        public double PriceAfterTax { get => 1.1 * priceUnit * quantity; }

        public Goods_Thanh() { }
        public Goods_Thanh(string idContract, string name, string origin, string manufacturer = "VNPT Technology", string code = "iGate GW020-H", string unit = "Bộ", double priceUnit = 0, int quantity = 0,string note="", string license= "Bản quyền ONT VNPT Techlonogy", string name1= "Thiết bị đầu cuối ONT loại  (2FE/GE + Wifi Dualband)")
        {
            IdContract = idContract;
            Name = name;
            Origin = origin;
            Manufacturer = manufacturer;
            Code = code;
            Unit = unit;
            PriceUnit = priceUnit;
            Quantity = quantity;
            Note = note;
            License = license;
            Name1 = name1;
        }
        public Goods_Thanh(DataRow row)
        {
            if (row == null) return;
            IdContract = row["idContract"].ToString();
            Name = row["name"].ToString();
            Origin = (row["Origin"]==null|| row["Origin"]==DBNull.Value)?"Việt Nam":row["Origin"].ToString();
            Manufacturer = (row["Manufacturer"] == null || row["Manufacturer"] == DBNull.Value) ? "VNPT Technology" : row["Manufacturer"].ToString();
            Name1 = (row["Name1"] == null || row["Name1"] == DBNull.Value) ? "Thiết bị đầu cuối ONT loại  (2FE/GE + Wifi Dualband)" : row["Name1"].ToString();
            Unit = (row["Unit"] == null || row["Unit"] == DBNull.Value) ? "Bộ" : row["Unit"].ToString();
            PriceUnit = (row["PriceUnit"] == null || row["PriceUnit"] == DBNull.Value) ? 0 : (double)row["PriceUnit"];
            Quantity = (row["Quantity"] == null || row["Quantity"] == DBNull.Value) ? 0 : (int)row["Quantity"];
            Note = (row["Note"] == null || row["Note"] == DBNull.Value) ? "" : row["Note"].ToString();
            License = (row["License"] == null || row["License"] == DBNull.Value) ? "":row["License"].ToString();
        }
        public Goods_Thanh(int id)
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
                    Origin = (row["Origin"] == null || row["Origin"] == DBNull.Value) ? "Việt Nam" : row["Origin"].ToString();
                    Manufacturer = (row["Manufacturer"] == null || row["Manufacturer"] == DBNull.Value) ? "VNPT Technology" : row["Manufacturer"].ToString();
                    Name1 = (row["Name1"] == null || row["Name1"] == DBNull.Value) ? "Thiết bị đầu cuối ONT loại  (2FE/GE + Wifi Dualband)" : row["Name1"].ToString();
                    Unit = (row["Unit"] == null || row["Unit"] == DBNull.Value) ? "Bộ" : row["Unit"].ToString();
                    PriceUnit = (row["PriceUnit"] == null || row["PriceUnit"] == DBNull.Value) ? 0 : (double)row["PriceUnit"];
                    Quantity = (row["Quantity"] == null || row["Quantity"] == DBNull.Value) ? 0 : (int)row["Quantity"];
                    Note = (row["Note"] == null || row["Note"] == DBNull.Value) ? "" : row["Note"].ToString();
                    License = (row["License"] == null || row["License"] == DBNull.Value) ? "Bản quyền ONT VNPT Techlonogy" : row["License"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu từ bảng dbo.Contract_Goods!");
            }
        }
        public Goods_Thanh(string idContract)
        {
            string query = string.Format("SELECT * FROM dbo.Contract_Goods WHERE idContract = '{0}'", idContract);
            IdContract = idContract;
            try
            {
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    Name = row["name"].ToString();
                    Origin = (row["Origin"] == null || row["Origin"] == DBNull.Value) ? "Việt Nam" : row["Origin"].ToString();
                    Manufacturer = (row["Manufacturer"] == null || row["Manufacturer"] == DBNull.Value) ? "VNPT Technology" : row["Manufacturer"].ToString();
                    Name1 = (row["Name1"] == null || row["Name1"] == DBNull.Value) ? "Thiết bị đầu cuối ONT loại  (2FE/GE + Wifi Dualband)" : row["Name1"].ToString();
                    Unit = (row["Unit"] == null || row["Unit"] == DBNull.Value) ? "Bộ" : row["Unit"].ToString();
                    PriceUnit = (row["PriceUnit"] == null || row["PriceUnit"] == DBNull.Value) ? 0 : (double)row["PriceUnit"];
                    Quantity = (row["Quantity"] == null || row["Quantity"] == DBNull.Value) ? 0 : (int)row["Quantity"];
                    Note = (row["Note"] == null || row["Note"] == DBNull.Value) ? "" : row["Note"].ToString();
                    License = (row["License"] == null || row["License"] == DBNull.Value) ? "Bản quyền ONT VNPT Techlonogy" : row["License"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu từ bảng dbo.Contract_Goods!");
            }
        }

        public Goods_Thanh(string idContract, string name)
        {
            string query = string.Format("SELECT * FROM dbo.Contract_Goods WHERE idContract = '{0}' and name = N'{1}'", idContract, name);
            IdContract = idContract;
            Name = name;
            try
            {
                DataTable table = OPMDBHandler.ExecuteQuery(query);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    Origin = (row["Origin"] == null || row["Origin"] == DBNull.Value) ? "Việt Nam" : row["Origin"].ToString();
                    Manufacturer = (row["Manufacturer"] == null || row["Manufacturer"] == DBNull.Value) ? "VNPT Technology" : row["Manufacturer"].ToString();
                    Name1 = (row["Name1"] == null || row["Name1"] == DBNull.Value) ? "Thiết bị đầu cuối ONT loại  (2FE/GE + Wifi Dualband)" : row["Name1"].ToString();
                    Unit = (row["Unit"] == null || row["Unit"] == DBNull.Value) ? "Bộ" : row["Unit"].ToString();
                    PriceUnit = (row["PriceUnit"] == null || row["PriceUnit"] == DBNull.Value) ? 0 : (double)row["PriceUnit"];
                    Quantity = (row["Quantity"] == null || row["Quantity"] == DBNull.Value) ? 0 : (int)row["Quantity"];
                    Note = (row["Note"] == null || row["Note"] == DBNull.Value) ? "" : row["Note"].ToString();
                    License = (row["License"] == null || row["License"] == DBNull.Value) ? "Bản quyền ONT VNPT Techlonogy" : row["License"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Không lấy được dữ liệu từ bảng dbo.Contract_Goods!");
            }
        }
        public bool Exist()
        {
            string query = string.Format("SELECT * FROM dbo.Contract_Goods WHERE idContract = '{0}'", idContract);
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
        public static bool Exist(string idContract)
        {
            string query = string.Format("SELECT * FROM dbo.Contract_Goods WHERE idContract = '{0}'", idContract);
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
        public static int GetId(string idContract)
        {
            string query = string.Format("SELECT id FROM dbo.Contract_Goods WHERE idContract = '{0}'", idContract);
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
        public static List<Goods_Thanh> GetList()
        {
            List<Goods_Thanh> list = new List<Goods_Thanh>();
            string query = string.Format("SELECT * FROM dbo.Contract_Goods");
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                Goods_Thanh contract_Goods = new Goods_Thanh(row);
                list.Add(contract_Goods);
            }
            return list;
        }
        public static List<Goods_Thanh> GetListByIdContract(string idContract)
        {
            List<Goods_Thanh> list = new List<Goods_Thanh>();
            //string query = string.Format("SELECT * FROM dbo.Contract_Goods where idContract = '{0}' ORDER BY code", idContract);
            string query = string.Format("SELECT * FROM dbo.Contract_Goods where idContract = '{0}'", idContract);
            DataTable dataTable = OPMDBHandler.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                Goods_Thanh contract_Goods = new Goods_Thanh(row);
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
            string query = string.Format(@"INSERT INTO dbo.Contract_Goods(idContract,name, origin, manufacturer, code, unit, priceUnit, quantity, note,license, name1) VALUES('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',{6},{7},N'{8}',N'{9}',N'{10}')", idContract, name, origin, manufacturer, code, unit, priceUnit, quantity, note, license, Name1);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public void Delete()
        {
            string query = string.Format(@"DELETE FROM dbo.Contract_Goods WHERE idContract = '{0}'", idContract);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static void Delete(string idContract)
        {
            string query = string.Format(@"DELETE FROM dbo.Contract_Goods WHERE idContract = '{0}'", idContract);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public void Update()
        {
            string query = string.Format("SET DATEFORMAT DMY UPDATE dbo.Contract_Goods SET origin = N'{2}', manufacturer = N'{3}', code = N'{4}', unit = N'{5}', priceUnit = {6}, quantity = {7}, note = N'{8}', license = N'{9}', name1 = N'10' WHERE idContract = '{0}' and name = N'{1}'", idContract, name, origin, manufacturer, code, unit, priceUnit, quantity, note,license,Name1);
            OPMDBHandler.ExecuteNonQuery(query);
        }
        public static double TotalPricePreTax(string idContract)
        {
            string query = string.Format("SELECT SUM(priceUnit*quantity) FROM dbo.Contract_Goods where idContract = '{0}'", idContract);
            object tam = OPMDBHandler.ExecuteScalar(query);
            double ret = (tam == null || tam == DBNull.Value) ? 0 : (double)tam;
            return ret;
        }
    }
}
