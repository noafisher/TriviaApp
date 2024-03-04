using TriviaApp.ViewModel;

namespace TriviaApp.View;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel vm)
	{
		InitializeComponent();
        this.BindingContext =vm  ;

    }
}