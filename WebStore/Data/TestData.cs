using WebStore.Models;

namespace WebStore.Data
{
    public static class TestData
    {
        public static List<Employee> Employees = new()
        {
            new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", BirthDay = new DateTime(1990, 01, 07) },
            new Employee { Id = 2, LastName = "Петров", FirstName = "Пётр", Patronymic = "Петрович", BirthDay = new DateTime(1995, 02, 18) },
            new Employee { Id = 3, LastName = "Иванов", FirstName = "Иван", Patronymic = "Иванович", BirthDay = new DateTime(2000, 03, 27) }
        };
    }
}
