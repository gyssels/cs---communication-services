using csCrossCutting;
using System;

namespace csBusinessLogicLayer.Domain
{
	public class MessageDomain
	{
		public StructMessage Message = new StructMessage();

		public MessageDomain()
		{
			Message.MessageType = MessageType.chat;
		}

		public MessageDomain(StructMessage message)
		{
			if (IsValid(message)) Message = message;
		}

		public bool IsValid(StructMessage message)
		{
			switch (message.MessageType)
			{
				case MessageType.chat:
					if (message.IdReceiver == 0) return false;
					if (message.Content == "") return false;
					return true;
				case MessageType.email:
					if (message.Email == "") return false;
					// if regex email valid
					if (message.Title == "") return false;
					if (message.Content == "") return false;
					return true;
				case MessageType.notification:
					if (message.IdReceiver == 0) return false;
					return true;
				default:
					return false;
			}
		}
	}
}
