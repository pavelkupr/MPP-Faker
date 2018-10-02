using System;
using FakerLib.Generator;

namespace FakerLib
{
	class ArrayGenerator : IGenerator
	{
		public Type[] GeneratedTypes => new[] { typeof(Array) };
		private const int minLength = 1, maxLength = 10;
		private ObjCreator _objCreator;
		private Random _numGen;

		public ArrayGenerator()
		{
			_objCreator = new ObjCreator();
			_numGen = new Random();
		}

		public ArrayGenerator(Random numGen, ObjCreator objCreator)
		{
			_objCreator = objCreator ?? throw new ArgumentNullException();
			_numGen = numGen ?? throw new ArgumentNullException();
		}

		public object Generate(Type type)
		{
			if (!type.IsArray)
				throw new ArgumentException();

			int[] length = new int[type.GetArrayRank()];
			for (int i = 0; i < length.Length; i++)
			{
				length[i] = _numGen.Next(minLength, maxLength);
			}
			Array arr = Array.CreateInstance(type.GetElementType(), length);
			FillArray(arr);
			return arr;
		}

		private void FillArray(Array array, int count = 0, int[] elementId = null)
		{
			elementId = elementId ?? new int[array.Rank];

			for (int i = 0; i < array.GetLength(count); i++)
			{
				elementId[count] = i;

				if (count == array.Rank - 1)
					array.SetValue(_objCreator.CreateInstance(array.GetType().GetElementType()), elementId);
				else
					FillArray(array, count + 1, elementId);
			}
		}
	}
}
