using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace JAMM.Data
{
    public class DataContext
    {
        public DataContext(string connectionString);
        /// <summary>
        /// The connection string to a database
        /// </summary>
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            //set { connectionString = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int defaultTimeout;

        public int DefaultTimeout
        {
            get { return defaultTimeout; }
            set { defaultTimeout = value; }
        }

        /// <summary>
        /// Create a SQL Parameter
        /// </summary>
        /// <param name="ParamName"></param>
        /// <param name="DbType"></param>
        /// <param name="ParameterDirection"></param>
        /// <returns></returns>
        public static SqlParameter CreateParameter(string ParameterName, DbType DbType, ParameterDirection ParameterDirection)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = ParameterName;
            param.DbType = DbType;
            param.Direction = ParameterDirection;
            
            return param;
        }
        public static SqlParameter CreateParameter(string ParameterName, object Value, DbType DbType, int Size)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = ParameterName;
            if (Value == null)
                Value = System.DBNull.Value;
            param.Value = Value;
            param.DbType = DbType;
            param.Size = Size;

            return param;
        }
        public static SqlParameter CreateParameter(string ParameterName, object Value, DbType DbType)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = ParameterName;
            if (Value == null)
                Value = System.DBNull.Value;
            param.Value = Value;
            param.DbType = DbType;

            return param;
        }
        
        protected DataTable ExecuteDataTable(string storeProcedure, IEnumerable<SqlParameter> parameters = null, CommandType commandType = CommandType.StoredProcedure, bool prepare = false, int? timeout = null)
        {
            DataTable DT = new DataTable();
            SqlDataReader Reader = ExecuteReader(storeProcedure, parameters, commandType, prepare, timeout);
            DT.Load(Reader);
            return DT;
        }
        protected T ExecuteEntity<T>(string storeProcedure, IEnumerable<SqlParameter> parameters = null, CommandType commandType = CommandType.StoredProcedure, int? timeout = null) where T : IEntity, new()
        {
            SqlDataReader Reader = ExecuteReader(storeProcedure, parameters, commandType, false, timeout);
            try
            {
                bool bandera = Reader.Read();
                //((IEntity)this).Load(new IDataRecord);
            }
            finally
            {
                
            }
            
            return T;
        }
        protected List<T> ExecuteList<T>(string storeProcedure, IEnumerable<SqlParameter> parameters = null, CommandType commandType = CommandType.StoredProcedure, bool prepare = false, int? timeout = null);
        protected void ExecuteNonQuery(string storeProcedure, IEnumerable<SqlParameter> parameters = null, CommandType commandType = CommandType.StoredProcedure, bool prepare = false, int? timeout = null);
        protected SqlDataReader ExecuteReader(string StoreProcedure, IEnumerable<SqlParameter> Parameters = null, CommandType CommandType = CommandType.StoredProcedure, bool Prepare = false, int? Timeout = null)
        {
            SqlDataReader DataReader = new SqlDataReader();
            SqlConnection connection = new SqlConnection(ConnectionString);
            try 
            {
                SqlCommand command = new SqlCommand();
                try
                {

                }
            }

            return DataReader;
        }
        protected T ExecuteScalar<T>(string storeProcedure, IEnumerable<SqlParameter> parameters = null, CommandType commandType = CommandType.StoredProcedure, bool prepare = false, int? timeout = null);
        protected object ExecuteScalar(string storeProcedure, IEnumerable<SqlParameter> parameters = null, CommandType commandType = CommandType.StoredProcedure, bool prepare = false, int? timeout = null);
        protected T ExecuteScalar<T>(string storeProcedure, T defaultValue, IEnumerable<SqlParameter> parameters = null, CommandType commandType = CommandType.StoredProcedure, bool prepare = false, int? timeout = null);
        protected Table<T> ExecuteTable<T>(string storeProcedure, IEnumerable<SqlParameter> parameters = null, CommandType commandType = CommandType.StoredProcedure, bool prepare = false, int? timeout = null) where T : IEntity, new();
    }
}