<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import namespace="Uptime.Models" %>
<%@ Import namespace="System.IO" %>
<%@ Import namespace="Newtonsoft.Json" %>
<% List<Results> vasteid = (List<Results>)ViewData["tooted"]; %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Uptime otsing</title>
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
	<script type="text/javascript" src="Scripts/TableRefresh.js"></script>
	<% List<Results> vasteid = (List<Results>)ViewData["tooted"]; %>
	<%try{%>
	<link rel="dns-prefetch" href=<%:vasteid[13].link%>/>
	<%}
	catch{
	try{%>

	<link rel="prerender" href=<%:vasteid[13].link%>/>
	<%}
	catch{}}%>
</head>
<body>
<div class="container">
	<a href="home">
	 <img src="Content/logo_uptime.gif"></a>
	 <h4>Valuuta:</h4>
	 <select class="form-control" id="valuuta" onChange="vahetus();">
	 <% 
	 foreach(www.webservicex.net.FromCurrency currency in Enum.GetValues (typeof(www.webservicex.net.FromCurrency)))
	 {%>
	 <option<%if(www.webservicex.net.FromCurrency.USD==currency){%>
	 selected="selected"
	 <%}%> value=<%:currency%>>
	 <%:currency%>
	 </option>
	 <%} %>
	 </select>
	 <div id="confirm" hidden></div>
	<div id="vasted">
	<table class="table">
	<tr>
	<th>Toode</th>
	<th>Hind</th>
	</tr>
	<%if(vasteid.Count<14){
	int i =0;
	foreach(Results vaste in vasteid){%>
	<tr>
	<td>
	<a href=<%:vaste.link%>>
	<%: vaste.nimi%>
	</a>
	</td>
	<td id="i<%:i%>" >
	<%:vaste.hind%> USD
	</td>
	<td id="a<%:i%>" hidden>
	<%:vaste.hind%>
	</td>
	</tr>
	<%i++;
	}%>
	</table>
	<%}
	else{
	for(int i=0;13>i;i++){%>
	<tr>
	<td>
	<a href=<%:vasteid[i].link%>>
	<%: vasteid[i].nimi%>
	</a>
	</td>
	<td id="i<%:i %>" >
	<%:vasteid[i].hind%> USD
	</td>
	</td>
	<td id="a<%:i %>" hidden>
	<%:vasteid[i].hind%>
	</td>
	</tr>
	<%}%>
	</table>
	<a href=<%:vasteid[13].link%> class="btn btn-primary btn-lg btn-block" role="button">
	<%: vasteid[13].nimi%>
		</a>
	<%} %>
	</div>
</div>
</body>
</html>
