using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGNITE.Core.Data
{
    public partial class DataSettingsManager
    {
        public class DataSettings
        {
            public string DataConnectionString { get; set; }
        }

        /// <summary>
        ///  Load settings
        /// </summary>
        /// <returns></returns>
        public virtual DataSettings LoadSettings()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HickConnectionString"].ToString();
            if (!string.IsNullOrEmpty(connectionString))
            {
                var DataSettings = new DataSettings();
                DataSettings.DataConnectionString = connectionString;
                return DataSettings;
            }
            else
                return new DataSettings();
        }
    }
}
