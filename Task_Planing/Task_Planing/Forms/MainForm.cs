using System.Linq;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Forms;
using Task_Planing.Class;
using Task_Planing.Forms.MenuDialogs;

namespace Task_Planing.Forms
{
    public partial class MainForm : DarkForm
    {
        #region Field Region
        private CreateTaskDialog createTaskDialog;
        private ListTasks listTasks;
        #endregion

        #region Constructor Region
        public MainForm()
        {
            InitializeComponent();
            listTasks = new ListTasks();
        }
        #endregion

        private void createToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            createTaskDialog = new CreateTaskDialog();
            createTaskDialog.ShowDialog();
            if(createTaskDialog.DialogResult == DialogResult.OK)
            {
                listTasks.Tasks.Add(new Task() { TaskName = createTaskDialog.darkTextBox1.Text, Date_Execution = System.DateTime.Parse(createTaskDialog.maskedTextBox1.Text), Prioritize = createTaskDialog.GetPrioritize(), Comment = createTaskDialog.darkTextBox2.Text });
                TaskList.Items.Add(new DarkListItem(listTasks.Tasks.Last<Task>().TaskName));
                listTasks.Save();
            }
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            Class.ListTasks.Read(ref listTasks);
            foreach (var item in listTasks.Tasks)
            {
                TaskList.Items.Add(new DarkListItem(item.TaskName));
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            listTasks.Delete(TaskList.SelectedIndices[0]);
            listTasks.Save();
            TaskList.Items.RemoveAt(TaskList.SelectedIndices[0]);
        }

        private void TaskList_SelectedIndicesChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (TaskList.SelectedIndices[0] >= 0 && TaskList.SelectedIndices[0] < TaskList.Items.Count)
                {
                    deleteToolStripMenuItem.Enabled = true;
                    modifyToolStripMenuItem.Enabled = true;
                    Date_Label.Text = listTasks.Tasks.ElementAt(TaskList.SelectedIndices[0]).Date_Execution.ToString();
                    prioritize_Label.Text = listTasks.Tasks.ElementAt(TaskList.SelectedIndices[0]).Prioritize.ToString();
                    Comment_Label.Text = listTasks.Tasks.ElementAt(TaskList.SelectedIndices[0]).Comment.ToString();
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
            }
        }

        private void modifyToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            createTaskDialog = new CreateTaskDialog(listTasks, TaskList.SelectedIndices[0]);
            createTaskDialog.ShowDialog();
            if (createTaskDialog.DialogResult == DialogResult.OK)
            {
                listTasks.Tasks.ElementAt(TaskList.SelectedIndices[0]).TaskName = createTaskDialog.darkTextBox1.Text;
                listTasks.Tasks.ElementAt(TaskList.SelectedIndices[0]).Prioritize = createTaskDialog.GetPrioritize();
                listTasks.Tasks.ElementAt(TaskList.SelectedIndices[0]).Comment = createTaskDialog.darkTextBox2.Text;
                listTasks.Tasks.ElementAt(TaskList.SelectedIndices[0]).Date_Execution = System.DateTime.Parse(createTaskDialog.maskedTextBox1.Text);
                TaskList.Items.ElementAt(TaskList.SelectedIndices[0]).Text = createTaskDialog.darkTextBox1.Text;
                listTasks.Save();
            }
        }
    }
}
