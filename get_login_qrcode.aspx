<%@ Page Language="C#" %>
<%@ Import Namespace="System.Runtime.Serialization" %>
<%@ Import Namespace="System.Runtime.Serialization.Json" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        long loginCode = Request["logincode"] == null ? 4294967295 : long.Parse(Request["logincode"].Trim());
        string token = Util.GetToken();
        string ticket = Util.GetQrCodeTicketTemp(token, loginCode);
        try
        {
            byte[] qrCodeByteArr = Util.GetQrCodeByTicket(ticket);
            Response.ContentType = "image/jpeg";
            Response.BinaryWrite(qrCodeByteArr);
        }
        catch(Exception err)
        {
            
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Dictionary<string, object> json = (Dictionary<string, object>)serializer.DeserializeObject(ticket);
            object v;
            json.TryGetValue("errcode", out v);
            if (v.ToString().Trim().Equals("40001"))
            {
                Util.ForceGetToken();
                Response.Redirect("get_login_qrcode.aspx?logincode=" + Request["logincode"].Trim(), true);
            }
            else
            {
                Response.Write(ticket);
            }
            
        }
    }
</script>