using csBusinessLogicLayer.Domain;
using csCrossCutting;
using csDataAccessLayer.Entities;
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

		public IEnumerable<int> GetHistory(int getByIdSender)
		{
			return _context.Messages.Where(x => x.IdSender == getByIdSender)
									.Select(x => x.IdReceiver)
									.ToList();
		}

		public IEnumerable<MessageTO> Read(int idSender, int idReceiver)
		{
			return _context.Messages.Where(x => x.IdSender == idSender)
									.Where(x => x.IdReceiver == idReceiver)
									.Select(x => x.ToTO())
									.ToList();
		}

		public MessageTO Write(MessageTO entity)
		{
			return _context.Update(entity.ToEF()).Entity.ToTO();
		}

		public void Erase()
		{
			List<int> list = _context.Messages.Select(x => x.Id).ToList();
			foreach (var id in list)
			{
				_context.Messages.Remove(new MessageEF(new StructMessage() { Id = id}));
			}
		}

		public void Delete(MessageTO entity)
		{
			_context.Remove(entity.ToEF());
		}

		public void Commit() => _context.SaveChanges();

		public void Dispose() => _context.Dispose();
	}
}
