using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Homework.Models.ViewModels
{
	public class AccountViewModel
	{
		public int No { get; set; }
		public string Category { get; set ; }
		public string Money{	get ; set ; }
		public string Date { get; set; }
		public string Description { get; set; }
	}
}