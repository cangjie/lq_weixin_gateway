<%@ Page Language="C#" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<%@ Import Namespace="System.Security.Cryptography" %>
<!DOCTYPE html>

<script runat="server">

    public string timeStamp = "";

    public string ticket = "";

    public string nonceStr = Util.GetNonceString(32);

    public string signature = "";

    public string shaString = "";

    public string shaStrOri = "";
    
    public string appId = System.Configuration.ConfigurationSettings.AppSettings["wxappid"];
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        timeStamp = Util.GetTimeStamp();
        string jsonStr = GetUrlContent("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token="
            + Util.GetToken() + "&type=jsapi");
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        Dictionary<string, object> json = (Dictionary<string, object>)serializer.DeserializeObject(jsonStr);
        object v;
        json.TryGetValue("ticket", out v);
        ticket = v.ToString();
        shaString = "jsapi_ticket=" + ticket.Trim() + "&noncestr=" + nonceStr.Trim() 
            + "&timestamp="+timeStamp.Trim()+"&url="+Request.Url.ToString().Trim();
        shaStrOri = shaString;
        /*
        SHA1 sha = SHA1.Create();
        ASCIIEncoding enc = new ASCIIEncoding();
        byte[] bArr = enc.GetBytes(shaString);
        bArr = sha.ComputeHash(bArr);
        string validResult = "";
        for (int i = 0; i < bArr.Length; i++)
        {
            validResult = validResult + bArr[i].ToString("x").PadLeft(2, '0');
        }
         */
        shaString = Util.GetSHA1(shaStrOri);
    }

    public string GetUrlContent(string url)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse res = (HttpWebResponse)req.GetResponse();
        string s = new StreamReader(res.GetResponseStream()).ReadToEnd();
        res.Close();
        req.Abort();
        return s;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js" ></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <script type="text/javascript" >
            wx.config({
                debug: true,
                appId: '<%=appId%>',
                timestamp: '<% =timeStamp%>',
                nonceStr:'<%=nonceStr%>',
                signature:'<% =shaString %>',
                jsApiList: ['getNetworkType', 'getLocation']
            });
            wx.ready(function () {
                alert('aaa');
            });
            wx.error(function (res) {
                alert(res);
            });
        </script>
        <%=shaStrOri %>
    </div>
    </form>
</body>
</html>
