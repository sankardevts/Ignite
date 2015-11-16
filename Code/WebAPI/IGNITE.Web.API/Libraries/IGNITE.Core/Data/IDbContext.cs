using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGNITE.Core.Data
{
    public interface IDbContext
    {
        /// <summary>
        /// executes a stored procedure and returns specified result
        /// </summary>
        /// <typeparam name="T">type of result</typeparam>
        /// <param name="commandText">sp name</param>
        /// <param name="parameters">any parameters if required</param>
        /// <returns>object result of type T</returns>
        List<T> ExecuteFunction<T>(string commandText, params object[] parameters);
    }
}
