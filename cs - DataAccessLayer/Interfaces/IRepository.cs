using System;
using System.Collections.Generic;
using System.Text;

namespace csDataAccessLayer.Interfaces
{
	public interface IRepository<T>
	{
		List<int> GetHistory(int getById);
		T Write(T entity);
		List<T> Read(int idSender, int idReceiver);
	}
}
