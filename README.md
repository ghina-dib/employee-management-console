# Employee Management Console App

A C# console application for managing a company's employees: adding, searching,
updating salaries, and removing records through an interactive menu.
Built as a foundation project to practice object-oriented design, input validation,
and the repository pattern before moving to full-stack development with ASP.NET and Angular.

## Features
- Add regular employees and managers (with bonus)
- List all employees
- Find an employee by ID
- Search employees by department (case-insensitive)
- Give a percentage raise
- Remove an employee
- Show the highest-paid employee
- Invalid input never crashes the app: the user gets a clear message instead

## Concepts Demonstrated
- **Encapsulation**: `Salary` has a private setter and can only change through
  `GiveRaise()`, which validates the percentage. `Id` is read-only after creation.
- **Validation (fail fast)**: the `Employee` constructor rejects empty names,
  empty departments, and non-positive salaries, so an invalid employee can never exist.
  Validation rules are defined once and reused.
- **Interface + Repository pattern**: `Program.cs` depends only on `IEmployeeRepository`.
  The in-memory implementation could be replaced by a database without changing the menu code.
- **Inheritance and polymorphism**: `Manager` extends `Employee` and overrides
  `CalculateAnnualPay()` and `ToString()`. A single list holds both types, and each
  one behaves correctly.
- **Read-only collections**: `GetAll()` returns `IReadOnlyList<Employee>`, so callers
  can't bypass the repository's duplicate-ID check.
- **Safe input handling**: `int.TryParse` / `decimal.TryParse` for user input, with
  domain errors caught and shown as messages.

## Project Structure
| File | Responsibility |
|---|---|
| `Employee.cs` | Employee data and business rules |
| `Manager.cs` | Manager-specific data (bonus) and behavior |
| `IEmployeeRepository.cs` | Contract for storing and querying employees |
| `InMemoryEmployeeRepository.cs` | List-based implementation of the repository |
| `Program.cs` | Console menu and user input handling |

## How to Run
Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download).

```bash
git clone https://github.com/ghina-dib/employee-management-console.git
cd employee-management-console
dotnet run --project "employee manegment"
```

## Known Limitations
- Data is stored in memory only and is lost when the app closes.
- Employee roles are modeled with inheritance, so promoting an employee to manager
  requires creating a new object. A role property (composition) would handle this better.

## What's Next
- Replace the in-memory list with a SQL database using Entity Framework Core
  (only a new `IEmployeeRepository` implementation is needed, thanks to the interface)
- Turn the console menu into an ASP.NET Web API with an Angular frontend
- Add unit tests for the validation rules in `Employee` and the repository