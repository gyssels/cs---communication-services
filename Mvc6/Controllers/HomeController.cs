using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using csCrossCutting;
using csDataAccessLayer.Interfaces;
using csDataAccessLayer.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc6.Models;
using csBusinessLogicLayer.Interfaces;
using csBusinessLogicLayer.UseCases;

namespace Mvc6.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			IUserInterfaceRole<MessageTO> role = new UserInterfaceRole(); // Attention not injected...

			role.GetDiscussion(1,2);
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
