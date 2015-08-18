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
            get { return DbContext.ParameterGet("LoggerConfig").Valor; }
        }
			
        public static class Filtros
        {
            public static string UrlAyuda
            {
                get { return DbContext.ParameterGet("UrlAyuda").Valor; }
            }

            public static int CriterioOrdenCantidadMaxima
            {
                get { return int.Parse(DbContext.ParameterGet("CriterioOrdenCantidadMaxima").Valor); }
            }
        }

        public static class Labels
        {
            public static string TestLabel
            {
                get { return "Esta es una etiqueta de prueba"; }
            }
        }

        public static class WebServices
        {
            public static string TestServicio
            {
				get { return DbContext.ParameterGet("TestServicio").Valor; }
            }
        }
    }
}
