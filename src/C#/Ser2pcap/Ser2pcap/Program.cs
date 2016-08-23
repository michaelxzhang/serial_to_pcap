using System;
//using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ser2pcap
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormSer2pcap());
        }
    }
}
