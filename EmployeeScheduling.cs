using System;
using System.Collections;

class EmployeeScheduling
{
    static List<Employee> EmployeeList = new List<Employee>();
    static Random random = new Random();
    public static void Run(string[] args)
    {
        Menu();
    }

    public static void Menu()
    {
        Console.WriteLine("\n1. Add Employee");
        Console.WriteLine("2. View Employees");
        Console.WriteLine("3. Assign Shift");
        Console.WriteLine("4. View Schedule");
        Console.WriteLine("5. Remove Employee");
        Console.WriteLine("6. Exit\n");

        string? result = Console.ReadLine();

        switch (result)
        {
            case "1":
                AddEmployee();
                Menu();
                break;

            case "2":
                ViewEmployees();
                Menu();
                break;

            default:
                Console.WriteLine("Invalid input, try again!");
                Menu();
                break;
                // add other options
        }
    }

    public static void AddEmployee()
    {
        Employee employee = new Employee();
        Console.WriteLine("Enter a name");
        employee.Name = Console.ReadLine();
        employee.Id = random.Next(1000, 2000);
        Console.WriteLine($"Name: {employee.Name}, ID: {employee.Id} was entered");
        EmployeeList.Add(employee);
    }

    public static void ViewEmployees()
    {
        foreach (var e in EmployeeList)
        {
            Console.WriteLine($"Name: {e.Name}, ID: {e.Id}");
        }
    }


    class Employee
    {
        public string? Name { get; set; }
        public int? Id { get; set; }
    }

    class Shift
    {
        public string? Day { get; set; }
        public string? Time { get; set; }
        public string? EmployeeName { get; set; }
    }
}