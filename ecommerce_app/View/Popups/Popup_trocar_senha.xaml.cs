using ecommerce_app.ViewModel;
using The49.Maui.BottomSheet;

namespace ecommerce_app.View.Popups;

public partial class Popup_trocar_senha : BottomSheet
{
	public Popup_trocar_senha(string email)
	{
		InitializeComponent();
		BindingContext = new Popup_trocar_senhaViewModel(this, email);
	}
}