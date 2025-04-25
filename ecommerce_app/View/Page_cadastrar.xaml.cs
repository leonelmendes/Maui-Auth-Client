using ecommerce_app.ViewModel;

namespace ecommerce_app.View;

public partial class Page_cadastrar : ContentPage
{
	public Page_cadastrar()
	{
		InitializeComponent();
		BindingContext = new Page_cadastrarViewModel();
	}
}