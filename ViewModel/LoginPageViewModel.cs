using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using TriviaApp.Models;
using TriviaApp.Services;

namespace TriviaApp.ViewModel
{
    public class LoginPageViewModel:ViewModel 
    {
        private TriviaAppService triviaAppService;
        private string username;
        private string password;
        private string theLogin;
        private Color theLoginColor;



        public string Username { get { return username; } set { username = value; OnPropertyChanged();((Command)LoginCommand).ChangeCanExecute(); } }
        public string Password { get { return password; } set { password = value; OnPropertyChanged(); ((Command)LoginCommand).ChangeCanExecute(); } }
        public string TheLogin { get { return theLogin; } set { theLogin = value; OnPropertyChanged(); } }
        public Color TheLoginColor { get { return theLoginColor; } set { theLoginColor = value; OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private User user;

        public LoginPageViewModel(TriviaAppService service)
        {
            this.triviaAppService = service;
            user = new User();
            LoginCommand = new Command(async () => await Login(), () => !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password)) ;
            CancelCommand = new Command(Cancel, () => !String.IsNullOrEmpty(Username) || !String.IsNullOrEmpty(Password));
        }

        public async Task Login()
        {
           
            bool isExist = triviaAppService.Login( username, password);
            if (isExist == true)
            {
                TheLogin = "התחבר בהצלחה";
                TheLoginColor = Colors.DeepSkyBlue;
                AppShell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
                await AppShell.Current.GoToAsync("///BestScoresPage");

            }

            else
            {
                TheLogin = "לא קיים משתמש";
                TheLoginColor = Colors.DeepSkyBlue;

            }
        }

        public void Cancel()
        {
            TheLogin = string.Empty;
            username = string.Empty;
            Password = string.Empty;
            user = new User();
        }
    }
}
