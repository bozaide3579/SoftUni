using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlHelper xmlHelper = new XmlHelper();
            const string xmlRoot = "Customers";

            ICollection<Customer> customersToImport = new List<Customer>();
            ImportCustomerDto[] deserializedCustomers = xmlHelper.Deserialize<ImportCustomerDto[]>(xmlString, xmlRoot);

            foreach (var customerDto in deserializedCustomers)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isAlreadyImported = context.Customers.Any
                    (c => c.FullName == customerDto.FullName ||
                    c.Email == customerDto.Email ||
                    c.PhoneNumber == customerDto.PhoneNumber);

                bool isToBeImported = customersToImport.Any
					(c => c.FullName == customerDto.FullName ||
					c.Email == customerDto.Email ||
					c.PhoneNumber == customerDto.PhoneNumber);

                if (isAlreadyImported || isToBeImported)
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                Customer customer = new Customer()
                {
                    PhoneNumber = customerDto.PhoneNumber,
                    Email = customerDto.Email,
                    FullName = customerDto.FullName
                };

                customersToImport.Add(customer);
                sb.AppendLine(String.Format(SuccessfullyImportedCustomer, customer.FullName));

            }

            context.AddRange(customersToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Booking> bookingsToImport = new List<Booking>();
            ImportBookingDto[] deserializedBookings = JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString)!;

            foreach (var bookingDto in deserializedBookings)
            {
                if (!IsValid(bookingDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime bookingDate;

                if (!DateTime.TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out bookingDate))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customerId = context.Customers.FirstOrDefault(c => c.FullName == bookingDto.CustomerName).Id;
                var tourPackageId = context.TourPackages.FirstOrDefault(tp => tp.PackageName == bookingDto.TourPackageName).Id;

                if (customerId == 0 || tourPackageId == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Booking booking = new Booking
                {
                    CustomerId = customerId,
                    TourPackageId = tourPackageId,
                    BookingDate = bookingDate
                };

                bookingsToImport.Add(booking);
                sb.AppendLine(String.Format(SuccessfullyImportedBooking, bookingDto.TourPackageName, bookingDto.BookingDate));
            }

            context.Bookings.AddRange(bookingsToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
