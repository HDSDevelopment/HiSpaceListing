using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HiSpaceListingWeb.Utilities.Common;

namespace HiSpaceListingWeb.ViewModel
{
	public class AmenityViewModel
	{
		public AmenityViewModel()
		{
			AmenityMasterList = new List<AmenityMasterVM>();
		}
		public List<AmenityMasterVM> AmenityMasterList { set; get; }
	}
}
