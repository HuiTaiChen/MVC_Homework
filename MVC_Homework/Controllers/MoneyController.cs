using MVC_Homework.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Homework.Models;
using System.Data.Entity;
using MVC_Homework.Service;
using MVC_Homework.Repository;

namespace MVC_Homework.Controllers
{
	public class MoneyController : Controller
	{
		//20190717 抽成Service
		private readonly MoneyService _moneyService;
		private readonly UnitOfWork _unitOfWork;

		public MoneyController()
		{
			_unitOfWork = new UnitOfWork();
			_moneyService = new MoneyService(_unitOfWork);
		}

		// GET: Money
		public ActionResult Money()
		{
			var viewModels = new List<AccountViewModel>();
			var accountbookList = _moneyService.Lookup();
			viewModels.AddRange(accountbookList);

			return View(viewModels);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Money([Bind(Include = "Category,Money,Date,Description")]AccountViewModel accountBook)
		{
			if (ModelState.IsValid)
			{
				_moneyService.Add(accountBook);
				_unitOfWork.Commit();
			}

			return RedirectToAction("Money");

		}
	}
}