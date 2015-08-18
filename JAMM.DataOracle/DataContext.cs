using System;
using System.Data;
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Reflection;


namespace JAMM.DataOracle
{
	// <summary>
	/// Clase que obtiene la información consultada en procedimientos almacenados oracle
	/// </summary>
	public class DataContext
	{
		/// <summary>
		/// Oracle Params List
		/// </summary>
		private List<OracleParameter> Params;

		/// <summary>
		/// The connection string.
		/// </summary>
		private string ConnectionString;

		/// <summary>
		/// Initialize the Oracle Params List
		/// </summary>
		public DataContext(string connectionString)
		{
			this.ConnectionString = connectionString;
			this.Params = new List<OracleParameter>();
		}

		/// <summary>
		/// Get an OUTPUT value from an stored procedure
		/// </summary>
		/// <param name="Param">Parameter name</param>
		/// <returns>Parameter Value</returns>
		public static string GetParamValue(string Param)
		{
			string result = string.Empty;

			foreach (OracleParameter parameter in this.Params)
			{
				if (parameter.ParameterName.Equals(Param))
				{
					result = parameter.Value.ToString();
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Adds the parameter.
		/// </summary>
		/// <param name="Param">Parameter.</param>
		/// <param name="Type">Type.</param>
		/// <param name="Value">Value.</param>
		/// <param name="Direction">Direction.</param>
		public static void AddParam(string Param, OracleType Type, object Value, ParameterDirection Direction)
		{
			OracleParameter param = new OracleParameter();
			param.ParameterName = Param;
			param.OracleType = Type;
			param.Value = Value;
			param.Direction = Direction;
			this.Params.Add(Param);
		}

		/// <summary>
		/// Adds the parameter.
		/// </summary>
		/// <param name="Param">Parameter.</param>
		/// <param name="Type">Type.</param>
		/// <param name="Direction">Direction.</param>
		public static void AddParam(string Param, OracleType Type, ParameterDirection Direction)
		{
			OracleParameter param = new OracleParameter();
			param.ParameterName = Param;
			param.OracleType = Type;
			param.Direction = Direction;
			this.Params.Add(param);
		}

		/// <summary>
		/// Adds the parameter.
		/// </summary>
		/// <param name="Param">Parameter.</param>
		/// <param name="Type">Type.</param>
		/// <param name="Direction">Direction.</param>
		/// <param name="Size">Size.</param>
		public static void AddParam(string Param, OracleType Type, ParameterDirection Direction, int Size)
		{
			OracleParameter param = new OracleParameter();
			param.ParameterName = Param;
			param.OracleType = Type;
			param.Direction = Direction;
			param.Size = Size;
			this.Params.Add(param);
		}

		public DataTable ExecuteDataTable(string Qry)
		{
			DataTable DT = new DataTable();
			DT.Load(ExecuteReader(Qry, CommandType.StoredProcedure));
			return DT;
		}

		/// <summary>
		/// Executes the reader without transaction.
		/// </summary>
		/// <returns>The reader.</returns>
		/// <param name="Qry">Qry (Only SELECT).</param>
		/// <param name="Type">Command Type.</param>
		protected OracleDataReader ExecuteReader(string Qry, CommandType Type)
		{
			OracleConnection Connection = new OracleConnection (ConnectionString);
			OracleCommand Command = new OracleCommand ();
			OracleDataReader DataReader = null;

			try {
				Connection.Open ();

				Command.Connection = Connection;
				Command.CommandText = Qry;
				Command.CommandType = Type;

				if (this.Params.Count > 0) {
					foreach (OracleParameter param in this.Params) {
						Command.Parameters.Add (param);
					}
				}

				Command.Prepare ();
				DataReader = Command.ExecuteReader (CommandBehavior.CloseConnection);
				return DataReader;
			} catch (Exception ex) {
				Connection.Dispose ();
				Connection.Close ();
				return null;
				// TO DO: log
//				throw new ExceptionAccesoDatosOracle(ex.Message, ex.InnerException);
			}
		}

		/// <summary>
		/// Executes the command with transaction.
		/// </summary>
		/// <param name="Cmd">Command to execute</param>
		protected void ExecuteCommand(string Cmd)
		{
			OracleConnection Connection = new OracleConnection (ConnectionString);
			OracleCommand Command = new OracleCommand ();
			OracleDataReader DataReader = null;
			OracleTransaction trx = null;
			try {
				Command.Connection = Connection;
				Command.CommandText = Cmd;
				Command.CommandType = CommandType.Text;

				Connection.Open ();
				trx = Connection.BeginTransaction ();
				Command.Transaction = trx;
				Command.ExecuteNonQuery (CommandBehavior.CloseConnection);
				trx.Commit ();
			} catch (Exception ex) {
				trx.Rollback ();
				// TO DO: Log
//					throw new ExceptionAccesoDatosOracle(ex.Message, ex.InnerException);
			}
		}

		/// <summary>
		/// Executes the stored procedure with transaction.
		/// </summary>
		/// <param name="StoredProcedure">Stored procedure.</param>
		protected void ExecuteStoredProcedure(string StoredProcedure)
		{
			OracleConnection Connection = new OracleConnection (ConnectionString);
			OracleCommand Command = new OracleCommand ();
			OracleDataReader DataReader = null;
			OracleTransaction trx = null;
			try {
				Command.Connection = Connection;	
				Command.CommandText = StoredProcedure;
				Command.CommandType = CommandType.StoredProcedure;

				Connection.Open();
				if (this.Params.Count > 0) {
					foreach (OracleParameter param in this.Params) {
						Command.Parameters.Add (param);
					}
				}

				trx = Connection.BeginTransaction ();
				Command.Transaction = trx;
				Command.ExecuteNonQuery(CommandBehavior.CloseConnection);
				trx.Commit ();//check if connection is close
			} catch (Exception ex) {
				trx.Rollback ();
				// TO DO: Log
//				throw new ExceptionAccesoDatosOracle (ex.Message, ex.InnerException);
			}

		}

		/// <summary>
		/// Clears the parameters.
		/// </summary>
		public void ClearParams()
		{
			this.Params.Clear();
		}


		/// <summary>
		/// Executes the list.
		/// </summary>
		/// <returns>The list.</returns>
		/// <param name="StoredProcedure">Stored procedure.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public List<T> ExecuteList<T>(string StoredProcedure)
		{
			
			List<T> list = new List<T> ();
			T obj = default(T);
			try {
				OracleDataReader DataReader = ExecuteReader (StoredProcedure, CommandType.StoredProcedure);

				while (DataReader.Read ()) {
					obj = Activator.CreateInstance<T> ();
					foreach (PropertyInfo prop in obj.GetType().GetProperties()) {
						if (!object.Equals (DataReader [prop.Name], DBNull.Value)) {
							prop.SetValue (obj, DataReader [prop.Name], null);
						}
					}
					list.Add (obj);
				}
			} catch (Exception ex) {
				// TO DO: Log
//				throw new ExceptionAccesoDatosOracle (ex.Message, ex.InnerException);
			}

			return list;
		}

	}
}

