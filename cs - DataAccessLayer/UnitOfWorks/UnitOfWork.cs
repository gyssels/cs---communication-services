using csDataAccessLayer.Interfaces;

namespace csDataAccessLayer.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		public MessageRepository MessageRepository { get; set; }

		public UnitOfWork(CSContext context) => MessageRepository = new MessageRepository(context);

		public void Commit() => MessageRepository.Commit();

		public void Dispose() => MessageRepository.Dispose();
	}
}
