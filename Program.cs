using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BASEC
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bnew = false;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, "YURASEARCH", out bnew);

            if (bnew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMother());
            }
            else
            {
                MessageBox.Show("Already Run the Program");
                Application.Exit();
            }
        }
    }
}
