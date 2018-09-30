using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP2.Generator;

namespace MPP2
{
	class ObjCreator
	{
		private Dictionary<Type, IGenerator> generators;

		public ObjCreator()
		{
			generators = new Dictionary<Type, IGenerator>();
		}

		public object Create(Type type)
		{
			IGenerator generator;
			if (generators.TryGetValue(type, out generator))
				return generator.Generate();
			else
				return null;
		}
	}
}
