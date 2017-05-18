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
    <script type="text/javascript" src="../js/jquery.min.js" ></script>
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
        

        open_id_arr = new Array();

        open_id_arr[0] = "oqrMvt-GNYkILld2eoNiBp_0BmzE";
        open_id_arr[1] = "oqrMvt0co2h001MkcQGrW6WYFPbc";
        open_id_arr[2] = "oqrMvt8K6cwKt5T1yAavEylbJaRs";
        open_id_arr[3] = "oqrMvtySBUCd-r6-ZIivSwsmzr44";



    </script>
</head>
<body>
    <div>
        
        <div><input type="button" value="send" onclick="send()"   id="btn" /> 总共：<span id="total_num" ></span> 已发：<span id="send_num" ></span></div>
        <div><br /></div>
        <div style="">Template JSON:<textarea cols="50" rows="25" id="txt_template_data"  ></textarea> </div>
    </div>
    <script type="text/javascript" >
        var total_num = open_id_arr.length;
        var send_num = 0;
        document.getElementById("total_num").innerText = total_num;
        document.getElementById("send_num").innerText = send_num;

        function send() {
            document.getElementById("btn").disabled = true;
            for(var i = 0; i < open_id_arr.length; i++ ){
                send_single_message(open_id_arr[i]);
            }
        }

        function send_single_message(open_id) {
            var template_data = document.getElementById("txt_template_data").innerText;
            template_data = template_data.replace("<@to_user_open_id@>", open_id);
            //alert(template_data);
            $.ajax({
                url: "../api/send_template_message.aspx",
                type: "POST",
                dataType: "text",
                data: template_data,
                async: false,
                success: function () {
                    send_num++;
                    document.getElementById("send_num").innerText = send_num;
                }
            });
        }

    </script>
</body>
</html>
