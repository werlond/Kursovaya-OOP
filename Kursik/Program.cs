using System;
using System.Windows.Forms;
using SQLitePCL;

namespace Kursik
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Batteries.Init();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}
