<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

    public string token = Util.GetToken();

    public string allUserJson = "";

    public object[] openIdArr;

    protected void Page_Load(object sender, EventArgs e)
    {
        allUserJson = Util.GetWebContent("https://api.weixin.qq.com/cgi-bin/user/get?access_token=" + token);

        Dictionary<string, object> dataObj = Util.GetObjectFromJsonByKey(allUserJson, "data");

        openIdArr = (object[])dataObj["openid"];

    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" >
        var open_id_arr = new Array();
        <%
        for (int i = 0; i < openIdArr.Length; i++)
        {
            %>
        open_id_arr[<%=i.ToString()%>] = "<%=openIdArr[i].ToString()%>";
        <%
        }
        %>
        


    </script>
</head>
<body>
    <div>
        
        <div><input type="button" value="send" /> 总共：<span id="total_num" ></span> 已发：<span id="send_num" ></span></div>
        <div>Template ID:<input type="text" id="txt_template_id" /></div>
        <div><br /></div>
        <div style="">Template JSON:<textarea cols="50" rows="25" id="txt_template_data"  ></textarea> </div>
    </div>
    <script type="text/javascript" >
        var total_num = open_id_arr.length;
        var send_num = 0;
        document.getElementById("total_num").innerText = total_num;
        document.getElementById("send_num").innerText = send_num;
    </script>
</body>
</html>
