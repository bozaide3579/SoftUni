namespace Medicines.DataProcessor
{
    using Medicines.Data;
	using Medicines.Data.Models;
	using Medicines.Data.Models.Enums;
	using Medicines.DataProcessor.ImportDtos;
	using Medicines.Utilities;
	using Newtonsoft.Json;
	using System.ComponentModel.DataAnnotations;
	using System.Globalization;
	using System.Text;

	public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ICollection<Patient> patientsToImport = new List<Patient>();

            var patientsDtos = JsonConvert.DeserializeObject<ImportPatientsDto[]>(jsonString);
            foreach ( var patientDto in patientsDtos)
            {
                if (!IsValid(patientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient patient = new Patient()
                {
                    FullName = patientDto.FullName,
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    Gender = (Gender)patientDto.Gender
                };

				foreach (int medicineId in patientDto.Medicines)
                {
                    if (patient.PatientsMedicines.Any(m => m.MedicineId == medicineId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine pateinetMedicine = new PatientMedicine()
                    {
                        Patient = patient,
                        MedicineId = medicineId
                    };

                    patient.PatientsMedicines.Add(pateinetMedicine);
                }

                patientsToImport.Add(patient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientsMedicines.Count));
			}

            context.Patients.AddRange(patientsToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();
            const string xmlRoot = "Pharmacies";

			ICollection<Pharmacy> pharmaciesToImport = new List<Pharmacy>();
            ImportPharmaciesDto[] deserializedPharmacies = xmlHelper.Deserialize<ImportPharmaciesDto[]>(xmlString, xmlRoot);

            foreach (var pharmacyDto in deserializedPharmacies)
            {
                if (!IsValid(pharmacyDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

				Pharmacy pharmacy = new Pharmacy()
                {
                    Name = pharmacyDto.Name,
                    PhoneNumber = pharmacyDto.PhoneNumber,
                    IsNonStop = pharmacyDto.IsNonStop
                };

				foreach (var medicineDto in pharmacyDto.Medicines)
                {
                    if (!IsValid(medicineDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

					DateTime medicineProductionDate;
					bool isProductionDateValid = DateTime
						.TryParseExact(medicineDto.ProductionDate, "yyyy-MM-dd", CultureInfo
						.InvariantCulture, DateTimeStyles.None, out medicineProductionDate);

					if (!isProductionDateValid)
					{
						sb.Append(ErrorMessage);
						continue;
					}

					DateTime medicineExpityDate;
					bool isExpityDateValid = DateTime
						.TryParseExact(medicineDto.ExpiryDate, "yyyy-MM-dd", CultureInfo
						.InvariantCulture, DateTimeStyles.None, out medicineExpityDate);

					if (!isExpityDateValid)
					{
						sb.Append(ErrorMessage);
						continue;
					}

					if (medicineProductionDate >= medicineExpityDate)
					{
						sb.AppendLine(ErrorMessage);
						continue;
					}

					if (pharmacy.Medicines.Any(x => x.Name == medicineDto.Name && x.Producer == medicineDto.Producer))
					{
						sb.AppendLine(ErrorMessage);
						continue;
					}

					Medicine medicine = new Medicine()
                    {
                        Name = medicineDto.Name,
                        Price = medicineDto.Price,
                        Category = (Category)medicineDto.Category,
                        ProductionDate = medicineProductionDate,
                        ExpiryDate = medicineExpityDate,
                        Producer = medicineDto.Producer
                    };

                    pharmacy.Medicines.Add(medicine);
                }

                pharmaciesToImport.Add(pharmacy);
                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(pharmaciesToImport);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
