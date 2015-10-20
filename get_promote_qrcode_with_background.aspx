<%@ Page Language="C#" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.IO" %>
<script runat="server">

    public string openId = "";
    public string type = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        openId = Request["openid"] == null ? "oqrMvtySBUCd-r6-ZIivSwsmzr44" : Request["openid"].Trim();
        type = Request["type"] == null ? "" : Request["type"].Trim();
        long promoteId = Util.GetInviteCode(openId, type);
        string ticket = Util.GetQrCodeTicketTemp(Util.GetToken(), promoteId);
        byte[] qrCodeByteArr = Util.GetQrCodeByTicket(ticket);
        System.Drawing.Image qrCodeImage = System.Drawing.Image.FromStream(new MemoryStream(qrCodeByteArr));
        System.Drawing.Image fingerImage = System.Drawing.Image.FromFile(Server.MapPath("images/finger_print.jpg"));
        System.Drawing.Image iconImage = System.Drawing.Image.FromFile(Server.MapPath("images/qr_head_icon.png"));
        Graphics fingerGraph = Graphics.FromImage(fingerImage);
        fingerGraph.DrawImage(qrCodeImage, 40, 40, 550, 550);
        fingerGraph.DrawImage(iconImage, 230, 230);
        fingerGraph.Save();
        Response.ContentType = "image/jpeg";  
        fingerImage.Save(Response.OutputStream,System.Drawing.Imaging.ImageFormat.Jpeg);
        
    }
</script>