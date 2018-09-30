using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MPP2
{
	class DTOCreator
	{
		private ObjCreator objCreator;
		private byte counter;

		public DTOCreator()
		{
			objCreator = new ObjCreator();
		}

		public object CreateInstance(Type type)
		{
			ConstructorInfo[] constructorsInfo = type.GetConstructors();
			if (constructorsInfo.Length > 0 && counter < 2)
			{
				counter++;
				object[] pArr;
				object instance;
				int indexOfConstr = 0;

				for (int i = 1; i < constructorsInfo.Length; i++)
					if (constructorsInfo[i].GetParameters().Length > constructorsInfo[indexOfConstr].GetParameters().Length)
						indexOfConstr = i;

				pArr = SetParameters(constructorsInfo[indexOfConstr].GetParameters());
				try
				{
					instance = constructorsInfo[indexOfConstr].Invoke(pArr);
					SetProperties(instance, type);
				}
				catch
				{
					// Если возникло исключение, то объект точно не DTO
					instance = null;
				}
				counter--;
				return instance;
			}
			else
				return null;
		}

		private object[] SetParameters(ParameterInfo[] parameters)
		{
			object[] result = new object[parameters.Length];
			int i = 0;
			foreach (var parameter in parameters)
			{
				result[i] = objCreator.Create(parameter.ParameterType) ?? CreateInstance(parameter.ParameterType);
				i++;
			}
			return result;
		}

		private void SetProperties(object obj, Type type)
		{
			PropertyInfo[] myPrInfo;
			myPrInfo = type.GetProperties();
			for (int i = 0; i < myPrInfo.Length; i++)
			{
				if (myPrInfo[i].CanWrite)
				{
					object value = objCreator.Create(myPrInfo[i].PropertyType) ?? CreateInstance(myPrInfo[i].PropertyType);
					myPrInfo[i].SetValue(obj, value);
				}
			}
		}
	}
}
