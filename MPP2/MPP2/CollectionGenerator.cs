using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MPP2.Generator;

namespace MPP2
{
	class CollectionGenerator : IGenerator
	{
		public Type[] GeneratedTypes => new[] { typeof(List<>) };
		private ObjCreator _objCreator;
		private Random _numGen;

		public CollectionGenerator()
		{
			_objCreator = new ObjCreator();
			_numGen = new Random();
		}

		public CollectionGenerator(Random numGen, ObjCreator objCreator)
		{
			_objCreator = objCreator ?? throw new ArgumentNullException();
			_numGen = numGen ?? throw new ArgumentNullException();
		}

		public object Generate(Type type)
		{
			if (!GeneratedTypes.Contains(type))
				throw new ArgumentException();

			ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(int) });
			object[] args = new[] { (object)_numGen.Next(1, 10) };
			dynamic instance = constructor.Invoke(args);
			foreach (var element in instance)
			{

			}
			return null;
		}
	}
}
