using HiSpaceListingModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiSpaceListingService.Models
{
	public class HiSpaceListingContext : DbContext
	{
		public HiSpaceListingContext(DbContextOptions<HiSpaceListingContext> options)
		   : base(options)
		{ }

		public DbSet<User> Users { get; set; }
	}
}