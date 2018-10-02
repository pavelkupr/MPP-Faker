using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerLib.Generator;

namespace FakerLib
{
	class DateTimeGenerator : IGenerator
	{
		public Type[] GeneratedTypes => new[] { typeof(DateTime) };
		private const int limit = 1469334605;
		private Random _numGen;

		public DateTimeGenerator()
		{
			_numGen = new Random();
		}

		public DateTimeGenerator(Random numGen)
		{
			_numGen = numGen ?? throw new ArgumentNullException();
		}
		public object Generate(Type type)
		{
			if (!GeneratedTypes.Contains(type))
				throw new ArgumentException();

			return new DateTime((long)_numGen.Next() * _numGen.Next(limit));
		}
	}
}
