using DapperAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Data;

namespace DapperAPI.DbContextFolder
{
    public class DbContextClass 
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionstring;

        public DbContextClass(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionstring = _configuration.GetConnectionString("Connection");
        }

        public IDbConnection CreateConnection()=>new SqlConnection(connectionstring);
        public DbSet<Employee> EmployeeTableDaper { get; set; }
       // public DbSet<SignIn> SignInTable { get; set; }
    }
}
