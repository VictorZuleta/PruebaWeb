using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using BE;
using System.ServiceModel;
using static DAL.ConexionBd.BdConexion;

namespace DAL
{
    public class Acceso
    {

        private Conexion conexion = new Conexion();

        #region GetAllusuarioNombre
        public UsuarioModel GetAllUsuarioId(int IdUsuario)
        {
            using (SqlCommand comando = new SqlCommand())
            {
                
                UsuarioModel entity = new UsuarioModel();
                comando.Connection = conexion.OpenConexion();
                comando.CommandText = "sp_usuario_listar_Id";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;

                using (SqlDataReader read = comando.ExecuteReader())
                {
                    if (read.HasRows)
                    {

                        while (read.Read())
                        {
                            entity.IdUsuario = (int)read["IdUsuario"];
                            entity.Nombre = read["Nombre"].ToString();
                            entity.FechaNacimiento = Convert.ToDateTime(read["FechaNacimiento"]);
                            entity.Sexo = read["Sexo"].ToString();

                        }
                    }
                }
                conexion.CloseConexion();
                return entity;
            }
        }
        #endregion

        #region InsertUsuario
        public string AddUsuario(UsuarioModel emp)
        {
            string mensaje = "";
            try
            {
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.Connection = conexion.OpenConexion();
                    comando.CommandText = "sp_usuario_insertar";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = Convert.ToString(emp.Nombre);
                    comando.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = emp.FechaNacimiento;
                    comando.Parameters.Add("@Sexo", SqlDbType.VarChar, 1).Value = (emp.Sexo);
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                    comando.Connection = conexion.CloseConexion();

                }

            }
            catch (FaultException fex)
            {
                mensaje = "Error" + fex;
            }

            return mensaje;
        }

        #endregion

        #region EditUsuario
        public void UpUsuario(UsuarioModel emp)
        {

            using (SqlCommand comando = new SqlCommand())
            {

                comando.Connection = conexion.OpenConexion();
                comando.CommandText = "sp_usuario_editar";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = (emp.IdUsuario);
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = (emp.Nombre);
                comando.Parameters.Add("@FechaNacimiento", SqlDbType.Date).Value = emp.FechaNacimiento;
                comando.Parameters.Add("@Sexo", SqlDbType.VarChar, 1).Value = (emp.Sexo);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CloseConexion();


            }

        }

        #endregion

        #region DeleteUsuario
        public void DeleteUsuario(UsuarioModel obj)
        {
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = conexion.OpenConexion();
                comando.CommandText = "sp_usuario_borrar";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = (obj.IdUsuario);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                comando.Connection = conexion.CloseConexion();

            }


        }

        #endregion

        #region GetAllusuario
        public List<UsuarioModel> GetAllUsuario()
        {
            using (SqlCommand comando = new SqlCommand())
            {
                List<UsuarioModel> items = new List<UsuarioModel>();

                comando.Connection = conexion.OpenConexion();
                comando.CommandText = "sp_usuario_listar";
                comando.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader read = comando.ExecuteReader())
                {
                    if (read.HasRows)
                    {

                        while (read.Read())
                        {
                            UsuarioModel entity = new UsuarioModel();
                            entity.IdUsuario = (int)read["IdUsuario"];
                            entity.Nombre = read["Nombre"].ToString();
                            entity.FechaNacimiento = Convert.ToDateTime(read["FechaNacimiento"]);
                            entity.Sexo = (read["Sexo"].ToString());
                            items.Add(entity);
                        }

                    }
                }
                conexion.CloseConexion();
                return items;
            }

        }
        #endregion

    }


}




//    private SqlConnection conexion;

//    private void Abrir()
//    {
//        conexion = new SqlConnection("Server=VICTORZULETA\\SQLEXPRESS02; DataBase=DBREGISTROWEB;Integrated Security=true ; Encrypt=False");
//        conexion.Open();
//    }

//    private void Cerrar()
//    {
//        conexion.Close();
//        conexion = null;
//        GC.Collect();
//    }

//    private SqlCommand CrearCmd(string nombre, List<SqlParameter> parametros = null)
//    {
//        SqlCommand cmd = new SqlCommand();
//        cmd.Connection = conexion;
//        cmd.CommandText = nombre;
//        cmd.CommandType = CommandType.StoredProcedure;

//        if (parametros!= null && parametros.Count > 0)
//        {
//            cmd.Parameters.AddRange(parametros.ToArray());
//        }

//        return cmd;

//    }

//    public DataTable Leer(string nombre, List<SqlParameter> parametros = null)
//    {
//        Abrir();

//        DataTable tabla = new DataTable();
//        SqlDataAdapter adaptador = new SqlDataAdapter();
//        adaptador.SelectCommand = CrearCmd(nombre, parametros);

//        adaptador.Fill(tabla);

//        adaptador = null;
//        Cerrar();
//        return tabla;
//    }
//    public int Escribir(string nombre, List<SqlParameter> parametros)
//    {
//        int filasAfectadas = 0;
//        Abrir();
//        SqlCommand cmd = CrearCmd(nombre, parametros);


//        try
//        {
//            filasAfectadas = cmd.ExecuteNonQuery();
//        }
//        catch
//        {
//            filasAfectadas = -1;
//        }


//        Cerrar();
//        return filasAfectadas;
//    }

//    public SqlParameter CrearParametro(string nombre, string valor)
//    {
//        SqlParameter parametro = new SqlParameter();
//        parametro.ParameterName = nombre;
//        parametro.Value = valor;
//        parametro.DbType = DbType.String;
//        return parametro;
//    }

//    public SqlParameter CrearParametro(string nombre, int valor)
//    {
//        SqlParameter parametro = new SqlParameter();
//        parametro.ParameterName = nombre;
//        parametro.Value = valor;
//        parametro.DbType = DbType.Int32;
//        return parametro;
//    }
//    public SqlParameter CrearParametro(string nombre, DateTime valor)
//    {
//        SqlParameter parametro = new SqlParameter();
//        parametro.ParameterName = nombre;
//        parametro.Value = valor;
//        parametro.DbType = DbType.Date;
//        return parametro;
//    }

//}
//}
