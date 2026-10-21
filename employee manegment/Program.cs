using EmployeeManagement;
IEmployeeRepository repo = new InMemoryEmployeeRepository();
repo.Add(new Employee(1, "Maya", "IT", 2500m));
repo.Add(new Employee(2, "John", "HR", 3000m));
repo.Add(new Employee(3, "Alice", "IT", 2800m));
repo.Add(new Manager(4, "Bob", "Finance", 3200m, 500m));



string choice = "";
while (choice != "0")
{

    Console.WriteLine("=== Employee Manager ===");
    Console.WriteLine("1. Add employee");
    Console.WriteLine("2. Add manager");
    Console.WriteLine("3. List all");
    Console.WriteLine("4. Find by ID");
    Console.WriteLine("5. Search by department");
    Console.WriteLine("6. Give raise");
    Console.WriteLine("7. Remove employee");
    Console.WriteLine("8. Show highest paid");
    Console.WriteLine("0. Exit");
    Console.WriteLine("your choice :");
    choice = Console.ReadLine() ?? "";
    switch (choice)
    {
        case "1":
            Console.WriteLine("Employee name: ");
            string name = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
                break;
            }
            int id = ReadInt("Enter Employee Id:");
            if (id < 0)
            {
                Console.WriteLine("Invalid ID. Please enter a valid positive integer.");
                break;
            }
            if (repo.GetById(id) != null)
            {
                Console.WriteLine($"An employee with ID {id} already exists.");
                break;
            }
            Console.Write("Enter department:");
            string department = Console.ReadLine() ;
            if(string.IsNullOrWhiteSpace(department))
            {
                Console.WriteLine("Department cannot be empty.");
                break;
            }
            decimal salary = ReadDecimal("Enter salary: ");
            try
            {

                repo.Add(new Employee(id, name, department, salary));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


            break;

        case "2":
            Console.WriteLine("Manager name: ");
            string nameMang = Console.ReadLine() ?? "";
            int idMang = ReadInt("Enter Manager Id:");
            if (idMang < 0)
            {
                Console.WriteLine("Invalid ID. Please enter a valid positive integer.");
                break;
            }
            if (repo.GetById(idMang) != null)
            {
                Console.WriteLine($"A mangeer with ID {idMang} already exists.");
                break;
            }
            Console.Write("Enter department:");
            string departmentMang = Console.ReadLine() ?? "";
            decimal salaryMang = ReadDecimal("Enter salary: ");
            decimal bonus = ReadDecimal("Enter bonus: ");
            if(bonus < 0)
            {
                Console.WriteLine("Bonus must be greater than or equal to zero.");
                break;
            }
            try
            {
                repo.Add(new Manager(idMang, nameMang, departmentMang, salaryMang, bonus));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            break;
        case "3":

            var allEmployees = repo.GetAll();
            if (allEmployees.Count == 0)
            {
                Console.WriteLine("No employees found.");
            }
            else
            {
                foreach (var employee in allEmployees)
                {
                    Console.WriteLine(employee);
                }
            }
            break;

        case "4":
            int searchId = ReadInt("Enter Employee Id:");
            var empserach = repo.GetById(searchId);
            if (empserach != null)
            {
                Console.WriteLine(empserach);
            }
            else
            {
                Console.WriteLine($"Employee with ID {searchId} not found.");
            }
            break;
        case "5":
            Console.WriteLine("Enter Department to search :");
            department = Console.ReadLine() ;
            if(string.IsNullOrWhiteSpace(department))
            {
                Console.WriteLine("Department cannot be empty.");
                break;
            }
            IReadOnlyList<Employee> employeesByDepartment = repo.GetByDepartment(department);
            if (employeesByDepartment.Count == 0)
            {
                Console.WriteLine($"No employees found in department {department}.");
            }
            else
            {
                foreach (Employee employee in employeesByDepartment)
                {
                    Console.WriteLine(employee);
                }
            }
            break;
        case "6":
            id = ReadInt("Enter Employee Id to give raise:");
            var employeeToRaise = repo.GetById(id);
            if (employeeToRaise != null)
            {
                decimal percentage = ReadDecimal("Enter raise percentage:");
                try
                {
                    employeeToRaise.GiveRaise(percentage);
                    Console.WriteLine($"New salary for {employeeToRaise.Name} is {employeeToRaise.Salary:F2}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                employeeToRaise.GiveRaise(percentage);
                Console.WriteLine($"New salary for {employeeToRaise.Name} is {employeeToRaise.Salary:C}");
            }
            else
            {
                Console.WriteLine($"Employee with ID {id} not found.");
            }
            break;
        case "7":
            id = ReadInt("Enter Employee Id to remove:");
            bool removed = repo.Remove(id);
            if (removed)
            {
                Console.WriteLine($"Employee with ID {id} has been removed.");
            }
            else
            {
                Console.WriteLine($"Employee with ID {id} not found.");
            }
            break;
        case "8":
            var highestPaid = repo.GetHighestPaid();
            if (highestPaid != null)
            {
                Console.WriteLine(highestPaid);
            }
            else
            {
                Console.WriteLine("No employees found.");
            }
            break;

        case "0":
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;

    }
}
static int ReadInt(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string input = Console.ReadLine() ?? "";
        if (int.TryParse(input, out int number))
        {
            return number;
        }
        Console.WriteLine("Invalid number please try again");
    }
}
static decimal ReadDecimal(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string input = Console.ReadLine() ?? "";
        if (decimal.TryParse(input, out decimal number))
        {
            return number;
        }
        Console.WriteLine("Invalid amount. Please try again");
    }
}

