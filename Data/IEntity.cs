using System;
using System.Data;

namespace JAMM.Data
{
    public interface IEntity
    {
        public abstract virtual void Load(IDataRecord record);
        public abstract virtual void Load(IDataRecord record, string[] fieldNames);
    }
}