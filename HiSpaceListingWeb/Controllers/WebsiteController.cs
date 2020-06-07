using HiSpaceListingModels;
using HiSpaceListingService.ViewModel;
using HiSpaceListingWeb.Utilities;
using HiSpaceListingWeb.ViewModel;
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
			SetSessionVariables();
			return View();
		}
		public ActionResult About()
		{
			SetSessionVariables();
			return View();
		}
		public ActionResult Contact()
		{
			SetSessionVariables();
			return View();
		}
		public ActionResult PropertyList()
		{
			SetSessionVariables();
			PropertyListViewModel vModel = new PropertyListViewModel();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Common.Instance.ApiCommonControllerName);
				//HTTP GET
				//Get Location
				var responseTask = client.GetAsync(Common.Instance.ApiCommonGetAllPropertyLocationSearch);
				responseTask.Wait();
				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<List<PropertyLocationSearchResponse>>();
					readTask.Wait();
					vModel.PropertyLocationSearchList = readTask.Result;
				}
				//Get Type
				responseTask = client.GetAsync(Common.Instance.ApiCommonGetAllPropertyTypeSearch);
				responseTask.Wait();
				result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<List<PropertyTypeSearchResponse>>();
					readTask.Wait();
					vModel.PropertyTypeSearchList = readTask.Result;
				}
				//Get Level
				responseTask = client.GetAsync(Common.Instance.ApiCommonGetAllPropertyLevelSearch);
				responseTask.Wait();
				result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<List<PropertyLevelSearchResponse>>();
					readTask.Wait();
					vModel.PropertyLevelSearchList = readTask.Result;
				}
				//Get Lister
				responseTask = client.GetAsync(Common.Instance.ApiCommonGetAllPropertyListerSearch);
				responseTask.Wait();
				result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<List<PropertyListerSearchResponse>>();
					readTask.Wait();
					vModel.PropertyListerSearchList = readTask.Result;
				}
			}

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Common.Instance.ApiListingControllerName);
				var responseTask = client.GetAsync(Common.Instance.ApiListingGetPropertyList);
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<List<PropertyDetailResponse>>();
					readTask.Wait();
					vModel.PropertyDetailSearchList = readTask.Result;
				}
			}
			return View(vModel);
		}
		public ActionResult PropertyLister(int UserID)
		{
			SetSessionVariables();
			PropertyListListerResponse vModel = new PropertyListListerResponse();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Common.Instance.ApiListingControllerName);
				var responseTask = client.GetAsync(Common.Instance.ApiListingGetPropertyListByUserID + UserID.ToString());
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<PropertyListListerResponse>();
					readTask.Wait();
					vModel = readTask.Result;
				}
			}
			return View(vModel);
		}
		public ActionResult PropertyDetail(int ListingID)
		{
			SetSessionVariables();
			PropertyDetailViewModelResponse vModel = new PropertyDetailViewModelResponse();
			using (var client = new HttpClient()){
				client.BaseAddress = new Uri(Common.Instance.ApiListingControllerName);
				var responseTask = client.GetAsync(Common.Instance.ApiListingGetPropertyDetailByListingID + ListingID.ToString());
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<PropertyDetailViewModelResponse>();
					readTask.Wait();
					vModel = readTask.Result;
				}
			}
			return View(vModel);
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