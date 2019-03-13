using System.Linq;
using System.Windows.Forms;
using DarkUI.Controls;
using DarkUI.Docking;
using DarkUI.Forms;
using DarkUI.Win32;
using Task_Planing.Class;
using Task_Planing.Forms.MenuDialogs;
using System.IO;

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
            createTaskDialog = new CreateTaskDialog();
            listTasks = new ListTasks();
        }
        #endregion

        private void createToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            createTaskDialog.ShowDialog();
            if(createTaskDialog.DialogResult == DialogResult.OK)
            {
                listTasks.Tasks.Add(new Task() { TaskName = createTaskDialog.darkTextBox1.Text, Date_Execution = System.DateTime.Parse(createTaskDialog.maskedTextBox1.Text), Prioritize = createTaskDialog.GetPrioritize() });
                TaskList.Items.Add(new DarkListItem(listTasks.Tasks.Last<Task>().TaskName));
                File.WriteAllText("Data.json", listTasks.ToJson());
            }
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            listTasks = Class.ListTasks.FromJson(File.ReadAllText("Data.json"));
            foreach (var item in listTasks.Tasks)
            {
                TaskList.Items.Add(new DarkListItem(item.TaskName));
            }
        }
    }
}
