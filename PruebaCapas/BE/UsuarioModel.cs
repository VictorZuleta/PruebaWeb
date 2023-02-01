using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BE
{
    public class UsuarioModel
    {
		public int IdUsuario { get; set; }
		public string Nombre { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public string Sexo { get; set; }


	}
}
