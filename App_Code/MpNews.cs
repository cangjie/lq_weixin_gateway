using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for MpNews
/// </summary>
public class MpNews
{
    public string mediaId = "";

    public RepliedMessage.news[] newsArr;

    public MpNews()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public MpNews(string mediaId, string token)
    {
        this.mediaId = mediaId;
        string jsonStr = Util.GetWebContent("https://api.weixin.qq.com/cgi-bin/material/get_material?access_token=" + token.Trim(), "POST",
            "{\"media_id\":\"" + mediaId + "\"}", "html/text");
        newsArr = ConvertNewsItemJsonToObjectArray(Util.GetObjectArrayFromJsonByKey(jsonStr, "news_item"));

    }

    public static RepliedMessage.news[] ConvertNewsItemJsonToObjectArray(object[] newsItem)
    {
        RepliedMessage.news[] arr = new RepliedMessage.news[newsItem.Length];
        for (int i = 0; i < newsItem.Length; i++)
        {
            Dictionary<string, object> news = (Dictionary<string, object>)newsItem[i];
            arr[i] = new RepliedMessage.news();
            arr[i].title = news["title"].ToString().Trim();
            arr[i].picUrl = news["thumb_url"].ToString().Trim();
            arr[i].description = news["digest"].ToString().Trim();
            arr[i].url = news["url"].ToString().Trim();
        }
        return arr;
    }

    public static MpNews[] GetMPNewsArr(string token, int offset, int count)
    {
        string postJson = "{ \"type\":\"news\", \"offset\":" + offset.ToString() + ", \"count\":" + count.ToString() + "}";
        string jsonStr = Util.GetWebContent("https://api.weixin.qq.com/cgi-bin/material/batchget_material?access_token=" + token.Trim(), "POST", postJson, "html/text");
        object[] itemArr = Util.GetObjectArrayFromJsonByKey(jsonStr, "item");
        MpNews[] mpNewsArr = new MpNews[itemArr.Length];
        for (int i = 0; i < itemArr.Length; i++)
        {
            mpNewsArr[i] = new MpNews();
            Dictionary<string, object> item = (Dictionary<string, object>)itemArr[i];
            Dictionary<string, object> content = (Dictionary<string, object>)item["content"];
            mpNewsArr[i].mediaId = item["media_id"].ToString().Trim();
            mpNewsArr[i].newsArr = MpNews.ConvertNewsItemJsonToObjectArray((object[])content["news_item"]);
            /*
            mpNewsArr[i].newsArr = new RepliedMessage.news[((object[])content["news_item"]).Length];
            for (int j = 0; j < mpNewsArr[i].newsArr.Length; j++)
            {
                Dictionary<string, object> news = (Dictionary<string, object>)((object[])content["news_item"])[j];
                mpNewsArr[i].newsArr[j] = new RepliedMessage.news();
                mpNewsArr[i].newsArr[j].title = news["title"].ToString();
            }
            */
        }
        return mpNewsArr;
    }

    public static string SendMpNews(string openId, string mediaId, string token)
    {
        string url = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + token.Trim();
        string postData = "{\"touser\":\"" + openId.Trim() + "\",\"msgtype\":\"mpnews\",\"mpnews\":{\"media_id\":\"" + mediaId.Trim() + "\"}}";
        return Util.GetWebContent(url, "POST", postData, "html/text");
    }

    public static string GetMediaIdByFirstTitle(string title, string token)
    {
        MpNews[] newsArr = GetMPNewsArr(token.Trim(), 0, 1000);
        string mediaId = "";
        foreach (MpNews mpNews in newsArr)
        {
            bool find = false;
            foreach (RepliedMessage.news news in mpNews.newsArr)
            {
                if (news.title.Trim().Equals(title.Trim()))
                {
                    find = true;
                    mediaId = mpNews.mediaId.Trim();
                    break;
                }
            }
            if (find)
            {
                break;
            }
        }
        return mediaId.Trim();
    }

    public static int SetReplyNewsMessage(string type, string keyword, string title, string token)
    {
        DBHelper.DeleteData("event_reply_messages", new string[,] {
            {"event_type", "varchar", type.Trim() },
            {"event_name", "varchar", keyword.Trim() },
        }, Util.conStr);

        string mediaId = GetMediaIdByFirstTitle(title, token);
        string messageType = "news";
        if (mediaId.Trim().Equals(""))
        {
            DBHelper.InsertData("event_reply_messages", new string[,] {
                {"event_type", "varchar", type.Trim() },
                {"event_name", "varchar", keyword.Trim() },
                {"title", "varchar", title.Trim() },
                {"descript", "varchar", "" },
                {"pic_url", "varchar", "" },
                {"message_type", "varchar", "text" },
                {"content_url", "varchar", "" }
            }, Util.conStr.Trim());
            return 1;

        }
        MpNews mpNews = new MpNews(mediaId, token);
        if (mpNews.newsArr.Length == 0)
        {
            return 0;
        }
        int i = 0;
        foreach (RepliedMessage.news news in mpNews.newsArr)
        {
            if (DBHelper.InsertData("event_reply_messages", new string[,] {
                {"event_type", "varchar", type.Trim() },
                {"event_name", "varchar", keyword.Trim() },
                {"title", "varchar", news.title.Trim() },
                {"descript", "varchar", news.description.Trim() },
                {"pic_url", "varchar", news.picUrl.Trim() },
                {"message_type", "varchar", messageType.Trim() },
                {"content_url", "varchar", news.url.Trim() }
            }, Util.conStr.Trim()) == 1)
            {
                i++;
            }
        }
        return i;
    }

    public static RepliedMessage.news[] GetReplyNewsMessage(string type, string keyword)
    {
        DataTable dt = DBHelper.GetDataTable(" select * from event_reply_messages where event_type = '" + type.Trim()
            + "'  and event_name = '" + keyword.Trim() + "' order by [id] ", Util.conStr);
        RepliedMessage.news[] newsArr = new RepliedMessage.news[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            newsArr[i] = new RepliedMessage.news();
            newsArr[i].title = dt.Rows[i]["title"].ToString();
            newsArr[i].description = dt.Rows[i]["descript"].ToString().Trim();
            newsArr[i].picUrl = dt.Rows[i]["pic_url"].ToString().Trim();
            newsArr[i].url = dt.Rows[i]["content_url"].ToString().Trim();
        }
        return newsArr;
    }

}