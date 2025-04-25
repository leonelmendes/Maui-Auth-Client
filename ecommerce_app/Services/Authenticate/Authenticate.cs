using ecommerce_app.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_app.Services.Login
{
    public class Authenticate : IAuthenticate
    {

        public async Task<string> Authenticate_Usuario(LoginRequestModel loginRequest)
        {
            //var url = "https://api20240324181718.azurewebsites.net/Authenticate/Authenticate_login";
            //var url = "https://apiseila.azurewebsites.net/Authenticate/Authenticate_login";
            //var url = "http://localhost:5142/Authenticate/Authenticate_login";
            var url = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5142/Authenticate/Authenticate_login"
                : "http://localhost:5142/Authenticate/Authenticate_login";

            string resposta;

            using (HttpClient client = new HttpClient())
            {
                var resultado = await client.PostAsJsonAsync(url, loginRequest);

                if (resultado.IsSuccessStatusCode)
                {
                    var loginResponse = await resultado.Content.ReadFromJsonAsync<LoginResponseModel>();
                    resposta = loginResponse.Token.ToString();
                }
                else
                {
                    resposta = "Não autorizado, dados incorretos.";
                }
            }
            return resposta;
        }

        public async Task<Usuario> Get_Usuario_Token(string token)
        {
            //var url = "https://apiseila.azurewebsites.net/Comprador/Get_comprador_token";
            //var url = "http://localhost:5142/Comprador/Get_comprador_token";
            var url = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5142/Comprador/Get_comprador_token"
                : "http://localhost:5142/Comprador/Get_comprador_token";

            var resposta = new Usuario();

            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var resultado = await client.GetAsync(url);

                if (resultado.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    resposta.Nome = "Falha ao buscar dados do usuário, renove o Token";
                }
                else if(resultado.IsSuccessStatusCode)
                {
                    resposta = await resultado.Content.ReadFromJsonAsync<Usuario>();
                }
                else
                {
                    resposta.Nome = "Ops! Algo deu errado no login. Por favor, tente novamente mais tarde.";
                }
            }
            return resposta;
        }

        /*public async Task<Usuario> LogarUsuario(string entrada, string senha)
        {
            Usuario usuario = new Usuario();

            string url = "https://api20240324181718.azurewebsites.net/Comprador/Logar_comprador";

            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    var resultado = await cliente.GetAsync($"{url}?entrada={entrada}&senha={senha}");
                    if (resultado.IsSuccessStatusCode)
                    {
                        var conteudo = await resultado.Content.ReadAsStringAsync();

                        usuario = JsonConvert.DeserializeObject<Usuario>(conteudo);
                    }
                    else
                    {
                        usuario.Nome = await resultado.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception)
            {
                usuario.Nome = "Erro de conexão com o servidor";
            }

            return usuario;
        }*/
    }
}
