using Mobile_Charging_Pile_System.Protocols;
using System.Windows.Forms;

namespace Mobile_Charging_Pile_System.Views
{
    public  class Field4UserControl : UserControl
    {
        public AbsProtocol AbsProtocol { get; set; }
        public virtual void Text_Change() { }
    }
}
