<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Uptime otsing</title>
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
</head>
<body>
<div class="container">
	<a href="home">
	 <img src="Content/logo_uptime.gif"></a>
	<div id=otsing>
	<form action="results">
	<h3>Eseme liigitus:</h3><input type="text" name="SearchIndex" value="All"><br>
	<h3>Eseme nimetus:</h3><input type="text" name="Search"><br>
	<input type="submit" value="Otsi">
	</form>
	</div>
</div>
</body>
</html>

