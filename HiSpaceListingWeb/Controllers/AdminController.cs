using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HiSpaceListingModels;
using HiSpaceListingWeb.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiSpaceListingWeb.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminLister()
        {
			SetSessionVariables();
			IEnumerable<User> users = null;
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Common.Instance.ApiUserControllerName);
				//HTTP GET
				var responseTask = client.GetAsync(Common.Instance.ApiUserGetUsers);
				responseTask.Wait();
				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<IList<User>>();
					readTask.Wait();
					users = readTask.Result;
				}
				else
				{
					users = Enumerable.Empty<User>();
					ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
				}
			}
			return View(users);
        }
        public ActionResult ListerCreate()
        {
			SetSessionVariables();
			return View();
        } 
		public ActionResult ListerEdit()
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
