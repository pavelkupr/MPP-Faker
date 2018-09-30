using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MPP2
{
	struct TestStruct
	{
		public TestStruct(int i)
		{
			Prop = i;
		}

		int Prop { get; set; }
	}

	class Test
	{
		public TestStruct TStruct{ get; set; }
		public int Prop { get; set; }
		public long Prop2 { get; set; }
		public List<int> list { get; set; }
		public Test Test1 { get; set; }
	}

	class Program
	{

		static void Main(string[] args)
		{
			Faker creator = new Faker();
			Test test = creator.Create<Test>();
			Console.WriteLine(test.Prop);
			
			Console.ReadLine();
		}
	}
}
