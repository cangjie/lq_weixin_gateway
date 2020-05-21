<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

    public string openId = "";

    public string userToken = "";

    public int vipLevel = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string currentPageUrl = Request.Url.ToString().Split('?')[0].Trim();
        if (!Request.QueryString.ToString().Trim().Equals(""))
        {
            currentPageUrl = currentPageUrl + "?" + Request.QueryString.ToString().Trim();
        }
        if (Session["user_token"] == null || Session["user_token"].ToString().Trim().Equals(""))
        {
            Response.Redirect("../authorize.aspx?callback=" + currentPageUrl, true);
        }
        userToken = Session["user_token"].ToString();

        openId = WeixinUser.CheckToken(userToken);

        WeixinUser user = new WeixinUser(openId.Trim());
        if (user.VipLevel == 1)
        {
            vipLevel = 1;
        }

    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <%=openId %> <%if (vipLevel == 1)
                     { %>可以查看
    <%
        }
        else
        { 
        %>不可查看
    <%
        }
        %>
</body>
</html>
