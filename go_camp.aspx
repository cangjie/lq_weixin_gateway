<%@ Page Language="C#" %>
<%

	Response.Redirect("http://www.luqinwenda.com/index.php?app=public&mod=Passport&act=pactbj2"
		+  ((Request["from"] == null) ? "" : "&from=" + Request["from"].Trim())   ,true);
%>