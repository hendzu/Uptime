using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Web.Mvc;
using Uptime.webser;
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace Uptime.Controllers
{
    public class CurrencyController : Controller
    {
		public ActionResult Index (String to)
		{

			string url = "http://webservicex.net/currencyconvertor.asmx/ConversionRate?FromCurrency=USD&ToCurrency=" + to.Trim();

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			Stream resStream = response.GetResponseStream();

			StreamReader reader = new StreamReader(resStream, Encoding.UTF8);
			//String responseString = reader.ReadToEnd();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(reader);
			string rate = xmlDoc.GetElementsByTagName("double").Item(0).InnerText.Trim();
			ViewData ["arv"] = rate;
			return View ();
		}
    }
}
