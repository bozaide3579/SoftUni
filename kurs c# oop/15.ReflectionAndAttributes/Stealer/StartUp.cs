﻿namespace Stealer
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			Spy spy = new Spy();
			string result = spy.StealFieldInfo("Steal,Hacker", "username", "password");
            Console.WriteLine(result);
        }
	}
}
