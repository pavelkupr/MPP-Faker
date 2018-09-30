using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MPP2
{
	class Program
	{
		class Test
		{
			public int Prop { get; set; }
		}

		static void Main(string[] args)
		{
			Faker creator = new Faker();
			Test test = creator.Create<Test>();
			Console.WriteLine(test.Prop);
			Console.ReadLine();
		}
	}
}
