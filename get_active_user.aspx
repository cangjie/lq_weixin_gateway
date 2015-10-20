<%@ Page Language="C#" %>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        string[] userInfoArr = Util.GetActiveOpenId("gh_b8d1e9dcecc8", DateTime.Now.AddDays(-2));
        string jsonStr = "{\"status\":0,\"openid\":[";
        for (int i = 0; i < userInfoArr.Length; i++)
        {
            if (i > 0)
                jsonStr = jsonStr + ",";
            jsonStr = jsonStr + "\"" + userInfoArr[i].Trim() + "\"";
            
        }
        jsonStr = jsonStr + "],\"count\":"  + userInfoArr.Length.ToString() +  "}";
        Response.Write(jsonStr);
    }
</script>