using System;
using System.Linq;
using FakerLib.Generator;

namespace MyPlugins
{
	public class DoubleGenerator : IGenerator
	{
		public Type[] GeneratedTypes => new[] { typeof(double) };
		private const int minPow = -323, maxPow = 309;
		private Random _numGen;

		public DoubleGenerator()
		{
			_numGen = new Random();
		}

		public DoubleGenerator(Random numGen)
		{
			_numGen = numGen ?? throw new ArgumentNullException();
		}

		public object Generate(Type type)
		{
			if (!GeneratedTypes.Contains(type))
				throw new ArgumentException();

			double exponent = Math.Pow(10.0, _numGen.Next(minPow, maxPow));
			return _numGen.NextDouble() * exponent;
		}
	}
}
