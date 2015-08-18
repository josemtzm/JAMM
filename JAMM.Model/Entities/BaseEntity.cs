using JAMM.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace JAMM.Model.Entities
{
    [Serializable]
    public abstract class BaseEntity : IEntity
    {
        /// <summary>
        /// Tabla de mapeo de clases y propiedades
        /// </summary>
        private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> Mappings = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

        /// <summary>
<<<<<<< HEAD
        /// Clase para comprar los nombres de campos de forma case insensitive
=======
        /// Clase para comparar los nombres de campos de forma case insensitive
>>>>>>> origin/master
        /// </summary>
        private class FieldNameComparer : IEqualityComparer<string>
        {
            public static readonly FieldNameComparer Instance = new FieldNameComparer();

            private FieldNameComparer()
            {
            }

            bool IEqualityComparer<string>.Equals(string x, string y)
            {
                return string.Equals(x, y, StringComparison.InvariantCultureIgnoreCase);
            }

            int IEqualityComparer<string>.GetHashCode(string obj)
            {
                return obj.ToUpper().GetHashCode();
            }
        }

        #region Constructors

        protected BaseEntity()
        {
            lock (Mappings)
            {
                Type type = GetType();

                if (!Mappings.ContainsKey(type))
                {
                    PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetField | BindingFlags.FlattenHierarchy);

                    Mappings.Add(type, new Dictionary<string, PropertyInfo>(properties.ToDictionary(p => p.Name), FieldNameComparer.Instance));

                    foreach (PropertyInfo property in properties)
                    {
                        MappingAttribute[] attrs = (MappingAttribute[])property.GetCustomAttributes(typeof(MappingAttribute), true);

                        foreach (var attr in attrs)
                        {
                            Mappings[type].Add(attr.DbField, property);
                        }
                    }
                }
            }
        }

        #endregion Constructors

        #region Properties

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Modificado { get; set; }

        public string ModificadoPor { get; set; }

        #endregion Properties

        #region Methods

        public void Load(IDataRecord record)
        {
            //string[] names = record.GetFieldNames();

            //((IEntity)this).Load(record, names);
        }

        public virtual void Load(IDataRecord record, string[] fieldNames)
        {
            Dictionary<string, PropertyInfo> mapping = Mappings[GetType()];

            // Recorro los campos del data record
            for (int i = 0; i < fieldNames.Length; i++)
            {
                // Busco si existe mapeo del campo a propiedad
                if (mapping.ContainsKey(fieldNames[i]))
                {
                    // Asigno el valor a la propiedad si no es NULL
                    if (!record.IsDBNull(i))
                    {
                        try
                        {
                            mapping[fieldNames[i]].SetValue(this, record.GetValue(i), null);
                        }
                        catch (Exception ex)
                        {
                            string m = ex.Message;
                        }
                    }
                }
            }
        }

        #endregion Methods
    }
}
