using csBusinessLogicLayer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace csCrossCutting
{
	public class MessageTO
	{
		public StructMessage Message;

		public MessageTO(StructMessage message)
		{
			Message = message;
		}
	}
}
