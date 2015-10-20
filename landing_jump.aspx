<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = int.Parse(Request["jumpid"].Trim());
        string openId = Request["openid"].Trim();

        switch (id)
        { 
            case 1:
                Response.Redirect("http://mall.luqinwenda.com/Activity_childrensday.aspx?preopenid="
                    + openId.Trim() + "&openid=" + openId.Trim() + "&source=1", true);
                break;
            default:
                break;
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
    
    </div>
    </form>
</body>
</html>
