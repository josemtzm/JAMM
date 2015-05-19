

namespace JAMM.Model.Entities
{
    public enum ParameterType
    {
        Texto,
        Entero,
        Booleano,
        Fecha,
        Decimal,
        Html,
        Url,
        Xml
    }

    public class Parameter : BaseEntity
    {
        public string Descripcion { get; set; }

        public string Id { get; set; }

        public ParameterType Tipo { get; set; }

        public string Valor { get; set; }

        public string Seccion { get; set; }
    }
}
