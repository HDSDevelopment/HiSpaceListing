using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HiSpaceListingModels
{
	[Table("WorkingHours")]
	public class WorkingHours
	{
		public int WorkingHoursId { set; get; }
		public int ListingId { set; get; }
		public bool Is24 { set; get; }
		public bool SunAvail { set; get; }
		public DateTime? SunOpen { set; get; }
		public DateTime? SunClose { set; get; }
		public bool MonAvail { set; get; }
		public DateTime? MonOpen { set; get; }
		public DateTime? MonClose { set; get; }
		public bool TueAvail { set; get; }
		public DateTime? TueOpen { set; get; }
		public DateTime? TueClose { set; get; }
		public bool WedAvail { set; get; }
		public DateTime? WedOpen { set; get; }
		public DateTime? WedClose { set; get; }
		public bool ThuAvail { set; get; }
		public DateTime? ThuOpen { set; get; }
		public DateTime? ThuClose { set; get; }
		public bool FriAvail { set; get; }
		public DateTime? FriOpen { set; get; }
		public DateTime? FriClose { set; get; }
		public bool SatAvail { set; get; }
		public DateTime? SatOpen { set; get; }
		public DateTime? SatClose { set; get; }
		public string Description { set; get; }
		public bool Status { set; get; }
		public DateTime? CreatedDateTime { set; get; }
		public int? ModifyBy { set; get; }
		public DateTime? ModifyDateTime { set; get; }
	}
}
