using Xamarin.Forms;

namespace Xforms47
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] { "Shapes_Experimental" });

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
