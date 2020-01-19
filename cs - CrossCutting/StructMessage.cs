using System;

namespace csBusinessLogicLayer.Domain
{
	public struct StructMessage
	{
		public int Id { get; set; }
		public int IdSender { get; set; }
		public int IdReceiver { get; set; }
		public MessageType MessageType { get; set; }
		public string Title { get; set; }
		public string Email { get; set; }
		public DateTime Date { get; set; }
		public bool IsSent { get; set; }
		public string Content { get; set; }
	}
}
