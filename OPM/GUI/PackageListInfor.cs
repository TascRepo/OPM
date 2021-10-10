using System.Windows.Forms;

namespace OPM.GUI
{

    public partial class PackageListInfor : Form
    {
        public delegate void UpdateCatalogDelegate(string value);
        public UpdateCatalogDelegate UpdateCatalogPanel;
        public PackageListInfor()
        {
            InitializeComponent();
        }
    }
}
