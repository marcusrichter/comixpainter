using comixpaint.Services.Ai;
using comixpaint.Services.App;
using comixpaint.Services.Drawing;
using comixpaint.Services.Palette;
using comixpaint.Services.State;
using comixpaint.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace comixpaint.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddComixpaintServices(this IServiceCollection services)
        {
            // App
            services.AddSingleton<InitService>();
            services.AddSingleton<SystemService>();
            services.AddSingleton<AppDataService>();

            // State
            services.AddSingleton<StateService>();

            // Drawing
            services.AddSingleton<PaintSurfaceService>();
            services.AddSingleton<PaintEditService>();
            services.AddSingleton<HistoryService>();
            services.AddSingleton<TemplateService>();
            services.AddSingleton<MenuService>();
            services.AddSingleton<ToolsService>();
            services.AddSingleton<SettingsService>();
            services.AddSingleton<PaintService>();
            services.AddSingleton<TextureService>();

            // Palette
            services.AddSingleton<PaletteStorageService>();
            services.AddSingleton<PaletteService>();

            // Ai
            services.AddSingleton<AiDrawingService>();

            // ViewModels
            services.AddSingleton<InitViewModel>();
            services.AddSingleton<SystemViewModel>();
            services.AddSingleton<MenuViewModel>();
            services.AddSingleton<ToolsViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<PaletteViewModel>();
            services.AddSingleton<TextureViewModel>();
            services.AddSingleton<PaintViewModel>();
            services.AddSingleton<MainViewModel>();

            // View
            services.AddSingleton<MainForm>();

            return services;
        }
    }
}
