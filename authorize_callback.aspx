<%@ Page Language="C#" %>
<%@ Import Namespace="System.Runtime.Serialization" %>
<%@ Import Namespace="System.Runtime.Serialization.Json" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<!DOCTYPE html>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Request["code"].Trim();
        string state = Request["state"].Trim();
        string jsonStr = Util.GetWebContent("https://api.weixin.qq.com/sns/oauth2/access_token?appid="
            + System.Configuration.ConfigurationSettings.AppSettings["wxappid"].Trim()
            + "&secret=" + System.Configuration.ConfigurationSettings.AppSettings["wxappsecret"].Trim()
            + "&code=" + code + "&grant_type=authorization_code", "GET", "", "text/htm");
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        Dictionary<string, object> json = (Dictionary<string, object>)serializer.DeserializeObject(jsonStr);
        object openId;
        json.TryGetValue("openid", out openId);

        string callBack = Session["call_back_url"] == null ? "" : Session["call_back_url"].ToString().Trim();

        Session["call_back_url"] = "";

        if (callBack.IndexOf('?') > 0)
            callBack = callBack + "&openid=" + Server.UrlEncode(openId.ToString().Trim());
        else
            callBack = callBack + "?openid=" + Server.UrlEncode(openId.ToString().Trim());

        Response.Redirect(callBack, true);
        
        //Response.Redirect(
        
        //Response.Write(openId);
        
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
