using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfUsuarios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        UsuarioModel GetlistId(int IdUsusario);

        [OperationContract]
        string setInsertUs(UsuarioModel obj);

        [OperationContract]
        void setUpdateUs(UsuarioModel obj);

        [OperationContract]
        void setDeleteUs(UsuarioModel obj);

        [OperationContract]
        List<UsuarioModel> getUsuarioAll();


        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.

}
