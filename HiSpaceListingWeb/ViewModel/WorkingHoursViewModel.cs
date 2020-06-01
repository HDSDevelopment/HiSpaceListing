using HiSpaceListingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceListingWeb.ViewModel
{
	public class WorkingHoursViewModel
	{
		public WorkingHoursViewModel()
		{
			WorkingHours = new WorkingHours();
		}
		public WorkingHours WorkingHours { get; set; }
		public bool? AllTimeCheck { set; get; }
		public bool? MonToFriCheck { set; get; }
		public bool? MonToSatCheck { set; get; }
		public bool? CustomCheck { set; get; }
		public string AllTimeOpen { set; get; }
		public string MonToFriOpen { set; get; }
		public string MonToFriClose { set; get; }
		public string MonToFriNotSatOpen { set; get; }
		public string MonToFriNotSatClose { set; get; }
		public string MonToFriWithSatOpen { set; get; }
		public string MonToFriWithSatClose { set; get; }
	}
}
