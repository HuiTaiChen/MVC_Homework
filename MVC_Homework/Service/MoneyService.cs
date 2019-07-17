using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Homework.Models;
using System.Data.Entity;

namespace MVC_Homework.Service
{
	public class MoneyService
	{
		private readonly SkillTreeHomeworkEntities _db;
		public MoneyService()
		{
			_db = new SkillTreeHomeworkEntities();
		}
		public IEnumerable<AccountBook> Lookup()
		{

			return _db.AccountBook.ToList();
		}

		public AccountBook GetSingle(Guid AccountBookId)
		{
			return _db.AccountBook.Find(AccountBookId);
		}

		public void Add(AccountBook AccountBook)
		{
			_db.AccountBook.Add(AccountBook);			
		}

		public void Edit(AccountBook pageData, AccountBook oldData)
		{
			oldData.Amounttt = pageData.Amounttt;
			oldData.Categoryyy = pageData.Categoryyy;
			oldData.Dateee = pageData.Dateee;
		}

		public void Delete(AccountBook data)
		{
			_db.AccountBook.Remove(data);
		}

		public void Save()
		{
			_db.SaveChanges();
		}
		
	}
}