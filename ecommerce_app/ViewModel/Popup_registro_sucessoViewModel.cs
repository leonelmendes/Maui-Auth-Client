using ecommerce_app.View.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ecommerce_app.ViewModel
{
    public class Popup_registro_sucessoViewModel
    {
        public Popup_registro_sucessoViewModel(Popup_registro_sucesso popup)
        {
            this.popup = popup;
        }
        #region Services
        private readonly Popup_registro_sucesso popup;
        #endregion

        #region Propertis
        #endregion

        #region Commands
        public ICommand Voltar_loginCommand => new Command(Voltar_login);
        #endregion

        #region Metodos
        async void Voltar_login()
        {
            
            await popup.DismissAsync();
            //await Shell.Current.GoToAsync("//Page_login");
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
        #endregion
    }
}
