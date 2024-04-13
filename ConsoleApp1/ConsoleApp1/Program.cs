using System;
using System.Collections.Generic;

public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Salary { get; set; }

    public Employee(string name, int age, double salary)
    {
        Name = name;
        Age = age;
        Salary = salary;
    }
}

public class EmployeeManagementSystem
{
    private List<Employee> employees;

    public EmployeeManagementSystem()
    {
        employees = new List<Employee>();
    }

    public void AddEmployee(string name, int age, double salary)
    {
        employees.Add(new Employee(name, age, salary));
        Console.WriteLine($"Сотрудник {name} успешно добавлен.");
    }

    public void RemoveEmployee(string name)
    {
        Employee employeeToRemove = employees.Find(emp => emp.Name == name);
        if (employeeToRemove != null)
        {
            employees.Remove(employeeToRemove);
            Console.WriteLine($"Сотрудник {name} успешно удален.");
        }
        else
        {
            Console.WriteLine($"Сотрудник {name} не найден.");
        }
    }

    public void ViewEmployeeCount()
    {
        Console.WriteLine($"Всего сотрудников: {employees.Count}");
    }

    public void UpdateSalary(string name, double newSalary)
    {
        Employee employeeToUpdate = employees.Find(emp => emp.Name == name);
        if (employeeToUpdate != null)
        {
            employeeToUpdate.Salary = newSalary;
            Console.WriteLine($"Зарплата сотрудника {name} успешно изменена на {newSalary}.");
        }
        else
        {
            Console.WriteLine($"Сотрудник {name} не найден.");
        }
    }

    public void UpdateAge(string name, int newAge)
    {
        Employee employeeToUpdate = employees.Find(emp => emp.Name == name);
        if (employeeToUpdate != null)
        {
            employeeToUpdate.Age = newAge;
            Console.WriteLine($"Возраст сотрудника {name} успешно изменен на {newAge}.");
        }
        else
        {
            Console.WriteLine($"Сотрудник {name} не найден.");
        }
    }

    public void ViewAllEmployees()
    {
        Console.WriteLine("Список всех сотрудников:");
        foreach (var employee in employees)
        {
            Console.WriteLine($"Имя: {employee.Name}, Возраст: {employee.Age}, Зарплата: {employee.Salary}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        EmployeeManagementSystem ems = new EmployeeManagementSystem();

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Добавить сотрудника");
            Console.WriteLine("2. Удалить сотрудника");
            Console.WriteLine("3. Посмотреть количество сотрудников");
            Console.WriteLine("4. Изменить зарплату сотрудника");
            Console.WriteLine("5. Изменить возраст сотрудника");
            Console.WriteLine("6. Вывести всех сотрудников");
            Console.WriteLine("7. Выйти из программы");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите имя сотрудника: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите возраст сотрудника: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Введите зарплату сотрудника: ");
                    double salary = double.Parse(Console.ReadLine());
                    ems.AddEmployee(name, age, salary);
                    break;
                case "2":
                    Console.Write("Введите имя сотрудника для удаления: ");
                    string nameToRemove = Console.ReadLine();
                    ems.RemoveEmployee(nameToRemove);
                    break;
                case "3":
                    ems.ViewEmployeeCount();
                    break;
                case "4":
                    Console.Write("Введите имя сотрудника, зарплату которого нужно изменить: ");
                    string nameToUpdateSalary = Console.ReadLine();
                    Console.Write("Введите новую зарплату: ");
                    double newSalary = double.Parse(Console.ReadLine());
                    ems.UpdateSalary(nameToUpdateSalary, newSalary);
                    break;
                case "5":
                    Console.Write("Введите имя сотрудника, возраст которого нужно изменить: ");
                    string nameToUpdateAge = Console.ReadLine();
                    Console.Write("Введите новый возраст: ");
                    int newAge = int.Parse(Console.ReadLine());
                    ems.UpdateAge(nameToUpdateAge, newAge);
                    break;
                case "6":
                    ems.ViewAllEmployees();
                    break;
                case "7":
                    Console.WriteLine("Выход из программы...");
                    return;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    break;
            }
        }
    }
}
