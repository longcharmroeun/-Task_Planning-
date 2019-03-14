using System;
using System.Windows.Forms;
using Task_Planing.Forms;

namespace Task_Planing
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 0)
            {
                Application.Run(new MainForm());
            }
            else if (args.Length >= 1)
            {
                new Task_Planing.Forms.MenuDialogs.TaskEventDialog(args[0], args[1]).ShowDialog();
            }
        }
    }
}
