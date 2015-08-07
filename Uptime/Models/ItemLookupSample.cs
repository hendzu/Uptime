using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using AmazonProductAdvtApi;

namespace ItemLookupSample
{
	class Program
	{
		private const string NAMESPACE = "http://webservices.amazon.com/AWSECommerceService/2011-08-01";
		public static string[] Search(string keywords, string searchIndex)
		{

			SignedRequestHelper otsi = new SignedRequestHelper("AKIAJESQ6QJNRFAC2G7A","MfLQGWTUqYQuDNF/tiqeerZDJ1Tjs5PWEKZLcivA","ecs.amazonaws.com");
			int page = 1;
			XmlNode titleNode;
			XmlDocument doc = FetchPage(searchIndex,keywords,page, otsi);

			string number = doc.GetElementsByTagName("TotalResults", NAMESPACE).Item(0).InnerText;
			int numVal = Int32.Parse(number);
			if (numVal > 100) {
				numVal = 100;
			}
			string[] items = new string[numVal];
			while (numVal > 10) {
				for (int i = 0; i < 10; i++)
				{
					titleNode = doc.GetElementsByTagName("Title", NAMESPACE).Item(i);
					items[numVal-1]= titleNode.InnerText;
					numVal--;
				}
				page++;
				doc = FetchPage(searchIndex,keywords,page, otsi);
			}
			for (int i = 0; numVal >0; i++)
			{
				titleNode = doc.GetElementsByTagName("Title", NAMESPACE).Item(i);
				items[numVal-1]= titleNode.InnerText;
				numVal--;
			}

			return items;
		}
		private static XmlDocument FetchPage(string searchIndex, string keywords, int page, SignedRequestHelper otsi)
		{

			string requestString = "Service=AWSECommerceService" 
				+ "&Version=2009-03-31"
				+ "&Operation=ItemSearch"
				+ "&ItemPage="+page
				+ "&AssociateTag=PutYourAssociateTagHere"
				+ "&SearchIndex="+searchIndex
				+ "&ResponseGroup=Small"
				+ "&Keywords=" + keywords
				;
			string requestUrl;
			requestUrl = otsi.Sign(requestString);
			WebRequest request = HttpWebRequest.Create(requestUrl);
			WebResponse response = request.GetResponse();
			XmlDocument doc = new XmlDocument();
			doc.Load(response.GetResponseStream());
			return doc;
			
		}}}