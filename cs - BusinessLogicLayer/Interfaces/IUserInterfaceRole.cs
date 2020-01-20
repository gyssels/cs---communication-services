using csCrossCutting;
using System;
using System.Collections.Generic;
using System.Text;

namespace csBusinessLogicLayer.Interfaces
{
	public interface IUserInterfaceRole<T>
	{
		public IEnumerable<int> GetHistory(int sender);

		public IEnumerable<T> GetDiscussion(int sender, int receiver);

		public bool SendMessage(T message);

		public bool SendMessage(T message, List<int> receivers);
	}

}
