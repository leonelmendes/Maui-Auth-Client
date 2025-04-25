using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_app.Controls
{
    internal class Picker_indicator_country : Picker
    {
        public Picker_indicator_country()
        {
            var regiao = Pegar_regiao();
            foreach (var country in regiao)
            {
                Items.Add(country.Value);
            }
        }

        private Dictionary<string, string> Pegar_regiao()
        {
            var Code_regiao = new Dictionary<string, string>
            {
                { "Angola", "+244" },
                { "Portugal", "+351" },
                { "Brasil", "+55" },
            };

            return Code_regiao;
        }
    }
}
