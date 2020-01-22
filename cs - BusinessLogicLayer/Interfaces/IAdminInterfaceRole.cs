using csCrossCutting;
using System;
using System.Collections.Generic;
using System.Text;

namespace csBusinessLogicLayer.Interfaces
{
	public interface IAdminInterfaceRole<T> : IUserInterfaceRole<T>
	{
		public void Delete(T entity);
	}

}
