using System;
using System.Collections.Generic;
using System.Data;

namespace JAMM.Data
{
    [Serializable]
    public class Table<T> : List<T> where T : JAMM.Data.IEntity, new()
    {
        public Table();
        public Table(IDataReader reader);
        public Table(IDataReader reader, bool closeReader);
    }
}
