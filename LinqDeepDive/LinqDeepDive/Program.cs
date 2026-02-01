using LinqDeepDive.Models;

class Program
{
    static void Main(string[] args)
    {
            var employees = new List<Employee>
            {
                new() { EmpId = 1, Name = "Alice",   Department = "IT",  Salary = 90000, ManagerId = 0 },
                new() { EmpId = 2, Name = "Bob",     Department = "IT",  Salary = 80000, ManagerId = 1 },
                new() { EmpId = 3, Name = "Charlie", Department = "IT",  Salary = 80000, ManagerId = 1 },
                new() { EmpId = 4, Name = "David",   Department = "HR",  Salary = 70000, ManagerId = 0 },
                new() { EmpId = 5, Name = "Eva",     Department = "HR",  Salary = 60000, ManagerId = 4 },
                new() { EmpId = 6, Name = "Frank",   Department = "HR",  Salary = 60000, ManagerId = 4 },
                new() { EmpId = 7, Name = "Grace",   Department = "Finance", Salary = 75000, ManagerId = 0 }
            };

            var departments = new List<Department>
            {
                new() { Name = "IT", Location = "Bangalore" },
                new() { Name = "HR", Location = "Mumbai" },
                new() { Name = "Finance", Location = "Delhi" }
            };

            var projects = new List<Project>
            {
                new() { ProjectId = 1, ProjectName = "Alpha", EmpId = 2 },
                new() { ProjectId = 2, ProjectName = "Beta",  EmpId = 2 },
                new() { ProjectId = 3, ProjectName = "Gamma", EmpId = 5 },
                new() { ProjectId = 4, ProjectName = "Delta", EmpId = 6 }
            };

        //Employees salary greater than 70000
        var highestSalary = employees.Where(c => c.Salary > 70000).ToList();
        foreach (var emp in highestSalary)
        {
            Console.WriteLine($"Name: {emp.Name}, Salary: {emp.Salary}");
        }

        //Employees without a manager
        var noManager = employees.Where(c=>c.ManagerId == 0).ToList();
        foreach (var emp in noManager)
        {
            Console.WriteLine($"Name: {emp.Name}, Department: {emp.Department}");
        }

        //Employees in IT department
        var employee = employees.Where(c => c.Department == "IT").ToList();
        foreach (var emp in employee)
        {
            Console.WriteLine($"Name: {emp.Name}, Department: {emp.Department}");
        }


        //Highest Salary
        var highSalary = employees.Max(c=>c.Salary);
        Console.WriteLine($"Highest Salary: {highSalary}");

        //Highest Salary by Dept
        var highSalaryByDept = employees.GroupBy(c => c.Department).Select(g => new
        {
            Department = g.Key,
            HighestSalary = g.Max(c => c.Salary),
        }).ToList();
        foreach (var emp in highSalaryByDept)
        {
            Console.WriteLine($"Highest Salary By Dept - Department: {emp.Department}, Salary: {emp.HighestSalary}");
        }


        //Second Highest Salary
        var secondHighestSalary = employees.OrderByDescending(c => c.Salary).Distinct().Skip(1).Take(1).ToList();
        foreach (var emp in secondHighestSalary)
        {
            Console.WriteLine($"Second Highest - Name: {emp.Name}, Department: {emp.Salary}");
        }

        //Top 3 Highest Salary
        var topThreeHighestSalary = employees.OrderByDescending(c => c.Salary).Distinct().Take(3).ToList();
        foreach (var emp in topThreeHighestSalary)
        {
            Console.WriteLine($"Top Three - Name: {emp.Name}, Department: {emp.Salary}");
        }

        //Duplicate Salaries
        var duplicateSalaries = employees.GroupBy(e => e.Salary).Where(e => e.Count() > 1).Select(e => e.Key);
        foreach (var emp in duplicateSalaries)
        {
            Console.WriteLine($"duplicate salary - {emp.ToString()}");
        }

        //Count how many employees earn the same salary
        var countOfEmpWithSameSalary = employees.GroupBy(e=>e.Salary).Select(g=> new
        {
            Salary = g.Key,
            Emp = g.Count()
        }).Where(c=>c.Emp>1);

        foreach (var emp in countOfEmpWithSameSalary)
        {
            Console.WriteLine($"Same salary - {emp.Salary}, {emp.Emp}");
        }

        //Find salaries that appear more than once
        var salariesMoreThanOnce =  employees
        .GroupBy(e => e.Salary)
        .Where(g => g.Count() > 1)
        .Select(g => new
        {
            Salary = g.Key,
            Occurrences = g.Count()
        });

        Console.WriteLine($"Same salary - {salariesMoreThanOnce}");

        //Count employees per department
        var countOfEmpPerDept = employees.GroupBy(c => c.Department).Select(g => new
        {
            Department = g.Key,
            EmployeeCount = g.Count()
        });

        foreach(var dep in  countOfEmpPerDept)
        {
            Console.WriteLine($"Dept - {dep.Department}, EmpCount - {dep.EmployeeCount} ");
        }

        //Find average salary per department
        var avgSalaryPerDept = employees.GroupBy(e => e.Department).Select(g => new
        {
            Department = g.Key,
            AvgSalary = g.Average(e => e.Salary)
        });

        foreach (var dep in avgSalaryPerDept)
        {
            Console.WriteLine($"Dept - {dep.Department}, AvgSalary - {dep.AvgSalary} ");
        }

        //Find departments where employee count > 2
        var EmpyCountGt2 = employees.GroupBy(e => e.Department).Select(g => new
        {
            Department = g.Key,
            EmpCount = g.Count()
        }).Where(e=>e.EmpCount > 2);

        foreach (var dep in EmpyCountGt2)
        {
            Console.WriteLine($"Dept - {dep.Department}, EmpCount - {dep.EmpCount} ");
        }

        //List employee names with their department location
        var joinNameAndDeptLocation = employees.Join(departments,
            e => e.Department,
            d => d.Name,
            (e, d) => new
            {
                EmployeeName = e.Name,
                Department = d.Name,
                Location = d.Location
            });

        foreach (var dep in joinNameAndDeptLocation)
        {
            Console.WriteLine($"{dep.EmployeeName}, {dep.Department}, {dep.Location} ");
        }

        //List employees who are not assigned to any project
        var empWithNoProject = from e in employees
                               join p in projects
                               on e.EmpId equals p.EmpId into ep
                               from p in ep.DefaultIfEmpty()
                               where p == null
                               select e;
        foreach (var dep in empWithNoProject) 
        {
            Console.WriteLine($"empName - {dep.Name}, ID - {dep.EmpId}");
        }

        //List employees with number of projects assigned
        var empProjectCount = from e in employees
                              join p in projects
                              on e.EmpId equals p.EmpId into ep
                              select new
                              {
                                  Employee = e.Name,
                                  ProjectCount = ep.Count()
                              };
        foreach (var dep in empProjectCount)
        {
            Console.WriteLine($"empName - {dep.Employee}, projectCount - {dep.ProjectCount}");
        }

        //Display employee name → manager name
        var empAndManager = from e in employees
                            join m in employees
                            on e.ManagerId equals m.EmpId into ep
                            from m in ep.DefaultIfEmpty()
                            select new
                            {
                                Employee = e.Name,
                                Manager = m != null? m.Name : "No Manager"
                            };

        foreach (var dep in empAndManager)
        {
            Console.WriteLine($"empName - {dep.Employee}, Manager - {dep.Manager}");
        }

        //Find managers who have more than one reportee
        var ManagerWithMoreThanOneReportee = employees
    .Where(e => e.ManagerId != 0)
    .GroupBy(e => e.ManagerId)
    .Where(g => g.Count() > 1)
    .Join(
        employees,
        g => g.Key,
        m => m.EmpId,
        (g, m) => new
        {
            ManagerName = m.Name,
            ReporteeCount = g.Count()
        }
    );

        foreach (var dep in ManagerWithMoreThanOneReportee)
        {
            Console.WriteLine($"Manager - {dep.ManagerName}, empCount - {dep.ReporteeCount}");
        }
    }

}