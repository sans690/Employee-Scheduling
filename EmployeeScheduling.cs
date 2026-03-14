using System;
using System.ComponentModel.Design;

class EmployeeScheduling
{
    public static void Run(string[] args)
    {
        Menu();
    }

    public static void Menu()
    {
        Console.WriteLine("1. Add Employee");
        Console.WriteLine("2. Assign Shift");
        Console.WriteLine("3. View Schedule");
        Console.WriteLine("4. Remove Employee");
        Console.WriteLine("5. Exit");
        string? result = Console.ReadLine();

        switch (result)
        {
            case "1":
                AddEmployee();
                break;
                // add other options
        }
    }

    public static void AddEmployee()
    {
        Console.WriteLine("\nEnter a name");
        Console.ReadLine();
        Random random = new Random();
        int id = random.Next(1000, 2000);

        // creates new instance of employee, and assigns those values
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