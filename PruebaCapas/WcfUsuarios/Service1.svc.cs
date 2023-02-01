using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BE;
using BLL;

namespace WcfUsuarios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        UsuarioServicio acceso= new UsuarioServicio();
        
        public UsuarioModel GetlistId(int IdUsuario)
        {
          return acceso.GetAllUsuarioId(IdUsuario);
        }

        public List<UsuarioModel> getUsuarioAll()
        {
            return acceso.GetAllUsuario();
        }

        public string setInsertUs(UsuarioModel obj)
        {
            return acceso.AddUsuario(obj);
        }



        public void setUpdateUs(UsuarioModel obj)
        {
            acceso.UpUsuario(obj);
        }

        public void setDeleteUs(UsuarioModel obj)
        {
            acceso.DeleteUsuario(obj);
        }


    }
}
