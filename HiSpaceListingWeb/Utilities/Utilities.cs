using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using HiSpaceListingWeb.Models;

namespace HiSpaceListingWeb.Utilities
{
	public class Common
	{
		private string _ApiAddress = "";

		public string ApiAddress
		{
			set
			{
				_ApiAddress = value;
			}
			get
			{
				return _ApiAddress;
			}
		}

		#region Constructor

		public Common()
		{
			//ApiAddress = ConfigurationManager.AppSettings["HiSpaceServiceURL"].ToString();
			//ApiAddress = "https://localhost:44339/api/";
		}

		#endregion Constructor

		#region Singleton Object

		private static readonly object padlock = new object();
		private static Common instance = null;

		public static Common Instance
		{
			get
			{
				if (instance == null)
				{
					lock (padlock)
					{
						if (instance == null)
						{
							instance = new Common();
						}
					}
				}
				return instance;
			}
		}

		#endregion Singleton Object

		#region Session Variables

		public const string SessionUserId = "_UserId";
		public const string SessionUserEmail = "_UserEmail";
		public const string SessionUserType = "_UserType";
		public const string SessionUserCompanyName = "_UserCompanyName";

		#endregion Session Variables

		#region API Methods

		#region User Controller

		public string ApiUserControllerName
		{
			get
			{
				return ApiAddress + "User/";
			}
		}

		public string ApiUserAuthenticateUser = "AuthenticateUser/";
		public string ApiUserGetUsers = "GetUsers/";
		public string ApiUserGetUser = "GetUser/";
		public string ApiUserAddUser = "AddUser/";
		public string ApiUserUpdateUser = "UpdateUser/";
		public string ApiUserDeleteUser = "DeleteUser/";

		#endregion User Controller

		#region Listing Controller

		public string ApiListingControllerName
		{
			get
			{
				return ApiAddress + "Listing/";
			}
		}

		public string ApiListingAuthenticateListing = "AuthenticateListing/";
		public string ApiListingGetListings = "GetListings/";
		public string ApiListingsByUserId = "GetListingsByUserId/";
		public string ApiListingGetListing = "GetListing/";
		public string ApiListingAddListing = "AddListing/";
		public string ApiListingUpdateListing = "UpdateListing/";
		public string ApiListingDeleteListing = "DeleteListing/";
		public string ApiListingAddCreateHours = "AddCreateHours/";
		public string ApiListingGetWoringHoursByWoringHoursID = "GetWoringHoursByWoringHoursID/";

		#endregion Listing Controller

		#region Addons Controller
		public string ApiAddonsControllerName
		{
			get
			{
				return ApiAddress + "Addons/";
			}
		}

		public string ApiAddonsGetImagesByListingId = "GetImagesByListingId/";
		public string ApiAddonsAddCreateHours = "AddCreateHours/";
		public string ApiAddonsGetWoringHoursByWoringHoursID = "GetWoringHoursByWoringHoursID/";
		public string ApiAddonsUpdateHours = "UpdateHours/";

		#endregion Addons Controller

		#endregion API Methods

		#region DropDown Methods

		public static List<ListingType> GetListingType()
		{
			List<ListingType> types = new List<ListingType>();
			types.Add(new ListingType() { ListingTypeId = 1, ListingTypeName = "Commercial" });
			types.Add(new ListingType() { ListingTypeId = 2, ListingTypeName = "Co-Working" });
			types.Add(new ListingType() { ListingTypeId = 3, ListingTypeName = "RE-Professional" });
			return types;
		}

		public static List<CommercialCategory> GetCommercialCategory()
		{
			List<CommercialCategory> types = new List<CommercialCategory>();
			types.Add(new CommercialCategory() { CommercialCategoryId = 1, CommercialCategoryName = "Retail" });
			types.Add(new CommercialCategory() { CommercialCategoryId = 2, CommercialCategoryName = "Industry" });
			types.Add(new CommercialCategory() { CommercialCategoryId = 3, CommercialCategoryName = "Warehouse" });
			return types;
		}
		public static List<CommercialInfa> GetCommercialInfa()
		{
			List<CommercialInfa> types = new List<CommercialInfa>();
			types.Add(new CommercialInfa() { CommercialInfaId = 1, CommercialInfaName = "Shell", CommercialInfaDisplay = "Shell (Empty/Unfurninshed)" });
			types.Add(new CommercialInfa() { CommercialInfaId = 2, CommercialInfaName = "Semi-Furnished", CommercialInfaDisplay = "Semi Furnished" });
			types.Add(new CommercialInfa() { CommercialInfaId = 3, CommercialInfaName = "Fully-Furnished", CommercialInfaDisplay = "Fully Furnished" });
			return types;
		}

		public static List<CoworkingCategory> GetCoworkingCategory()
		{
			List<CoworkingCategory> types = new List<CoworkingCategory>();
			types.Add(new CoworkingCategory() { CoworkingCategoryId = 1, CoworkingCategoryName = "Office" });
			types.Add(new CoworkingCategory() { CoworkingCategoryId = 2, CoworkingCategoryName = "Cafe" });
			return types;
		}
		public static List<ProfessionalCategory> GetProfessionalCategory()
		{
			List<ProfessionalCategory> types = new List<ProfessionalCategory>();
			types.Add(new ProfessionalCategory() { ProfessionalCategoryId = 1, ProfessionalCategoryName = "PropertyDeveloper", ProfessionalCategoryDisplay = "Property Developer" });
			types.Add(new ProfessionalCategory() { ProfessionalCategoryId = 2, ProfessionalCategoryName = "Leasing", ProfessionalCategoryDisplay = "Leasing" });
			types.Add(new ProfessionalCategory() { ProfessionalCategoryId = 3, ProfessionalCategoryName = "InteriorDesigner", ProfessionalCategoryDisplay = "Interior Designer" });
			types.Add(new ProfessionalCategory() { ProfessionalCategoryId = 4, ProfessionalCategoryName = "CoworkingArchitecture", ProfessionalCategoryDisplay = "Co-working Architecture" });
			types.Add(new ProfessionalCategory() { ProfessionalCategoryId = 5, ProfessionalCategoryName = "Investor", ProfessionalCategoryDisplay = "Investor" });
			return types;
		}

		public static List<ScheduleTime> GetScheduleTime()
		{
			List<ScheduleTime> time = new List<ScheduleTime>();
			time.Add(new ScheduleTime() { ScheduleTimeID = 0, ScheduleTimeView = "-select-" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 1, ScheduleTimeSpan = TimeSpan.Parse("00:00:00"), ScheduleTimeView = "12:00 am" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 2, ScheduleTimeSpan = TimeSpan.Parse("00:30:00"), ScheduleTimeView = "12:30 am" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 3, ScheduleTimeSpan = TimeSpan.Parse("01:00:00"), ScheduleTimeView = "01:00 am" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 4, ScheduleTimeSpan = TimeSpan.Parse("01:30:00"), ScheduleTimeView = "01:30 am" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 5, ScheduleTimeSpan = TimeSpan.Parse("02:00:00"), ScheduleTimeView = "02:00 am" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 6, ScheduleTimeSpan = TimeSpan.Parse("02:30:00"), ScheduleTimeView = "02:30 am" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 7, ScheduleTimeSpan = TimeSpan.Parse("03:00:00"), ScheduleTimeView = "03:00 am" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 8, ScheduleTimeSpan = TimeSpan.Parse("03:30:00"), ScheduleTimeView = "03:30 am" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 9, ScheduleTimeSpan = TimeSpan.Parse("04:00:00"), ScheduleTimeView = "04:00 am" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 10, ScheduleTimeSpan = TimeSpan.Parse("04:30:00"), ScheduleTimeView = "04:30 am" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 11, ScheduleTimeSpan = TimeSpan.Parse("05:00:00"), ScheduleTimeView = "05:00 am" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 12, ScheduleTimeSpan = TimeSpan.Parse("05:30:00"), ScheduleTimeView = "05:30 am" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 13, ScheduleTimeSpan = TimeSpan.Parse("06:00:00"), ScheduleTimeView = "06:00 am" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 14, ScheduleTimeSpan = TimeSpan.Parse("06:30:00"), ScheduleTimeView = "06:30 am" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 15, ScheduleTimeSpan = TimeSpan.Parse("07:00:00"), ScheduleTimeView = "07:00 am" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 16, ScheduleTimeSpan = TimeSpan.Parse("07:30:00"), ScheduleTimeView = "07:30 am" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 17, ScheduleTimeSpan = TimeSpan.Parse("08:00:00"), ScheduleTimeView = "08:00 am" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 18, ScheduleTimeSpan = TimeSpan.Parse("08:30:00"), ScheduleTimeView = "08:30 am" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 19, ScheduleTimeSpan = TimeSpan.Parse("09:00:00"), ScheduleTimeView = "09:00 am" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 20, ScheduleTimeSpan = TimeSpan.Parse("09:30:00"), ScheduleTimeView = "09:30 am" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 21, ScheduleTimeSpan = TimeSpan.Parse("10:00:00"), ScheduleTimeView = "10:00 am" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 22, ScheduleTimeSpan = TimeSpan.Parse("10:30:00"), ScheduleTimeView = "10:30 am" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 23, ScheduleTimeSpan = TimeSpan.Parse("11:00:00"), ScheduleTimeView = "11:00 am" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 24, ScheduleTimeSpan = TimeSpan.Parse("11:30:00"), ScheduleTimeView = "11:30 am" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 25, ScheduleTimeSpan = TimeSpan.Parse("12:00:00"), ScheduleTimeView = "12:00 am" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 26, ScheduleTimeSpan = TimeSpan.Parse("12:30:00"), ScheduleTimeView = "12:30 am" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 27, ScheduleTimeSpan = TimeSpan.Parse("13:00:00"), ScheduleTimeView = "01:00 pm" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 28, ScheduleTimeSpan = TimeSpan.Parse("13:30:00"), ScheduleTimeView = "01:30 pm" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 29, ScheduleTimeSpan = TimeSpan.Parse("14:00:00"), ScheduleTimeView = "02:00 pm" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 30, ScheduleTimeSpan = TimeSpan.Parse("14:30:00"), ScheduleTimeView = "02:30 pm" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 31, ScheduleTimeSpan = TimeSpan.Parse("15:00:00"), ScheduleTimeView = "03:00 pm" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 32, ScheduleTimeSpan = TimeSpan.Parse("15:30:00"), ScheduleTimeView = "03:30 pm" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 33, ScheduleTimeSpan = TimeSpan.Parse("16:00:00"), ScheduleTimeView = "04:00 pm" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 34, ScheduleTimeSpan = TimeSpan.Parse("16:30:00"), ScheduleTimeView = "04:30 pm" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 35, ScheduleTimeSpan = TimeSpan.Parse("17:00:00"), ScheduleTimeView = "05:00 pm" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 36, ScheduleTimeSpan = TimeSpan.Parse("17:30:00"), ScheduleTimeView = "05:30 pm" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 37, ScheduleTimeSpan = TimeSpan.Parse("18:00:00"), ScheduleTimeView = "06:00 pm" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 38, ScheduleTimeSpan = TimeSpan.Parse("18:30:00"), ScheduleTimeView = "06:30 pm" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 39, ScheduleTimeSpan = TimeSpan.Parse("19:00:00"), ScheduleTimeView = "07:00 pm" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 40, ScheduleTimeSpan = TimeSpan.Parse("19:30:00"), ScheduleTimeView = "07:30 pm" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 41, ScheduleTimeSpan = TimeSpan.Parse("20:00:00"), ScheduleTimeView = "08:00 pm" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 42, ScheduleTimeSpan = TimeSpan.Parse("20:30:00"), ScheduleTimeView = "08:30 pm" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 43, ScheduleTimeSpan = TimeSpan.Parse("21:00:00"), ScheduleTimeView = "09:00 pm" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 44, ScheduleTimeSpan = TimeSpan.Parse("21:30:00"), ScheduleTimeView = "09:30 pm" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 45, ScheduleTimeSpan = TimeSpan.Parse("22:00:00"), ScheduleTimeView = "10:00 pm" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 46, ScheduleTimeSpan = TimeSpan.Parse("22:30:00"), ScheduleTimeView = "10:30 pm" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 47, ScheduleTimeSpan = TimeSpan.Parse("23:00:00"), ScheduleTimeView = "11:00 pm" });
			time.Add(new ScheduleTime() { ScheduleTimeID = 48, ScheduleTimeSpan = TimeSpan.Parse("23:30:00"), ScheduleTimeView = "11:30 pm" });

			time.Add(new ScheduleTime() { ScheduleTimeID = 49, ScheduleTimeSpan = TimeSpan.Parse("23:59:59"), ScheduleTimeView = "11:59 pm" });

			return time;
		}

		#endregion DropDown Methods
	}
}