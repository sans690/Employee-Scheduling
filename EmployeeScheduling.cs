using System;

class EmployeeScheduling
{
    static List<Employee> EmployeeList = new List<Employee>();
    static List<Shift> ShiftList = new List<Shift>();
    static Random random = new Random();
    static List<string> ValidDays = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
    static List<string> ValidTimes = new List<string>() { "1:00", "1:30", "2:00", "2:30" };
    public static void Run(string[] args)
    {
        Menu();
    }

    public static void Menu()
    {
        Console.WriteLine("\n1. Add Employee");
        Console.WriteLine("2. Remove Employee");
        Console.WriteLine("3. View Employees");
        Console.WriteLine("4. Assign Shift");
        Console.WriteLine("5. Remove Shift");
        Console.WriteLine("6. View Schedule");
        Console.WriteLine("7. Exit\n");

        string? selectionOption = Console.ReadLine();

        switch (selectionOption)
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
                    RemoveEmployee();
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
                    ViewEmployees();
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                Menu();
                break;

            case "4":
                try
                {
                    AssignShifts();
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                Menu();
                break;

            case "5":
                try
                {
                    RemoveShifts();
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                Menu();
                break;

            case "6":
                try
                {
                    ViewSchedule();
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
        }
    }

    public static void AddEmployee()
    {
        Employee employee = new Employee();
        Console.WriteLine("Enter a name: ");
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
        bool idFound = false;

        if (EmployeeList.Count() == 0)
        {
            throw new Exception("\nNo employees for you to remove");
        }

        Console.WriteLine("Enter ID of employee that you want to remove: ");
        string? id = Console.ReadLine();

        if (!int.TryParse(id, out int intId))
        {
            throw new Exception("Invalid id was entered");
        }

        for (int e = EmployeeList.Count - 1; e >= 0; e--)
        {
            {
                if (EmployeeList[e].Id == intId)
                {
                    idFound = true;
                    Console.WriteLine($"\n{EmployeeList[e].Name} was removed");
                    EmployeeList.Remove(EmployeeList[e]);
                }
            }
        }

        if (!idFound)
        {
            throw new Exception("No employee with this id exist for you to remove");
        }
    }

    public static void AssignShifts()
    {
        if (EmployeeList.Count == 0)
        {
            throw new Exception("\nNo employees for you to assign shift");
        }

        Console.WriteLine("Enter ID of employee that you want to assign a shift: ");
        string? id = Console.ReadLine();
        Console.WriteLine("Enter the day that you want to assign to the employee: ");
        string? day = Console.ReadLine();
        Console.WriteLine("Enter the time that you want to assign to the employee: ");
        string? time = Console.ReadLine();
        if (!int.TryParse(id, out int intId))
        {
            throw new Exception("Invalid id was entered");
        }

        bool isValidDay = false;
        bool isValidTime = false;

        foreach (string d in ValidDays)
        {
            string? dayLower = d.ToLower();
            if (day?.ToLower() == dayLower)
            {
                isValidDay = true;
                break;
            }
        }

        foreach (string t in ValidTimes)
        {
            if (time?.Trim() == t)
            {
                isValidTime = true;
                break;
            }
        }

        if (!isValidDay)
        {
            throw new Exception("Invalid day was entered");
        }

        if (!isValidTime)
        {
            throw new Exception("Invalid time was entered");
        }

        foreach (Employee employee in EmployeeList)
        {
            if (employee.Id == intId)
            {
                if (isValidDay && isValidTime)
                {
                    Shift shift = new Shift();
                    shift.employeeId = intId;
                    shift.Day = day;
                    shift.Time = time;
                    ShiftList.Add(shift);

                    Console.WriteLine($"Employee with ID: {shift.employeeId} has been assigned {shift.Day} at {shift.Time}");
                }
            }
        }
    }
    public static void RemoveShifts()
    {
        if (EmployeeList.Count == 0)
        {
            throw new Exception("\nNo employees for you to remove shift for");
        }

        else if (ShiftList.Count == 0)
        {
            throw new Exception("\nNo shift for you to remove");
        }

        Console.WriteLine("Enter the id of the employee that you want to remove a shift for: ");
        string? id = Console.ReadLine();
        Console.WriteLine("Enter the day for the shift that you want to remove: ");
        string? day = Console.ReadLine();
        Console.WriteLine("Enter the time for the shift that you want to remove: ");
        string? time = Console.ReadLine();
        if (!int.TryParse(id, out int intId))
        {
            throw new Exception("Invalid id was entered");
        }

        bool employeeFound = false;
        bool shiftRemoved = false;

        for (int e = EmployeeList.Count - 1; e >= 0; e--)
        {
            if (EmployeeList[e].Id == intId)
            {
                employeeFound = true;

                for (int s = ShiftList.Count - 1; s >= 0; s--)
                {
                    if (ShiftList[s].employeeId == intId)
                    {
                        if (day == ShiftList[s].Day)
                        {
                            if (time == ShiftList[s].Time)
                            {
                                Console.WriteLine($"Employee with ID: {ShiftList[s].employeeId} has been removed for shift {ShiftList[s].Day} at {ShiftList[s].Time}");
                                ShiftList.Remove(ShiftList[s]);
                                shiftRemoved = true;
                            }
                        }
                    }
                }
            }
        }

        if (!employeeFound)
        {
            throw new Exception("No employee with this id exist for you to remove");
        }

        if (!shiftRemoved)
        {
            throw new Exception("No matching shift found for this employee, day, and time");
        }
    }

    public static void ViewSchedule()
    {
        if (EmployeeList.Count == 0)
        {
            Console.WriteLine("No employees to view schedule");
        }

        else if (ShiftList.Count == 0)
        {
            Console.WriteLine("No shifts to view the schedule");
        }

        foreach (var shift in ShiftList)
        {
            Console.WriteLine($"ID: {shift.employeeId}, Day: {shift.Day}, Time: {shift.Time}");
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
        public int? employeeId { get; set; }
    }
}