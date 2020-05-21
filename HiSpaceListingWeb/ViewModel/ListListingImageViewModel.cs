using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceListingWeb.ViewModel
{
	public class ListListingImageViewModel
	{
		public ListListingImageViewModel()
		{
			ListingImageViewModel = new List<ListingImageViewModel>();
		}

		public List<ListingImageViewModel> ListingImageViewModel { get; set; }
	}
}
