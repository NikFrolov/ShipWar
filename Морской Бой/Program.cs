using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Морской_Бой
{
    static class Program
    {
        static public MainForm GameForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GameForm = new MainForm();
            BattleField Test = new BattleField();
            Application.Run(GameForm);

        }
    }
}
