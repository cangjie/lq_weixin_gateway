<%@ Page Language="C#" %>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = int.Parse(Util.GetSafeRequestValue(Request, "id", "0"));
        string jumpUrl = "";
        switch (id)
        { 
            case 21:
                jumpUrl = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=405128253&idx=1&sn=d56b08ebdbf1cf37c84cca58a5d95311#rd";
                break;
            case 22:
                jumpUrl = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=403387018&idx=2&sn=ce2982e4d8024ad6ac21e2f2ed960a8b#rd";
                break;
            case 23:
                jumpUrl = "https://mp.weixin.qq.com/cgi-bin/appmsg?begin=10&count=10&t=media/appmsg_list2&type=10&action=list_card&token=1518177255&lang=zh_CN";
                break;
            case 31:
                jumpUrl = "http://game.luqinwenda.com/dingyue/Default.aspx";
                break;
            case 32:
                jumpUrl = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=404561527&idx=1&sn=30ca26b010856e8af05db2dc183a0522#rd";
                break;
            case 33:
                jumpUrl = "http://mall.luqinwenda.com/default.aspx";
                break;
            default:
                break;
        }
        Response.Redirect(jumpUrl, true);
    }
</script>