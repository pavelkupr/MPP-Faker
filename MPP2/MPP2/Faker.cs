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
		private ObjCreator objCreator;

		public Faker()
		{
			objCreator = new ObjCreator();
		}

		public T Create<T>()
			where T : class
		{
			Type typeOfT = typeof(T);
			T instance = CreateObject(typeOfT) as T;
		
			if (instance != null)
			{
				SetProperties(instance, typeOfT);
			}
			return instance;
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
		private void SetProperties(object obj, Type type)
		{
			PropertyInfo[] myPrInfo;
			myPrInfo = type.GetProperties();
			for (int i=0;i < myPrInfo.Length;i++)
			{
				if (myPrInfo[i].CanWrite)
				{
					myPrInfo[i].SetValue(obj, objCreator.Create(myPrInfo[i].PropertyType));
				}
			}
		}
	}
}
