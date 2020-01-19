using csBusinessLogicLayer.Domain;
using csCrossCutting;
using csDataAccessLayer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace csBusinessLogicLayer.Extensions
{
	public static class Helper
	{
		public static void SaveMessage(this MessageDomain message)
		{
			UnitOfWork unitOfWork = new UnitOfWork(new CSContext());

			unitOfWork.MessageRepository.Write(message.ToTO());
			unitOfWork.Commit();
			unitOfWork.Dispose();
		}

		public static void SendMessage(this MessageDomain message)
		{
			// check si le destinataire est connecté
			SaveMessage(message);
		}

		public static void SendMail(this MessageDomain message)
		{
			// envoyer un email
			SaveMessage(message);
		}
	}
}
