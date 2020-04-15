using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HiSpaceListingModels
{
	[Table("Listing")]
	public class Listing
	{
		public int ListingId { set; get; }
		public int UserId { set; get; }
		public string ListingType { set; get; }
		public string CommercialInfraType { set; get; }
		public string CommercialType { set; get; }
		public string CoworkingType { set; get; }
		public string REprofessionalsType { set; get; }
		public string REprofessionalsIntrest { set; get; }
		public string Name { set; get; }
		public string Email { set; get; }
		public string Phone { set; get; }
		public string SecondaryPhone { set; get; }
		public string Fax { set; get; }
		public string Address { set; get; }
		public string City { set; get; }
		public string State { set; get; }
		public string Country { set; get; }
		public string Postalcode { set; get; }
		public DateTime? BuildYear { set; get; }
		public DateTime? RecentInnovation { set; get; }
		public bool? CM_IntrestedCoworking { set; get; }
		public string Rental { set; get; }
		public decimal? PriceMin { set; get; }
		public decimal? PriceMax { set; get; }
		public int? TotalSeats { set; get; }
		public int? CurrentOccupancy { set; get; }
		public decimal? SpaceSize { set; get; }
		public int? CW_MeetingRoom { set; get; }
		public int? CW_Coworking { set; get; }
		public bool? CW_VirtualOffice { set; get; }
		public bool? CW_DayUsers { set; get; }
		public string Description { set; get; }
		public string PrimaryConatctName { set; get; }
		public string PrimaryConatctPhone { set; get; }
		public bool? Status { set; get; }
		public DateTime? CreatedDateTime { set; get; }
		public int? ModifyBy { set; get; }
		public DateTime? ModifyDateTime { set; get; }
	}
}
