using ecommerce_app.View;
using ecommerce_app.View.Popups;

namespace ecommerce_app;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        #region Rotas
        Routing.RegisterRoute("Page_cadastrar", typeof(Page_cadastrar));
        Routing.RegisterRoute("Page_verificar_cadastro", typeof(Page_verificar_cadastro)); 
        Routing.RegisterRoute("Popup_recuperar_senha", typeof(Popup_recuperar_senha));
        Routing.RegisterRoute("Popup_verificar_senha", typeof(Popup_verificacar_senha));
        #endregion

        #region Keys
        //Introducao apenas uma vez
        var Pegar_intro_key = Preferences.Get("FecharIntroducao", false);

        if (Pegar_intro_key == true)
        {
            My_Shell.CurrentItem = MyPage_login;
        }
        else
        {
            My_Shell.CurrentItem = MyPage_introducao;
        }

        
        #endregion

    }
}
