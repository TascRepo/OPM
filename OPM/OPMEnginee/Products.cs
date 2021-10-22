using System.Data;
namespace OPM.DBHandler
{
    class Products
    {
        public DataTable GetListProduct()
        {
            DataTable d = new DataTable();
            string query = string.Format("select c.idContract as 'Mã Hợp Đồng',c.code as 'Mã Hàng',c.name as 'Tên Hàng',p.CodeProduct as 'Mã Sản Phẩm',p.NameProduct as 'Tên Sản Phẩm' from dbo.Contract_Goods c left join dbo.Products p on p.Id_Contract_Goods = c.id");
            d = OPMDBHandler.ExecuteQuery(query);
            return d;
        }
        public DataTable GetListmaHang()
        {
            DataTable d = new DataTable();
            string query = string.Format("select code from Contract_Goods");
            d = OPMDBHandler.ExecuteQuery(query);
            return d;
        }
        public DataTable GetNametTenHang(string tenHang)
        {
            DataTable d = new DataTable();
            string query = string.Format("select name from Contract_Goods where code = N'{0}'", tenHang);
            d = OPMDBHandler.ExecuteQuery(query);
            return d;
        }
        public bool CheckProducts(string CodeProduct)
        {
            string query = string.Format("select * from dbo.Products where CodeProduct = N'{0}'", CodeProduct);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }
        public int InsertUpdateProducts(int Id_Contracts_Goods, string codeProducts, string nameProducts)
        {
            int result = 0;
            if (CheckProducts(codeProducts))
            {
                string query = string.Format("update dbo.Products set NameProduct = N'{0}' where CodeProduct = N'{1}'", nameProducts, codeProducts);
                result = OPMDBHandler.fInsertData(query);
                result = 0;
            }
            else
            {
                string query = string.Format("SET DATEFORMAT DMY INSERT INTO dbo.Products(Id_Contract_Goods,CodeProduct,NameProduct) VALUES({0},N'{1}',N'{2}')", Id_Contracts_Goods, codeProducts, nameProducts);
                result = OPMDBHandler.fInsertData(query);
                result = 1;
            }
            return result;
        }
        public int GetId(string codeProducts)
        {
            int result = 0;
            string query = string.Format("select top 1 id from Contract_Goods where idContract = N'{0}'", codeProducts);
            result = OPMDBHandler.fInsertData(query);
            return result;
        }
        public int DeleteProduct(string codeProducts)
        {
            int result = 0;
            string query = string.Format("delete dbo.Products where CodeProduct = '{0}'", codeProducts);
            result = OPMDBHandler.fInsertData(query);
            return result;
        }
        public DataTable GetListMaSP(string idHang)
        {
            DataTable d = new DataTable();
            string query = string.Format("select CodeProduct from dbo.Products p left join dbo.Contract_Goods c on c.id = p.Id_Contract_Goods where c.code = N'{0}'", idHang);
            d = OPMDBHandler.ExecuteQuery(query);
            return d;
        }
        public DataTable GetNameProductByCodeProduct(string codeProducts)
        {
            DataTable d = new DataTable();
            string query = string.Format("select top 1 NameProduct from dbo.Products where CodeProduct = N'{0}'", codeProducts);
            d = OPMDBHandler.ExecuteQuery(query);
            return d;
        }
    }
}
