using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP2
{
	namespace Generator
	{
		interface IGenerator
		{
			Type GeneratedType { get; }

			object Generate();
		}
	}
}
