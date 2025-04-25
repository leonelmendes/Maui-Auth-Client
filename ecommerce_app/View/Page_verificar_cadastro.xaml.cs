using ecommerce_app.Model;
using ecommerce_app.ViewModel;
using Newtonsoft.Json;

namespace ecommerce_app.View;

public partial class Page_verificar_cadastro : ContentPage
{
	public Page_verificar_cadastro()
	{
		InitializeComponent();
        BindingContext = new Page_verificar_cadastroViewModel();
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
            btn_confirmar.Focus();
        }
    }



}