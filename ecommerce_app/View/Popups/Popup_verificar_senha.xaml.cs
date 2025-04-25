using ecommerce_app.ViewModel;
using The49.Maui.BottomSheet;

namespace ecommerce_app.View.Popups;

public partial class Popup_verificacar_senha : BottomSheet
{
	public Popup_verificacar_senha(string codigo, string email)
	{
		InitializeComponent();
		BindingContext = new Popup_verificar_senhaViewModel(this, codigo, email);
	}

    private void Mudar_foco1(object sender, TextChangedEventArgs e)
    {
        if (entry1.Text.Length >= 1)
        {
            entry2.Focus();
        }
    }

    private void Mudar_foco2(object sender, TextChangedEventArgs e)
    {
        if (entry2.Text.Length >= 1)
        {
            entry3.Focus();
        }
    }

    private void Mudar_foco3(object sender, TextChangedEventArgs e)
    {
        if (entry3.Text.Length >= 1)
        {
            entry4.Focus();
        }
    }


    private void Mudar_foco4(object sender, TextChangedEventArgs e)
    {
        if (entry4.Text.Length >= 1)
        {
            entry4.Unfocus();
        }
    }
}