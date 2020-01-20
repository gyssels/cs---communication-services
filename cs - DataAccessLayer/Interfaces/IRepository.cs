using System;
using System.Collections.Generic;
using System.Text;

namespace csDataAccessLayer.Interfaces
{
	public interface IRepository<T>
	{
		IEnumerable<int> GetHistory(int getById);
		T Write(T entity);
		IEnumerable<T> Read(int idSender, int idReceiver);
	}
}
