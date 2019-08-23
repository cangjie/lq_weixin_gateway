<%@ Page Language="C#" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="System.Data" %>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        string token = "24_YkIzk74tbABXUqptgVPJrYilzOdJsniQPlTCzmBL4Lb8YeohGqibJrWXbLfYrXos6tXUkmiECLjP3-CcWodzClkKFdRA2DodKObsU7gjex-GIOwO_EJkJh2BslQKFXgADAXSK";
        try
        {
            token = Util.GetToken();
        }
        catch
        {

        }
        MpNews[] newsArr = MpNews.GetMPNewsArr(token, 0, 10);
        string title = "";
        string mediaId = "";
        for (int i = 0; i < newsArr.Length; i++)
        {
            bool find = false;
            foreach (RepliedMessage.news news in newsArr[i].newsArr)
            {
                if (Regex.IsMatch(news.title, @"[20\d\d\d\d\d\d老马复盘].+"))
                {
                    find = true;
                    title = news.title.Trim();
                    mediaId = newsArr[i].mediaId.Trim();
                    break;
                }
            }
            if (find)
            {
                break;
            }
        }
        DataTable dt = DBHelper.GetDataTable(" select distinct wxreceivemsg_from from wxreceivemsg where wxreceivemsg_crt >= dateadd(d, -2, getdate())   ", Util.conStr);
        foreach (DataRow dr in dt.Rows)
        {
            if (DBHelper.InsertData("review_log", new string[,] {
                {"open_id", "varchar", dr[0].ToString().Trim() },
                {"title", "varchar", title.Trim() }
            }, Util.conStr.Trim()) == 1)
            {
                MpNews.SendMpNews(dr[0].ToString().Trim(), mediaId, token.Trim());
            }
        }

    }

    
</script>