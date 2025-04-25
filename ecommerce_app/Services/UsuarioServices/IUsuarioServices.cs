using ecommerce_app.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_app.Services.UsuarioServices
{
    public interface IUsuarioServices
    {
        Task<string> CadastrarUsuario(Usuario usuario);
        Task<string> Enviar_email(string email, string nome, int codigo);
        Task<bool> Usuario_existe(string entrada);
        //Task<string> Logar_usuario(Usuario usuario);
        Task<string> Trocar_senha(string novasenha, string email);
    }
}
