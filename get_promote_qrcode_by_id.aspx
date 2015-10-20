<%@ Page Language="C#" %>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        long promoteId = (Request["id"] == null) ? 1 : long.Parse(Request["id"].Trim());
        string imagePath = PromoteQrcode.GetQrcodeImage(promoteId, Server.MapPath("qrcode"));
        Response.Redirect("qrcode/" + imagePath.Trim().Replace("\\","/"));
    }
</script>