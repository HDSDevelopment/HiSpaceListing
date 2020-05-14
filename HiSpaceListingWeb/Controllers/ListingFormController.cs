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
    public class ListingFormController : Controller
    {
        public ActionResult Create()
        {
			SetSessionVariables();
			ViewBag.ListOfListType = Common.GetListingType();
			ViewBag.ListOfCommercialCategory = Common.GetCommercialCategory();
			ViewBag.ListOfCommercialInfa = Common.GetCommercialInfa();
			ViewBag.ListOfCoworkingCategory = Common.GetCoworkingCategory();
			ViewBag.ListOfProfessionalCategory = Common.GetProfessionalCategory();
			Listing model = new Listing();
			return View(model);
        }

		public ActionResult AddForm(Listing model)
		{
			SetSessionVariables();

			if(model != null)
			{
				model.CreatedDateTime = DateTime.Now;
				model.ModifyDateTime = DateTime.Now;
				model.ModifyBy = GetSessionObject().UserId;
				model.UserId = GetSessionObject().UserId;
				model.Status = true;
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri(Common.Instance.ApiListingControllerName);

					//HTTP POST
					var postTask = client.PostAsJsonAsync<Listing>(Common.Instance.ApiListingAddListing, model);
					postTask.Wait();

					var result = postTask.Result;
					if (result.IsSuccessStatusCode)
					{
						return RedirectToAction("ListingTable", "Listing", new { UserID = model.UserId });
					}
				}

				ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");


			}

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