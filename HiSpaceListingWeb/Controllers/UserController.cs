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
	public class UserController : Controller
	{
		[HttpPost]
		public ActionResult Login(User user)
		{
			User _user = null;
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Common.Instance.ApiUserControllerName);
				var responseTask = client.PostAsJsonAsync(Common.Instance.ApiUserAuthenticateUser, user);
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<User>();
					readTask.Wait();
					_user = readTask.Result;
				}
			}
			if (_user != null && _user.Email == user.Email && _user.Password == user.Password)
			{
				AssignSessionVariables(_user);
				SetSessionVariables();
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ViewData["loginError"] = "err = Incorrect username or password.";
				return RedirectToAction("Privacy", "Home");
			}
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

		public void AssignSessionVariables(User _user)
		{
			HttpContext.Session.SetObjectAsJson("_user", _user);
			HttpContext.Session.SetString(Common.SessionUserEmail, _user.Email);
			int? UserType = _user.UserType;
			var _UserType = UserType.Value;
			HttpContext.Session.SetInt32(Common.SessionUserType, _UserType);
			HttpContext.Session.SetInt32(Common.SessionUserId, _user.UserId);
			HttpContext.Session.SetString(Common.SessionUserCompanyName, _user.CompanyName);
		}

		public User GetSessionObject()
		{
			return HttpContext.Session.GetObjectFromJson<User>("_user");
		}
	}
}