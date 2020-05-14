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

		public SerializationInfo ApiClientControllerName { get; internal set; }

		public string ApiListingAuthenticateListing = "AuthenticateListing/";
		public string ApiListingGetListings = "GetListings/";
		public string ApiListingsByUserId = "GetListingsByUserId/";
		public string ApiListingGetListing = "GetListing/";
		public string ApiListingAddListing = "AddListing/";
		public string ApiListingUpdateListing = "UpdateListing/";
		public string ApiListingDeleteListing = "DeleteListing/";

		#endregion Listing Controller

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


		#endregion DropDown Methods
	}
}