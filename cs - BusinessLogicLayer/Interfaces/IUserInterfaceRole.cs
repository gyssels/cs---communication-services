using csCrossCutting;
using System;
using System.Collections.Generic;
using System.Text;

namespace csBusinessLogicLayer.Interfaces
{
	public interface IUserInterfaceRole<T>
	{
		public List<int> GetHistory(int sender);

		public List<T> GetDiscussion(int sender, int receiver);

		public void SendMessage(T message);

		public void SendMessage(T message, List<int> receivers);
	}

}
