using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using AmazonProductAdvtApi;
using Uptime.Models;

namespace ItemLookupSample
{
	class Program
	{
		private const string NAMESPACE = "http://webservices.amazon.com/AWSECommerceService/2011-08-01";
		public static List<Results> Search(string keywords, string searchIndex, int page)
		{
			keywords=keywords.Replace(" ","+");
			bool jargmine = false;
			SignedRequestHelper otsi = new SignedRequestHelper("AKIAJESQ6QJNRFAC2G7A","MfLQGWTUqYQuDNF/tiqeerZDJ1Tjs5PWEKZLcivA","ecs.amazonaws.com");
			List<Results> tooted = new List<Results> ();
			int esimene = 1 + ((page - 1) * 13);//1
			int leht = (esimene-1) / 10 + 1;//1

			XmlDocument doc = FetchPage(searchIndex,keywords,leht, otsi);
			string number = doc.GetElementsByTagName("TotalResults", NAMESPACE).Item(0).InnerText;
			int numVal = Int32.Parse(number);
			if (numVal > 100) {
				numVal = 100;
			}
			if (searchIndex == "All") {
				if (numVal > 50) {
					numVal = 50;
				}
			}
			int jargi;
			int alates = esimene - (10 * (leht - 1));
			if (numVal > (esimene + 12)) {
				jargmine = true;
				jargi = 13;
			} else {
				jargi = numVal - esimene+1;
			}
			float hind;
			while (true) {
				for (int i = alates - 1; i < 10; i++) {
					XmlNode node = doc.GetElementsByTagName ("OfferSummary", NAMESPACE).Item (i);
					//string ID = doc.GetElementsByTagName ("ASIN", NAMESPACE).Item (i).InnerText;
					try{
						hind = float.Parse(node.ChildNodes[0].ChildNodes[0].InnerText)/100;
					}
					catch{
						hind=0;
					}
					//XmlDocument doc2 = FetchItem(ID, otsi);
					string nimi,link;
					try{
						nimi=doc.GetElementsByTagName ("Title", NAMESPACE).Item (i).InnerText;}
					catch{
						nimi = "nimi";
					}
					try{
						link = doc.GetElementsByTagName ("DetailPageURL", NAMESPACE).Item (i).InnerText;}
					catch{
						link = "link";
					}
					tooted.Add(new Results() {
						link=link,
						nimi=nimi,
						hind=hind
					});
					jargi--;
					if (jargi == 0) {
						break;}
				}
				alates = 1;
				leht++;
				if (jargi == 0) {
					break;}
				doc = FetchPage(searchIndex,keywords,leht, otsi);
			}
			if (jargmine == true) {
				tooted.Add (new Results (){ nimi = "Järgmine leht", link = "results?SearchIndex="+searchIndex+"&Search="+keywords+"&Page="+(page+1), hind = 0 });
			}

			return tooted;
		}
		private static XmlDocument FetchPage(string searchIndex, string keywords, int page, SignedRequestHelper otsi)
		{

			string requestString = "Service=AWSECommerceService" 
				+ "&Version=2011-08-01"
				+ "&Operation=ItemSearch"
				+ "&ItemPage="+page
				+ "&AssociateTag=PutYourAssociateTagHere"
				+ "&SearchIndex="+searchIndex
				+ "&ResponseGroup=Medium"
				+ "&MerchantId=All"
				+ "&Keywords=" + keywords
				;
			string requestUrl;
			requestUrl = otsi.Sign(requestString);
			WebRequest request = HttpWebRequest.Create(requestUrl);
			WebResponse response = request.GetResponse();
			XmlDocument doc = new XmlDocument();
			doc.Load(response.GetResponseStream());
			return doc;
			
		}
		private static XmlDocument FetchItem(string id, SignedRequestHelper otsi)
		{

			string requestString = "Service=AWSECommerceService" 
				+ "&Version=2011-08-01"
				+ "&Operation=ItemLookup"
				+ "&AssociateTag=PutYourAssociateTagHere"
				+ "&ItemId=" + id
				;
			string requestUrl;
			requestUrl = otsi.Sign(requestString);
			WebRequest request = HttpWebRequest.Create(requestUrl);
			WebResponse response = request.GetResponse();
			XmlDocument doc = new XmlDocument();
			doc.Load(response.GetResponseStream());
			return doc;

		}}}