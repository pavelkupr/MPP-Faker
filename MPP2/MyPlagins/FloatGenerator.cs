﻿using System;
using System.Linq;
using FakerLib.Generator;

namespace MyPlugins
{
	public class FloatGenerator : IGenerator
	{
		public Type[] GeneratedTypes => new[] { typeof(float) };
		private const int minPow = -44, maxPow = 39;
		private Random _numGen;

		public FloatGenerator()
		{
			_numGen = new Random();
		}

		public FloatGenerator(Random numGen)
		{
			_numGen = numGen ?? throw new ArgumentNullException();
		}

		public object Generate(Type type)
		{
			if (!GeneratedTypes.Contains(type))
				throw new ArgumentException();
			
			double exponent = Math.Pow(10.0, _numGen.Next(minPow, maxPow));
			return (float)(_numGen.NextDouble() * exponent);
		}
	}
}
