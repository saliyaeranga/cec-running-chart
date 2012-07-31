using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CECRunningChart.Data
{
    public class BaseDataProvider : IBaseDataProvider
    {
        //public ILogger Logger { get; set; }

        //public BaseDataProvider()
        //{
        //    if (Logger == null)
        //        Logger = LogManager.Logger;
        //}

        public IDataReader ExecuteReader(string procedureName, Parameters parameters)
        {
            IDataReader dataReader;
            DbProviderFactory factory = DbProviderFactories.GetFactory(DataSource.ProviderName);
            DbConnection conn = factory.CreateConnection();
            try
            {
                using (DbCommand command = factory.CreateCommand())
                {
                    conn.ConnectionString = DataSource.ConnectionString;
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedureName;
                    InsertCommandParameters(command, parameters);
                    conn.Open();
                    dataReader = command.ExecuteReader();
                }

                return dataReader;
            }
            catch (SqlException exception)
            {
                throw new DataException(string.Format("Error executing procedure: {0}", procedureName), exception);
            }
            catch (Exception exception)
            {
                throw new DataException(string.Format("Error executing procedure: {0}", procedureName), exception);
            }
        }

        public DataSet ExecuteDataSet(string procedureName, Parameters parameters)
        {
            DataSet dataSet = new DataSet();

            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(DataSource.ProviderName);
                using (DbConnection conn = factory.CreateConnection())
                using (DbCommand command = factory.CreateCommand())
                {
                    conn.ConnectionString = DataSource.ConnectionString;
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedureName;
                    InsertCommandParameters(command, parameters);
                    //conn.Open();
                    using (DbDataAdapter dap = factory.CreateDataAdapter())
                    {
                        dap.SelectCommand = command;
                        dap.Fill(dataSet);
                    }
                }

                return dataSet;
            }
            catch (SqlException exception)
            {
                throw new DataException(string.Format("Error executing procedure: {0}", procedureName), exception);
            }
            catch (Exception exception)
            {
                throw new DataException(string.Format("Error executing procedure: {0}", procedureName), exception);
            }
        }

        public void ExecuteNoneQuery(string procedureName, Parameters parameters)
        {
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(DataSource.ProviderName);
                using (DbConnection conn = factory.CreateConnection())
                using (DbCommand command = factory.CreateCommand())
                {
                    conn.ConnectionString = DataSource.ConnectionString;
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedureName;
                    InsertCommandParameters(command, parameters);
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException exception)
            {
                throw new DataException(string.Format("Error executing procedure: {0}", procedureName), exception);
            }
            catch (Exception exception)
            {
                throw new DataException(string.Format("Error executing procedure: {0}", procedureName), exception);
            }
        }

        public Dictionary<string, object> ExecuteNoneQueryWithOutputParams(string procedureName, Parameters parameters)
        {
            Dictionary<String, Object> outputParameters = new Dictionary<String, Object>();

            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory(DataSource.ProviderName);
                using (DbConnection conn = factory.CreateConnection())
                using (DbCommand command = factory.CreateCommand())
                {
                    conn.ConnectionString = DataSource.ConnectionString;
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedureName;
                    InsertCommandParameters(command, parameters);
                    conn.Open();
                    command.ExecuteNonQuery();

                    foreach (IDataParameter parameter in command.Parameters)
                    {
                        if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                        {
                            outputParameters.Add(parameter.ParameterName, parameter.Value);
                        }
                    }
                }

                return outputParameters;
            }
            catch (SqlException exception)
            {
                throw new DataException(string.Format("Error executing procedure: {0}", procedureName), exception);
            }
            catch (Exception exception)
            {
                throw new DataException(string.Format("Error executing procedure: {0}", procedureName), exception);
            }
        }

        public int ExecuteScalar(string procedureName, Parameters parameters)
        {
            try
            {
                int returnValue;
                DbProviderFactory factory = DbProviderFactories.GetFactory(DataSource.ProviderName);
                using (DbConnection conn = factory.CreateConnection())
                using (DbCommand command = factory.CreateCommand())
                {
                    conn.ConnectionString = DataSource.ConnectionString;
                    command.Connection = conn;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedureName;
                    InsertCommandParameters(command, parameters);
                    conn.Open();
                    returnValue = Convert.ToInt32(command.ExecuteScalar());
                }

                return returnValue;
            }
            catch (SqlException exception)
            {
                throw new DataException(string.Format("Error executing procedure: {0}", procedureName), exception);
            }
            catch (Exception exception)
            {
                throw new DataException(string.Format("Error executing procedure: {0}", procedureName), exception);
            }
        }

        private void InsertCommandParameters(DbCommand dbCommand, List<Parameter> parameters)
        {
            if (parameters == null || parameters.Count <= 0)
                return;

            parameters.ForEach(
                delegate(Parameter parameter)
                {
                    DbParameter param = dbCommand.CreateParameter();
                    param.ParameterName = parameter.Key;
                    param.Value = parameter.Value;
                    param.Direction = parameter.Direction;
                    dbCommand.Parameters.Add(param);
                });
        }
    }
}
