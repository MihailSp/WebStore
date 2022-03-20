using WebStore.Services.Interfaces;
using WebStore.Models;
using WebStore.Data;

namespace WebStore.Services
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private int _LastFreeId;
        private readonly ILogger<InMemoryEmployeesData> _Logger;
        private readonly ICollection<Employee> _Employees;
        public InMemoryEmployeesData(ILogger<InMemoryEmployeesData> Logger)
        {
            _Logger = Logger;
            _Employees = TestData.Employees;
            _LastFreeId = _Employees.Count == 0 ? 1 : _Employees.Max(e => e.Id) + 1;
        }

        public int Add(Employee employee)
        {
            if(employee is null) 
                throw new ArgumentNullException(nameof(employee));

            //не для БД
            if (_Employees.Contains(employee))
                return employee.Id;
            //

            employee.Id = _LastFreeId++;
            _Employees.Add(employee);

            return employee.Id;
        }

        public bool Delete(int id)
        {
            var db_employee = GetById(id);
            if (db_employee is null)
            {
                _Logger.LogWarning("Попытка удаления отсутствующего сотрудника с id:{0}", id);
                return false;
            }

            _Employees.Remove(db_employee);
            _Logger.LogInformation("Сотрудник с id:{0} удален", id);

            return true;
        }

        public bool Edit(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            //не для БД
            if (_Employees.Contains(employee))
                return true;
            //
            var db_employee = GetById(employee.Id);
            if (db_employee is null)
            {
                _Logger.LogWarning("Попытка редактирования отсутствующего сотрудника с id:{0}", employee.Id);
                return false;
            }

            db_employee.Id = employee.Id;
            db_employee.LastName = employee.LastName;
            db_employee.FirstName = employee.FirstName;
            db_employee.Age = employee.Age;
            _Logger.LogInformation("Сотрудник (id:{0}) {1} добавлен", employee.Id, employee);

            return true;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _Employees;
        }

        public Employee? GetById(int id)
        {
            var employee = _Employees.FirstOrDefault(employee => employee.Id == id);
            return employee;
        }
    }
}
