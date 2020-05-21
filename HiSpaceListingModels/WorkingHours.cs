using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HiSpaceListingModels
{
	[Table("WorkingHours")]
	public class WorkingHours
	{
		[Key]
		public int WorkingHoursId { set; get; }
		public int ListingId { set; get; }
		public bool? Is24 { set; get; }
		public bool? SunAvail { set; get; }
		public TimeSpan? SunOpen { set; get; }
		public TimeSpan? SunClose { set; get; }
		public bool? MonAvail { set; get; }
		public TimeSpan? MonOpen { set; get; }
		public TimeSpan? MonClose { set; get; }
		public bool? TueAvail { set; get; }
		public TimeSpan? TueOpen { set; get; }
		public TimeSpan? TueClose { set; get; }
		public bool? WedAvail { set; get; }
		public TimeSpan? WedOpen { set; get; }
		public TimeSpan? WedClose { set; get; }
		public bool? ThuAvail { set; get; }
		public TimeSpan? ThuOpen { set; get; }
		public TimeSpan? ThuClose { set; get; }
		public bool? FriAvail { set; get; }
		public TimeSpan? FriOpen { set; get; }
		public TimeSpan? FriClose { set; get; }
		public bool? SatAvail { set; get; }
		public TimeSpan? SatOpen { set; get; }
		public TimeSpan? SatClose { set; get; }
		public string Description { set; get; }
		public bool Status { set; get; }
		public DateTime? CreatedDateTime { set; get; }
		public int? ModifyBy { set; get; }
		public DateTime? ModifyDateTime { set; get; }
	}
}
