using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace CadeteriaRemake.Models
{
    public class DBContextCadeteria : DbContext
    {
        /*public string ConnectionString { get; set; }

        public DBContextCadeteria(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionsBuilder.UseMySQL(configuration["ConnectionStrings:DefaultConnection"]);
        }
    }
}
