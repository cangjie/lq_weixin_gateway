<%@ Page Language="C#" %>
<script runat="server">
protected void Page_Load(object sender, EventArgs e)
{
	//Response.Redirect("http://mp.weixin.qq.com/mp/getmasssendmsg?__biz=MzA3MTM1OTIwNg==&uin=ODk3MzEzNzY0&key=96f2da6c33869e77a1465a9bf3abce9eb03c20ea2728bd90d3ce5838e172296da08b527243fe69fad279d9f05de4cd62&devicetype=iMac+MacBookAir6%2C2+OSX+OSX+10.10+build(14A389)&version=11010011&lang=en&pass_ticket=jFye4A8YhZipP4xSj%2BLw55OXPLKW2KHNYACnSau9Oqf3oV2P2NdlLO3YXRPEn8Vc#wechat_webview_type=1",true);
	Response.Redirect("http://mp.weixin.qq.com/mp/getmasssendmsg?__biz=MzA3MzM1NjcxNA==#wechat_webview_type=1&wechat_redirect",true);

}
</script>