using csBusinessLogicLayer.Domain;
using csCrossCutting;
using csDataAccessLayer.UnitOfWorks;
using csBusinessLogicLayer.Extensions;
using System;
using System.Collections.Generic;
using csBusinessLogicLayer.Interfaces;

namespace csBusinessLogicLayer.UseCases
{
	public class AdminInterfaceRole : IAdminInterfaceRole<MessageTO>
	{
		public AdminInterfaceRole()
		{

		}

		public void Erase()
		{
			UnitOfWork unitOfWork = new UnitOfWork(new CSContext());

			unitOfWork.MessageRepository.Erase();
			unitOfWork.Commit();
			unitOfWork.Dispose();
		}

		public void Delete(MessageTO entity)
		{
			UnitOfWork unitOfWork = new UnitOfWork(new CSContext());

			unitOfWork.MessageRepository.Delete(entity);
			unitOfWork.Commit();
			unitOfWork.Dispose();
		}

		public IEnumerable<MessageTO> GetDiscussion(int sender, int receiver)
		{
			UserInterfaceRole system = new UserInterfaceRole();
			return system.GetDiscussion(sender, receiver);
		}

		public IEnumerable<int> GetHistory(int sender)
		{
			UserInterfaceRole system = new UserInterfaceRole();
			return system.GetHistory(sender);
		}

		public bool SendMessage(MessageTO message)
		{
			UserInterfaceRole system = new UserInterfaceRole();
			return system.SendMessage(message);
		}

		public bool SendMessage(MessageTO message, List<int> receivers)
		{
			UserInterfaceRole system = new UserInterfaceRole();
			return system.SendMessage(message, receivers);
		}
	}
}
