using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Xforms47.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
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
        public Command LoginClick { get; set; }

        public LoginViewModel()
        {
            LoginClick = new Command(NavigateToHome);
        }

        private void NavigateToHome(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new HomePage(Name), false);
        }
    }
}
