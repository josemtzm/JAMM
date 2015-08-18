using System.Configuration;
using System.ServiceModel;

namespace JAMM.Model
{
    public static partial class Config
    {
        public const string DATE_FORMAT = "dd / MM / yyyy";

        public const string DATE_TIME_FORMAT = "dd / MM / yyyy hh : mm : ss";

        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString; }
        }

        public static bool DebugMode
        {
            get
            {
#if DEBUG
                return true;
#endif
#if !DEBUG
                return false;
#endif
            }
        }

#if DEBUG
        public static string DebugUser
        {
            get { return ConfigurationManager.AppSettings["DebugUser"]; }
        }
#endif

        public static string LoggerConfig
        {
            get { return DbContext.ParameterGet("General.LoggerConfig").Valor; }
        }

<<<<<<< HEAD
        public static class FichaEmpleado
        {
            public static int LimiteBusqueda
            {
                get { return int.Parse(DbContext.ParameterGet("FichaEmpleado.LimiteBusqueda").Valor); }
            }
        }



=======
>>>>>>> origin/master
        public static class Filtros
        {
            public static string UrlAyuda
            {
                get { return DbContext.ParameterGet("Filtros.UrlAyuda").Valor; }
            }

            public static int CriterioOrdenCantidadMaxima
            {
                get { return int.Parse(DbContext.ParameterGet("Filtros.CriterioOrdenCantidadMaxima").Valor); }
            }
        }

        public static class Labels
        {
            public static string NuevaEvaluacionConfirmacionCancelar
            {
                get { return "Al cancelar este paso la evaluación no será creada. ¿Desea continuar?"; }
            }


        }

        public static class WebServices
        {
            public static string FindEvaluator
            {
                get { return DbContext.ParameterGet("FindEvaluator").Valor; }
            }

            public static string Objetive
            {
                get { return DbContext.ParameterGet("ObjectiveApi").Valor; }
            }
        }
    }
}
