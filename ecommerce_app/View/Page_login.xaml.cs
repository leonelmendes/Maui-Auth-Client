using ecommerce_app.View.Popups;
using ecommerce_app.ViewModel;

namespace ecommerce_app.View;

public partial class Page_login : ContentPage
{
	public Page_login()
	{
		InitializeComponent();
        BindingContext = new Page_loginViewModel();
	}

}