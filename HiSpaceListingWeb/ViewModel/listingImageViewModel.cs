using HiSpaceListingModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceListingWeb.ViewModel
{
	public class ListingImageViewModel
	{
		public ListingImageViewModel()
		{
			ListingImages = new ListingImages();
		}

		public ListingImages ListingImages { get; set; }
		public IFormFile File_ImageUrl { set; get; }
	}
}
