<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<% var array = (string[])ViewData["Titles"]; %>
<!DOCTYPE html>
<html>
<head runat="server">
<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
<script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
  <script>
  $(function() {
    $( "#tabs" ).tabs();
  });
  </script>
	<title>Uptime otsingu tulemused</title>
</head>
<body>
<h2>Uptime .NET praktika otsingu tulemused</h2>
	<div id = "tabs">
	<ul>
	<%int lehti= array.Length/13;
	if(lehti*13<array.Length){
	lehti++;
	}
	for(int i=1;i<lehti+1;i++){%>
	<li><a href="#tabs-<%:i%>">  Leht <%:i%>  </a></li>
	<%}
	%>
	</ul><%
	int tooteid=array.Length;
	int j =1;
	while(tooteid>0){%>
	<div id="tabs-<%:j%>">
	<ul>
	<%for(int i=0;i<13;i++){
	if(tooteid==0){
	break;
	}
	tooteid--;%>
	<li><%: array[tooteid]%></li>
	<%}%>
	</ul>
	</div>
	<%j++;}%>
	</div>
</body>
</html>
