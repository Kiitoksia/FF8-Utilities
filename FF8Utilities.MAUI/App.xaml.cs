using FF8Utilities.MAUI.Pages;
using UltimeciaManip;

namespace FF8Utilities.MAUI
{
    public partial class App : Application
    {
        public static DriveManager DriveManager { get; } = new DriveManager();

        public App()
        {
            InitializeComponent();

            // MAUI cant use LocalAppData, point it to the right path
            Common.Const.PackagesFolder = FileSystem.AppDataDirectory;

        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            return new Window(new MainPage());
        }

        public static int? DelayFrames
        {
            get
            {
                int value = Preferences.Get(nameof(DelayFrames), -1); // Default to an invalid value so its null, as we cannot store nullable ints
                if (value == -1) return null; // Invalid
                return value;
            }
            set
            {
                if (value == DelayFrames) return;
                Preferences.Set(nameof(DelayFrames), value ?? -1);
            }
        }

        public static Common.Platform Platform
        {
            get => Enum.Parse<Common.Platform>(Preferences.Get(nameof(Platform), Common.Platform.PS2.ToString()));
            set => Preferences.Set(nameof(Platform), value.ToString());
        }

        public static UltimeciaManipLanguage GameLanguage
        {
            get => Enum.Parse<UltimeciaManipLanguage>(Preferences.Get(nameof(GameLanguage), UltimeciaManipLanguage.English.ToString()));
            set => Preferences.Set(nameof(GameLanguage), value.ToString());
        }
    }
}