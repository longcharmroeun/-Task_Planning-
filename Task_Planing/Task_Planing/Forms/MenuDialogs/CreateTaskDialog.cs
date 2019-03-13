using DarkUI.Forms;
using System.Linq;

namespace Task_Planing.Forms.MenuDialogs
{
    public partial class CreateTaskDialog : DarkForm
    {
        private Class.ListTasks ListTasks;

        public Class.Prioritize GetPrioritize()
        {
            if (Normal_radiobox.Checked) return Class.Prioritize.Normal;
            else if (Hight_radiobox.Checked) return Class.Prioritize.Hight;
            else return Class.Prioritize.low;
        }

        private void SetPrioritize(Class.Prioritize prioritize)
        {
            if (prioritize == Class.Prioritize.Normal) Normal_radiobox.Checked = true;
            else if (prioritize == Class.Prioritize.Hight) Hight_radiobox.Checked = true;
            else Low_radiobox.Checked = true;
        }

        public CreateTaskDialog()
        {
            InitializeComponent();
            Normal_radiobox.Checked = true;
        }

        public CreateTaskDialog(Class.ListTasks listTasks, int Index)
        {
            InitializeComponent();
            Normal_radiobox.Checked = true;
            this.ListTasks = listTasks;
            darkTextBox1.Text = listTasks.Tasks.ElementAt(Index).TaskName;
            maskedTextBox1.Text = listTasks.Tasks.ElementAt(Index).Date_Execution.ToString();
            SetPrioritize(listTasks.Tasks.ElementAt(Index).Prioritize);
        }

        private void ok_bt_Click(object sender, System.EventArgs e)
        {
            GetPrioritize();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
