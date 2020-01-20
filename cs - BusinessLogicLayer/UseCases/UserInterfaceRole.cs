using csBusinessLogicLayer.Domain;
using csCrossCutting;
using csDataAccessLayer.UnitOfWorks;
using csBusinessLogicLayer.Extensions;
using System;
using System.Collections.Generic;
using csBusinessLogicLayer.Interfaces;

namespace csBusinessLogicLayer.UseCases
{
	public class UserInterfaceRole : IUserInterfaceRole<MessageTO>
	{
		public UserInterfaceRole()
		{

		}

		public IEnumerable<int> GetHistory(int sender)
		{
			UnitOfWork unitOfWork = new UnitOfWork(new CSContext());

			IEnumerable<int> receivers = unitOfWork.MessageRepository.GetHistory(sender);
			unitOfWork.Commit();
			unitOfWork.Dispose();
			return receivers;
		}

		public IEnumerable<MessageTO> GetDiscussion(int sender, int receiver)
		{
			UnitOfWork unitOfWork = new UnitOfWork(new CSContext());

			IEnumerable<MessageTO> messages = unitOfWork.MessageRepository.Read(sender, receiver);
			unitOfWork.Commit();
			unitOfWork.Dispose();
			return messages;
		}

		public bool SendMessage(MessageTO message)
		{
			MessageDomain _message = message.ToDomain();

			if (!_message.IsEmpty)
				switch (_message.Message.MessageType)
				{
					case MessageType.chat:
						return _message.SendMessage();
					case MessageType.email:
						return _message.SendMail();
				}
			return false;
		}

		public bool SendMessage(MessageTO message, List<int> receivers)
		{
			if (message.ToDomain() == null)
				return false;
			foreach (int receiver in receivers)
			{
				message.Message.IdReceiver = receiver;
				SendMessage(message);
			}
			return true;
		}
	}
}
