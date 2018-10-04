using System;
using System.Collections.Generic;
using System.Reflection;

namespace FakerLib
{
	class DTOCreator : ICreator
	{
		private ObjCreator objCreator;
		private List<Type> parentTypes;
		private Stack<Type> nesting;

		public DTOCreator()
		{
			objCreator = new ObjCreator();
			parentTypes = new List<Type>();
			nesting = new Stack<Type>();
		}

		public object CreateInstance(Type type)
		{
			bool isNotRecurtion = false;

			if (nesting.Count == 0)
				isNotRecurtion = true;
			else if (!parentTypes.Contains(nesting.Peek()))
				isNotRecurtion = true;

			ConstructorInfo[] constructorsInfo = type.GetConstructors();
			if (constructorsInfo.Length > 0 && isNotRecurtion)
			{
				object instance;
				int indexOfConstr = 0;

				if (nesting.Count != 0)
					parentTypes.Add(nesting.Peek());
				nesting.Push(type);

				for (int i = 1; i < constructorsInfo.Length; i++)
					if (constructorsInfo[i].GetParameters().Length > constructorsInfo[indexOfConstr].GetParameters().Length)
						indexOfConstr = i;

				try
				{
					instance = CallConstructor(constructorsInfo[indexOfConstr]);
					SetProperties(instance, type);
					SetFields(instance, type);
				}
				// Если возникло исключение, то объект точно не DTO
				catch
				{
					instance = null;
				}
				nesting.Pop();
				if (nesting.Count != 0)
					parentTypes.Remove(nesting.Peek());
				return instance;
			}
			else
				return null;
		}

		private object CallConstructor(ConstructorInfo constructor)
		{
			ParameterInfo[] parametersInfo = constructor.GetParameters();
			object[] parameters = new object[parametersInfo.Length];
			int i = 0;
			foreach (var parameterInfo in parametersInfo)
			{
				parameters[i] = objCreator.CreateInstance(parameterInfo.ParameterType) ?? CreateInstance(parameterInfo.ParameterType);
				i++;
			}
			return constructor.Invoke(parameters);
		}

		private void SetProperties(object obj, Type type)
		{
			PropertyInfo[] propertyInfo = type.GetProperties();
			for (int i = 0; i < propertyInfo.Length; i++)
			{
				if (propertyInfo[i].CanWrite)
				{
					object value = objCreator.CreateInstance(propertyInfo[i].PropertyType) ?? CreateInstance(propertyInfo[i].PropertyType);
					propertyInfo[i].SetValue(obj, value);
				}
			}
		}

		private void SetFields(object obj, Type type)
		{
			FieldInfo[] fieldInfo = type.GetFields();
			for (int i = 0; i < fieldInfo.Length; i++)
			{
				if (!(fieldInfo[i].IsInitOnly || fieldInfo[i].IsStatic))
				{
					object value = objCreator.CreateInstance(fieldInfo[i].FieldType) ?? CreateInstance(fieldInfo[i].FieldType);
					fieldInfo[i].SetValue(obj, value);
				}
			}
		}
	}
}
