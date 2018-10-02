using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerLib.Generator;

namespace FakerLib
{
	class IntGenerator : IGenerator
	{
		public Type[] GeneratedTypes => new[] { typeof(int) };
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

			if (_numGen.Next(2) == 0)
				return _numGen.Next();
			else
				return -_numGen.Next();
		}
	}
}
