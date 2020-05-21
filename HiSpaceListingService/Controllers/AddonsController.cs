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
	public class AddonsController : ControllerBase
	{
		private readonly HiSpaceListingContext _context;

		public AddonsController(HiSpaceListingContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Gets the list of all Images.
		/// </summary>
		/// <returns>The list of Images.</returns>
		// GET: api/Addons/GetImagesByListingId/1
		[HttpGet("GetImagesByListingId/{ListingID}")]
		public async Task<ActionResult<IEnumerable<ListingImages>>> GetImagesByListingId(int ListingID)
		{
			return await _context.ListingImagess.Where(d => d.ListingId == ListingID).ToListAsync();
		}

		// GET: api/Addons/GetWoringHoursByWoringHoursID/1
		[HttpGet("GetWoringHoursByWoringHoursID/{WoringHoursID}")]
		public async Task<ActionResult<WorkingHours>> GetWoringHoursByWoringHoursID(int WoringHoursID)
		{
			var workingHours = await _context.WorkingHourss.FindAsync(WoringHoursID);

			if (workingHours == null)
			{
				return NotFound();
			}

			return workingHours;
		}

		/// <summary>
		/// Post the WorkingHours.
		/// </summary>
		/// <returns>The list of WorkingHours.</returns>
		// POST: api/Addons/AddCreateHours
		[HttpPost("AddCreateHours")]
		public async Task<ActionResult<WorkingHours>> AddCreateHours([FromBody] WorkingHours workingHours)
		{
			_context.WorkingHourss.Add(workingHours);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetWoringHoursByWoringHoursID", new { WoringHoursID = workingHours.WorkingHoursId }, workingHours);
		}

		// PUT: api/Addons/UpdateHours/1
		[HttpPut("UpdateHours/{WoringHoursID}")]
		public async Task<IActionResult> UpdateHours(int WoringHoursID, [FromBody] WorkingHours workingHours)
		{
			if (WoringHoursID != workingHours.WorkingHoursId || workingHours == null)
			{
				return BadRequest();
			}

			_context.Entry(workingHours).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!WorkingHoursExists(WoringHoursID))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		private bool WorkingHoursExists(int WoringHoursID)
		{
			return _context.WorkingHourss.Any(e => e.WorkingHoursId == WoringHoursID);
		}

	}
}