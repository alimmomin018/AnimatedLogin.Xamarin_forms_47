using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

namespace Xforms47.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginControl : ContentView
    {
        public Command LoginRequest { get; set; }
        public LoginControl()
        {
            LoginRequest = new Command(LoginRequestAction);
            InitializeComponent();
        }

        private double _originalGridHeight;
        private void LoginRequestAction(object obj)
        {
            EntryPassword.IsEnabled = false;
            EntryUsername.IsEnabled = false;
            Login = EntryUsername.Text;
            Password = EntryPassword.Text;

            Activity.IsRunning = false;
            _originalGridHeight = GridMain.Height;
            var animation = new Animation();
            animation.Add(0, 1, new Animation(c => GridMain.HeightRequest = c, GridMain.Height, 200, Easing.SinInOut));
            animation.Add(0, 0.7, new Animation(c => ArrowIcon.Opacity = c, 1, 0, Easing.SinInOut));
            animation.Commit(this, "name", 16, 1200, null, LoginStartAnimationFinished);
        }

        private async void LoginStartAnimationFinished(double arg1, bool arg2)
        {
            Activity.IsRunning = true;
            await Task.Delay(10000);
            Activity.IsRunning = false;
            EntryPassword.IsVisible = false;
            EntryUsername.IsVisible = false;
            var animation = new Animation();
            animation.Add(0, 1, new Animation(c => GridMain.HeightRequest = c, 200, _originalGridHeight, Easing.SinInOut));
            animation.Add(0, 1, new Animation(c => GridButton.TranslationY = c, 0, -50, Easing.SinInOut));
            animation.Add(0.7, 1, new Animation(c => LabelTitle.Opacity = c, 1, 0, Easing.SinInOut));
            animation.Commit(this, "name2", 16, 1200, null, LoginShowWelcomeAnimation);
        }

        private void LoginShowWelcomeAnimation(double arg1, bool arg2)
        {
            LabelTitle.Text = "Welcome";
            LabelLoginBig.Text = Login;
            LabelLoginBig.IsVisible = true;
            GridButton.IsVisible = false;
            var animation = new Animation();
            animation.Add(0, 0.3, new Animation(c => LabelTitle.Opacity = c, 0, 1, Easing.SinInOut));
            animation.Add(0.1, 0.4, new Animation(c => LabelLoginBig.Opacity = c, 0, 1, Easing.SinInOut));
            animation.Add(0.6, 0.8, new Animation(c => LabelTitle.Opacity = c, 1, 0, Easing.SinInOut));
            animation.Add(0.8, 1, new Animation(c => GridMain.ScaleX = c, 1, 3, Easing.BounceOut));
            animation.Add(0.8, 1, new Animation(c => GridMain.ScaleY = c, 1, 3, Easing.BounceOut));
            animation.Add(0.8, 1, new Animation(c => LabelLoginBig.TranslationX = c, 0, -50, Easing.SinInOut));
            animation.Add(0.8, 1, new Animation(c => LabelLoginBig.TranslationY = c, 0, -420, Easing.SinInOut));
            animation.Commit(this, "name3", 16, 4800, null, CallNavigate);

        }

        private void CallNavigate(double arg1, bool arg2)
        {
            NavigateCommand?.Execute(null);
        }

        public static readonly BindableProperty LoginProperty = BindableProperty.Create(
                        "Login",
                        typeof(string),
                        typeof(LoginControl),
                        null,
                        BindingMode.TwoWay,
                        propertyChanged: LoginPropertyChanged);

        public static readonly BindableProperty PasswordProperty = BindableProperty.Create(
                        "Password",
                        typeof(string),
                        typeof(LoginControl),
                        null,
                        BindingMode.TwoWay,
                        propertyChanged: PasswordPropertyChanged);

        public static readonly BindableProperty NavigateCommandProperty = BindableProperty.Create(
                        nameof(NavigateCommand),
                        typeof(ICommand),
                        typeof(LoginControl),
                        default(ICommand));

        private static void LoginPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (LoginControl)bindable;
            control.Login = newValue.ToString();
        }

        private static void PasswordPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (LoginControl)bindable;
            control.Password = newValue.ToString();
        }
        public string Login
        {
            get => GetValue(LoginProperty).ToString();
            set => SetValue(LoginProperty, value);
        }
        public string Password
        {
            get => GetValue(PasswordProperty).ToString();
            set => SetValue(PasswordProperty, value);
        }

        public ICommand NavigateCommand
        {
            get => (ICommand)GetValue(NavigateCommandProperty);
            set => SetValue(NavigateCommandProperty, value);
        }
    }
}