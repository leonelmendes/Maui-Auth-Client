using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using ecommerce_app.Model;
using ecommerce_app.Services.UsuarioServices;
using ecommerce_app.View.Popups;
using ecommerce_app.ViewModel.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;

namespace ecommerce_app.ViewModel
{
    /*[QueryProperty(nameof(Content), "Content")]
    [QueryProperty(nameof(Codigo), "Codigo")]*/
    public class Page_verificar_cadastroViewModel : BaseViewModel, IQueryAttributable
    {
        #region Services
        private readonly IUsuarioServices _services;
        #endregion

        public Page_verificar_cadastroViewModel()
        {
            _services = new UsuarioServices();
        }

        #region Propertis
        /*string content = string.Empty;
        public string Content
        {
            get => content;
            set
            {
                content = Uri.UnescapeDataString(value ?? string.Empty);
                PerformOperation(content);
            }
        }*/

        private string codigo;
        public string Codigo
        {
            get => codigo;
            set => SetProperty(ref codigo, value);
        }

        private Usuario _usuario;
        public Usuario _Usuario
        {
            get => _usuario;
            set => SetProperty(ref _usuario, value);
        }

        private string _codigo1;
        public string Codigo1
        {
            get => _codigo1;
            set => SetProperty(ref _codigo1, value);
        }

        private string _codigo2;
        public string Codigo2
        {
            get => _codigo2;
            set => SetProperty(ref _codigo2, value);
        }

        private string _codigo3;
        public string Codigo3
        {
            get => _codigo3;
            set => SetProperty(ref _codigo3, value);
        }

        private string _codigo4;
        public string Codigo4
        {
            get => _codigo4;
            set => SetProperty(ref _codigo4, value);
        }

        /*private Color _frame_color = Colors.LightGray;
        public Color Frame_color
        {
            get => _frame_color;
            set => SetProperty(ref _frame_color, value);
        }*/
        #endregion

        #region Commands
        public ICommand BackCommand => new Command(Back);
        public ICommand Popup_sucessoCommand => new Command(Verificar_cadastro);
        public ICommand VerificarCadastro => new Command(Verificar_cadastro);
        #endregion

        #region Metodos
        async void Back()
        {
            await Shell.Current.GoToAsync(state: "..");
        }

        async void Verificar_cadastro()
        {

            if(string.IsNullOrEmpty(Codigo1) && string.IsNullOrEmpty(Codigo2) && string.IsNullOrEmpty(Codigo3) && string.IsNullOrEmpty(Codigo4)) 
            {
                //await Shell.Current.DisplayAlert("Ação necessária", "Por favor, preencha todos os campos obrigatórios para continuar.", "Tentar Novamente");
                var snackbaroptions = new SnackbarOptions
                {
                    BackgroundColor = Color.Parse("#cc3429"),
                    CornerRadius = 10,
                    ActionButtonTextColor = Colors.White,
                    TextColor = Colors.White,
                };

                var snackbar = Snackbar.Make("Por favor, preencha todos os campos obrigatórios para continuar.", null, "Tentar novamente", TimeSpan.FromSeconds(5), visualOptions: snackbaroptions);
                await snackbar.Show();
            }
            else
            {
                var CodigoFinal = $"{Codigo1}{Codigo2}{Codigo3}{Codigo4}";

                if (CodigoFinal == Codigo)
                {
                    string requisicao = await _services.CadastrarUsuario(_Usuario);
                    if (requisicao.Contains("concluído"))
                    {
                        Popup_registro_sucesso popup = new Popup_registro_sucesso();
                        await popup.ShowAsync();
                    }
                    else
                    {
                        var SnackbarOptions = new SnackbarOptions
                        {
                            BackgroundColor = Colors.Red,
                            CornerRadius = 5,
                            ActionButtonTextColor = Colors.White,
                            TextColor = Colors.White,
                        };

                        var snackbar = Snackbar.Make(requisicao, null, "Tentar novamente", TimeSpan.FromSeconds(5), visualOptions:  SnackbarOptions);
                        await snackbar.Show();
                    }
                }
                else
                {
                    var SnackbarOptions = new SnackbarOptions
                    {
                        BackgroundColor = Colors.Red,
                        CornerRadius = 5,
                        ActionButtonTextColor = Colors.White,
                        TextColor = Colors.White,
                    };

                    var snackbar = Snackbar.Make("O código de verificação não condiz com o que lhe foi enviado", null, "Tentar novamente", TimeSpan.FromSeconds(5), visualOptions: SnackbarOptions);
                    await snackbar.Show();
                }
            }
        }

        /*private void PerformOperation(string getconten)
        {
            var content = JsonConvert.DeserializeObject<Usuario>(getconten);
            usuario = content;
        }

        private void PerformOperationCodigo(string getconten)
        {
            var content = JsonConvert.DeserializeObject<string>(getconten);
            Codigo = content;
        }*/

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            //throw new NotImplementedException();
            Codigo = HttpUtility.UrlDecode(query["Codigo"].ToString());
            //_Usuario = query["Usuario"] as Usuario; //_Usuario = JsonConvert.DeserializeObject<Usuario>(parameterUserJson);

            if (query.ContainsKey("Usuario"))
            {
                string usuarioJson = HttpUtility.UrlDecode(query["Usuario"].ToString());
                _Usuario = JsonConvert.DeserializeObject<Usuario>(usuarioJson);
            }
        }
        #endregion
    }
}
