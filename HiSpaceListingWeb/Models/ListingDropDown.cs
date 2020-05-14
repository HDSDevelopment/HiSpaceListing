﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceListingWeb.Models
{
	public class ListingDropDown
	{
		
	}
	public class ListingType
	{
		public int ListingTypeId { set; get; }
		public string ListingTypeName { set; get; }
	}

	public class CommercialCategory
	{
		public int CommercialCategoryId { set; get; }
		public string CommercialCategoryName { set; get; }
	}

	public class CommercialInfa
	{
		public int CommercialInfaId { set; get; }
		public string CommercialInfaName { set; get; }
		public string CommercialInfaDisplay { set; get; }
	}

	public class CoworkingCategory
	{
		public int CoworkingCategoryId { set; get; }
		public string CoworkingCategoryName { set; get; }
	}
	public class ProfessionalCategory
	{
		public int ProfessionalCategoryId { set; get; }
		public string ProfessionalCategoryName { set; get; }
		public string ProfessionalCategoryDisplay { set; get; }
	}
}
