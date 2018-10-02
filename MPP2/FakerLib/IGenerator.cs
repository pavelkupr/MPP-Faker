using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
