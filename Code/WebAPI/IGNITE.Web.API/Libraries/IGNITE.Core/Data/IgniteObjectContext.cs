using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;

namespace IGNITE.Core.Data
{
    public class IgniteObjectContext : DbContext, IDbContext
    {
        #region Ctor
        public IgniteObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
        #endregion

        #region Methods

        /// <summary>
        /// executes a stored procedure and returns specified result
        /// </summary>
        /// <typeparam name="T">type of result</typeparam>
        /// <param name="commandText">sp name</param>
        /// <param name="parameters">any parameters if required</param>
        /// <returns>object result of type T</returns>
        public List<T> ExecuteFunction<T>(string commandText, params object[] parameters)
        {
            bool hasOutputParameters = false;
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    var outputP = p as DbParameter;
                    if (outputP == null)
                        continue;

                    if (outputP.Direction == ParameterDirection.InputOutput ||
                        outputP.Direction == ParameterDirection.Output)
                        hasOutputParameters = true;
                }
            }



            var context = ((IObjectContextAdapter)(this)).ObjectContext;

            //var connection = context.Connection;
            var connection = this.Database.Connection;
            //Don't close the connection after command execution


            //open the connection for use
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            //create a command object
            using (var cmd = connection.CreateCommand())
            {
                //command to execute
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.StoredProcedure;

                // move parameters to command object
                if (parameters != null)
                    foreach (var p in parameters)
                        cmd.Parameters.Add(p);

                //database call
                var reader = cmd.ExecuteReader();
                //return reader.DataReaderToObjectList<TEntity>();
                var result = context.Translate<T>(reader).ToList();

                //close up the reader, we're done saving results
                reader.Close();
                return result;
            }
        }

        #endregion
    }
}
