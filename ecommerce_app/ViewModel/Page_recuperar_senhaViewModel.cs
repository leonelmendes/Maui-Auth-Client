using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ecommerce_app.Services.UsuarioServices;
using ecommerce_app.View.Popups;
using ecommerce_app.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ecommerce_app.ViewModel
{
    public class Page_recuperar_senhaViewModel : BaseViewModel
    {
        public Page_recuperar_senhaViewModel(Popup_recuperar_senha popup1)
        {
            this.popup1 = popup1;
            _services = new UsuarioServices();
        }

        #region Services
        private readonly Popup_recuperar_senha popup1;
        private readonly IUsuarioServices _services;
        #endregion

        #region Propertis
        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
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

        #region Commands
        public ICommand Verificar_codeCommand => new Command(Verificar_code);
        #endregion

        #region Metodos
        async void Verificar_code()
        {
            if (string.IsNullOrEmpty(Email))
            {
                //var snackbar = Snackbar.Make("Digite um email válido", null, "Tentar novamente!", TimeSpan.FromSeconds(5), visualOptions: snackbaroptionErro);
                //await snackbar.Show();

                var toast = Toast.Make("O campo email é de Carater Obrigatorio", ToastDuration.Short);
                await toast.Show();
            }
            else
            {
                if (validarEmail(Email))
                {
                    int codigo = Gerar_codigo();
                    string requisicao = await _services.Enviar_email(Email, "Usuario Teste", codigo);
                    if (requisicao.Contains("sucesso"))
                    {
                        //var snackbar = Snackbar.Make(requisicao, null, "", TimeSpan.FromSeconds(5), visualOptions: snackbaroptionTrue);
                        //await snackbar.Show();
                        var toast = Toast.Make(requisicao, ToastDuration.Long);
                        await toast.Show();

                        await popup1.DismissAsync();
                        Popup_verificacar_senha popup = new Popup_verificacar_senha(codigo.ToString(), Email);
                        await popup.ShowAsync();
                    }
                    else
                    {
                        //var snackbar = Snackbar.Make(requisicao, null, "Tentar novamente", TimeSpan.FromSeconds(5), visualOptions: snackbaroptionErro);
                        //await snackbar.Show();

                        var toast = Toast.Make(requisicao, ToastDuration.Long);
                        await toast.Show();
                    }
                }
                else
                {
                    //var snackbar = Snackbar.Make("Digite um email válido", null, "Tentar novamente!", TimeSpan.FromSeconds(5), visualOptions: snackbaroptionErro);
                    //await snackbar.Show();
                    var toast = Toast.Make("Digite um email válido", ToastDuration.Long);
                    await toast.Show();
                }
            }
        }

        private int Gerar_codigo()
        {
            Random random = new Random();
            var resposta = random.Next(1000, 9999);
            return resposta;
        }

        private bool validarEmail(string email)
        {
            Regex verificador = new Regex(@"\w+@([a-zA-Z_]+?\.[a-zA-Z]{2,3})");
            if (verificador.IsMatch(email))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
