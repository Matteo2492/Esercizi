using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DB_05_Biblioteca.Utilities
{
    internal class Config
    {
        private static Config? istanza;
        private string? connectionString;

        public static Config GetIstanza()
        {
            if (istanza == null)
            {
                istanza = new Config();
            }
            return istanza;
        }
        private Config()
        {

        }
        public string? GetConnectionString()
        {
            if (connectionString == null)
            {
                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appSettings.json", false, true);

                IConfiguration configuration = builder.Build();

#if DEBUG
                connectionString = configuration.GetConnectionString("ServerLocale");
#else
            connectionString = configuration.GetConnectionString("ServerRemota");
#endif
            }

            return connectionString;
        }
    }
}
