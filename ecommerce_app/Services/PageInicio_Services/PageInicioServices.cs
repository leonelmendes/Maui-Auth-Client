using ecommerce_app.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_app.Services.PageInicio_Services
{
    public class PageInicioServices : IPageInicioServices
    {
        public async Task<List<CardPromocional_Model>> Get_CardPromocional()
        {
            var promocional = new List<CardPromocional_Model>();

            string url = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5142/DropBox/Get_CardPromocional"
                : "http://localhost:5142/DropBox/Get_CardPromocional";

            using (var client = new HttpClient())
            {
                //var serializedObject = JsonConvert.SerializeObject(promocional);
                //var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                var request =  await client.GetAsync(url);

                if (request.IsSuccessStatusCode)
                {
                    promocional = await request.Content.ReadFromJsonAsync<List<CardPromocional_Model>>();
                }

            }

            return promocional;
        }
    }
}