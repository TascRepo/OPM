using WordOffice = Microsoft.Office.Interop.Word;
namespace OPM.WordHandler
{
    interface IWordHandler
    {
        public void CreateWordDocument(object filename, object SaveAs, string strName, string strFirstname, string strBirthday, string strDate);
        public void FindAndReplace(WordOffice.Application wordApp, object ToFindText, object replaceWithText);
        public void Create_BLTU_Contract(object filename, object SaveAs, string strPOnumber, string strIdContract, string strSigndate, string strPOdate);
        public void Create_BLTH_PO(object filename, object SaveAs);
        public void Create_BLTU_PO(object filename, object SaveAs);
        public void Create_DNTU_PO(object filename, object SaveAs);
        public void Create_NTKTHH(object filename, object SaveAs);
        public void PrintDocument(object filename);
        public void CreateBLTH_Contract(object filename, object SaveAs, string strContractCode, string strContractName, string strSigneddate);


    }
}
