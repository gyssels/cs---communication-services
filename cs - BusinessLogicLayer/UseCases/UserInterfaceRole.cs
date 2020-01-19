using csBusinessLogicLayer.Domain;
using csCrossCutting;
using csDataAccessLayer.UnitOfWorks;
using csBusinessLogicLayer.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using csBusinessLogicLayer.Interfaces;

namespace csBusinessLogicLayer.UseCases
{
	public class UserInterfaceRole : IUserInterfaceRole<MessageTO>
	{
		public UserInterfaceRole()
		{

		}

		public List<int> GetHistory(int sender)
		{
			UnitOfWork unitOfWork = new UnitOfWork(new CSContext());

			List<int> receivers = unitOfWork.MessageRepository.GetHistory(sender);
			unitOfWork.Commit();
			unitOfWork.Dispose();
			return receivers;
		}

		public List<MessageTO> GetDiscussion(int sender, int receiver)
		{
			UnitOfWork unitOfWork = new UnitOfWork(new CSContext());

			List<MessageTO> messages = unitOfWork.MessageRepository.Read(sender, receiver);
			unitOfWork.Commit();
			unitOfWork.Dispose();
			return messages;
		}

		public void SendMessage(MessageTO message)
		{
			MessageDomain _message = message.ToDomain();

			if (_message != null)
				switch (_message.Message.MessageType)
				{
					case MessageType.chat:
						_message.SendMessage();
						break;
					case MessageType.email:
						_message.SendMail();
						break;
				}
		}

		public void SendMessage(MessageTO message, List<int> receivers)
		{
			foreach (int receiver in receivers)
			{
				message.Message.IdReceiver = receiver;
				SendMessage(message);
			}
		}
	}
}
