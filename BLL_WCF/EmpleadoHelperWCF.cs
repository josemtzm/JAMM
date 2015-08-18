using BLL_WCF.SrvEmpleado;
using System.Collections.Generic;
using System.Linq;

namespace BLL_WCF
{
    public class EmpleadoHelperWCF
    {
        public EmpleadoHelperWCF()
        {
            Empleado employeeDb = new Empleado();
        }
        /// <summary>
        /// Obtiene la lista de empleados.
        /// </summary>
        /// <returns></returns>
        public List<Empleado> ObtenerEmpleadosLista()
        {
            ServicioClient servicio = new ServicioClient();
            return servicio.ObtenerEmpleadosLista().ToList<Empleado>();
        }

        /// <summary>
        /// Actualiza los datos de un empleado
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        public bool ActualizarEmpleado(Empleado empleado)
        {
            ServicioClient servicio = new ServicioClient();
            return servicio.ActualizarEmpleado(empleado);
        }

        /// <summary>
        /// Obtiene el detalle de un empleado
        /// </summary>
        /// <param name="empID"></param>
        /// <returns></returns>
        public Empleado ObtenerEmpleadoDetalle(int empID)
        {
            ServicioClient servicio = new ServicioClient();
            return servicio.ObtenerEmpleadoDetalle(empID);
        }

        /// <summary>
        /// Borrar un empleado
        /// </summary>
        /// <param name="empID"></param>
        /// <returns></returns>
        public bool BorrarEmpleado(int empID)
        {
            ServicioClient servicio = new ServicioClient();
            return servicio.BorrarEmpleado(empID);
        }

        /// <summary>
        /// Agrega un empleado
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        public bool AgregarEmpleado(Empleado empleado)
        {
            ServicioClient servicio = new ServicioClient();
            return servicio.AgregarEmpleado(empleado);
        }
    }
}
