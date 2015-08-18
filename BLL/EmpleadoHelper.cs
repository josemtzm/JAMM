using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace BLL
{
    public class EmpleadoHelper
    {
        public EmpleadoHelper()
        {
            Empleado employeeDb = new Empleado();
        }
        /// <summary>
        /// Obtiene la lista de empleados.
        /// </summary>
        /// <returns></returns>
        public List<Empleado> ObtenerEmpleadosLista()
        {
            return DbContext.ObtenerEmpleadosLista();
        }

        /// <summary>
        /// Actualiza los datos de un empleado
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        public bool ActualizarEmpleado(Empleado empleado)
        {
            return DbContext.ActualizarEmpleado(empleado);
        }

        /// <summary>
        /// Obtiene el detalle de un empleado
        /// </summary>
        /// <param name="empID"></param>
        /// <returns></returns>
        public Empleado ObtenerEmpleadoDetalle(int empID)
        {
            return DbContext.ObtenerEmpleadoDetalle(empID);
        }

        /// <summary>
        /// Borrar un empleado
        /// </summary>
        /// <param name="empID"></param>
        /// <returns></returns>
        public bool BorrarEmpleado(int empID)
        {
            return DbContext.BorrarEmpleado(empID);
        }

        /// <summary>
        /// Agrega un empleado
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        public bool AgregarEmpleado(Empleado empleado)
        {
            return DbContext.AgregarEmpleado(empleado);
        }
    }
}
