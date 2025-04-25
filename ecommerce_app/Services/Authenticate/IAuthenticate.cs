using ecommerce_app.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_app.Services.Login
{
    public interface IAuthenticate
    {
        //Task<string> Get_tipo_Usuario(string entrada);
        Task<string> Authenticate_Usuario(LoginRequestModel loginRequest);
        Task<Usuario> Get_Usuario_Token(string token);
        //Task<string> Authenticate_Vendedor(Usuario usuario);
        //Task<Usuario> LogarUsuario(string entrada, string senha);
    }
}
