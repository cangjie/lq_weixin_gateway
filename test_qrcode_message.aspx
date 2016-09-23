<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        string qrXuMediaId1 = Util.UploadImageToWeixin(System.Configuration.ConfigurationSettings.AppSettings["qrcode_path"].Trim()
                       + "\\28.jpg", Util.GetToken());
        RepliedMessage imageMessage1 = new RepliedMessage();
        imageMessage1.from = "gh_7c0c5cc0906a";
        imageMessage1.to = "oqrMvtySBUCd-r6-ZIivSwsmzr44";
        imageMessage1.type = "image";
        imageMessage1.mediaId = qrXuMediaId1.Trim();
        imageMessage1.SendAsServiceMessage();
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
