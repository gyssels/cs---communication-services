using csBusinessLogicLayer.Domain;
using csBusinessLogicLayer.Extensions;
using csCrossCutting;
using Xunit;

namespace csTests
{
	public class TestDomain
	{
		[Fact]
		public void MessageDomainEmpty()
		{
			MessageDomain message = new MessageDomain();

			Assert.False(message.IsValid(message.Message));
		}

		[Fact]
		public void MessageDomain_Equal_MessageTO()
		{
			MessageDomain message = new MessageDomain();
			message.Message.Date = new System.DateTime();
			message.Message.Id = 15;

			MessageTO messageTO = message.ToTO();

			Assert.Equal(messageTO.Message, message.Message);

			message.Message.Id = 13;

			Assert.NotEqual(messageTO.Message, message.Message);
		}
	}
}
