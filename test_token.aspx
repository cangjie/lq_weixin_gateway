<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

    public string token = "";

    public DateTime token_time;

    protected void Page_Load(object sender, EventArgs e)
    {
        token = Util.GetToken();
        token_time = Util.tokenTime;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%=token %><br /><%=token_time.ToString() %>
    </div>
    </form>
</body>
</html>
