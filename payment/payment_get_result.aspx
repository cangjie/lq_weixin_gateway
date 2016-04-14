<%@ Page Language="C#" %>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        string body = Util.GetSafeRequestValue(Request, "body", "卢勤问答平台微课堂");
        int productId = int.Parse(Util.GetSafeRequestValue(Request, "productid", "398"));
        int amount = int.Parse(Util.GetSafeRequestValue(Request, "amount", "100"));
        Order order = Order.GetOrderByOriginInfo(body, productId, amount);
        if (order.Status == 2)
        {
            Response.Write("PAID");
        }
        else
        {
            Response.Write("UNPAID");
        }
    }
</script>