using System.Windows.Forms;

namespace Task_Planing.Forms.MenuDialogs
{
    public partial class DateSearchDialog : DarkUI.Forms.DarkForm
    {
        public DateSearchDialog()
        {
            InitializeComponent();
            maskedTextBox1.Text = System.DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            maskedTextBox2.Text = System.DateTime.Now.ToString("MM/dd/yyyy HH:mm");
        }

        private void darkButton1_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
