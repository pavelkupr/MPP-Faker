using System;
using System.Linq;
using FakerLib.Generator;

namespace FakerLib
{
	class IntGenerator : IGenerator
	{
		public Type[] GeneratedTypes => new[] { typeof(int) };
		private const int minValue = -2147483648, maxValue = 2147483647;
		private Random _numGen;

		public IntGenerator()
		{
			_numGen = new Random();
		}

		public IntGenerator(Random numGen)
		{
			_numGen = numGen ?? throw new ArgumentNullException();
		}

		public object Generate(Type type)
		{
			if (!GeneratedTypes.Contains(type))
				throw new ArgumentException();
			
			return _numGen.Next(minValue,maxValue);
		}
	}
}
