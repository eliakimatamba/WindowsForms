using System;
using System.Windows.Forms;

namespace PeasantSimulation
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm = new MainForm();

            // Run the application with the main form
            Application.Run(mainForm);

            // Dispose the main form when the application closes
            mainForm.Dispose();
        }
    }
}
