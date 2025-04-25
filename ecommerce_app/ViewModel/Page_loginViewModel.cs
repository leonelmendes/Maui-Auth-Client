using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ecommerce_app.Model;
using ecommerce_app.Services.Login;
using ecommerce_app.Services.UsuarioServices;
using ecommerce_app.View.Popups;
using ecommerce_app.ViewModel.Base;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;

namespace ecommerce_app.ViewModel
{
    public class Page_loginViewModel : BaseViewModel
    {
        public Page_loginViewModel()
        {
            _authenticateServices = new Authenticate();
            VerificarTokenSalvo();
        }

        #region Services
        private readonly IAuthenticate _authenticateServices;
        //private readonly IUsuarioServices _usuarioServices;
        //private readonly IVendedorServices _vendedor_services;
        #endregion

        #region Propertis
        private bool _isVisible = false;
        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }

        private bool _rememberMe;
        public bool RememberMe
        {
            get => _rememberMe;
            set => SetProperty(ref _rememberMe, value);
        }

        private string _entrada;
        public string Entrada
        {
            get => _entrada;
            set => SetProperty(ref _entrada, value);
        }

        private string _senha;
        public string Senha
        {
            get => _senha;
            set => SetProperty(ref _senha, value);
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
        public ICommand LogarCommand => new Command(Logar);
        public ICommand CadastrarCommand => new Command(Cadastrar);
        public ICommand Recuperar_senhaCommand => new Command(Recuperar_senha);
        #endregion

        #region Metodos
        async void Logar()
        {
            if (/*Entrada.Length == 9 && !validarTelefone(Entrada) || !validarEmail(Entrada) ||*/ string.IsNullOrEmpty(Entrada))
            {
                var snackbar = Snackbar.Make("Digite um Email ou Número de Telefone válido", null, "Ok", TimeSpan.FromSeconds(5), visualOptions: snackbaroptionErro);
                await snackbar.Show();
            }
            else if (string.IsNullOrEmpty(Senha))
            {
                var snackbar = Snackbar.Make("Digite a Senha", null, "Ok", TimeSpan.FromSeconds(5), visualOptions: snackbaroptionErro);
                await snackbar.Show();
            }
            else
            {
                IsVisible = true;

                LoginRequestModel loginRequest = new LoginRequestModel()
                {
                    Entrada = Entrada,
                    Senha = Senha,
                };

                var requisicaoToken = await _authenticateServices.Authenticate_Usuario(loginRequest);

                if (requisicaoToken.Contains("incorretos"))
                {
                    var snackbar = Snackbar.Make(requisicaoToken, null, "Tentar novamente", TimeSpan.FromSeconds(5), visualOptions: snackbaroptionErro);
                    await snackbar.Show();

                    IsVisible = false;
                }
                else
                {
                    if (RememberMe)
                    {
                        await SecureStorage.SetAsync("AuthToken", requisicaoToken);
                    }

                    var requisicaoUsuario = await _authenticateServices.Get_Usuario_Token(requisicaoToken);

                    if (requisicaoUsuario.Nome.Contains("Falha"))
                    {
                        var snackbar = Snackbar.Make(requisicaoUsuario.Nome, null, "Tentar novamente", TimeSpan.FromSeconds(5), visualOptions: snackbaroptionErro);
                        await snackbar.Show();

                        IsVisible = false;
                    }
                    else
                    {
                        var snackbar = Snackbar.Make($"Sejá bem-vindo {requisicaoUsuario.Nome}", null, "Ok", TimeSpan.FromSeconds(5), visualOptions: snackbaroptionTrue);
                        await snackbar.Show();
                        var json = JsonConvert.SerializeObject(requisicaoUsuario);
                        await Shell.Current.GoToAsync(state: $"//Page_inicio?Usuario={HttpUtility.UrlEncode(json)}");

                        IsVisible = false;
                    }
                }

                /*if (requisicao.Nome.Contains("incorretos") || requisicao.Nome.Contains("Erro"))
                {
                    var snackbar = Snackbar.Make(requisicao.Nome, null, "Tentar novamente", TimeSpan.FromSeconds(5), visualOptions: snackbaroptionErro);
                    await snackbar.Show();
                }
                else
                {
                    //criar key para deixar o usuario logado
                    Preferences.Set("UserLogado", true);

                    var snackbar = Snackbar.Make($"Sejá bem-vindo {requisicao.Nome}", null, "Ok", TimeSpan.FromSeconds(5), visualOptions: snackbaroptionTrue);
                    await snackbar.Show();
                    var json = JsonConvert.SerializeObject(requisicao);
                    await Shell.Current.GoToAsync(state: $"//Page_inicio?Usuario={HttpUtility.UrlEncode(json)}");
                }*/
            }
        }

        private async void VerificarTokenSalvo()
        {
            IsVisible = true;
            var salvarToken = await SecureStorage.GetAsync("AuthToken");

            if (!string.IsNullOrEmpty(salvarToken))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var JwtToken = tokenHandler.ReadToken(salvarToken) as JwtSecurityToken;

                if(JwtToken != null && JwtToken.ValidTo > DateTime.UtcNow)
                {
                    var requisicaoUsuario = await _authenticateServices.Get_Usuario_Token(salvarToken);

                    var snackbar = Snackbar.Make($"Sejá bem-vindo {requisicaoUsuario.Nome}", null, "Ok", TimeSpan.FromSeconds(5), visualOptions: snackbaroptionTrue);
                    await snackbar.Show();
                    var json = JsonConvert.SerializeObject(requisicaoUsuario);
                    await Shell.Current.GoToAsync(state: $"//Page_inicio?Usuario={HttpUtility.UrlEncode(json)}");
                }
                else
                {
                    SecureStorage.Remove("AuthToken");
                }
            }
            IsVisible = false;
        }

        async void Cadastrar()
        {
            await Shell.Current.GoToAsync(state: "Page_cadastrar");
        }

        private async void Recuperar_senha()
        {
            Popup_recuperar_senha popup = new Popup_recuperar_senha();
            await popup.ShowAsync();
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

        private bool validarTelefone(string telefone)
        {
            Regex verificador = new Regex(@"[9][0-9]{8}");
            if (verificador.IsMatch(telefone))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
