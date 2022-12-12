using System.Windows.Forms;

namespace Mobile_Charging_Pile_System
{
    public partial class Close_Form : Form
    {
        public Close_Form()
        {
            InitializeComponent();
            btn_OK.Click += (s, e) =>
            {
                if (txt_Password.Text != "qu!t")
                {
                    DialogResult = DialogResult.No;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            };
            btn_Cancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
            };
        }
    }
}
