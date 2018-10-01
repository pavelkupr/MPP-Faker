using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP2
{
	interface ICreator
	{
		object CreateInstance(Type type);
	}
}
