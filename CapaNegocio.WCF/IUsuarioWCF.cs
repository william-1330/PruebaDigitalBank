using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CapaNegocio.Entidades;
using CapaDatos.Data;
using System.Threading.Tasks;

namespace CapaNegocio.WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuarioWCF
    {
        [OperationContract]
        List<Usuario> ListadoUsuarios();

        [OperationContract]
        Usuario Obtener(int idUsuario);

        [OperationContract]
        bool Crear(Usuario usuarioEnt);

        [OperationContract]
        bool Editar(Usuario usuarioEnt);

        [OperationContract]
        bool Eliminar(int idUsuario);

    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
