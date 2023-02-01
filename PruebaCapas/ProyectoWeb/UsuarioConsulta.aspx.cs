using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoWeb
{
    public partial class UsuarioConsulta : System.Web.UI.Page
    {
        BLL.Usuario gestor = new BLL.Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                Enlazar();
            }
        }
        public void Enlazar()
        {
            GrVUsuarios.DataSource= gestor.Listar();
            GrVUsuarios.DataBind();
        }
        protected void GrVUsuarios_RowComand(object sender, GridViewCommandEventArgs e)
        {
            
            int id = int.Parse(GrVUsuarios.Rows[int.Parse(e.CommandArgument.ToString())].Cells[2].Text);
            BE.Usuario usua = gestor.Listar(id);

            switch (e.CommandName) 
            {

                case "Borrar":
                    {
                        gestor.Borrar(usua);
                        Enlazar();
                        break;
                    }
                case "Selecionar":
                    {

                        hIdUsuario.Value = usua.IdUsuario.ToString();
                        txtNombre.Text = usua.Nombre;
                        txtFecha.Text = usua.FechaNacimiento.ToString();
                        DrpLSexo.SelectedValue = usua.Sexo;
                        

                     break;
                    }
            
            }
        }

        protected void ModiUsusario_Click(object sender, EventArgs e)
        {

            {
                BE.Usuario usua = new BE.Usuario();
                //usua.IdUsuario = hIdUsuario.Value;
                usua.Nombre = txtNombre.Text;
                usua.FechaNacimiento = DateTime.Parse(txtFecha.Text);
                usua.Sexo = DrpLSexo.SelectedValue;
                gestor.Editar(usua);
                Enlazar();
            }
        }


    }
}