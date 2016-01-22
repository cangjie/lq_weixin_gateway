<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

    public string token = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string callBack = Server.UrlEncode("dingyue/pages/go_to_classroom.aspx?dingyue_open_id=" 
            + Util.GetSafeRequestValue(Request, "dingyue_open_id", ""));
        if ((Session["user_token"] == null || Session["user_token"].ToString().Trim().Equals("")) && Request["token"] == null )
        {
            Response.Redirect("../../authorize_final.aspx?callback=" + callBack, true);
        }

        if (Request["token"] != null)
            Session["user_token"] = Util.GetSafeRequestValue(Request, "token", "");
        
        
        
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        token : <%=Session["token"] %>
    </div>
    </form>
</body>
</html>
