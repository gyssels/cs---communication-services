using System;

namespace csBusinessLogicLayer.Domain
{
	internal class MessageDomain : IDisposable
	{
		internal StructMessage Message = new StructMessage();

		private bool _isEmpty;

		public bool IsEmpty
		{
			get
			{
				return _isEmpty;
			}
		}

		internal MessageDomain(StructMessage message)
		{
			_isEmpty = false;
			if (IsValid(message)) Message = message;
			else Dispose();
		}

		public void Dispose()
		{
			_isEmpty = true;
			GC.SuppressFinalize(this);
		}

		private bool IsValid(StructMessage message)
		{
			switch (message.MessageType)
			{
				case MessageType.chat:
					if (message.IdReceiver == 0) return false;
					if (message.Content == null) return false;
					break;
				case MessageType.email:
					if (message.Email == null) return false;
					// if regex email valid
					if (message.Title == null) return false;
					if (message.Content == null) return false;
					break;
				case MessageType.notification:
					if (message.IdReceiver == 0) return false;
					break;
			}
			return true;
		}
	}
}
