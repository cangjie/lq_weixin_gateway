<%@ Page Language="C#" %>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = int.Parse(Util.GetSafeRequestValue(Request, "id", "0"));
        string jumpUrl = "";
        switch (id)
        { 
            case 21:
                jumpUrl = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=404799164&idx=1&sn=0c3db5b778a73fcebbcd3464499d752d#rd";
                break;
            case 22:
                jumpUrl = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=404790715&idx=2&sn=ae0c64da8d02002e0172303c1625ca21#rd";
                break;
            case 23:
                jumpUrl = "https://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=404790715&idx=2&sn=ae0c64da8d02002e0172303c1625ca21&key=710a5d99946419d9153b41dae430268d7f0c716563569d79e7564acce355e15f1bedd227b4e8f0df534d2a022174ee03&ascene=0&uin=ODk3MzEzNzY0&devicetype=iMac+MacBookAir6%2C2++10.11.3+build(15D21)&version=11020201&pass_ticket=DoDG0KgnLvpaAOSrBmhxd3SMBHuQd4FEkfvqq280WqukFe898MHexipdePVFLLAq";
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