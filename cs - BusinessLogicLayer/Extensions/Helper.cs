using csBusinessLogicLayer.Domain;
using csDataAccessLayer.UnitOfWorks;

namespace csBusinessLogicLayer.Extensions
{
	internal static class Helper
	{
		internal static void SaveMessage(this MessageDomain message)
		{
			UnitOfWork unitOfWork = new UnitOfWork(new CSContext());

			unitOfWork.MessageRepository.Write(message.ToTO());
			unitOfWork.Commit();
			unitOfWork.Dispose();
		}

		internal static bool SendMessage(this MessageDomain message)
		{
			// envois le message et previens si il a été bien recu
			SaveMessage(message);
			return true;
		}

		internal static bool SendMail(this MessageDomain message)
		{
			// envoyer un email
			// SaveMessage(message);
			return true;
		}
	}
}
