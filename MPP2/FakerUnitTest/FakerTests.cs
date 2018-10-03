using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerLib;

namespace FakerUnitTest
{
	class Test1
	{
		public int[,,] IntArr { get; set; }
		public long Long { get; set; }
		public Queue<int[]> QueueOfIntArr { get; set; }
		public Test1 NestedTestDTO { get; set; }
		public string String { get; set; }
		public DateTime DateTime { get; set; }
		public int intField;
	}

	class Test2
	{
		public Test2(int param1)
		{
			Integer = param1;
			IsSecondConstructorCalled = false;
		}

		public Test2(int param1, int param2)
		{
			Integer = param1;
			IsSecondConstructorCalled = true;
		}

		public int Integer { get; }
		public bool IsSecondConstructorCalled { get; }
	}

	[TestClass]
	public class FakerTests
	{
		private static Faker faker;
		private static Test1 test1DTO;
		private static Test2 test2DTO;

		[ClassInitialize]
		public static void ClassInitilize(TestContext context)
		{
			faker = new Faker();
			test1DTO = faker.Create<Test1>();
			test2DTO = faker.Create<Test2>();
		}

		[TestMethod]
		public void Result_Of_Create_Method_Is_Not_Null()
		{
			Assert.IsNotNull(test1DTO, "Faker hasn't created instance of DTO");
		}

		[TestMethod]
		public void Integer_Arr_Property_Is_Not_Null()
		{
			Assert.IsNotNull(test1DTO.IntArr, "Faker hasn't created array of integer property");
		}

		[TestMethod]
		public void Long_Property_Is_Not_Null()
		{
			Assert.IsNotNull(test1DTO.Long, "Faker hasn't created long property");
		}

		[TestMethod]
		public void Nested_DTO_Property_Is_Not_Null()
		{
			Assert.IsNotNull(test1DTO.NestedTestDTO, "Faker hasn't created nested DTO property");
		}

		[TestMethod]
		public void Queue_Of_Int_Arr_Property_Is_Not_Null()
		{
			Assert.IsNotNull(test1DTO.QueueOfIntArr, "Faker hasn't created queue of integer array property");
		}

		[TestMethod]
		public void String_Property_Is_Not_Null()
		{
			Assert.IsNotNull(test1DTO.String, "Faker hasn't created string property");
		}

		[TestMethod]
		public void DateTime_Property_Is_Not_Null()
		{
			Assert.IsNotNull(test1DTO.DateTime, "Faker hasn't created DateTime property");
		}

		[TestMethod]
		public void Int_Field_Is_Not_Null()
		{
			Assert.IsNotNull(test1DTO.intField, "Faker hasn't created integer field");
		}

		[TestMethod]
		public void Nested_DTO_Property_Of_Nested_DTO_Is_Null()
		{
			Assert.IsNull(test1DTO.NestedTestDTO.NestedTestDTO, "Faker has created nested DTO property of nested DTO");
		}

		[TestMethod]
		public void Faker_Call_Constructor_With_A_Large_Number_Of_Parameters()
		{
			Assert.IsTrue(test2DTO.IsSecondConstructorCalled, "Faker has called constructor with a less number of parameters");
		}

		[TestMethod]
		public void Integer_Parameter_Of_DTO_Constructor_Is_Not_Null()
		{
			Assert.IsNotNull(test2DTO.Integer, "Faker hasn't created integer parameter");
		}
	}
}