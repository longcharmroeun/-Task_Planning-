using DarkUI.Forms;

namespace Task_Planing.Forms.MenuDialogs
{
    public partial class CreateTaskDialog : DarkForm
    {
        public Class.Prioritize GetPrioritize()
        {
            if (Normal_radiobox.Checked) return Class.Prioritize.Normal;
            else if (Hight_radiobox.Checked) return Class.Prioritize.Hight;
            else return Class.Prioritize.low;
        }

        public CreateTaskDialog()
        {
            InitializeComponent();
            Normal_radiobox.Checked = true;
        }

        private void ok_bt_Click(object sender, System.EventArgs e)
        {
            GetPrioritize();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
