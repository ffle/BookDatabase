//-----------------------------------------------------------------------
// <copyright file="SqlExecutor.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Data.SqlClient;

namespace BookDatabase.Api.Tests.DataHelpers
{
    /// <summary>
    /// Class for executing SQL against a SQL Server database
    /// </summary>
    public abstract class SqlExecutor
    {
        /// <summary>
        /// Stores the connection string
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the SqlExecutor class
        /// </summary>
        /// <param name="connectionString">The connection string to use</param>
        protected SqlExecutor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Executes a non-query
        /// </summary>
        /// <param name="sql">The SQL to execute</param>
        /// <param name="commandType">The command type</param>
        /// <param name="parameters">Required parameters</param>
        /// <returns>The number of affected rows</returns>
        protected int ExecuteNonQuery(string sql, CommandType commandType, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = commandType;
                    command.CommandText = sql;
                    command.Parameters.AddRange(parameters);

                    command.Connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Executes a scalar
        /// </summary>
        /// <typeparam name="T">The type expected to be returned</typeparam>
        /// <param name="sql">The SQL to execute</param>
        /// <param name="commandType">The command type</param>
        /// <param name="parameters">Required parameters</param>
        /// <returns>The scalar returned</returns>
        protected T ExecuteScalar<T>(string sql, CommandType commandType, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = commandType;
                    command.CommandText = sql;
                    command.Parameters.AddRange(parameters);

                    command.Connection.Open();
                    return (T)command.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Gets a parameter
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        /// <param name="value">The value of the parameter</param>
        /// <param name="direction">The parameter direction</param>
        /// <returns>A configured parameter</returns>
        protected SqlParameter GetParameter(string name, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            var parameter = new SqlParameter();

            parameter.ParameterName = name;
            parameter.Direction = direction;
            parameter.Value = value;

            return parameter;
        }
    }
}
