﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldestFamilyMember
{
	public class Person
	{

        public Person(string name, int age)
        {
            this.Name = name; 
            this.Age = age;
        }

        
        public string Name { get; }
		public int Age { get; }
	}
}
