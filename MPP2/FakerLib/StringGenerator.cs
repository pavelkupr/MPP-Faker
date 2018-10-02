using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerLib.Generator;

namespace FakerLib
{
	class StringGenerator : IGenerator
	{
		public Type[] GeneratedTypes => new[] { typeof(string) };
		private const int minLength = 5, maxLength = 20;
		private Random _numGen;

		public StringGenerator()
		{
			_numGen = new Random();
		}

		public StringGenerator(Random numGen)
		{
			_numGen = numGen ?? throw new ArgumentNullException();
		}

		public object Generate(Type type)
		{
			if (!GeneratedTypes.Contains(type))
				throw new ArgumentException();

			byte[] chars = new byte[_numGen.Next(minLength, maxLength)];
			_numGen.NextBytes(chars);
			return Encoding.GetEncoding(1251).GetString(chars);
		}
	}
}
