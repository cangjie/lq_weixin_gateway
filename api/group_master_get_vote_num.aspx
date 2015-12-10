<%@ Page Language="C#" %>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = int.Parse(Util.GetSafeRequestValue(Request, "id", "1"));
        GroupMaster groupMaster = new GroupMaster(id);
        try
        {
            Response.Write("{\"status\":0 , \"num\": " + groupMaster.VoteNumber.ToString() + " }");
        }
        catch
        {
            Response.Write("{\"status\":1 , \"error_message\" : \"The group is not exists.\"}");
        }
    }
</script>