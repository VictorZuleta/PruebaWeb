using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BLL;
using DAL;
using BE;

namespace BLL
{
    public class UsuarioServicio
    {



        #region insObj
        private DataTable tb = new DataTable();
        Acceso acceso= new Acceso();
        #endregion

        #region MethodGetAllUsuarioNombre
        public UsuarioModel GetAllUsuarioId(int IdUsuario)
        {
            return acceso.GetAllUsuarioId(IdUsuario);
            
        }
        #endregion

        #region MethodAddUsuario
        public string AddUsuario(UsuarioModel obj)
        {

            return acceso.AddUsuario(obj);
        }
        #endregion

        #region MethodUpUsuario
        public void UpUsuario(UsuarioModel obj)
        {
            acceso.UpUsuario(obj);
        }
        #endregion

        #region MethodDeleteUsuario
        public void DeleteUsuario(BE.UsuarioModel obj)
        {
            acceso.DeleteUsuario(obj);
        }
        #endregion

        #region MethodGetAllUsuario
        public List<UsuarioModel> GetAllUsuario()
        {
            return acceso.GetAllUsuario();
            
        }
        #endregion


       

    }


}
