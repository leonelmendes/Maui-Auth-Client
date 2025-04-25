using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
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
    public class Popup_verificar_senhaViewModel : BaseViewModel
    {
        public Popup_verificar_senhaViewModel(Popup_verificacar_senha popup1, string codigo, string email)
        {
            this.popup1 = popup1;
            Codigo = codigo;
            Email = email;
        }

        #region Services
        private readonly Popup_verificacar_senha popup1;
        #endregion

        #region Propertis
        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
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

        private string _codigo;
        public string Codigo
        {
            get => _codigo; 
            set => SetProperty(ref _codigo, value);
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
        public ICommand Popup_sucessoCommand => new Command(Popup_sucesso);
        #endregion

        #region Metodos
        async void Popup_sucesso()
        {
            if(string.IsNullOrEmpty(Codigo1) && string.IsNullOrEmpty(Codigo2) && string.IsNullOrEmpty(Codigo3) && string.IsNullOrEmpty(Codigo4))
            {
                var toast = Toast.Make("Por favor, preencha todos os campos obrigatórios para continuar", ToastDuration.Long);
                await toast.Show();
            }
            else
            {
                var CodigoFinal = $"{Codigo1}{Codigo2}{Codigo3}{Codigo4}";

                if (Codigo == CodigoFinal)
                {
                    await popup1.DismissAsync();

                    Popup_trocar_senha popup = new Popup_trocar_senha(Email);
                    await popup.ShowAsync();

                }
            }
        }
        #endregion
    }
}
