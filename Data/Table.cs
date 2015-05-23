using System;
using System.Collections.Generic;
using System.Data;

namespace JAMM.Data
{
    [Serializable]
    public class Table<T> : List<T> where T : JAMM.Data.IEntity, new()
    {
        //public Table()
        //{
        //    //return new Table<T>();
        //}
        //public static void Table(IDataReader reader)
        //{
        //    return Table(reader, true);
        //}
        //public static void Table(IDataReader reader, bool closeReader)
        //{
        //    IDataReader record;
        //    T table = new T();

        //    table.Load(record);
        //}
    }
}
