using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FakerLib.Generator;

namespace FakerLib
{
	class ObjCreator : ICreator
	{
		private Dictionary<Type, IGenerator> generators;
		private Random random;

		public ObjCreator()
		{
			generators = new Dictionary<Type, IGenerator>();
			random = new Random();
			AddGenerators();
		}

		public object CreateInstance(Type type)
		{
			Type typeDefinition;

			if (type.IsGenericType)
				typeDefinition = type.GetGenericTypeDefinition();
			else if (type.IsArray)
				typeDefinition = typeof(Array);
			else
				typeDefinition = type;

			IGenerator generator;
			if (generators.TryGetValue(typeDefinition, out generator))
				return generator.Generate(type);
			else
				return null;
		}

		private void AddGenerators()
		{
			IGenerator[] genArr = { new IntGenerator(random),
									new LongGenerator(random),
									new StringGenerator(random),
									new DateTimeGenerator(random),
									new ArrayGenerator(random, this),
									new BaseCollectionsGenerator(this) };

			foreach (IGenerator gen in genArr)
				foreach (Type type in gen.GeneratedTypes)
					generators.Add(type, gen);
		}
	}
}
