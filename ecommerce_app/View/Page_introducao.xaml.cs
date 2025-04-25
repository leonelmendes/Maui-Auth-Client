using ecommerce_app.ViewModel;

namespace ecommerce_app.View;

public partial class Page_introducao : ContentPage
{
	public Page_introducao()
	{
		InitializeComponent();
        BindingContext = new Page_introducaoViewModel();
    }
}