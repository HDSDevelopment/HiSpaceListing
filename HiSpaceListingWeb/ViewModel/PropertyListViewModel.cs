using HiSpaceListingService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceListingWeb.ViewModel
{
	public class PropertyListViewModel
	{
		public PropertyListViewModel()
		{
			PropertyLocationSearchList = new List<PropertyLocationSearchResponse>();
			PropertyTypeSearchList = new List<PropertyTypeSearchResponse>();
			PropertyLevelSearchList = new List<PropertyLevelSearchResponse>();
			PropertyListerSearchList = new List<PropertyListerSearchResponse>();
		}
		public List<PropertyLocationSearchResponse> PropertyLocationSearchList { set; get; }
		public List<PropertyTypeSearchResponse> PropertyTypeSearchList { set; get; }
		public List<PropertyLevelSearchResponse> PropertyLevelSearchList { set; get; }
		public List<PropertyListerSearchResponse> PropertyListerSearchList { set; get; }
		public List<PropertyDetailResponse> PropertyDetailSearchList { set; get; }
	}
}
