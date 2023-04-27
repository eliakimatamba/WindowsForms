using System;
using System.Threading;
using System.Windows.Forms;

namespace PeasantSimulation
{
    public static class ThreadsAndForms
    {
        public static void AddItem(ListBox listbox, string item)
        {
            if (listbox.InvokeRequired)
            {
                listbox.Invoke(new MethodInvoker(() => listbox.Items.Add(item)));
            }
            else
            {
                listbox.Items.Add(item);
            }
        }

        public static void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }
    }
}
