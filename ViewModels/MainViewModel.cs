namespace comixpaint.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MenuViewModel Menu { get; }
        public ToolsViewModel Tools { get; }
        public SettingsViewModel Settings { get; }
        public PaletteViewModel Palette { get; }
        public TextureViewModel Texture { get; }
        public PaintViewModel Paint { get; }
        public SystemViewModel System { get; }

        public MainViewModel(
            MenuViewModel menu,
            ToolsViewModel tools,
            SettingsViewModel settings,
            PaletteViewModel palette,
            TextureViewModel texture,
            PaintViewModel paint,
            SystemViewModel system)
        {
            Menu = menu;
            Tools = tools;
            Settings = settings;
            Palette = palette;
            Texture = texture;
            Paint = paint;
            System = system;
        }
    }
}
