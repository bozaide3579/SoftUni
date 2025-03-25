using Microsoft.EntityFrameworkCore;
using NetPay.Data;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;

namespace NetPay.DataProcessor
{
	public class Serializer
	{
		public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
		{
			XmlHelper xmlHelper = new XmlHelper();
			const string xmlRoot = "Households";

			ExportHouseholdDto[] householdsToExport = context
				.Households
				.Include(h => h.Expenses)
				.ThenInclude(e => e.Service)
				.Where(h => h.Expenses.Any(e => e.PaymentStatus != PaymentStatus.Paid))
				.OrderBy(h => h.ContactPerson)
				.ToArray()
				.Select(h => new ExportHouseholdDto()
				{
					ContactPerson = h.ContactPerson,
					Email = h.Email,
					PhoneNumber = h.PhoneNumber,
					Expenses = h.Expenses
						.Where(e => e.PaymentStatus != PaymentStatus.Paid)
						.Select(e => new ExportExpenseDto()
						{
							ExpenseName = e.ExpenseName,
							Amount = e.Amount.ToString("F2"),
							PaymentDate = e.DueDate.ToString("yyyy-MM-dd"),
							ServiceName = e.Service.ServiceName
						})
						.OrderBy(e => e.PaymentDate)
						.ThenBy(e => e.Amount)
						.ToArray()
				})
				.ToArray();

			return xmlHelper.Serialize(householdsToExport, xmlRoot);

		}

		public static string ExportAllServicesWithSuppliers(NetPayContext context)
		{
			var servicesToExport = context.Services
				.Select(s => new
				{
					s.ServiceName,
					Suppliers = s.SuppliersServices
						.Select(ss => ss.Supplier)
						.Select(sup => new
						{
							sup.SupplierName,
						})
						.OrderBy(sup => sup.SupplierName)
						.ToArray()
				})
				.OrderBy(s => s.ServiceName)
				.ToArray();

			return JsonConvert.SerializeObject(servicesToExport, Formatting.Indented);
		}
	}
}
