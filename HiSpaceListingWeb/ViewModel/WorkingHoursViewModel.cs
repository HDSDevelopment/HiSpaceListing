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
		public TimeSpan? AllTimeOpen { set; get; }
		public TimeSpan? MonToFriOpen { set; get; }
		public TimeSpan? MonToFriClose { set; get; }
		public TimeSpan? MonToFriNotSatOpen { set; get; }
		public TimeSpan? MonToFriNotSatClose { set; get; }
		public TimeSpan? MonToFriWithSatOpen { set; get; }
		public TimeSpan? MonToFriWithSatClose { set; get; }
	}
}
