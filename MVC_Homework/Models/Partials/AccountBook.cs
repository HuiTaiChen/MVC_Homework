using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Homework.Models
{
	public partial class AccountBook
	{
		[MetadataType(typeof(AccountBookMD))]
		public class AccountBookMD
		{
			public System.Guid Id { get; set; }
			public int Categoryyy { get; set; }
			public int Amounttt { get; set; }
			public System.DateTime Dateee { get; set; }
			public string Remarkkk { get; set; }
		}
	}
}