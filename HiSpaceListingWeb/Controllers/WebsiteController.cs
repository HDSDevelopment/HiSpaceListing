using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace HiSpaceListingWeb.Controllers
{
	public class WebsiteController : Controller
	{

		public ActionResult Index()
		{
			return View();
		}
		public ActionResult About()
		{
			return View();
		}
		public ActionResult Contact()
		{
			return View();
		}
		public ActionResult PropertyGrid()
		{
			return View();
		}
		public ActionResult PropertyList()
		{
			return View();
		}
		public ActionResult PropertyLister()
		{
			return View();
		}
		public ActionResult PropertyListMap()
		{
			return View();
		}
		public ActionResult PropertyDetail()
		{
			return View();
		}


	}
}