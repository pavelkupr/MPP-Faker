using System;
using System.Linq;
using FakerLib.Generator;

namespace FakerLib
{
	class LongGenerator : IGenerator
	{
		public Type[] GeneratedTypes => new[] { typeof(long) };
		private const int minValue = -2147483648, maxValue = 2147483647;
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
			
			return (long)_numGen.Next(minValue,maxValue) * _numGen.Next();
		}
	}
}
