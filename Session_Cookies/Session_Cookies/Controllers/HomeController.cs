using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session_Cookies.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			if (Request.Cookies["KeepMeLoggedIn"] != null)
			{
				
				ViewBag.Message = "You're already logged in";
			}
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		[HttpPost]
		public ActionResult Login()
		{
			var username = Request["username"];
			var password = Request["password"];
			var keepLoggedIn = Request["keepLoggedIn"];

			if (username == "test" && password == "test")
			{
				if (keepLoggedIn == "on")
				{
					HttpCookie KeepMeLoggedInCookie = new HttpCookie("KeepMeLoggedIn");
					KeepMeLoggedInCookie.Value = "true";
					KeepMeLoggedInCookie.Expires = DateTime.Now.AddDays(14);
					Response.Cookies.Add(KeepMeLoggedInCookie);
				}
				else
				{
					Session.Add("loggedIn", true);
				}
			}
			else
			{
				ViewBag.Message = "Wrong Credentials";
			}


			return RedirectToAction("Index");
		}
	}
}