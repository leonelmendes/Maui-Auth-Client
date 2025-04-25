using ecommerce_app.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_app.Services.IntroducaoServices
{
    public interface IIntroducaoServices
    {
        List<IntroducaoModel> Get_Introducao();
    }
}
