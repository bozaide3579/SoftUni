using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProblem
{
	public class Tracker
	{
		public void PrintmethodByAuthor()
		{
			PrintmethodByType(typeof(StartUp));
		}

		private void PrintmethodByType(Type type)
		{
			MethodInfo[] methods = type.GetMethods();
			foreach (MethodInfo method in methods)
			{
				List<AuthorAttribute> attributes =
				method.GetCustomAttributes<AuthorAttribute>().ToList();
				if (attributes.Count > 0)
				{
					foreach (AuthorAttribute attribute in attributes)
					{
						Console.WriteLine($"{method.Name} is written by {attribute.Name}");
					}
				}
            }
		}
	}
}
