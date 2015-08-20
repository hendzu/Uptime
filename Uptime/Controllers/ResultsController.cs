using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uptime.Models;

namespace Uptime.Controllers
{
    public class ResultsController : Controller
    {
		static List<Results> tooted = new List<Results> ();

		public ActionResult Index (string Search, string SearchIndex, int Page=1)
		{
			tooted = ItemLookupSample.Program.Search (Search, SearchIndex, Page);

			ViewData ["tooted"] = tooted;

			return View ();
		}

	}
	}