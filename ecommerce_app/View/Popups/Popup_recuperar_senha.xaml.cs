using CommunityToolkit.Maui.Alerts;
using ecommerce_app.ViewModel;
using The49.Maui.BottomSheet;

namespace ecommerce_app.View.Popups;

public partial class Popup_recuperar_senha : BottomSheet
{
	public Popup_recuperar_senha()
	{
		InitializeComponent();
		BindingContext = new Page_recuperar_senhaViewModel(this);
	}
}