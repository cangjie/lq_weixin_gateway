﻿<%@ Page Language="C#" %>
<%@ Import Namespace="System.Runtime.Serialization" %>
<%@ Import Namespace="System.Runtime.Serialization.Json" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<%@ Import Namespace="System.IO" %>
<!DOCTYPE html>

<script runat="server">

    public int tryGetOpenIdTimes = 0;

    public string GetOpenId(string code)
    {
        if (tryGetOpenIdTimes > 0)
        {
            System.Threading.Thread.Sleep(1000);
        }
        if (tryGetOpenIdTimes > 10)
        {
            return "";
        }
        tryGetOpenIdTimes++;
        
        string openIdStr = "";

        try
        {

            string jsonStr = "";
            jsonStr = Util.GetWebContent("https://api.weixin.qq.com/sns/oauth2/access_token?appid="
                + System.Configuration.ConfigurationSettings.AppSettings["wxappid"].Trim()
                + "&secret=" + System.Configuration.ConfigurationSettings.AppSettings["wxappsecret"].Trim()
                + "&code=" + code + "&grant_type=authorization_code", "GET", "", "text/htm");
            JavaScriptSerializer serializer = new JavaScriptSerializer();

		



            Dictionary<string, object> json = (Dictionary<string, object>)serializer.DeserializeObject(jsonStr);
            object openId;
            json.TryGetValue("openid", out openId);

            object userAccessToken = "";

            try
            {
                json.TryGetValue("access_token", out userAccessToken);
            }
            catch
            {
                File.AppendAllText(Server.MapPath("/log/authorize_error.txt"), DateTime.Now.ToString() + "\t"
                    + jsonStr.Trim() + "\r\n");
                Response.Write(jsonStr.Trim());
            }

            //Session["user_access_token"] = userAccessToken.ToString();
            
            openIdStr = openId.ToString().Trim();

            Util.GetWebContent("http://weixin.luqinwenda.com/get_user_info.aspx?openid=" + openIdStr + "&accesstoken=" + userAccessToken);
            
            
        }
        catch
        { 
        
        }
        if (openIdStr.Trim().Equals(""))
        {
            return GetOpenId(code);
        }
        else
        {
            return openIdStr.Trim();
        }
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Request["code"].Trim();
        string state = Request["state"].Trim();
        string openId = GetOpenId(code);
        string callBack = Request["callback"].Trim();
        callBack = Server.UrlDecode(callBack);
        
        Users user;
        if (Users.IsExistsUser(openId))
        {
            try
            {
                user = Users.GetUser("openid", openId);
            }
            catch
            {
                user = Users.GetUser("username", openId);
            }
        }
        else
        {
            int userId = Users.AddUser("openid", openId);
            user = new Users(userId);
        }
        string token = user.CreateToken(DateTime.Now.AddDays(100));
        Session["user_token"] = token;
        if (callBack.IndexOf("?") > 0)
            callBack = callBack + "&token=" + token.Trim();
        else
            callBack = callBack + "?token=" + token.Trim();
        //Response.Write(callBack.Trim());
       Response.Redirect(callBack);
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
