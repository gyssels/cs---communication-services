using csBusinessLogicLayer.Domain;
using csCrossCutting;
using System;
using System.Collections.Generic;
using System.Text;

namespace csBusinessLogicLayer.Extensions
{
	internal static class MessageDomainExtension
	{
		internal static MessageTO ToTO(this MessageDomain message)
		{
			return new MessageTO(message.Message);
		}

		internal static MessageDomain ToDomain(this MessageTO message)
		{
			return new MessageDomain(message.Message);
		}
	}
}
