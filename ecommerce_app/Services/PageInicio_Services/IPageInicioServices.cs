using ecommerce_app.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_app.Services.PageInicio_Services
{
    public interface IPageInicioServices
    {
        Task<List<CardPromocional_Model>> Get_CardPromocional();
    }
}
