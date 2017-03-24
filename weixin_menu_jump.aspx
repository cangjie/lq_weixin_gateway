<%@ Page Language="C#" %>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = int.Parse(Util.GetSafeRequestValue(Request, "id", "0"));
        string jumpUrl = "";
        switch (id)
        { 
            case 21:
                jumpUrl = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=406086240&idx=2&sn=2430a3259e8a3409f7bd2d572ebdb241#rd";
                break;
            case 22:
                jumpUrl = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=506765941&idx=1&sn=5eeb8516eba5c7be388d2eccc5044b4a#rd";
                break;
            case 23:
                jumpUrl = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=506765941&idx=2&sn=bc5c3db1858c9036d97637262821e000#rd";
                break;
            case 30:
                jumpUrl = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=405749679&idx=1&sn=b2920ee0725c839666becee897764bbd#rd";
                break;
            case 31:
                jumpUrl = "http://game.luqinwenda.com/dingyue/Default.aspx";
                break;
            case 32:
                jumpUrl = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=405844141&idx=1&sn=fb85317b54adbd207fbb7a56ffd5b4eb#rd";
                break;
            case 33:
                jumpUrl = "https://weidian.com/?userid=842789047&wfr=wx&share_id=842789047&code=011P0V9r05cD0s1rgp9r05gD9r0P0V99&state=H5WXshare";
                break;
            default:
                break;
        }
        Response.Redirect(jumpUrl, true);
    }
</script>