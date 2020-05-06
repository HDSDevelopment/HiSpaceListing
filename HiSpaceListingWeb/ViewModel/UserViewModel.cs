using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using HiSpaceListingModels;
using Microsoft.AspNetCore.Http;

namespace HiSpaceListingWeb.ViewModel
{
	public class UserViewModel
	{
		public UserViewModel()
		{
			User = new User();
		}

		public User User { get; set; }
		public IFormFile RCCopy { set; get; }
		public IFormFile PANCopy { set; get; }
		public IFormFile Logo { set; get; }
	}
}
