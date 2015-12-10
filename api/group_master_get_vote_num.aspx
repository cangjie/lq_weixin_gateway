<%@ Page Language="C#" %>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = int.Parse(Util.GetSafeRequestValue(Request, "id", "0"));
        GroupMaster groupMaster = new GroupMaster(id);
        Response.Write("{\"status\":0 , \"num\": " + groupMaster.VoteNumber.ToString() + " }");
    }
</script>