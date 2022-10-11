
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraWPF.Models
{
    // PENDIENTE A MODIFICAR (PUBLIC)
    internal class UserModel
    {
        public int UsuarioID { get; set; }
        public int TrabajadorID { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }
    }
}
