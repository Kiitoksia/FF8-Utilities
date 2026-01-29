using FF8Utilities.MAUI.Pages;

namespace FF8Utilities.MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MAUI cant use LocalAppData, point it to the right path
            Common.Const.PackagesFolder = FileSystem.AppDataDirectory;
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            return new Window(new CardManipulationPage());
        }
    }
}