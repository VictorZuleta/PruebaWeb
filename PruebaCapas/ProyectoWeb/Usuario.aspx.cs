using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoWeb
{
    public partial class Usuario : System.Web.UI.Page
    {
        BLL.Usuario gestor = new BLL.Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AgreUsusario_Click(object sender, EventArgs e)

        {
            BE.Usuario usua = new BE.Usuario();
            usua.Nombre = txtNombre.Text;
            usua.FechaNacimiento = DateTime.Parse(txtFecha.Text);
            usua.Sexo = DrpLSexo.SelectedValue;
            gestor.Insertar(usua);

        }
    }
}