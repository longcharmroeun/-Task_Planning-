using System;

namespace Task_Planing.Forms.MenuDialogs
{
    public partial class TaskEventDialog : DarkUI.Forms.DarkForm
    {
        public TaskEventDialog(string Task, string Comment)
        {
            InitializeComponent();
            Task_Label.Text = Task;
            Comment_Label.Text = Comment;
            System.Media.SystemSounds.Exclamation.Play();
        }

        private void Ok_bt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
