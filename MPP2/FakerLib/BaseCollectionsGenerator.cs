using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using FakerLib.Generator;

namespace FakerLib
{
	class BaseCollectionsGenerator : IGenerator
	{
		public Type[] GeneratedTypes => new[] { typeof(List<>), typeof(Stack<>), typeof(Queue<>) };
		private ObjCreator _objCreator;

		public BaseCollectionsGenerator()
		{
			_objCreator = new ObjCreator();
		}

		public BaseCollectionsGenerator(ObjCreator objCreator)
		{
			_objCreator = objCreator ?? throw new ArgumentNullException();
		}

		public object Generate(Type type)
		{
			if (!GeneratedTypes.Contains(type.GetGenericTypeDefinition()))
				throw new ArgumentException();

			ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(IEnumerable<>).MakeGenericType(type.GenericTypeArguments) });

			object[] args = new[] { _objCreator.CreateInstance(type.GenericTypeArguments[0].MakeArrayType()) };

			return constructor.Invoke(args);
		}
	}
}
