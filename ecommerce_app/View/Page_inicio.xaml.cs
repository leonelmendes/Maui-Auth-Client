using ecommerce_app.ViewModel;

namespace ecommerce_app.View;

public partial class Page_inicio : ContentPage
{
	public Page_inicio()
	{
		InitializeComponent();
		BindingContext = new Page_inicioViewModel();
	}
}