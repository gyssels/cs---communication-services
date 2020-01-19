using csCrossCutting;
using csDataAccessLayer.Extensions;
using csDataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace csDataAccessLayer.UnitOfWorks
{
	public class MessageRepository : IRepository<MessageTO>
	{
		private readonly CSContext _context;

		public MessageRepository(CSContext context) => _context = context;

		public List<int> GetHistory(int getByIdSender)
		{
			return _context.Messages.Where(x => x.IdSender == getByIdSender)
									.Select(x => x.IdSender)
									.ToList();
		}

		public List<MessageTO> Read(int idSender, int idReceiver)
		{
			return _context.Messages.Where(x => x.IdSender == idSender)
									.Where(x => x.IdReceiver == idReceiver)
									.Select(x => x.ToTO())
									.ToList();
		}

		public MessageTO Write(MessageTO entity)
		{
			_context.Add(entity.ToEF());
			Commit();
			return entity;
		}

		public void Commit() => _context.SaveChanges();

		public void Dispose() => _context.Dispose();
	}
}
