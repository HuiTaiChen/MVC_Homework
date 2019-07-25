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

		public IEnumerable<AccountBook> Lookup()
		{
			return _MoneyRepository.LookupAll();
		}

		public AccountBook GetSingle(Guid orderId)
		{
			return _MoneyRepository.GetSingle(d => d.Id == orderId);
		}

		

		public void Edit(AccountBook pageData, AccountBook oldData)
		{
			oldData.Amounttt = pageData.Amounttt;
			oldData.Dateee = pageData.Dateee;
			oldData.Id = pageData.Id;
		}

		public void Delete(AccountBook data)
		{
			_MoneyRepository.Remove(data);
		}
	}
}