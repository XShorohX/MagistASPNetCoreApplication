using PraktASPApp.Database;
using PraktASPApp.Models;
using Corpa4Sem4.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;

namespace PraktASPApp.Controllers
{
    public class OfficeController : Controller
	{

		[HttpGet]
		public IActionResult Office(FilterVM model)
		{
			using ApplicationContext db = new ApplicationContext();
			var user = (from usr in db.Users
						where usr.Login == Request.Cookies["Login"]
						where usr.Password == Request.Cookies["Password"]
						select usr).Take(1).ToList().FirstOrDefault(u => true, null);

			if (user == null)
			{
				return RedirectToAction("Index", "Home");
			}

			Console.WriteLine(model.Status);
			var messages = (from msg in db.Messages.ToList()
							where msg.ToUserId == user.Id
							select msg).ToList()
							.Where(msg=> !msg.Status || model.Status != "on")
				.Select(msg => new MessageVM
				{
					Id = msg.Id, 
					From = db.Users.ToList().First(u => u.Id == msg.FromUserId).Login
					,
					Title = msg.MessageHeadline,
					Text = msg.MessageText,
					Date = msg.SendDate,
					Status = msg.Status
					
				}).ToList().OrderByDescending(m => m.Date);

			ViewData["Name"] = user.FullName;
			return View(messages);
		}

		[HttpPost]
		public IActionResult MarkAsRead(int id)
		{
			using ApplicationContext db = new ApplicationContext();
			var message = db.Messages.Find(id);
			if (message == null)
			{
				return NotFound();
			}

			message.Status = true;
    		message.SendDate = DateTime.UtcNow; // Ensure DateTime is in UTC
			db.Messages.Update(message);
			db.SaveChanges();

			return NoContent();
		}



		[HttpPost]
		public IActionResult Office(SendMessage model)
		{
			using ApplicationContext db = new ApplicationContext();
			var user = (from usr in db.Users
						where usr.Login == Request.Cookies["Login"]
						where usr.Password == Request.Cookies["Password"]
						select usr).Take(1).ToList().FirstOrDefault(u => true, null);

			if (user == null)
			{
				return RedirectToAction("Index", "Home");
			}

			var receiverUser = (from usr in db.Users.ToList()
								where usr.Login == model.To
								select usr).Take(1).ToList().FirstOrDefault(u => true, null);

			if (receiverUser == null)
			{
                ViewData["Message"] = $"������: ����� '{model.To}' �� ������";
                return View();
			}

			DateTime currentTime = DateTime.UtcNow;
			db.Messages.Add(new Corpa4Sem4.Database.Models.Message
			{
				FromUserId = user.Id,
				ToUserId = receiverUser.Id,
				MessageHeadline = model.Title,
				MessageText = model.Text,
				SendDate = DateTime.UtcNow
			});
			db.SaveChanges();

            ViewData["Message"] = "������: �������� �� ���������";
            return RedirectToAction("Office", "Office");
		}

	}
}
