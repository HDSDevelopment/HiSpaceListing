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
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult AddImage(int id)
		{
			SetSessionVariables();
			//ListingImages model = new ListingImages
			//{
			//	ListingId = id
			//};
			//ListListingImageViewModel vModel = new ListListingImageViewModel();
			//using (var client = new HttpClient())
			//{
			//	client.BaseAddress = new Uri(Common.Instance.ApiAddonsControllerName);
			//	//HTTP GET
			//	var responseTask = client.GetAsync(Common.Instance.ApiAddonsGetImagesByListingId + id);
			//	responseTask.Wait();

			//	var result = responseTask.Result;
			//	if (result.IsSuccessStatusCode)
			//	{
			//		var readTask = result.Content.ReadAsAsync<IList<ListingImageViewModel>>();
			//		readTask.Wait();

			//		vModel.ListingImageViewModel = readTask.Result.ToList();
			//	}
			//	else //web api sent error response 
			//	{
			//		//log response status here..

			//		//vModel = Enumerable.Empty<ListingImageViewModel>();

			//		ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
			//	}
			//}
			//return View(clLocations);
			return PartialView("_AddImagePartialView");
		}

		//public ActionResult CreateImage(List<ListListingImageViewModel> model, IFormCollection formCollection)
		//{
		//	SetSessionVariables();
		//	ListListingImageViewModel vModel = new ListListingImageViewModel();
		//	return PartialView("_AddImagePartialView", vModel);
		//}

		

		public ActionResult AddAmenities(int id)
		{
			Amenity model = new Amenity
			{
				ListingId = id
			};
			return PartialView("_AddAmenitiesPartialView", model);
		}

		public ActionResult AddFacilities(int id)
		{
			Facility model = new Facility
			{
				ListingId = id
			};
			return PartialView("_AddFacilitiesPartialView", model);
		}

		public ActionResult AddProject(int id)
		{
			REProfessionalMaster model = new REProfessionalMaster
			{
				ListingId = id
			};
			return PartialView("_AddProjectPartialView", model);
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

		public ActionResult ListingTable(int UserID)
		{
			SetSessionVariables();
			UserMasterViewModel vModel = new UserMasterViewModel();
			if (UserID != 0)
			{
				using (var client = new HttpClient())
				{
					//User user = null;
					client.BaseAddress = new Uri(Common.Instance.ApiUserControllerName);
					//HTTP GET
					var responseTask = client.GetAsync(Common.Instance.ApiUserGetUser + UserID.ToString());
					responseTask.Wait();

					var result = responseTask.Result;
					if (result.IsSuccessStatusCode)
					{
						var readTask = result.Content.ReadAsAsync<User>();
						readTask.Wait();
						//user = readTask.Result;
						vModel.User = readTask.Result;
					}
				}

				using (var client = new HttpClient())
				{
					//IEnumerable<Listing> listingList = null;
					client.BaseAddress = new Uri(Common.Instance.ApiListingControllerName);
					//HTTP GET
					var responseTask = client.GetAsync(Common.Instance.ApiListingsByUserId + UserID.ToString());
					responseTask.Wait();

					var result = responseTask.Result;
					if (result.IsSuccessStatusCode)
					{
						var readTask = result.Content.ReadAsAsync<IList<Listing>>();
						readTask.Wait();
						//listingList = readTask.Result.ToList();
						vModel.ListingList = readTask.Result.ToList();
					}
					else
					{
						//vModel.ListingList = Enumerable.Empty<Listing>();
						ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
					}
				}
				return View(vModel);
			}
			else
			{
				return RedirectToAction("Index", "Website");
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

		public User GetSessionObject()
		{
			return HttpContext.Session.GetObjectFromJson<User>("_user");
		}
	}
}