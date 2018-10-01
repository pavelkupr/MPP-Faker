using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP2.Generator;

namespace MPP2
{
	class LongGenerator : IGenerator
	{
		public Type[] GeneratedTypes => new[] { typeof(long) };
		private Random _numGen;

		public LongGenerator()
		{
			_numGen = new Random();
		}

		public LongGenerator(Random numGen)
		{
			_numGen = numGen ?? throw new ArgumentNullException();
		}

		public object Generate(Type type)
		{
			if (!GeneratedTypes.Contains(type))
				throw new ArgumentException();

			if (_numGen.Next(2) == 0)
				return (long)_numGen.Next() * _numGen.Next();
			else
				return (long)_numGen.Next() * _numGen.Next() * - 1;
		}
	}
}
