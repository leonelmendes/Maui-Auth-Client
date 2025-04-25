using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ecommerce_app.Services.UsuarioServices;
using ecommerce_app.View.Popups;
using ecommerce_app.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ecommerce_app.ViewModel
{
    public class Popup_trocar_senhaViewModel : BaseViewModel
    {
        #region Services
        private readonly Popup_trocar_senha popup;
        private readonly IUsuarioServices _services;

        public Popup_trocar_senhaViewModel(Popup_trocar_senha popup,string email)
        {
            this.popup = popup;
            _services = new UsuarioServices();
            Email = email;
        }
        #endregion

        #region Propertis
        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _novasenha;
        public string Nova_senha
        {
            get => _novasenha;
            set => SetProperty(ref _novasenha, value);
        }

        private string _confirmar_nova_senha;
        public string Confirmar_nova_senha
        {
            get => _confirmar_nova_senha;
            set => SetProperty(ref _confirmar_nova_senha, value);
        }
        #endregion

        #region Controls
        SnackbarOptions snackbaroptionErro = new SnackbarOptions
        {
            BackgroundColor = Color.Parse("#cc3429"),
            CornerRadius = 10,
            ActionButtonTextColor = Colors.White,
            TextColor = Colors.White,
        };

        SnackbarOptions snackbaroptionTrue = new SnackbarOptions
        {
            BackgroundColor = Colors.Green,
            CornerRadius = 10,
            TextColor = Colors.White,
        };
        #endregion

        #region Command
        public ICommand Trocar_senhaCommand => new Command(Trocar_senha);
        #endregion

        #region Methods
        async void Trocar_senha()
        {
            if(string.IsNullOrEmpty(Nova_senha) && string.IsNullOrEmpty(Confirmar_nova_senha))
            {
                //var snackbar = Snackbar.Make("Por favor, preencha todos os campos obrigatórios para continuar", null, "Tentar Novamente", TimeSpan.FromSeconds(5), visualOptions:snackbaroptionErro);
                //await snackbar.Show();
                var toast = Toast.Make("Por favor, preencha todos os campos obrigatórios para continuar", ToastDuration.Long);
                await toast.Show();
            }
            else if (Confirmar_nova_senha != Nova_senha)
            {
                //var snackbar = Snackbar.Make("A confirmação da nova senha não corresponde com a nova senha", null, "Tentar Novamente", TimeSpan.FromSeconds(5), visualOptions: snackbaroptionErro);
                //await snackbar.Show();
                var toast = Toast.Make("A confirmação da senha não corresponde com a nova senha", ToastDuration.Long);
                await toast.Show();
            }
            else
            {
                var requisicao = await _services.Trocar_senha(Nova_senha, Email);
                if (requisicao.Contains("Sucesso"))
                {
                     await popup.DismissAsync();

                    var snackbar = Snackbar.Make(requisicao, null, "Ok", TimeSpan.FromSeconds(5), visualOptions: snackbaroptionTrue);
                    await snackbar.Show();
                    //var toast = Toast.Make(requisicao, ToastDuration.Long);
                    //await toast.Show();
                }
                else
                {
                    //var snackbar = Snackbar.Make(requisicao, null, "Ok", TimeSpan.FromSeconds(5), visualOptions: snackbaroptionErro);
                    //await snackbar.Show();
                    var toast = Toast.Make(requisicao, ToastDuration.Long);
                    await toast.Show();
                }
            }
        }
        #endregion
    }
}
