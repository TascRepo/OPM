using System.Windows.Forms;

namespace OPM.GUI
{

    public partial class PLInfo : Form
    {
        public delegate void UpdateCatalogDelegate(string value);
        public UpdateCatalogDelegate UpdateCatalogPanel;
        public PLInfo()
        {
            InitializeComponent();
        }
    }
}
