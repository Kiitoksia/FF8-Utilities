using FF8Utilities.MAUI.Pages;

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

        public static int DelayFrames
        {
            get => Preferences.Get(nameof(DelayFrames), 9);
            set
            {
                if (value == DelayFrames) return;
                Preferences.Set(nameof(DelayFrames), value);
            }
        }
    }
}