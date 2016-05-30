<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Xml" %>
<!DOCTYPE html>

<script runat="server">

    public string timeStamp = "1423973912";
    public string nonceStr = "x9l1yah0zaxvz4j9ytfbmsh9f4jvmpg6";
    public string prepayId = "wx20150215121832b70ccf09200856361135";
    public string ticket = "";
    public string shaParam = "";
    public string appId = "wx905b45631b024b9c";
    public string jsPatameter = "";
    public string jsMd5 = "";
    public string jsMD5Enc = "";
    public string jsMD5Str = "";
    protected void Page_Load(object sender, EventArgs e)
    {

	Response.Redirect("http://weiketang.streaming.mediaservices.chinacloudapi.cn/a0c34c3b-eefc-4238-91f7-3c0d8d7ad65d/992057c9-0e81-4afa-95df-33ab93449783.ism/Manifest(format=m3u8-aapl)",true);


        jsMD5Str = "appId=wx905b45631b024b9c&timeStamp=" + timeStamp.Trim() + "&nonceStr=" + nonceStr.Trim() + "&package=prepay_id=" + prepayId.Trim() + "&signType=SHA1";
        //string jsMD5Str = "appId=wx905b45631b024b9c&nonceStr=lcfndscnduapju9z6bxy52tznxrpfurr&package=prepay_id=wx20150214161922fb4f1f4c860428369837&signType=MD5&timeStamp=1423901962&key=jihuowangluoactivenetworkjarrodc";
          
        
        
        //appId=wx905b45631b024b9c&nonceStr=lcfndscnduapju9z6bxy52tznxrpfurr&package=prepay_id=wx20150214161922fb4f1f4c860428369837&signType=MD5&timeStamp=1423901962
        jsMD5Str = Util.GetSortedArrayString(jsMD5Str);
        
        jsMD5Enc = Util.GetMd5Sign(jsMD5Str, "jihuowangluoactivenetworkjarrodc");

        jsMD5Enc = Util.GetSHA1(jsMD5Str + "&key=jihuowangluoactivenetworkjarrodc").ToUpper();
        
        
        //jsMD5Enc = Util.GetMd5(jsMD5Str).ToUpper();
        
        string jsonStrForTicket = Util.GetWebContent("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token="
           + Util.GetToken() + "&type=jsapi", "get", "", "form-data");
        ticket = Util.GetSimpleJsonValueByKey(jsonStrForTicket, "ticket");
        string shaString = "jsapi_ticket=" + ticket.Trim() + "&noncestr=" + nonceStr.Trim()
            + "&timestamp=" + timeStamp.Trim() + "&url=" + Request.Url.ToString().Trim();

        shaParam = Util.GetSHA1(shaString);

        string[] jsPArr = jsMD5Str.Split('&');

        jsMd5 = "";
        foreach (string s in jsPArr)
        {
            string key = s.Split('=')[0].Trim();
            string v = s.Substring(key.Length+1, s.Length - key.Length-1).Trim();
            jsMd5 = jsMd5  + key.Trim() + ":'" + v + "',\r\n";
        }
        jsMd5 = jsMd5 + "paySign:'" + jsMD5Enc + "'";
        
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://res.wx.qq.com/open/js/jweixin-1.0.0.js" ></script>
    <script type="text/javascript" >
        wx.config({
            debug: true,
            appId: '<%=appId%>',
            timestamp: '<% =timeStamp%>',
            nonceStr: '<%=nonceStr%>',
            signature: '<% =shaParam %>',
            jsApiList: ['chooseWXPay']
        });
        wx.ready(function () {
            alert('prepare to pay');

            
            wx.chooseWXPay({<%=jsMd5%>,
                    success:function (res) {
                
                        alert(res.err_code+ "!" + res.err_desc + "!" + res.err_msg);
            
                    }});
       
            /*
            WeixinJSBridge.invoke('getBrandWCPayRequest',
                {
                   
                },
                    function (res) {
                        alert(res.err_code+ "!" + res.err_desc + "!" + res.err_msg);
                    }
                    ); */

        });
       
                wx.error(function (res) {
                    alert(res.err_code+ "!" + res.err_desc + "!" + res.err_msg);
                });
               
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%=jsMd5 %>
    </div>
    </form>
</body>
</html>
