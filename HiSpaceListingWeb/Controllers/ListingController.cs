using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using HiSpaceListingModels;
using HiSpaceListingWeb.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using HiSpaceListingWeb.ViewModel;

namespace HiSpaceListingWeb.Controllers
{
    public class ListingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
		//public IActionResult ListingTable()
		//{
		//	SetSessionVariables();
		//	if (ViewBag.UserId != null)
		//	{
		//		return View();
		//	}
		//	else
		//	{
		//		return View();
		//	}

		//}

		public IActionResult ListingTable(int UserID)
		{
			SetSessionVariables();
			User user = null;
			UserViewModel userViewModel = null;
			if (UserID != 0)
			{
				
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri(Common.Instance.ApiUserControllerName);
					//HTTP GET
					var responseTask = client.GetAsync(Common.Instance.ApiUserGetUser + UserID.ToString());
					responseTask.Wait();

					var result = responseTask.Result;
					if (result.IsSuccessStatusCode)
					{
						var readTask = result.Content.ReadAsAsync<User>();
						readTask.Wait();
						user = readTask.Result;
					}
					//user = new User();
					userViewModel = new UserViewModel
					{
						User = user
					};
				}
				

				return View(userViewModel);
			}
			else
			{
				return RedirectToAction("Index", "Website");
			}
				
		}
		
		public IActionResult ListingForm()
		{
			SetSessionVariables();
			return View();
		}
		public void SetSessionVariables()
		{
			#region
			User rs = HttpContext.Session.GetObjectFromJson<User>("_user");
			ViewBag.UserEmail = HttpContext.Session.GetString(Common.SessionUserEmail);
			ViewBag.UserId = HttpContext.Session.GetInt32(Common.SessionUserId);
			ViewBag.UserType = HttpContext.Session.GetInt32(Common.SessionUserType);
			ViewBag.UserCompanyName = HttpContext.Session.GetString(Common.SessionUserCompanyName);
			#endregion
		}

		public User GetSessionObject()
		{
			return HttpContext.Session.GetObjectFromJson<User>("_user");
		}
	}
}