using System;

namespace FakerLib
{
	interface ICreator
	{
		object CreateInstance(Type type);
	}
}
