using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HiSpaceListingModels;
using HiSpaceListingWeb.Utilities;
using HiSpaceListingWeb.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Hosting;

namespace HiSpaceListingWeb.Controllers
{
	public class UserController : Controller
	{
		private readonly IHostEnvironment hostEnvironment;
		public UserController(IHostEnvironment hostEnvironment)
		{
			this.hostEnvironment = hostEnvironment;
		}

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
				return RedirectToAction("ListingTable", "Listing", new { UserID = _user.UserId });
				//			return RedirectToAction("ListingTable", new RouteValueDictionary(
				//new { controller = "Listing", action = "ListingTable", UserID = _user.UserId }));
			}
			else
			{
				ViewData["loginError"] = "err = Incorrect username or password.";
				return RedirectToAction("Index", "Website");
			}
		}

		[HttpPost]
		public ActionResult Create(User model)
		{
			SetSessionVariables();
			if(model != null)
			{
				model.UserType = 1;
				User NewUser = new User();
				using(var client = new HttpClient())
				{
					client.BaseAddress = new Uri(Common.Instance.ApiUserControllerName);
					//HTTP POST
					var postTask = client.PostAsJsonAsync<User>
						(Common.Instance.ApiUserAddUser, model);
					postTask.Wait();
					var result = postTask.Result;
					if (result.IsSuccessStatusCode)
					{
						var rs = result.Content.ReadAsAsync<User>();
						//return RedirectToAction("Index");
						model = rs.Result;
					}

				}
				ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
			}
			return RedirectToAction("Index", "Website");
		}
		// POST: Edit
		[HttpPost]
		public ActionResult Edit(UserViewModel model)
		{
			SetSessionVariables();

			User user = null;


			string DuplicateName = "";
			string OriginalName = "";
			string UploadRootPath = "wwwroot\\images\\Upload";
			string UploadRootPath_removeRoot = "images\\Upload";
			string uploadsFolder = "\\user\\" + GetSessionObject().UserId + "\\documents\\";
			string serverUploadsFolder = Path.Combine(hostEnvironment.ContentRootPath, UploadRootPath);
			serverUploadsFolder += uploadsFolder;
			if (!Directory.Exists(serverUploadsFolder))
			{
				Directory.CreateDirectory(serverUploadsFolder);
			}

			//RCCopy image uploader
			if (model.RCCopy != null)
			{
				OriginalName = model.RCCopy.FileName;
				string extension = Path.GetExtension(OriginalName);
				DuplicateName = "_RCCopy" + extension;

				string filePath = Path.Combine(serverUploadsFolder, DuplicateName);
				model.RCCopy.CopyTo(new FileStream(filePath, FileMode.Create));
				model.User.Doc_RCCopy = "\\" + UploadRootPath_removeRoot + uploadsFolder + DuplicateName;
			}
			//PANCopy image uploader
			if (model.PANCopy != null)
			{
				OriginalName = model.PANCopy.FileName;
				string extension = Path.GetExtension(OriginalName);
				DuplicateName = "_PANCopy" + extension;

				string filePath = Path.Combine(serverUploadsFolder, DuplicateName);
				model.PANCopy.CopyTo(new FileStream(filePath, FileMode.Create));
				model.User.Doc_PANCopy = "\\" + UploadRootPath_removeRoot + uploadsFolder + DuplicateName;
			}
			//Logo image uploader
			if (model.Logo != null)
			{
				OriginalName = model.Logo.FileName;
				string extension = Path.GetExtension(OriginalName);
				DuplicateName = "_Logo" + extension;

				string filePath = Path.Combine(serverUploadsFolder, DuplicateName);
				model.Logo.CopyTo(new FileStream(filePath, FileMode.Create));
				model.User.Doc_CompanyLogo = "\\" + UploadRootPath_removeRoot + uploadsFolder + DuplicateName;
			}


			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Common.Instance.ApiUserControllerName);
				//HTTP GET
				var responseTask = client.PutAsJsonAsync(Common.Instance.ApiUserUpdateUser + model.User.UserId, model.User);
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<User>();
					readTask.Wait();

					user = readTask.Result;
				}
			}
			return RedirectToAction("ListingTable","Listing",new { UserID = model.User.UserId});
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