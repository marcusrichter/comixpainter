using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using mystical.Grafix.Data;
using mystical.Grafix.Textures;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Media.Imaging;
using DrawingColor = System.Drawing.Color;

namespace comixpaint.ViewModels
{
    public partial class TexturePickerViewModel : DialogViewModelBase
    {
        private const int PreviewSize = 128;

        private static readonly (string Name, Func<int, int, ArrayBitmap> Create)[] TextureFactories =
        {
            ("Agate",          (w, h) => AgateTexture.CreateAgateBitmap(w, h)),
            ("Aurora",         (w, h) => AuroraTexture.CreateAuroraBitmap(w, h)),
            ("BasketWeave",    (w, h) => BasketWeaveTexture.CreateBasketWeaveBitmap(w, h)),
            ("Bismuth",        (w, h) => BismuthTexture.CreateBismuthBitmap(w, h)),
            ("Brick",          (w, h) => BrickTexture.CreateBrickBitmap(w, h)),
            ("Camouflage",     (w, h) => CamouflageTexture.CreateCamouflageBitmap(w, h)),
            ("Cellular",       (w, h) => CellularTexture.CreateCellularBitmap(w, h, DrawingColor.DarkSlateGray, DrawingColor.LightGray)),
            ("CircuitBoard",   (w, h) => CircuitBoardTexture.CreateCircuitBoardBitmap(w, h)),
            ("Cloud",          (w, h) => CloudTexture.CreateCloudBitmap(w, h, DrawingColor.CornflowerBlue, DrawingColor.White)),
            ("Cobblestone",    (w, h) => CobblestoneTexture.CreateCobblestoneBitmap(w, h)),
            ("Coral",          (w, h) => CoralTexture.CreateCoralBitmap(w, h)),
            ("Diffraction",    (w, h) => DiffractionTexture.CreateDiffractionBitmap(w, h)),
            ("DragonScale",    (w, h) => DragonScaleTexture.CreateDragonScaleBitmap(w, h)),
            ("Fabric",         (w, h) => FabricTexture.CreateFabricBitmap(w, h)),
            ("Fingerprint",    (w, h) => FingerprintTexture.CreateFingerprintBitmap(w, h)),
            ("Fire",           (w, h) => FireTexture.CreateFireBitmap(w, h)),
            ("Galaxy",         (w, h) => GalaxyTexture.CreateGalaxyBitmap(w, h)),
            ("Gemstone",       (w, h) => GemstoneTexture.CreateGemstoneBitmap(w, h)),
            ("Hexagon",        (w, h) => HexagonTexture.CreateHexagonBitmap(w, h)),
            ("Ice",            (w, h) => IceTexture.CreateIceBitmap(w, h)),
            ("LavaLamp",       (w, h) => LavaLampTexture.CreateLavaLampBitmap(w, h, DrawingColor.Black, DrawingColor.OrangeRed)),
            ("Lava",           (w, h) => LavaTexture.CreateLavaBitmap(w, h)),
            ("Leather",        (w, h) => LeatherTexture.CreateLeatherBitmap(w, h)),
            ("Lightning",      (w, h) => LightningTexture.CreateLightningBitmap(w, h)),
            ("MagneticField",  (w, h) => MagneticFieldTexture.CreateMagneticFieldBitmap(w, h)),
            ("Marble",         (w, h) => MarbleTexture.CreateMarbleBitmap(w, h, DrawingColor.WhiteSmoke, DrawingColor.DarkGray)),
            ("Mosaic",         (w, h) => MosaicTexture.CreateMosaicBitmap(w, h)),
            ("Nebula",         (w, h) => NebulaTexture.CreateNebulaBitmap(w, h)),
            ("NeonGrid",       (w, h) => NeonGridTexture.CreateNeonGridBitmap(w, h)),
            ("NightSky",       (w, h) => NightSkyTexture.CreateNightSkyBitmap(w, h)),
            ("Ocean",          (w, h) => OceanTexture.CreateOceanBitmap(w, h)),
            ("OilSlick",       (w, h) => OilSlickTexture.CreateOilSlickBitmap(w, h)),
            ("Parchment",      (w, h) => ParchmentTexture.CreateParchmentBitmap(w, h)),
            ("Ring",           (w, h) => RingTexture.CreateRingBitmap(w, h)),
            ("RuneStone",      (w, h) => RuneStoneTexture.CreateRuneStoneBitmap(w, h)),
            ("Rust",           (w, h) => RustTexture.CreateRustBitmap(w, h)),
            ("SandDune",       (w, h) => SandDuneTexture.CreateSandDuneBitmap(w, h)),
            ("Scale",          (w, h) => ScaleTexture.CreateScaleBitmap(w, h)),
            ("SnakeSkin",      (w, h) => SnakeSkinTexture.CreateSnakeSkinBitmap(w, h)),
            ("SoapBubble",     (w, h) => SoapBubbleTexture.CreateSoapBubbleBitmap(w, h)),
            ("SolarSurface",   (w, h) => SolarSurfaceTexture.CreateSolarSurfaceBitmap(w, h)),
            ("StainedGlass",   (w, h) => StainedGlassTexture.CreateStainedGlassBitmap(w, h)),
            ("Stucco",         (w, h) => StuccoTexture.CreateStuccoBitmap(w, h)),
            ("Terrain",        (w, h) => TerrainTexture.CreateTerrainBitmap(w, h)),
            ("TieDye",         (w, h) => TieDyeTexture.CreateTieDyeBitmap(w, h)),
            ("Turbulence",     (w, h) => TurbulenceTexture.CreateTurbulenceBitmap(w, h, DrawingColor.DarkBlue, DrawingColor.OrangeRed)),
            ("WaterRipple",    (w, h) => WaterRippleTexture.CreateRippleBitmap(w, h, DrawingColor.DarkBlue, DrawingColor.LightCyan)),
            ("Wood",           (w, h) => WoodTexture.CreateWoodBitmap(w, h, DrawingColor.SandyBrown, DrawingColor.SaddleBrown)),
        };

        [ObservableProperty]
        private TextureItem _selectedTexture;

        [ObservableProperty]
        private BitmapSource _preview;

        public ObservableCollection<TextureItem> Textures { get; } = new ObservableCollection<TextureItem>();

        public ArrayBitmap Result { get; private set; }

        public bool Cleared { get; private set; }

        public TexturePickerViewModel()
        {
            foreach (var (name, create) in TextureFactories)
            {
                Textures.Add(new TextureItem(name, create));
            }
        }

        partial void OnSelectedTextureChanged(TextureItem value)
        {
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            if (SelectedTexture == null)
            {
                Preview = null;
                return;
            }

            try
            {
                var bmp = SelectedTexture.Create(PreviewSize, PreviewSize);
                ToGrayscale(bmp);
                Preview = ArrayBitmapToBitmapSource(bmp);
            }
            catch
            {
                Preview = null;
            }
        }

        [RelayCommand]
        private void Ok()
        {
            if (SelectedTexture == null)
            {
                Close(false);
                return;
            }

            Result = SelectedTexture.Create(256, 256);
            ToGrayscale(Result);
            Close();
        }

        [RelayCommand]
        private void Clear()
        {
            Cleared = true;
            Close();
        }

        [RelayCommand]
        private void Cancel() => Close(false);

        private static void ToGrayscale(ArrayBitmap bmp)
        {
            for (var x = 0; x < bmp.Width; x++)
            {
                for (var y = 0; y < bmp.Height; y++)
                {
                    var c = bmp.GetPixel(x, y);
                    var gray = (int)(c.R * 0.299f + c.G * 0.587f + c.B * 0.114f);
                    bmp.SetPixel(x, y, DrawingColor.FromArgb(c.A, gray, gray, gray));
                }
            }
        }

        private static BitmapSource ArrayBitmapToBitmapSource(ArrayBitmap src)
        {
            using var bmp = new Bitmap(src.Width, src.Height);
            for (var x = 0; x < src.Width; x++)
            {
                for (var y = 0; y < src.Height; y++)
                {
                    bmp.SetPixel(x, y, src.GetPixel(x, y));
                }
            }

            return bmp.ToBitmapSource();
        }
    }
}
