using System;
using System.Collections.Generic;
using System.Text;
using OPM.EmailHandler;
using OPM.OPMEnginee;
using OPM.WordHandler;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OPM.ExcelHandler;
using System.Data.OleDb;
using System.Data.Common;
namespace OPM.DBHandler
{
    class Provinces
    {
        private string nameProvinces = "Tỉnh A";
        public string NameProvinces { get => nameProvinces; set => nameProvinces = value; }
        public Provinces() { }
        public Provinces(string NameProvinces)
        {
            NameProvinces = nameProvinces;
        }
        public string querySQLProvinces()
        {
            string strQuery = string.Format("SELECT NameProvinces FROM dbo.Provinces");
            return strQuery;
        }
    }
}
