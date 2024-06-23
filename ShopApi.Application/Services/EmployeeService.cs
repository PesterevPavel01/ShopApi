using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Dto;
using ShopApi.Domain.Entity;
using ShopApi.Domain.Interfaces.Interactors;
using ShopApi.Domain.Interfaces.Services;

namespace ShopApi.Application.Services
{
    public class EmployeeService : ICommonService<EmployeeDto,int>
    {
        private readonly ICommonInteractor<Employee> _employeeInteractor;

        public EmployeeService(ICommonInteractor<Employee> employeeInteractor)
        {
            _employeeInteractor = employeeInteractor;
        }

        public async Task<bool> CreateMultiple(List<EmployeeDto> listModels)
        {
            if (listModels == null) return false;

            List<Employee> newEmployees = new List<Employee>();
            try
            {
                foreach (var currentEmployee in listModels)
                {
                    var employee = await _employeeInteractor.GetAll().FirstOrDefaultAsync(x => x.NameEmployee == currentEmployee.NameEmployee);

                    if (employee!=null) continue;

                    newEmployees.Add(new Employee() 
                    {
                        NameEmployee= currentEmployee.NameEmployee,
                        Password= currentEmployee.Password,
                        Login= currentEmployee.Login,
                        Address = currentEmployee.Address,
                        Status = currentEmployee.Status
                    });

                }

                return await _employeeInteractor.CreateMultipleAsync(newEmployees); 

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<EmployeeDto> CreateAsync(EmployeeDto model)
        {
            if (model == null) return new EmployeeDto();

            try
            {
                var employee = await _employeeInteractor.GetAll().FirstOrDefaultAsync(x => x.NameEmployee == model.NameEmployee);

                if (employee != null)
                    return null;

                employee = new Employee()
                {
                    NameEmployee = model.NameEmployee,
                    Password = model.Password,
                    Login = model.Login,
                    Address = model.Address,
                    Status = model.Status
                };

                var result=await _employeeInteractor.CreateAsync(employee);

                return new() 
                {
                    NameEmployee=result.NameEmployee,
                    Status=result.Status,
                    Address=result.Address,
                    Login=result.Login,
                    Id = result.Id,
                    Password= result.Password
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<EmployeeDto> UpdateAsync(EmployeeDto model)
        {
            if (model == null) return null;
            try
            {
                var employee = await _employeeInteractor.GetAll().FirstOrDefaultAsync(x => x.NameEmployee == model.NameEmployee);
                
                if (employee == null)
                    return null;

                employee.NameEmployee= model.NameEmployee;
                employee.Address = model.Address;
                employee.Status = model.Status;
                employee.Login=model.Login;
                employee.Password = model.Password;

                await _employeeInteractor.UpdateAsync(employee);

                return new()
                {
                    NameEmployee = employee.NameEmployee,
                    Status = employee.Status,
                    Address = employee.Address,
                    Login = employee.Login,
                    Id = employee.Id,
                    Password = employee.Password
                };

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<EmployeeDto> DeleteAsync(int id)
        {
            try
            {
                var employee = await _employeeInteractor.GetAll().FirstOrDefaultAsync(x => x.Id == id);

                if (employee == null)
                    return null;

                var result = await _employeeInteractor.RemoveAsync(employee);

                return new()
                {
                    NameEmployee = result.NameEmployee,
                    Status = result.Status,
                    Address = result.Address,
                    Login = result.Login,
                    Id = result.Id,
                    Password = result.Password
                };

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            EmployeeDto[] employees;
            try
            {
                employees = await _employeeInteractor.GetAll()
                    .Select(x => new EmployeeDto(x.Id, x.NameEmployee, x.Address, x.Login, x.Password, x.Status)).ToArrayAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return employees.ToList();
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            Employee employee;
            try
            {
                employee = await _employeeInteractor.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (employee == null)
                    return null;
            }
            catch (Exception ex)
            {
                employee = null;
            }

            return new()
            {
                NameEmployee = employee.NameEmployee,
                Status = employee.Status,
                Address = employee.Address,
                Login = employee.Login,
                Id = employee.Id,
                Password = employee.Password
            };

        }
    }
}
