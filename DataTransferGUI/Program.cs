/*
 * Thanks : http://www.codeproject.com/Articles/317996/SMO-Tutorial-4-of-n-Transferring-Data-and-Tracing
 * License
 * This article, along with any associated source code and files, is licensed under The Code Project Open License (CPOL)
 * Author
 * Kanasz Robert
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataTransferGUI
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
            Application.Run(new Main());
        }
    }
}
