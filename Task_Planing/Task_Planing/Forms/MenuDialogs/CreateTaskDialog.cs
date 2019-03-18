using DarkUI.Forms;
namespace Task_Planing.Forms.MenuDialogs
{
    public partial class CreateTaskDialog : DarkForm
    {
        #region Method Region
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
            maskedTextBox1.Text = System.DateTime.Now.ToString("MM/dd/yyyy HH:mm");
        }

        public CreateTaskDialog(Class.Task task)
        {
            InitializeComponent();
            Normal_radiobox.Checked = true;
            maskedTextBox1.Text = task.Date_Execution.ToString("MM/dd/yyyy HH:mm");
            darkTextBox1.Text = task.TaskName;
            darkTextBox2.Text = task.Comment;
            SetPrioritize(task.Prioritize);
        }
        #endregion

        #region Event Region
        private void ok_bt_Click(object sender, System.EventArgs e)
        {
            GetPrioritize();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        #endregion
    }
}
