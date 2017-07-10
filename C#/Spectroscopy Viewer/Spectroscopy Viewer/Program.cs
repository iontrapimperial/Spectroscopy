using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Spectroscopy_Viewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
		/*  Designed and Implemented by PavH and Graham Stutter.
		7/7: Additional work by John Peurifoy
		*/
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SpectroscopyViewerForm());
        }
    }
}
