using CommunityToolkit.Mvvm.ComponentModel;
using ecommerce_app.Model;
using ecommerce_app.Services.IntroducaoServices;
using ecommerce_app.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ecommerce_app.ViewModel
{
    public class Page_introducaoViewModel : BaseViewModel
    {
        #region Services
        private readonly IIntroducaoServices _service = new IntroducaoServices();
        #endregion

        #region Propertis
        private bool _btnvisible = false;
        public bool Btnvisible
        {
            get => _btnvisible;
            set => SetProperty(ref _btnvisible, value);
        }

        private string _btncontinuar = "Continuar";
        public string Btncontinuar
        {
            get =>_btncontinuar; 
            set => SetProperty(ref _btncontinuar, value);
            
        }

        private int _position;
        public int Position
        {
            get => _position;
            set
            {
                if (SetProperty(ref _position, value))
                {
                    if (value == Introducao.Count - 1)
                    {
                        Btncontinuar = "Começar";
                    }
                    else if (value == 0)
                    {
                        Btnvisible = false;
                    }
                    else
                    {
                        Btnvisible = true;
                        Btncontinuar = "Continuar";
                    } 
                    
                }
            }
        }

        public ObservableCollection<IntroducaoModel> Introducao { get; set; } = new ObservableCollection<IntroducaoModel>();

        #endregion

        #region Commands
        public ICommand AvancarCommand => new Command(Avancar);
        public ICommand RetornarCommand => new Command(Retornar);

        #endregion

        public Page_introducaoViewModel()
        {
            Carregar();
        }

        #region Metodos
        void Carregar()
        {
            Introducao = new ObservableCollection<IntroducaoModel>(_service.Get_Introducao());
        }

        async void Avancar()
        { 
            if (Btncontinuar == "Continuar")
            {
                Btnvisible = true;
                if (Position >= Introducao.Count - 1)
                {

                }
                else
                {
                    Position += 1;

                }
            }
            else
            {
                //criar a key para a introducao não aparecer
                Preferences.Set("FecharIntroducao", true);
                await Shell.Current.GoToAsync(state: "//Page_login");
            }
            
        }

        void Retornar()
        {
            if (Position <= 1)  //(Position <= Introducao.Count -1)
            {
                Position -= 1;
                Btnvisible = false;
            }
            else
            {
                Position -= 1;
            }
        }
        #endregion
    }
}
