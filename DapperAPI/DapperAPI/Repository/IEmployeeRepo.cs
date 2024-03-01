using DapperAPI.Model;

namespace DapperAPI.Repository
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetDetails();
        Task<List<Employee>> GetDetailsbyCode(string empcode);
        
        Task<Employee> GetById(int id);
        Task<string> Create(Employee employee);
        Task<string> Update(Employee employee,int id);
        Task<string> Delete(int id);



    }
}
