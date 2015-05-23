using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMM.Model.Entities
{
    [AttributeUsage(AttributeTargets.Property)]
    class MappingAttribute : Attribute
    {
        public string DbField { get; set; }

        public MappingAttribute(string dbField)
        {
            DbField = dbField;
        }
    }
}
