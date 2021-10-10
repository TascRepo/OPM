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
