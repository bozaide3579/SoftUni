using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ImportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Serialization;

namespace NetPay.DataProcessor
{
	public class Deserializer
	{
		private const string ErrorMessage = "Invalid data format!";
		private const string DuplicationDataMessage = "Error! Data duplicated.";
		private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
		private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

		public static string ImportHouseholds(NetPayContext context, string xmlString)
		{
			StringBuilder sb = new StringBuilder();
			XmlHelper xmlHelper = new XmlHelper();
			const string xmlRoot = "Households";

			ICollection<Household> householdsToImport = new List<Household>();
			ImportHouseholdDto[] deserializedHouseholds = xmlHelper.Deserialize<ImportHouseholdDto[]>(xmlString, xmlRoot);

			foreach (ImportHouseholdDto householdDto in deserializedHouseholds)
			{
				if (!IsValid(householdDto))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				bool isAlreadyImportedHousehold = context.Households.Any
					(h => h.ContactPerson == householdDto.ContactPerson ||
					 h.Email == householdDto.Email ||
					 h.PhoneNumber == householdDto.PhoneNumber);

				bool isToBeImportedHousehold = householdsToImport.Any
					(h => h.ContactPerson == householdDto.ContactPerson ||
					 h.Email == householdDto.Email ||
					 h.PhoneNumber == householdDto.PhoneNumber);

				if (isAlreadyImportedHousehold || isToBeImportedHousehold)
				{
					sb.AppendLine(DuplicationDataMessage);
					continue;
				}

				Household household = new Household()
				{
					ContactPerson = householdDto.ContactPerson,
					Email = householdDto.Email,
					PhoneNumber = householdDto.PhoneNumber,
				};

				householdsToImport.Add(household);
				sb.AppendLine(String.Format(SuccessfullyImportedHousehold, household.ContactPerson));
			}

			context.Households.AddRange(householdsToImport);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static string ImportExpenses(NetPayContext context, string jsonString)
		{
			StringBuilder sb = new StringBuilder();

			ICollection<Expense> expencesToImport = new List<Expense>();
			ImportExpenceDto[] deserializedExpences = JsonConvert.DeserializeObject<ImportExpenceDto[]>(jsonString)!;

			foreach (ImportExpenceDto expenseDto in deserializedExpences)
			{
				if (!IsValid(expenseDto))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				bool householdExists = context.Households.Any
					(h => h.Id == expenseDto.HouseholdId);

				bool serviceExists = context.Services.Any
					(s => s.Id == expenseDto.ServiceId);

				if ((!householdExists) || (!serviceExists))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				bool isDueDateValid = DateTime
					.TryParseExact
					(expenseDto.DueDate,
					"yyyy-MM-dd",
					CultureInfo.InvariantCulture,
					DateTimeStyles.None,
					out DateTime dueDate);

				bool isPaymentStatusValid = Enum
					.TryParse<PaymentStatus>
					(expenseDto.PaymentStatus,
					out PaymentStatus paymentStatus);

				if ((!isDueDateValid) || (!isPaymentStatusValid))
				{
					sb.AppendLine(ErrorMessage);
					continue;
				}

				Expense expense = new Expense()
				{
					ExpenseName = expenseDto.ExpenseName,
					Amount = expenseDto.Amount,
					DueDate = dueDate,
					PaymentStatus = paymentStatus,
					HouseholdId = expenseDto.HouseholdId,
					ServiceId = expenseDto.ServiceId
				};

				expencesToImport.Add(expense);
				sb.AppendLine(String.Format(SuccessfullyImportedExpense, expense.ExpenseName, expense.Amount.ToString("f2")));
			}

			context.AddRange(expencesToImport);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		public static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResults = new List<ValidationResult>();

			bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

			foreach (var result in validationResults)
			{
				string currvValidationMessage = result.ErrorMessage;
			}

			return isValid;
		}
	}
}
