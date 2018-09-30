using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP2.Generator;

namespace MPP2
{
	class IntGenerator : IGenerator
	{
		public Type GeneratedType => typeof(int);
		private Random _numGen;

		public IntGenerator()
		{
			_numGen = new Random();
		}

		public IntGenerator(Random numGen)
		{
			_numGen = numGen ?? throw new ArgumentNullException();
		}

		public object Generate()
		{
			if (_numGen.Next(2) == 0)
				return _numGen.Next();
			else
				return _numGen.Next() * -1;
		}
	}
}
