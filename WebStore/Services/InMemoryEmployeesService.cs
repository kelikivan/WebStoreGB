using WebStore.Data;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Services
{
    public class InMemoryEmployeesService : IEmployeesService
    {
        private readonly ICollection<Employee> _employees;
        private int _maxFreeId;

        public InMemoryEmployeesService()
        {
            _employees = TestData.Employees;
            _maxFreeId = _employees.DefaultIfEmpty().Max(empl => empl?.Id ?? 0) + 1;
        }

        public IEnumerable<Employee> GetAll() => _employees;

        public Employee? GetById(int id) => _employees.FirstOrDefault(empl => empl.Id == id);

        public int Add(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            if (_employees.Contains(employee))
            {
                return employee.Id;
            }

            employee.Id = _maxFreeId++;
            _employees.Add(employee);

            return employee.Id;
        }

        public bool Edit(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            if (_employees.Contains(employee))
            {
                return true;
            }

            var db_employee = GetById(employee.Id);
            if (db_employee is null)
            {
                return false;
            }

            db_employee.LastName = employee.LastName;
            db_employee.FirstName = employee.FirstName;
            db_employee.Patronymic = employee.Patronymic;
            db_employee.BirthDay = employee.BirthDay;

            return true;
        }

        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee is null)
            {
                return false;
            }

            _employees.Remove(employee);

            return true;
        }
    }
}
