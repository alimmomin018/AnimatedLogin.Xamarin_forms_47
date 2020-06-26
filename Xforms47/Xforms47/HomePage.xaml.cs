using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xforms47
{
    /* Not the proper place for that kind of code, but it's a fast Project.
     Add custom controls and Mvvm to this page so it better suits a new project format.*/
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage, INotifyPropertyChanged
    {
        public HomePage(string login)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Name = login;

            new Task(async () =>
            {
                await Task.Delay(500);

                var animation = new Animation();
                animation.Add(0, 0.3, new Animation(c => Frame00.Opacity = c, 0, 1, Easing.SinInOut));
                animation.Add(0.3, 0.6, new Animation(c => Frame10.Opacity = c, 0, 1, Easing.SinInOut));
                animation.Add(0.3, 0.6, new Animation(c => Frame01.Opacity = c, 0, 1, Easing.SinInOut));
                animation.Add(0.6, 0.9, new Animation(c => Frame20.Opacity = c, 0, 1, Easing.SinInOut));
                animation.Add(0.6, 0.9, new Animation(c => Frame11.Opacity = c, 0, 1, Easing.SinInOut));
                animation.Add(0.8, 1, new Animation(c => Frame21.Opacity = c, 0, 1, Easing.SinInOut));
                animation.Commit(this, "homename", 16, 1000);
            }).Start();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }


    }
}