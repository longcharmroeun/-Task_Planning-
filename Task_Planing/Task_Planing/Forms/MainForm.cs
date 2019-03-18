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
        private DateSearchDialog DateSearchDialog;
        #endregion

        #region Constructor Region
        public MainForm()
        {
            InitializeComponent();
            listTasks = new ListTasks();
        }
        #endregion

        #region Event Region

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            listTasks = Class.ListTasks.Load();
            foreach (var item in listTasks.Tasks)
            {
                TaskList.Items.Add(new DarkListItem(item.TaskName));
            }
        }

        private void createToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            createTaskDialog = new CreateTaskDialog();
            createTaskDialog.ShowDialog();
            if(createTaskDialog.DialogResult == DialogResult.OK)
            {
                try
                {
                    Class.Task task = new Class.Task() { TaskName = createTaskDialog.darkTextBox1.Text, Date_Execution = System.DateTime.Parse(createTaskDialog.maskedTextBox1.Text), Prioritize = createTaskDialog.GetPrioritize(), Comment = createTaskDialog.darkTextBox2.Text };
                    listTasks.Tasks.Add(task);
                    TaskList.Items.Add(new DarkListItem(listTasks.Tasks.Last<Class.Task>().TaskName));
                    task.Create();
                }
                catch (System.FormatException)
                {
                    DarkMessageBox.ShowError("Please enter the correct format", "Format error!");
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            listTasks.Tasks.ElementAt(TaskList.SelectedIndices[0]).Delete();
            listTasks.Delete(TaskList.SelectedIndices[0]);
            TaskList.Items.RemoveAt(TaskList.SelectedIndices[0]);
            if (TaskList.Items.Count <= 0)
            {
                deleteToolStripMenuItem.Enabled = false;
                modifyToolStripMenuItem.Enabled = false;
            }
        }

        private void TaskList_SelectedIndicesChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (TaskList.SelectedIndices[0] >= 0 && TaskList.SelectedIndices[0] < TaskList.Items.Count)
                {
                    deleteToolStripMenuItem.Enabled = true;
                    modifyToolStripMenuItem.Enabled = true;
                    Date_Label.Text = listTasks.Tasks.ElementAt(TaskList.SelectedIndices[0]).Date_Execution.ToString("MM/dd/yyyy HH:mm");
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
            createTaskDialog = new CreateTaskDialog(listTasks.Tasks.ElementAt(TaskList.SelectedIndices[0]));
            createTaskDialog.ShowDialog();
            if (createTaskDialog.DialogResult == DialogResult.OK)
            {
                listTasks.Tasks.ElementAt(TaskList.SelectedIndices[0]).TaskName = createTaskDialog.darkTextBox1.Text;
                listTasks.Tasks.ElementAt(TaskList.SelectedIndices[0]).Prioritize = createTaskDialog.GetPrioritize();
                listTasks.Tasks.ElementAt(TaskList.SelectedIndices[0]).Comment = createTaskDialog.darkTextBox2.Text;
                listTasks.Tasks.ElementAt(TaskList.SelectedIndices[0]).Date_Execution = System.DateTime.Parse(createTaskDialog.maskedTextBox1.Text);
                TaskList.Items.ElementAt(TaskList.SelectedIndices[0]).Text = createTaskDialog.darkTextBox1.Text;
                listTasks.Tasks.ElementAt(TaskList.SelectedIndices[0]).Modify();
            }
        }

        private void dateToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DateSearchDialog = new DateSearchDialog();
            DateSearchDialog.ShowDialog();
            if(DateSearchDialog.DialogResult == DialogResult.OK)
            {
                try
                {
                    int[] tmp = listTasks.DateSearch(System.DateTime.Parse(DateSearchDialog.maskedTextBox1.Text), System.DateTime.Parse(DateSearchDialog.maskedTextBox2.Text));
                    foreach (var item in tmp)
                    {
                        TaskList.Items.ElementAt(item).TextColor = System.Drawing.Color.Green;
                    }
                }
                catch (System.FormatException)
                {
                    DarkMessageBox.ShowError("Please enter the correct format", "Format error!");
                }
            }
        }

        private void clearToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            foreach (var item in TaskList.Items)
            {
                item.TextColor = System.Drawing.Color.White;
            }
            TaskList.Invalidate();
        }

        #endregion
    }
}
