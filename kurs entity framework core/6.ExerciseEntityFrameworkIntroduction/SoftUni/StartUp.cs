using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
	public class StartUp
	{
		public static void Main()
		{
			SoftUniContext context = new SoftUniContext();
			Console.WriteLine(GetEmployeesInPeriod(context));
		}

		public static string GetEmployeesFullInformation(SoftUniContext context)
		{
			//return string.Join(Environment.NewLine, context.Employees
			//	.Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}")
			//	.ToList());

			var employees = context.Employees
				.Select(e => new
				{
					e.FirstName,
					e.LastName,
					e.MiddleName,
					e.JobTitle,
					e.Salary
				})
				.ToList();

			StringBuilder sb = new StringBuilder();
			foreach (var e in employees)
			{
				sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
		{
			var richEmployees = context.Employees
				.Where(e => e.Salary > 50000)
				.Select(e => new
				{
					e.FirstName,
					e.Salary
				})
				.OrderBy(e => e.FirstName);

			StringBuilder sb = new StringBuilder();
			foreach (var e in richEmployees)
			{
				sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
			}

			return sb.ToString().TrimEnd();
		}

		public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
		{
			var employees = context.Employees
				.Select(e => new
				{
					e.FirstName,
					e.LastName,
					e.Salary,
					e.Department
				})
				.Where(e => e.Department.Name == "Research and Development")
				.OrderBy(e => e.Salary)
				.ThenByDescending(e => e.FirstName)
				.ToList();

			StringBuilder sb = new StringBuilder();
			foreach (var e in employees)
			{
				sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}");
			}

			return sb.ToString().TrimEnd();
		}

		public static string AddNewAddressToEmployee(SoftUniContext context)
		{
			Address newAdress = new Address()
			{
				AddressText = "Vitoshka 15",
				TownId = 4
			};

			var nakov = context.Employees
				.FirstOrDefault(e => e.LastName == "Nakov");

            if (nakov != null)
            {
				nakov.Address = newAdress;
				context.SaveChanges();
            }

			var employees = context.Employees
				.OrderByDescending(e => e.AddressId)
				.Take(10)
				.Select(e => e.Address.AddressText)
				.ToList();

			return string.Join(Environment.NewLine, employees);
        }

		public static string GetEmployeesInPeriod(SoftUniContext context)
		{
			var result = context.Employees
				.Take(10)
				.Select(e => new
				{
					EmployeeNames = $"{e.FirstName} {e.LastName}",
					ManagerNames = $"{e.Manager.FirstName} {e.Manager.LastName}",
					Projects = e.EmployeesProjects
						.Where(ep =>
							ep.Project.StartDate.Year >= 2001 &&
							ep.Project.StartDate.Year <= 2003)
						.Select(ep => new
						{
							ProjectName = ep.Project.Name,
							ep.Project.StartDate,
							EndDate = ep.Project.EndDate.HasValue ?
								ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") :
								"not finished"
						}) 
				});

			var sb = new StringBuilder();
			foreach(var e in result)
			{
				sb.AppendLine($"{e.EmployeeNames} - Manager: {e.ManagerNames}");
				if (e.Projects.Any())
				{
					foreach(var p in e.Projects)
					{
						sb.AppendLine($"--{p.ProjectName} - {p.StartDate:M/d/yyyy h:mm:ss tt} - " +
									  $"{p.EndDate:M/d/yyyy h:mm:ss tt}");
					}
				}
			}

			return sb.ToString().TrimEnd();
		}
	}
}
