using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiSpaceListingModels;
using HiSpaceListingService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HiSpaceListingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
		private readonly HiSpaceListingContext _context;

		public ListingController(HiSpaceListingContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Gets the list of all Listings by userId.
		/// </summary>
		/// <returns>The list of Listings.</returns>
		// GET: api/Listing/Listings/1
		[HttpGet]
		[Route("GetListingsByUserId/{UserId}")]
		public async Task<ActionResult<IEnumerable<Listing>>> GetListingsByUserId(int UserId)
		{
			return await _context.Listings.Where(d => d.UserId == UserId).ToListAsync();
		}

		/// <summary>
		/// Gets the list of all Listings.
		/// </summary>
		/// <returns>The list of Listings.</returns>
		// GET: api/Listing/Listings
		[HttpGet]
		[Route("GetListings")]
		public async Task<ActionResult<IEnumerable<Listing>>> GetListings()
		{
			return await _context.Listings.ToListAsync();
		}

		/// <summary>
		/// Gets the Listing by ListingId.
		/// </summary>
		/// <returns>The Listing by ListingId.</returns>
		// GET: api/Listing/GetListing/1
		//[HttpGet("GetListing/{ListingId}")]
		[HttpGet]
		[Route("GetListing/{ListingId}")]
		public async Task<ActionResult<Listing>> GetListing(int ListingId)
		{
			var listing = await _context.Listings.FindAsync(ListingId);

			if (listing == null)
			{
				return NotFound();
			}

			return listing;
		}

		/// <summary>
		/// Add the Listing.
		/// </summary>
		/// <returns>The Listing by ListingId.</returns>
		// POST: api/Listing/AddListing
		[HttpPost]
		[Route("AddListing")]
		public async Task<ActionResult<Listing>> AddListing([FromBody] Listing listing)
		{
			listing.CreatedDateTime = DateTime.Now;

			_context.Listings.Add(listing);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetListing", new { ListingId = listing.ListingId }, listing);
		}

		/// <summary>
		/// Update the Listing by ListingId.
		/// </summary>
		/// <returns>The Listing by ListingId.</returns>
		// PUT: api/Listing/UpdateListing
		[HttpPut]
		[Route("UpdateListing/{ListingId}")]
		public async Task<IActionResult> UpdateListing(int ListingId, [FromBody]  Listing listing)
		{
			if (ListingId != listing.ListingId || listing == null)
			{
				return BadRequest();
			}

			using (var trans = _context.Database.BeginTransaction())
			{
				try
				{
					_context.Entry(listing).State = EntityState.Modified;

					try
					{
						await _context.SaveChangesAsync();
					}
					catch (DbUpdateConcurrencyException)
					{
						if (!ListingExists(ListingId))
						{
							return NotFound();
						}
						else
						{
							throw;
						}
					}

					trans.Commit();
				}
				catch (Exception err)
				{
					trans.Rollback();
				}
			}

			return NoContent();
		}

		private bool ListingExists(int ListingId)
		{
			return _context.Listings.Any(e => e.ListingId == ListingId);
		}

		/// <summary>
		/// Delete the Listing by ListingId.
		/// </summary>
		/// <returns>The Listings list.</returns>
		// POST: api/Listing/DeleteListing
		[HttpPost]
		[Route("DeleteListing/{ListingId}")]
		public async Task<ActionResult<IEnumerable<Listing>>> DeleteListing(int ListingId)
		{
			var listing = await _context.Listings.FindAsync(ListingId);
			_context.Listings.Remove(listing);
			await _context.SaveChangesAsync();
			return CreatedAtAction("GetUsers", listing);
		}


	}
}