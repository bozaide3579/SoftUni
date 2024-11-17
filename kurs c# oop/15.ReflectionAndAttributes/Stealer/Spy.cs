﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
	public class Spy
	{

		public string StealFieldInfo(string classToInvestigate, params string[] fields)
		{
			Type classType = Type.GetType(classToInvestigate);
			FieldInfo[] classFields = classType.GetFields
				(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
			StringBuilder sb = new StringBuilder();

			Object classInstance = Activator.CreateInstance(classType, new object[] { });

			sb.AppendLine($"Class under investigation: {classToInvestigate}");

			foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name)))
			{
				sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
			}

			return sb.ToString().Trim();
		}
	}
}
