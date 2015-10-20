<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        string callBack = Request["callback"] == null ? "" : Request["callback"].Trim();
        Session["call_back_url"] = callBack.Trim(); 
        Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" 
            + System.Configuration.ConfigurationSettings.AppSettings["wxappid"].Trim()   
            + "&redirect_uri=" + Server.UrlEncode("http://weixin.luqinwenda.com/authorize_callback.aspx")
            + "&response_type=code&scope=snsapi_base&state=1000#wechat_redirect", true);
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
