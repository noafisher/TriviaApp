using TriviaApp.ViewModel;

namespace TriviaApp.View;

public partial class UserAdminPage : ContentPage
{
	public UserAdminPage(UserAdminPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}