using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Homework.Models;
using System.Data.Entity;
using MVC_Homework.Models.ViewModels;
using MVC_Homework.Repository;

namespace MVC_Homework.Service
{
	public class MoneyService
	{
		private readonly IRepository<AccountBook> _MoneyRepository;

		public MoneyService(IUnitOfWork unitOfWork)
		{
			_MoneyRepository = new Repository<AccountBook>(unitOfWork);
		}

		public void Add(string Categoryyy, string Amounttt, string Dateee, Guid Id)
		{
			_MoneyRepository.Create(new AccountBook
			{
				Amounttt = Convert.ToInt32(Amounttt),
				Dateee = Convert.ToDateTime(Dateee),
				Id = Id
			});
		}

		public IEnumerable<AccountViewModel> Lookup()
		{
			return covertViewModel(_MoneyRepository.LookupAll());
		}

		public IEnumerable<AccountViewModel> GetSingle(Guid orderId)
		{
			return covertViewModel(_MoneyRepository.GetSingle(d => d.Id == orderId));
		}



		public void Edit(AccountViewModel pageData, AccountViewModel oldData)
		{
			oldData.Money = pageData.Money;
			oldData.Date = pageData.Date;
			oldData.No = pageData.No;
		}

		public void Delete(AccountViewModel data)
		{
			_MoneyRepository.Remove(covertModel(data));
		}

		private IEnumerable<AccountViewModel> covertViewModel(IEnumerable<AccountBook> accountBook)
		{
			var viewModels = new List<AccountViewModel>();
			int i = 0;
			foreach (var item in accountBook)
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
			return viewModels;
		}
		private IEnumerable<AccountViewModel> covertViewModel(AccountBook accountBook)
		{
			var viewModels = new List<AccountViewModel>();
			int i = 0;

			AccountViewModel data = new AccountViewModel
			{
				No = ++i,
				Money = accountBook.Amounttt.ToString("###,###"),
				Date = accountBook.Dateee.ToString("yyyy-MM-dd"),
				Category = accountBook.Categoryyy == 0 ? "支出" : "收入"
			};
			viewModels.Add(data);

			return viewModels;
		}
		private AccountBook covertModel(AccountViewModel accountViewModel)
		{
			var accountbook = new AccountBook();
			
			AccountBook data = new AccountBook
			{				
				Amounttt = Convert.ToInt32(accountViewModel.Money),
				Dateee = Convert.ToDateTime(accountViewModel.Date),
				Categoryyy = Convert.ToInt32(accountViewModel.Category )
			};
			

			return data;
		}

	}
}