using csBusinessLogicLayer.Domain;
using csBusinessLogicLayer.UseCases;
using csCrossCutting;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace csBLLTests
{
	public class TestBLL
	{
		[Fact]
		public void UserInterfaceTest()
		{
			//			UserInterfaceRole AssistanteRole = new UserInterfaceRole();
			AdminInterfaceRole AssistanteRole = new AdminInterfaceRole();
			AdminInterfaceRole Garbage = new AdminInterfaceRole();

			StructMessage structure = new StructMessage()
			{
				MessageType = MessageType.chat,
				IdSender = 1,
				IdReceiver = 2,
				Title = "subject",
				Email = "tarik@t-knix.be",
				Content = "",
				IsSent = false,
				Date = new DateTime(),
				Id = 0
			};

			MessageTO message0 = new MessageTO(new StructMessage());
			Assert.False(AssistanteRole.SendMessage(message0));

			MessageTO message = new MessageTO(structure);
			Assert.True(AssistanteRole.SendMessage(message));

			structure.IdReceiver = 3;
			structure.MessageType = MessageType.email;
			MessageTO message1 = new MessageTO(structure);
			Assert.True(AssistanteRole.SendMessage(message1));

			structure.MessageType = MessageType.notification;
			MessageTO message2 = new MessageTO(structure);
			Assert.False(AssistanteRole.SendMessage(message2));

			Garbage.Erase();

			Assert.Equal(new List<int>() { },AssistanteRole.GetHistory(1));
		}
	}
}
