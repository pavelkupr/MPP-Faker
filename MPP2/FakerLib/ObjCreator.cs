﻿using System;
using System.Collections.Generic;
using FakerLib.Generator;

namespace FakerLib
{
	public class ObjCreator : ICreator
	{
		private Dictionary<Type, IGenerator> generators;
		private PluginInstaller pluginInstaller;
		private Random random;

		public ObjCreator()
		{
			generators = new Dictionary<Type, IGenerator>();
			pluginInstaller = new PluginInstaller();
			random = new Random();
			AddGenerators();
			AddPlugins();
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

		private void AddPlugins()
		{
			foreach (IGenerator gen in pluginInstaller.Plugins)
				foreach (Type type in gen.GeneratedTypes)
					generators.Add(type, gen);
		}
	}
}
