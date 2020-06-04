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
	public class AddonsController : Controller
	{
		public ActionResult Index()
		{
			SetSessionVariables();
			return View();
		}
		public ActionResult AddHours(int id)
		{
			SetSessionVariables();
			ViewBag.ListOfScheduleTime = Common.GetScheduleTime();

			WorkingHoursViewModel vModel = new WorkingHoursViewModel();
			//vModel.WorkingHours.WorkingHoursId = id;
			vModel.WorkingHours.ListingId = id;

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Common.Instance.ApiAddonsControllerName);
				var responseTask = client.GetAsync(Common.Instance.ApiAddonsGetWoringHoursByListingID + vModel.WorkingHours.ListingId.ToString());
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<WorkingHours>();
					//var readTask = JsonConvert.DeserializeObject<WorkingHours>();
					readTask.Wait();

					vModel.WorkingHours = readTask.Result;

					if (vModel.WorkingHours.Is24 == true)
					{
						vModel.AllTimeCheck = true;
						vModel.MonToFriCheck = false;
						vModel.MonToSatCheck = false;
						vModel.CustomCheck = false;
					}
					//else if ((vModel.WorkingHours.Is24 == false) && (vModel.WorkingHours.MonAvail == true) && (vModel.WorkingHours.TueAvail == true) && (vModel.WorkingHours.WedAvail == true) && (vModel.WorkingHours.ThuAvail == true) && (vModel.WorkingHours.FriAvail == true) && (vModel.WorkingHours.SatAvail == false) && (vModel.WorkingHours.SunAvail == false) && (new[] { vModel.WorkingHours.MonOpen, vModel.WorkingHours.TueOpen, vModel.WorkingHours.WedOpen, vModel.WorkingHours.ThuOpen, vModel.WorkingHours.FriOpen }.Contains(vModel.WorkingHours.MonOpen)) && (new[] { vModel.WorkingHours.MonClose, vModel.WorkingHours.TueClose, vModel.WorkingHours.WedClose, vModel.WorkingHours.ThuClose, vModel.WorkingHours.FriClose }.Contains(vModel.WorkingHours.MonClose)))	
						else if ((vModel.WorkingHours.Is24 == false) && (vModel.WorkingHours.MonAvail == true) && (vModel.WorkingHours.TueAvail == true) && (vModel.WorkingHours.WedAvail == true) && (vModel.WorkingHours.ThuAvail == true) && (vModel.WorkingHours.FriAvail == true) && (vModel.WorkingHours.SatAvail == false) && (vModel.WorkingHours.SunAvail == false) && (vModel.WorkingHours.MonOpen == vModel.WorkingHours.TueOpen) && (vModel.WorkingHours.MonOpen == vModel.WorkingHours.WedOpen) && (vModel.WorkingHours.MonOpen == vModel.WorkingHours.ThuOpen) && (vModel.WorkingHours.MonOpen == vModel.WorkingHours.FriOpen)
						 && (vModel.WorkingHours.MonClose == vModel.WorkingHours.TueClose) && (vModel.WorkingHours.MonClose == vModel.WorkingHours.WedClose) && (vModel.WorkingHours.MonClose == vModel.WorkingHours.ThuClose) && (vModel.WorkingHours.MonClose == vModel.WorkingHours.FriClose))
					{
						vModel.AllTimeCheck = false;
						vModel.MonToFriCheck = true;
						vModel.MonToSatCheck = false;
						vModel.CustomCheck = false;
						vModel.MonToFriOpen = vModel.WorkingHours.MonOpen;
						vModel.MonToFriClose = vModel.WorkingHours.MonClose;
					}
					else if ((vModel.WorkingHours.Is24 == false) && (vModel.WorkingHours.MonAvail == true) && (vModel.WorkingHours.TueAvail == true) && (vModel.WorkingHours.WedAvail == true) && (vModel.WorkingHours.ThuAvail == true) && (vModel.WorkingHours.FriAvail == true) && (vModel.WorkingHours.SatAvail == true) && (vModel.WorkingHours.SunAvail == false) && (vModel.WorkingHours.MonOpen == vModel.WorkingHours.TueOpen) && (vModel.WorkingHours.MonOpen == vModel.WorkingHours.WedOpen) && (vModel.WorkingHours.MonOpen == vModel.WorkingHours.ThuOpen) && (vModel.WorkingHours.MonOpen == vModel.WorkingHours.FriOpen)
						 && (vModel.WorkingHours.MonClose == vModel.WorkingHours.TueClose) && (vModel.WorkingHours.MonClose == vModel.WorkingHours.WedClose) && (vModel.WorkingHours.MonClose == vModel.WorkingHours.ThuClose) && (vModel.WorkingHours.MonClose == vModel.WorkingHours.FriClose))
					{
						vModel.AllTimeCheck = false;
						vModel.MonToFriCheck = false;
						vModel.MonToSatCheck = true;
						vModel.CustomCheck = false;
						vModel.MonToFriNotSatOpen = vModel.WorkingHours.MonOpen;
						vModel.MonToFriNotSatClose = vModel.WorkingHours.MonClose;
						vModel.MonToFriWithSatOpen = vModel.WorkingHours.SatOpen;
						vModel.MonToFriWithSatClose = vModel.WorkingHours.SatClose;
					}
					else
					{
						vModel.AllTimeCheck = false;
						vModel.MonToFriCheck = false;
						vModel.MonToSatCheck = false;
						vModel.CustomCheck = true;
					}
				}
				else
				{

				}
			}
			

			return PartialView("_AddHoursPartialView", vModel);
		}
		public ActionResult UpdateHours(WorkingHoursViewModel model)
		{
			SetSessionVariables();
			WorkingHours worHours = new WorkingHours();
			//var id = model.WorkingHours.WorkingHoursId;
			if (model != null)
			{
				model.WorkingHours.ModifyBy = GetSessionObject().UserId;
				model.WorkingHours.CreatedDateTime = DateTime.Now;
				model.WorkingHours.ModifyDateTime = DateTime.Now;
				model.WorkingHours.Status = true;
				//model.WorkingHours.ListingId = 1;
				if (model.AllTimeCheck == true)
				{
					model.WorkingHours.MonAvail = true;
					model.WorkingHours.TueAvail = true;
					model.WorkingHours.WedAvail = true;
					model.WorkingHours.ThuAvail = true;
					model.WorkingHours.FriAvail = true;
					model.WorkingHours.SatAvail = true;
					model.WorkingHours.SunAvail = true;

					//open
					model.WorkingHours.MonOpen = "00:00:00";
					model.WorkingHours.TueOpen = "00:00:00";
					model.WorkingHours.WedOpen = "00:00:00";
					model.WorkingHours.ThuOpen = "00:00:00";
					model.WorkingHours.FriOpen = "00:00:00";
					model.WorkingHours.SatOpen = "00:00:00";
					model.WorkingHours.SunOpen = "00:00:00";

					//close
					model.WorkingHours.MonClose = "23:59:59";
					model.WorkingHours.TueClose = "23:59:59";
					model.WorkingHours.WedClose = "23:59:59";
					model.WorkingHours.ThuClose = "23:59:59";
					model.WorkingHours.FriClose = "23:59:59";
					model.WorkingHours.SatClose = "23:59:59";
					model.WorkingHours.SunClose = "23:59:59";
				}
				else if (model.MonToFriCheck == true)
				{
					model.WorkingHours.Is24 = false;
					model.WorkingHours.MonAvail = true;
					model.WorkingHours.TueAvail = true;
					model.WorkingHours.WedAvail = true;
					model.WorkingHours.ThuAvail = true;
					model.WorkingHours.FriAvail = true;
					model.WorkingHours.SatAvail = false;
					model.WorkingHours.SunAvail = false;

					//open
					model.WorkingHours.MonOpen = model.MonToFriOpen;
					model.WorkingHours.TueOpen = model.MonToFriOpen;
					model.WorkingHours.WedOpen = model.MonToFriOpen;
					model.WorkingHours.ThuOpen = model.MonToFriOpen;
					model.WorkingHours.FriOpen = model.MonToFriOpen;
					model.WorkingHours.SatOpen = null;
					model.WorkingHours.SunOpen = null;

					//close
					model.WorkingHours.MonClose = model.MonToFriClose;
					model.WorkingHours.TueClose = model.MonToFriClose;
					model.WorkingHours.WedClose = model.MonToFriClose;
					model.WorkingHours.ThuClose = model.MonToFriClose;
					model.WorkingHours.FriClose = model.MonToFriClose;
					model.WorkingHours.SatClose = null;
					model.WorkingHours.SunClose = null;
				}
				else if (model.MonToSatCheck == true)
				{
					model.WorkingHours.Is24 = false;
					model.WorkingHours.MonAvail = true;
					model.WorkingHours.TueAvail = true;
					model.WorkingHours.WedAvail = true;
					model.WorkingHours.ThuAvail = true;
					model.WorkingHours.FriAvail = true;
					model.WorkingHours.SatAvail = true;
					model.WorkingHours.SunAvail = false;

					//open
					model.WorkingHours.MonOpen = model.MonToFriNotSatOpen;
					model.WorkingHours.TueOpen = model.MonToFriNotSatOpen;
					model.WorkingHours.WedOpen = model.MonToFriNotSatOpen;
					model.WorkingHours.ThuOpen = model.MonToFriNotSatOpen;
					model.WorkingHours.FriOpen = model.MonToFriNotSatOpen;
					model.WorkingHours.SatOpen = model.MonToFriWithSatOpen;
					model.WorkingHours.SunOpen = null;

					//close
					model.WorkingHours.MonClose = model.MonToFriNotSatClose;
					model.WorkingHours.TueClose = model.MonToFriNotSatClose;
					model.WorkingHours.WedClose = model.MonToFriNotSatClose;
					model.WorkingHours.ThuClose = model.MonToFriNotSatClose;
					model.WorkingHours.FriClose = model.MonToFriNotSatClose;
					model.WorkingHours.SatClose = model.MonToFriWithSatClose;
					model.WorkingHours.SunClose = null;
				}
				else if (model.CustomCheck == true)
				{
					model.WorkingHours.Is24 = false;
					if(model.WorkingHours.MonAvail == null)
					{
						model.WorkingHours.MonAvail = false;
					}
					if (model.WorkingHours.TueAvail == null)
					{
						model.WorkingHours.TueAvail = false;
					}
					if (model.WorkingHours.WedAvail == null)
					{
						model.WorkingHours.WedAvail = false;
					}
					if (model.WorkingHours.ThuAvail == null)
					{
						model.WorkingHours.ThuAvail = false;
					}
					if (model.WorkingHours.FriAvail == null)
					{
						model.WorkingHours.FriAvail = false;
					}
					if (model.WorkingHours.SatAvail == null)
					{
						model.WorkingHours.SatAvail = false;
					}
					if (model.WorkingHours.SunAvail == null)
					{
						model.WorkingHours.SunAvail = false;
					}
				}

				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri(Common.Instance.ApiAddonsControllerName);
					//HTTP POST
					if(model.WorkingHours.WorkingHoursId == 0)
					{
						var postTask = client.PostAsJsonAsync<WorkingHours>(Common.Instance.ApiAddonsAddCreateHours, model.WorkingHours);
						postTask.Wait();
						var result = postTask.Result;
						if (result.IsSuccessStatusCode)
						{
							var rs = result.Content.ReadAsAsync<WorkingHours>();
							//return RedirectToAction("Index");
							worHours = rs.Result;
						}
					}
					else if(model.WorkingHours.WorkingHoursId > 0)
					{
						var postTask = client.PutAsJsonAsync(Common.Instance.ApiAddonsUpdateHours + model.WorkingHours.ListingId, model.WorkingHours);
						postTask.Wait();
						var result = postTask.Result;
						if (result.IsSuccessStatusCode)
						{
							var rs = result.Content.ReadAsAsync<WorkingHours>();
							rs.Wait();
							//return RedirectToAction("Index");
							worHours = rs.Result;
						}
					}

				}
				ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
			}
			return RedirectToAction("ListingTable", "Listing", new { UserID = GetSessionObject().UserId, UserType = GetSessionObject().UserType });
		}

		public ActionResult AddAmenities(int id)
		{
			SetSessionVariables();
			ViewBag.AmenitiesPaymentTypeList = Common.GetAmenitiesPaymentTypeList();
			AmenityViewModel vModel = new AmenityViewModel
			{
				AmenityMasterList = Common.GetAmenityMasterList()
			}; 
			return PartialView("_AddAmenitiesPartialView", vModel);
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

		public ActionResult AddFacilities(int id)
		{
			SetSessionVariables();
			Facility model = new Facility
			{
				ListingId = id
			};
			return PartialView("_AddFacilitiesPartialView", model);
		}

		public ActionResult AddProject(int id)
		{
			SetSessionVariables();
			REProfessionalMaster model = new REProfessionalMaster
			{
				ListingId = id
			};
			return PartialView("_AddProjectPartialView", model);
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