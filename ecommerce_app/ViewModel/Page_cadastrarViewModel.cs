using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using ecommerce_app.Model;
using ecommerce_app.Services.UsuarioServices;
using ecommerce_app.View;
using ecommerce_app.ViewModel.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;

namespace ecommerce_app.ViewModel
{
    public partial class Page_cadastrarViewModel : BaseViewModel
    {
        public Page_cadastrarViewModel()
        {
            _services = new UsuarioServices();
            
        }

        #region Services
        private readonly IUsuarioServices _services;
        #endregion

        #region Propertis
        //public ObservableCollection<string> Pais { get; } = new ObservableCollection<string>();

        private bool _isVisible = false;
        public bool IsVisible
        {
            get => _isVisible; 
            set => SetProperty(ref _isVisible, value);
        }
        private bool _carregar = true;
        public bool Carregar
        {
            get => _carregar;
            set => SetProperty(ref _carregar, value);
        }

        [ObservableProperty]
        string nome;

        private string _nomeCompleto;
        public string NomeCompleto
        {
            get => _nomeCompleto;
            set => SetProperty(ref _nomeCompleto, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _telefone;
        public string Telefone
        {
            get => _telefone;
            set => SetProperty(ref _telefone, value);
        }

        private string _senha;
        public string Senha
        {
            get => _senha;
            set => SetProperty(ref _senha, value);
        }
        #endregion

        #region Commands
        public ICommand BackCommand => new Command(Back);
        public ICommand Verificar_CadastroCommand => new Command(Verificar_Cadastro);
        #endregion

        #region Metodos
        async void Back()
        {
            await Shell.Current.GoToAsync(state: "..");
        }

        async void Verificar_Cadastro()
        {
            if (string.IsNullOrEmpty(NomeCompleto))
            {
                await Shell.Current.DisplayAlert("Ação necessária", "Digite o Nome Completo", "Ok");
            }
            else if (!validarEmail(Email))
            {
                await Shell.Current.DisplayAlert("Ação necessária", "Digite um Email válido", "Ok");
            }
            else if (Telefone == null || Telefone.ToString().Length < 9)
            {
                await Shell.Current.DisplayAlert("Ação Necessária", "Digite um Número de Telefone Válido", "Ok");
            }
            else if(string.IsNullOrEmpty(Senha))
            {
                await Shell.Current.DisplayAlert("Ação Necessária", "Digite a senha", "Ok");
            }
            else
            {
                Mostrar_carregamento();

                Usuario usuario = new Usuario()
                {
                    Nome = NomeCompleto,
                    Email = Email,
                    Telefone = Convert.ToInt32(Telefone),
                    Tarefa = "Comprador",
                    Senha = Senha,
                };

                var verificarUsuario = await _services.Usuario_existe(usuario.Email);
                if (verificarUsuario == false)
                {
                    int codigo = GerarCodigo();
                    string requisicao = await _services.Enviar_email(usuario.Email, usuario.Nome , codigo);
                    if (requisicao.Contains("sucesso"))
                    {
                        var snackbaroption = new SnackbarOptions
                        {
                            BackgroundColor = Colors.Green,
                            CornerRadius = 5,
                            TextColor = Colors.White,
                        };

                        var snackbar = Snackbar.Make(requisicao, null, "",TimeSpan.FromSeconds(5), visualOptions: snackbaroption);
                        await snackbar.Show();
                        var json = JsonConvert.SerializeObject(usuario);
                        await Shell.Current.GoToAsync($"Page_verificar_cadastro?Usuario={HttpUtility.UrlEncode(json)}&Codigo={codigo}"); //{Uri.EscapeDataString(JsonConvert.SerializeObject(usuario))} state: $"Page_verificar_cadastro?Content={usuario}"

                        Mostrar_carregamento();
                    }
                    else
                    {
                        var snackbaroption = new SnackbarOptions
                        {
                            BackgroundColor = Color.Parse("#cc3429"),
                            CornerRadius = 10,
                            ActionButtonTextColor = Colors.White,
                            TextColor = Colors.White,
                        };

                        var snackbar = Snackbar.Make(requisicao, null, "Tentar novamente", TimeSpan.FromSeconds(5), visualOptions: snackbaroption);//
                        await snackbar.Show();

                        Mostrar_carregamento();
                    }
                }
                else
                {
                    //await Shell.Current.DisplayAlert("Alo deu errado", "Dados já existentes no nosso sistema", "Tentar novamente");
                    var snackbaroption = new SnackbarOptions
                    {
                        BackgroundColor = Color.Parse("#cc3429"),
                        CornerRadius = 10,
                        ActionButtonTextColor = Colors.White,
                        TextColor = Colors.White,
                    };

                    var snackbar = Snackbar.Make("Dados já existentes no nosso sistema", null, "Tentar novamente", TimeSpan.FromSeconds(5), visualOptions: snackbaroption);
                    await snackbar.Show();

                    Mostrar_carregamento();
                }

            }
        }

        private int GerarCodigo()
        {
            Random random = new Random();
            int resposta = random.Next(1000, 9999);

            return resposta;
        }

        bool validarEmail(string email)
        {
            Regex verificador = new Regex(@"\w+@([a-zA-Z_]+?\.[a-zA-Z]{2,3})");
            if (verificador.IsMatch(email))
            {
                return true;
            }
            return false;
        }

        void Mostrar_carregamento()
        {
            if (Carregar)
            {
                IsVisible = true;

                Carregar = false;
            }
            else
            {
                IsVisible = false;

                Carregar = true;
            }
        }


        /*bool validarEntrada(string entrada)
        {
            Usuario usuario = new Usuario();

            Regex padraoEmail = new Regex(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");
            Regex padraoTelefone = new Regex(@"[9][0-9]{8}");
            if (padraoEmail.IsMatch(entrada))
            {
                usuario = new Usuario()
                {
                    Email = entrada,
                };
            }
            else if (padraoTelefone.IsMatch(entrada))
            {
                usuario = new Usuario()
                {
                    Email = string.Empty,
                    Telefone = Convert.ToInt32(entrada),
                };
            }
            else
            {
                usuario = new Usuario()
                {
                    Email = string.Empty,
                    Telefone = 0,
                };
            }

        }*/
        #endregion
    }
}
