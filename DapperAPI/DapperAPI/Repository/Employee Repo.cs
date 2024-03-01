using Dapper;
using DapperAPI.DbContextFolder;
using DapperAPI.Model;
using System.Data;

namespace DapperAPI.Repository
{
    public class Employee_Repo : IEmployeeRepo
    {
        private DbContextClass _context;
        public Employee_Repo(DbContextClass context)
        {
            _context = context;
        }


        public async Task<List<Employee>> GetDetails()
        {
            string query = "Select * from EmployeeTableDaper";
            using (var connectin = _context.CreateConnection())
            {
                var emplist = await connectin.QueryAsync<Employee>(query);
                return emplist.ToList();
            }
        }
        public async Task<string> Create(Employee employee)
        {
            string response = string.Empty;
            string query = "insert into EmployeeTableDaper(name,email,phone,address,employeecode) values (@name,@email,@phone,@address,@employeecode)";
            var parameter = new DynamicParameters();
            parameter.Add("name", employee.Name, DbType.String);
            parameter.Add("email", employee.Email, DbType.String);
            parameter.Add("phone", employee.Phone, DbType.String);
            parameter.Add("address", employee.Address, DbType.String);
            parameter.Add("employeecode", employee.EmployeeCode, DbType.String);

            using (var connectin = _context.CreateConnection())
            {
                var emplist = await connectin.ExecuteAsync(query, parameter);
                response = "Task Done";

            }
            return response;
        }

        public async Task<string> Delete(int id)
        {
            string response = string.Empty;
            string query = "delete from EmployeeTableDaper where id = @id";
            using (var connectin = _context.CreateConnection())
            {
                var emplist = await connectin.ExecuteAsync(query, new { id });
                response = "Task Done";

            }
            return response;
        }

        public async Task<Employee> GetById(int id)
        {
            string query = "Select * from EmployeeTableDaper where id = @id";
            using (var connectin = _context.CreateConnection())
            {
                var emplist = await connectin.QueryFirstOrDefaultAsync<Employee>(query, new { id });
                return emplist;
            }
        }



        public async Task<string> Update(Employee employee, int id)
        {
            string response = string.Empty;
            string query = "update  EmployeeTableDaper set name=@name,email=@email,phone=@phone,address=@address where id=@id";
            var parameter = new DynamicParameters();
            parameter.Add("id", id,DbType.Int32);
            parameter.Add("name", employee.Name, DbType.String);
            parameter.Add("email", employee.Email, DbType.String);
            parameter.Add("phone", employee.Phone, DbType.String);
            parameter.Add("address", employee.Address, DbType.String);

            using (var connectin = _context.CreateConnection())
            {
                var emplist = await connectin.ExecuteAsync(query, parameter);
                response = "Task Done";

            }
            return response;
        }

        public async Task<List<Employee>> GetDetailsbyCode(string empcode)
        {
            string query = "EXEC GetEmployeeByCode @empcode";
            using (var connectin = _context.CreateConnection())
            {
                var emplist = await connectin.QueryAsync<Employee>(query, new { empcode });
                return emplist.ToList();
            }
        }
    }
}

