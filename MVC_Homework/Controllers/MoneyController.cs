using MVC_Homework.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Homework.Models;
using System.Data.Entity;
using MVC_Homework.Service;

namespace MVC_Homework.Controllers
{
	public class MoneyController : Controller
	{
		//20190717 抽成Service
		private readonly MoneyService _moneyService;

		public MoneyController()
		{
			_moneyService = new MoneyService();
		}

		// GET: Money
		public ActionResult Money()
		{
			List<AccountViewModel> viewModels = new List<AccountViewModel> { };
			//20190717 改由真DB串接，抽成Service
			var accountbookList = _moneyService.Lookup();
			int i = 0;
			foreach (var item in accountbookList)
			{

				AccountViewModel data = new AccountViewModel
				{
					No = ++i,
					Money = item.Amounttt.ToString("###,###"),
					Date = item.Dateee.ToString("yyyy-MM-dd"),
					Category = item.Categoryyy == 0 ? "支出" : "收入"
				};
				viewModels.Add(data);
			}
			//Random rnd = new Random();
			//for (int i = 1; i <= 100; i++)
			//{
			//	AccountViewModel data = new AccountViewModel
			//	{
			//		No = i,
			//		Money = rnd.Next(10000).ToString("###,###"),
			//		Date = DateTime.Now.AddDays(-(rnd.Next(100))).ToString("yyyy-MM-dd"),
			//		Category = rnd.Next(2) == 1 ? "支出" : "收入"
			//	};				
			//}

			return View(viewModels);
		}
	}
}