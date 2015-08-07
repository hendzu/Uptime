using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Uptime.Controllers
{
    public class ResultsController : Controller
    {
		public ActionResult Index (string Search, string SearchIndex)
		{
			string[] title=null;
			if (Search != null) {
				title = ItemLookupSample.Program.Search (Search, SearchIndex);
			}
			
			ViewData ["Titles"] = title;

			return View ();
		}

	}
	}