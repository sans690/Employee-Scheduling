using System;
using System.Collections;
using System.Linq;

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
        Console.WriteLine("3. Remove Employee");
        Console.WriteLine("4. Assign Shift");
        Console.WriteLine("5. View Schedule");
        Console.WriteLine("6. Exit\n");

        string? result = Console.ReadLine();

        switch (result)
        {
            case "1":
                try
                {
                    AddEmployee();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                Menu();
                break;

            case "2":
                try
                {
                    ViewEmployees();
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                Menu();
                break;

            case "3":
                try
                {
                    RemoveEmployee();
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
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

        if (employee.Name.Any(char.IsDigit))
        {
            throw new Exception("\nInvalid input entered");
        }

        employee.Id = random.Next(1000, 2000);
        Console.WriteLine($"Name: {employee.Name}, ID: {employee.Id} was entered");
        EmployeeList.Add(employee);
    }

    public static void ViewEmployees()
    {
        if (EmployeeList.Count() == 0)
        {
            throw new Exception("\n No employees for you to view");
        }

        foreach (var employee in EmployeeList)
        {
            Console.WriteLine($"Name: {employee.Name}, ID: {employee.Id}");
        }
    }

    public static void RemoveEmployee()
    {
        if (EmployeeList.Count() == 0)
        {
            throw new Exception("\nNo employees for you to remove");
        }

        Console.WriteLine("Enter ID of employee that you want to remove: ");
        string? result = Console.ReadLine();
        int.TryParse(result, out int intResult);
        for (int e = EmployeeList.Count - 1; e >= 0; e--)
        {
            {
                if (EmployeeList[e].Id == intResult)
                {
                    Console.WriteLine($"\n{EmployeeList[e].Name} was removed");
                    EmployeeList.Remove(EmployeeList[e]);
                }
            }
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