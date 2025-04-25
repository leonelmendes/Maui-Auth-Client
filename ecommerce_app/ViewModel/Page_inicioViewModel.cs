using CommunityToolkit.Mvvm.ComponentModel;
using ecommerce_app.Model;
using ecommerce_app.Services.PageInicio_Services;
using ecommerce_app.ViewModel.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;

namespace ecommerce_app.ViewModel
{
    public class Page_inicioViewModel : BaseViewModel, IQueryAttributable
    {

        #region Services
        private readonly IPageInicioServices _services;
        #endregion

        #region Propertis
        //public ObservableCollection<CardPromocional_Model> Promocional {  get; set; }

        private ObservableCollection<CardPromocional_Model> _promocional;
        public ObservableCollection<CardPromocional_Model> Promocional
        {
            get => _promocional;
            set => SetProperty(ref _promocional, value);
        }

        private Usuario _usuario;
        public Usuario _Usuario
        {
            get => _usuario;
            set => SetProperty(ref _usuario, value);
        }
        #endregion

        #region Controls
        #endregion

        #region Commands
        public ICommand LogoutCommand => new Command(Logout);
        //public ICommand LoadDataCommand { get; }
        #endregion

        #region Method
        public Page_inicioViewModel()
        {
            _services = new PageInicioServices();
            //LoadDataCommand = new Command(async () => await LoadData());
            LoadData();
        }

        private async Task LoadData()
        {
            var request = await _services.Get_CardPromocional();
            Promocional = new ObservableCollection<CardPromocional_Model>(request);
        }

        public async void Logout()
        {
            await Shell.Current.GoToAsync(state: "//Page_login");
            SecureStorage.Remove("AuthToken");
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            //throw new NotImplementedException();
            //Codigo = HttpUtility.UrlDecode(query["Codigo"].ToString());
            _Usuario = query["Usuario"] as Usuario; //_Usuario = JsonConvert.DeserializeObject<Usuario>(parameterUserJson);

            if (query.ContainsKey("Usuario"))
            {
                string usuarioJson = HttpUtility.UrlDecode(query["Usuario"].ToString());
                _Usuario = JsonConvert.DeserializeObject<Usuario>(usuarioJson);
            }
        }
        #endregion
    }
}
