using WebStore.Data;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Services
{
    public class InMemoryEmployeesService : IEmployeesService
    {
        private readonly ILogger<InMemoryEmployeesService> _logger;
        private readonly ICollection<Employee> _employees;
        private int _maxFreeId;

        public InMemoryEmployeesService(ILogger<InMemoryEmployeesService> logger)
        {
            _logger = logger;
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
                _logger.LogWarning("Попытка редактирования отсутствующего сотрудника с Id:{0}.", employee.Id);
                return false;
            }

            db_employee.LastName = employee.LastName;
            db_employee.FirstName = employee.FirstName;
            db_employee.Patronymic = employee.Patronymic;
            db_employee.BirthDay = employee.BirthDay;

            _logger.LogInformation("Информация о сотруднике id:{0} была изменена.", employee.Id);

            return true;
        }

        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee is null)
            {
                _logger.LogWarning("Попытка удаления отсутствующего сотрудника с Id:{0}.", id);
                return false;
            }

            _employees.Remove(employee);

            _logger.LogInformation("Сотрудник с id:{0} был успешно удалён.", id);
            return true;
        }
    }
}
