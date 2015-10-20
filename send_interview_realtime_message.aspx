<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.IO" %>
<!DOCTYPE html>

<script runat="server">

    public string[] GetActiveOpenid()
    {
        return new string[0];
    }

    public string[] GetTestOpenId()
    {
        return new string[1] { "oqrMvt8K6cwKt5T1yAavEylbJaRs" };
    }
    
   

    public RepliedMessage.news[] GetInterviewContent()
    {

        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://test.luqinwenda.com/index.php?app=public&mod=api&act=getInterviewFeed&p=1");
        HttpWebResponse res = (HttpWebResponse)req.GetResponse();
        string jsonStr = (new StreamReader(res.GetResponseStream())).ReadToEnd();
        res.Close();
        req.Abort();

        JavaScriptSerializer serializer = new JavaScriptSerializer();
        Dictionary<string, object> json = (Dictionary<string, object>)serializer.DeserializeObject(jsonStr);
        
        object questionData;

        json.TryGetValue("data", out questionData);

        object[] questionDataArr = (object[])questionData;

        int count = (questionDataArr.Length > 3) ? 3 : questionDataArr.Length;
       
        
        RepliedMessage.news[] newsContentArr = new RepliedMessage.news[count*2+1];

        newsContentArr[0] = new RepliedMessage.news();

        newsContentArr[0].picUrl = "http://weixin.luqinwenda.com/images/luqin_fangtan_head_image.jpeg";
        newsContentArr[0].title = "卢老师访谈正在进行中！";
        newsContentArr[0].description = "已经有67位家长的问题迎刃而解。";

        for (int i = 0; i < count; i++)
        {
            Dictionary<string, object> currentQuestion = (Dictionary<string, object>)questionDataArr[i];
            object uid;
            
            currentQuestion.TryGetValue("uid", out uid);

            string userName = "匿名家长";
            string userHead = "http://weixin.luqinwenda.com/images/user_head.png";
            string answerHead = "http://weixin.luqinwenda.com/images/luqin_head.png";
            
            
            
            if (!uid.ToString().Equals("-1"))
            {
                object userInfoObject;
                currentQuestion.TryGetValue("user_info", out userInfoObject);
                Dictionary<string, object> userInfo = (Dictionary<string, object>)userInfoObject;
                object userNameObject = "";
                userInfo.TryGetValue("uname", out userNameObject);
                userName = userNameObject.ToString().Trim();
                object userHeadObject = "";
                userInfo.TryGetValue("avatar_small", out userHeadObject);
                userHead = userHeadObject.ToString();
                
            }

            object questionStr = "";
            object answerStr = "";

            currentQuestion.TryGetValue("body", out questionStr);

            object answerObj;
            currentQuestion.TryGetValue("answer", out answerObj);

            ((Dictionary<string, object>)((object[])answerObj)[0]).TryGetValue("body", out answerStr);

            newsContentArr[i * 2 + 1].title = userName + "：" + questionStr.ToString().Trim();
            newsContentArr[i * 2 + 1].description = newsContentArr[i * 2 + 1].title;
            newsContentArr[i * 2 + 1].picUrl = userHead.Trim();

            newsContentArr[i * 2 + 2].title = (answerStr.ToString().Trim().Length > 40) ? (answerStr.ToString().Trim().Substring(0, 30)+"……" ) : answerStr.ToString().Trim();
            newsContentArr[i * 2 + 2].description = newsContentArr[i * 2 + 2].title;
            newsContentArr[i * 2 + 2].picUrl = answerHead.Trim();
            
        }
        

        return newsContentArr;
    }

    public void SendMessages(string[] openid)
    {
        
        //ServiceMessage serviceMessage = new ServiceMessage();
        
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {

    }



    protected void Button2_Click(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //GetInterviewContent();
        RepliedMessage repliedMessage = new RepliedMessage();
        repliedMessage.from = "gh_7c0c5cc0906a";
        repliedMessage.to = "oqrMvt8K6cwKt5T1yAavEylbJaRs";
        repliedMessage.newsContent = GetInterviewContent();
        repliedMessage.type = "news";
        repliedMessage.SendAsServiceMessage();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="SendTest" />
&nbsp;&nbsp;&nbsp;&nbsp;
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send" />
    
    </div>
    </form>
</body>
</html>
