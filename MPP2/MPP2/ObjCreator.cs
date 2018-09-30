using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MPP2.Generator;

namespace MPP2
{
	class ObjCreator
	{
		private Dictionary<Type, IGenerator> generators;
		private Random random;

		public ObjCreator()
		{
			generators = new Dictionary<Type, IGenerator>();
			random = new Random();
			AddGenerators();
		}

		public object Create(Type type)
		{
			IGenerator generator;
			if (generators.TryGetValue(type, out generator))
				return generator.Generate();
			else
				return null;
		}

		private void AddGenerators()
		{
			IGenerator[] genArr = { new IntGenerator(random) };

			foreach (IGenerator gen in genArr)
				generators.Add(gen.GeneratedType,gen);
		}
	}
}
