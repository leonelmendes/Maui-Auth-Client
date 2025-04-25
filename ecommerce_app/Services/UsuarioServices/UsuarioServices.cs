using ecommerce_app.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_app.Services.UsuarioServices
{
    public class UsuarioServices : IUsuarioServices
    {
        public async Task<string> CadastrarUsuario(Usuario usuario)
        {
            var resposta = string.Empty;

            //string url = "https://api20240324181718.azurewebsites.net/Comprador/Cadastrar_comprador";
            //string url = "https://apiseila.azurewebsites.net/Comprador/Cadastrar_comprador";
            string url = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5142/Comprador/Cadastrar_comprador"
                : "http://localhost:5142/Comprador/Cadastrar_comprador";

            try
            {
                using (var cliente = new HttpClient())
                {
                    var serializedUsuario = JsonConvert.SerializeObject(usuario);
                    var content = new StringContent(serializedUsuario, Encoding.UTF8, "application/json");
                    var resultado = cliente.PostAsync(url, content).Result;

                    string requisicao = await resultado.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(requisicao))
                    {
                        requisicao = "erro de conexao com o servidor";
                    }
                    resposta = requisicao;
                }
            }
            catch (Exception )
            {
                resposta = "Erro de conexão com o servidor";
            }

            return resposta;
        }

        public async Task<string> Enviar_email(string email, string nome, int codigo)
        {
            var resposta = string.Empty;

            //string url = "https://apiseila.azurewebsites.net/Verificacao/Enviar_email";
            //string url = "http://localhost:5142/Verificacao/Enviar_email";
            string url = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5142/Verificacao/Enviar_email"
                : "http://localhost:5142/Verificacao/Enviar_email";

            var cliente = new HttpClient();
            var resultado = await cliente.GetAsync($"{url}?email={email}&nome={nome}&codigo={codigo}");

            if (resultado.IsSuccessStatusCode)
            {
                resposta = await resultado.Content.ReadAsStringAsync();
            }
            else
            {
                resposta = await resultado.Content.ReadAsStringAsync();
            }
            return resposta;
        }

        public async Task<bool> Usuario_existe(string entrada)
        {
            var resposta = false;

            //string url = "https://apiseila.azurewebsites.net/Comprador/Comprador_existe";
            //string url = "http://localhost:5142/Comprador/Comprador_existe";
            string url = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5142/Comprador/Comprador_existe"
                : "http://localhost:5142/Comprador/Comprador_existe";

            try
            {
                using (var cliente = new HttpClient())
                {
                    //var serializedUsuario = JsonConvert.SerializeObject(usuario);
                    //var content = new StringContent(serializedUsuario, Encoding.UTF8, "application/json");
                    var resultado = await cliente.GetAsync($"{url}?entrada={entrada}");

                    if (resultado.IsSuccessStatusCode)
                    {
                        resposta = true;
                    }
                    else
                    {
                        resposta = false;
                    }
                }
            }
            catch (Exception)
            {
                
            }

            return resposta;
        }

        public async Task<string> Trocar_senha(string novasenha, string email)
        {
            var resposta = string.Empty;

            //string url = "https://apiseila.azurewebsites.net/Comprador/Trocar_senha_Comprador";
            //string url = "http://localhost:5142/Comprador/Trocar_senha_Comprador";
            string url = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5142/Comprador/Trocar_senha_Comprador"
                : "http://localhost:5142/Comprador/Trocar_senha_Comprador";

            var usuario = new Usuario()
            {
                Senha = novasenha,
                Email = email
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var serializedjson = JsonConvert.SerializeObject(usuario);
                    var content = new StringContent(serializedjson, Encoding.UTF8, "application/json");
                    var resultado = await client.PutAsync(url,content);

                    if (resultado.IsSuccessStatusCode)
                    {
                        resposta = await resultado.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        resposta = await resultado.Content.ReadAsStringAsync();
                    }
                }
            }
            catch
            {
                resposta = "Erro de conexão com o servidor";
            }

            return resposta;
        }
    }
}
