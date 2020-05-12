using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

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
	}
}