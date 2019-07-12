using MVC_Homework.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Homework.Controllers
{
    public class MoneyController : Controller
    {
        
      // GET: Money
		public ActionResult Money()
		{
			List<AccountViewModel> viewModels = new List<AccountViewModel> { };

			Random rnd = new Random();
			for (int i = 1; i <= 100; i++)
			{
				AccountViewModel data = new AccountViewModel
				{
					No = i,
					Money = rnd.Next(10000).ToString("###,###"),
					Date = DateTime.Now.AddDays(-(rnd.Next(100))).ToString("yyyy-MM-dd"),
					Category = rnd.Next(2) == 1 ? "支出" : "收入"
				};
				viewModels.Add(data);
			}
			return View(viewModels);
		}
    }
}