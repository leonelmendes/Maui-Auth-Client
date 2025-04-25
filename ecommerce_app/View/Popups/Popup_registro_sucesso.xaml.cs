using ecommerce_app.ViewModel;
using The49.Maui.BottomSheet;

namespace ecommerce_app.View.Popups;

public partial class Popup_registro_sucesso : BottomSheet
{
	public Popup_registro_sucesso()
	{
		InitializeComponent();
		BindingContext = new Popup_registro_sucessoViewModel(this);
	}
}