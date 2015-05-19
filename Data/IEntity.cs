using System;
using System.Data;

namespace JAMM.Data
{
    public interface IEntity
    {
        void Load(IDataRecord record);
        void Load(IDataRecord record, string[] fieldNames);
    }
}