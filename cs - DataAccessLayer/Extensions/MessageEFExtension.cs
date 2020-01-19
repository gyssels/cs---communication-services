using csBusinessLogicLayer.Domain;
using csCrossCutting;
using csDataAccessLayer.Entities;

namespace csDataAccessLayer.Extensions
{
	public static class MessageEFExtension
	{
		public static MessageTO ToTO(this MessageEF message)
		{
			StructMessage _message = new StructMessage();
			_message.Id = message.Id;
			_message.IdSender = message.IdSender;
			_message.IdReceiver = message.IdReceiver;
			_message.MessageType = (MessageType) message.MessageType;
			_message.IsSent = message.IsSent;
			_message.Title = message.Title;
			_message.Content = message.Content;
			_message.Date = message.Date;
			_message.Email = message.Email;
			return new MessageTO(_message);
		}

		public static MessageEF ToEF(this MessageTO message)
		{
			return new MessageEF(message.Message);
		}
	}
}
