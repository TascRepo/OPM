using OPM.DBHandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace OPM.OPMEnginee
{
    public partial class PackingListObj : PLObj
    {
        public string PackingListCaseNumber { get; set; } = "xxxxx";
        public int PackingListCaseQuantity { get; set; } = 20;
        public string PackingListProductionBoxNumber { get; set; } = "xxxxx";
        public string PackingListSerialRange { get; set; } = "xxxxx";
        public string PackingListMacRange { get; set; } = "xxxxx";
        public string PackingListSerialGPONRange { get; set; } = "xxxxx";

        public PackingListObj(string CaseNumber, int CaseQuantity, string ProductionBatchNumber, string SerialRange, string MacrRange, string SerialGPONRange)
        {
            PackingListCaseNumber = CaseNumber;
            PackingListCaseQuantity = CaseQuantity;
            PackingListProductionBoxNumber = ProductionBatchNumber;
            PackingListSerialRange = SerialRange;
            PackingListMacRange = MacrRange;
            PackingListSerialGPONRange = SerialGPONRange;
        }
        public static bool PackingListExist(string PackingListCaseNumber)
        {
            string query = string.Format("SELECT * FROM dbo.PackingList WHERE PackingListCaseNumber = '{0}'", PackingListCaseNumber);
            DataTable table = OPMDBHandler.ExecuteQuery(query);
            return table.Rows.Count > 0;
        }

        public int PackingListInsert()
        {
            if (PackingListExist(PackingListCaseNumber))
            {
                return 0;
            }
            string query = string.Format("INSERT INTO dbo.PackingList(PackingListCaseNumber, PLId, PackingListCaseQuantity, PackingListProductionBoxNumber, PackingListSerialRange, PackingListMacRange, PackingListSerialGPONRange)VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}' ,'{6}')", PackingListCaseNumber, PLId, PackingListCaseQuantity, PackingListProductionBoxNumber, PackingListSerialRange, PackingListMacRange, PackingListSerialGPONRange);
            return OPMDBHandler.ExecuteNonQuery(query);
        }
    }
}
