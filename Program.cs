using System;

namespace comixpaint
{
    /// <summary>
    /// WPF-Einstiegspunkt der Anwendung.
    /// </summary>
    internal sealed class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var app = new App();
            app.Run();
        }
    }
}
