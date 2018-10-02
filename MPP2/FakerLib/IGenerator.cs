using System;

namespace FakerLib
{
	namespace Generator
	{
		public interface IGenerator
		{
			Type[] GeneratedTypes { get; }

			object Generate(Type type);
		}
	}
}
