using comixpaint.Services;
using comixpaint.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace comixpaint
{
    /// <summary>
    /// WPF-Anwendung. Baut den Microsoft-DI-Container auf und startet das Hauptfenster.
    /// </summary>
    public class App : Application
    {
        private ServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            mysticalPlatform.Mystical.StartUp("ComixPainter", false);

            var services = new ServiceCollection();
            services.AddComixpaintServices();
            _serviceProvider = services.BuildServiceProvider();

            _serviceProvider.GetRequiredService<InitViewModel>().Init();

            var mainForm = _serviceProvider.GetRequiredService<MainForm>();
            MainWindow = mainForm;
            mainForm.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _serviceProvider?.Dispose();
        }
    }
}
