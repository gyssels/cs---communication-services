using csBusinessLogicLayer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace csDataAccessLayer.Entities
{
	public class MessageEF
	{
		public int Id { get; set; }
		public int IdSender { get; set; }
		public int IdReceiver { get; set; }
		public int MessageType { get; set; }
		public string Title { get; set; }
		public string Email { get; set; }
		public DateTime Date { get; set; }
		public bool IsSent { get; set; }
		public string Content { get; set; }

		public MessageEF(StructMessage message)
		{
			Id = message.Id;
			IdSender = message.IdSender;
			IdReceiver = message.IdReceiver;
			MessageType = (int) message.MessageType;
			Title = message.Title;
			Email = message.Email;
			Date = message.Date;
			IsSent = message.IsSent;
			Content = message.Content;
		}
	}
}
