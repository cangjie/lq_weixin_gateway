﻿<%@ Page Language="C#" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Stream s = Request.InputStream;
            StreamReader sr = new StreamReader(s);
            string jsonStr = sr.ReadToEnd();
			File.WriteAllText(Server.MapPath("111.txt"),jsonStr);
			//Response.Write(jsonStr);
			//return;
            //jsonStr = "{\"fromuser\":\"gh_7c0c5cc0906a\",\"touser\":\"oqrMvt8K6cwKt5T1yAavEylbJaRs\",\"msgtype\":\"news\",\"news\":{\"articles\": [{\"title\":\"Happy Day\",\"description\":\"Is Really A Happy Day\",\"url\":\"http://www.luqinwenda.com\",\"picurl\":\"http://www.nanshanski.com/images/ppt1.jpg\"},{\"title\":\"Happy Day2\",\"description\":\"Is Really A Happy Day2\",\"url\":\"http://www.nanshanski.com\",\"picurl\":\"http://www.nanshanski.com/images/ppt2.jpg\"}]}}";
            ServiceMessage serviceMessage = new ServiceMessage(jsonStr);
            int i = ServiceMessage.SendServiceMessage(serviceMessage);
            Response.Write("{\"status\":0,\"message_id\":" + i.ToString() + "}");
        }
    }
</script>