using csDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace csDataAccessLayer.Interfaces
{
	interface IUnitOfWork
	{
		void Commit();
		void Dispose();
	}
}
