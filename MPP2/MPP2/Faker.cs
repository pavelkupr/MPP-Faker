using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MPP2
{
	class Faker
	{
		public T Create<T>()
			where T : class
		{
			T t = null;
			return t;
		}

		private object CreateObject(Type type)
		{
			ConstructorInfo[] constructorsInfo = type.GetConstructors();
			if (constructorsInfo.Length > 0)
			{
				int indexOfConstructor = 0, paramCount = 0;
				for (int i = 0; i < constructorsInfo.Length; i++)
				{
					if (constructorsInfo[i].GetParameters().Length > paramCount)
					{
						paramCount = constructorsInfo[i].GetParameters().Length;
						indexOfConstructor = i;
					}
				}
				object[] paramArr = new object[paramCount];
				//заполнение массива
				return constructorsInfo[indexOfConstructor].Invoke(paramArr);
			}
			else
				return null;
		}
	}
}
