namespace SoftUniKindergarten
{
	public class Child
	{
		public Child(string firstName, string lastName, int age, string parentName, string contactNumber)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Age = age;
			this.ParentName = parentName;
			this.ContactNumber = contactNumber;
		}

		public string FirstName { get; }
		public string LastName { get; }
		public int Age { get; }
		public string ParentName { get; }
		public string ContactNumber { get; }

		public override string ToString()
		{
			return $"Child: {FirstName} {LastName}, Age: {Age}, Contact info: {ParentName} - {ContactNumber}";
		}
	}
}
