using csBusinessLogicLayer.Domain;
using csCrossCutting;
using System;
using System.Collections.Generic;
using System.Text;

namespace csBusinessLogicLayer.Extensions
{
	public static class MessageDomainExtension
	{
		public static MessageTO ToTO(this MessageDomain message)
		{
			return new MessageTO(message.Message);
		}

		public static MessageDomain ToDomain(this MessageTO message)
		{
			return new MessageDomain(message.Message);
		}
	}
}
