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
	public class UserController : ControllerBase
	{
		private readonly HiSpaceListingContext _context;

		public UserController(HiSpaceListingContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Authenticate the user.
		/// </summary>
		/// <returns>The authenticated user.</returns>
		// POST: api/user/AuthenticateUser
		[HttpPost]
		[Route("AuthenticateUser")]
		public async Task<ActionResult<User>> AuthenticateUser([FromForm] User user)
		{
			var _user = await _context.Users.FirstOrDefaultAsync(d => d.Email == user.Email && d.Password == user.Password && d.Status == true);

			if (_user == null)
			{
				return BadRequest(new { message = "Email or password is incorrect" });
			}
			else
			{
				_user.LoginCount = _user.LoginCount + 1;
				_user.LastLoginDateTime = DateTime.Now;
				_context.Entry(_user).State = EntityState.Modified;
				await _context.SaveChangesAsync();
			}
			return Ok(new
			{
				UserId = _user.UserId,
				UserEmail = _user.Email,
				UserPassword = _user.Password,
				UserType = _user.UserType
			});
		}

		/// <summary>
		/// Gets the list of all Employees.
		/// </summary>
		/// <returns>The list of Employees.</returns>
		// GET: api/user/Users
		[HttpGet]
		[Route("GetUsers")]
		public async Task<ActionResult<IEnumerable<User>>> GetUsers()
		{
			return await _context.Users.ToListAsync();
		}

		// GET: api/user/GetUser/1
		//[HttpGet("GetUser/{UserId}")]
		[HttpGet("GetUser/{UserId}")]
		//[Route("GetClient/{UserId}")]
		public async Task<ActionResult<User>> GetUser(int UserId)
		{
			var user = await _context.Users.FindAsync(UserId);

			if (user == null)
			{
				return NotFound();
			}

			return user;
		}
	}
}