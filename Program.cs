using comixpaint.controllers;
using System;
using System.Windows.Forms;

namespace comixpaint
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Program entry point.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            mysticalPlatform.Mystical.StartUp("ComixPainter", false);
            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
            InitController.I().Init();
            Application.Run(new MainForm());
        }
    }
}
