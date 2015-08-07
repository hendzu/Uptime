<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Uptime otsing</title>
</head>
<body>
	<%-- <h2>Welcome to ASP.NET MVC < %: ViewData["Version"] %> on < %: ViewData["Runtime"] %>!</h2>--%>
	<h2>Uptime .NET praktika otsing</h2>
	<div id=otsing>
	<form action="results">
	Eseme liigitus<input type="text" name="SearchIndex"><br>
	Eseme nimetus<input type="text" name="Search"><br>
	<input type="submit" value="Otsi">
	</form>
	</div>

</body>

