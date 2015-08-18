using DAL;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace SrvEmpleado
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicio
    {
        [OperationContract]
        List<Empleado> ObtenerEmpleadosLista();
        [OperationContract]
        bool ActualizarEmpleado(Empleado empleado);
        [OperationContract]
        Empleado ObtenerEmpleadoDetalle(int empID);
        [OperationContract]
        bool BorrarEmpleado(int empID);
        [OperationContract]
        bool AgregarEmpleado(Empleado empleado);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "SrvEmpleado.ContractType".
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
