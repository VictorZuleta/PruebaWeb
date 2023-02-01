using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ConexionBd
{
    public class BdConexion
    {
        public class Conexion
        {

            #region CadenaConexion
            private SqlConnection Con = new SqlConnection("Server=VICTORZULETA\\SQLEXPRESS02; DataBase=DBREGISTROWEB;Integrated Security=true ; Encrypt=False");

            #endregion

            #region MethodOpen 
            public SqlConnection OpenConexion()
            {
                if (Con.State == ConnectionState.Closed)
                    Con.Open();
                return Con;
            }
            #endregion

            
            public SqlConnection CloseConexion()
            {
                if (Con.State == ConnectionState.Open)
                    Con.Close();
                return Con;
            }

        }
    }
}
