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
		private DTOCreator _DTOCreator;

		public Faker()
		{
			_DTOCreator = new DTOCreator();
		}

		public T Create<T>()
			where T : class
		{
			Type typeOfT = typeof(T);
			T instance = _DTOCreator.CreateInstance(typeOfT) as T;
			return instance;
		}	
	}
}
