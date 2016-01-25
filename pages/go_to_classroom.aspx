<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

    public string token = "";

    public string dingyueOpenId = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {

       
        
        string callBack = Server.UrlEncode("dingyue/pages/go_to_classroom.aspx?dingyue_open_id=" 
            + Util.GetSafeRequestValue(Request, "dingyue_open_id", ""));
        if ((Session["user_token"] == null || Session["user_token"].ToString().Trim().Equals("")) && Request["token"] == null)
        {
            Response.Redirect("../../authorize_final.aspx?callback=" + callBack, true);
        }
        if (Request["token"] != null)
        {
            Session["user_token"] = Util.GetSafeRequestValue(Request, "token", "");
           int userId = Users.CheckToken(Session["user_token"].ToString());
           //Users users = new Users(userId);
            //DBHelper.up

           dingyueOpenId = Util.GetSafeRequestValue(Request, "dingyue_openid", "");

           string[,] updateParameter = { { "dingyue_openid", "varchar", dingyueOpenId.Trim() } };
            string[,] keyPatameter = {{"uid", "int", userId.ToString()}};
            DBHelper.UpdateData("m_user", updateParameter, keyPatameter, Util.ConnectionStringMall);
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        token : <%=Session["user_token"] %>
        dingyue:<%=dingyueOpenId %>
    </div>
    </form>
</body>
</html>
