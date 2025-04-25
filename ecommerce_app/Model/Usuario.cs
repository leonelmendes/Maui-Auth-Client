using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_app.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Id_telefone { get; set; }
        public int Telefone { get; set; }
        public int Id_email { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Tarefa { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}
