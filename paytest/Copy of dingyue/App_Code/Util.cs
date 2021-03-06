﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;
using System.Xml;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Util
/// </summary>
public class Util
{
	public Util()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string GetAccessToken(string appId, string appSecret)
    {
        string token = "";
        string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid="+ appId.Trim() +"&secret=" + appSecret.Trim() ;
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse res = (HttpWebResponse)req.GetResponse();
        Stream s = res.GetResponseStream();
        string ret = (new StreamReader(s)).ReadToEnd();
        s.Close();
        res.Close();
        req.Abort();

        JavaScriptSerializer serializer = new JavaScriptSerializer();
        Dictionary<string, object> json = (Dictionary<string, object>)serializer.DeserializeObject(ret);
        object v;
        json.TryGetValue("access_token", out v);
        token = v.ToString();

        return token;
    }

    public static string Get2014SummerCampVideoForWexinNews()
    {
        string xmlStr = "<item>"
            + "<Title><![CDATA[2014年“放飞梦想我能行”知心姐姐北京营纪录片]]></Title>"
            + "<Description><![CDATA[看到最后有惊喜……你会看到从未见过的神奇场景！]]></Description>"
            + "<PicUrl><![CDATA[http://img.luqinwenda.com/beijing.jpeg]]></PicUrl>"
            + "<Url><![CDATA[http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=201013628&idx=1&sn=2d30e27d8a9b3dbbe6d61910f1a67399#rd]]></Url>"
            + "</item>"
            + "<item>"
            + "<Title><![CDATA[2014年“勇敢小使者”知心姐姐草原发现之旅纪录片]]></Title>"
            + "<Description><![CDATA[2014年知心姐姐“勇敢者小使者”草原发现之旅纪录片]]></Description>"
            + "<PicUrl><![CDATA[http://img.luqinwenda.com/caoyuan.jpeg]]></PicUrl>"
            + "<Url><![CDATA[http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=201035393&idx=1&sn=1c37602ed48f04a2ae29fc87dc71ce8c#rd]]></Url>"
            + "</item>"
            + "<item>"
            + "<Title><![CDATA[2014年“快乐生存，我真了不起”知心姐姐鸡公山营纪录片]]></Title>"
            + "<Description><![CDATA[听，孩子们的呐喊声，你知道他们在喊什么吗？]]></Description>"
            + "<PicUrl><![CDATA[http://img.luqinwenda.com/jigongshan.jpeg]]></PicUrl>"
            + "<Url><![CDATA[http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=201082003&idx=1&sn=919fe437486f1f5370be88ecd564c187#rd]]></Url>"
            + "</item>"
            + "<item>"
            + "<Title><![CDATA[2014年“快乐生存，秦岭自然体验营”，知心姐姐探秦岭龙脉，访西安古城纪录片]]></Title>"
            + "<Description><![CDATA[六天五晚的时光，秦岭的印象，大自然的声音，孩子们的欢声笑语，一点一滴都浓缩在这个短片中。现在让我们来重温这些美好的记忆吧！]]></Description>"
            + "<PicUrl><![CDATA[http://img.luqinwenda.com/qinling.jpeg]]></PicUrl>"
            + "<Url><![CDATA[http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=201121027&idx=1&sn=78be8563d12eb4850a091f2d6765ff91#rd]]></Url>"
            + "</item>"
            + "<item>"
            + "<Title><![CDATA[2014年世贸天阶梦想放飞仪式纪录片]]></Title>"
            + "<Description><![CDATA[世贸天阶无数孩子一起分享的震撼视频！]]></Description>"
            + "<PicUrl><![CDATA[http://img.luqinwenda.com/qinling.jpeg]]></PicUrl>"
            + "<Url><![CDATA[http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=201121027&idx=1&sn=78be8563d12eb4850a091f2d6765ff91#rd]]></Url>"
            + "</item>";
        return xmlStr;
    }


    public static XmlDocument CreateReplyDocument(int id)
    {



        XmlDocument xmlD = new XmlDocument();
        xmlD.LoadXml("<xml></xml>");

        string from = "";
        string to = "";
        string msgType = "";
        int msgCount = 1;
        string content = "";

        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["constr"].Trim());
        SqlCommand cmd = new SqlCommand(" select * from wxreplymsg where wxreplymsg_id = " + id.ToString(), conn);
        conn.Open();
        SqlDataReader sqlDr = cmd.ExecuteReader();
        if (sqlDr.Read())
        {
            msgType = sqlDr["wxreplymsg_msgtype"].ToString().Trim();
            from = sqlDr["wxreplymsg_from"].ToString().Trim();
            to = sqlDr["wxreplymsg_to"].ToString().Trim();
            msgCount = int.Parse(sqlDr["wxreplymsg_msgcount"].ToString().Trim());

            XmlNode n = xmlD.CreateNode(XmlNodeType.Element, "FromUserName", "");
            n.InnerXml = "<![CDATA[" + from + "]]>";
            xmlD.SelectSingleNode("//xml").AppendChild(n);

            n = xmlD.CreateNode(XmlNodeType.Element, "ToUserName", "");
            n.InnerXml = "<![CDATA[" + to + "]]>";
            xmlD.SelectSingleNode("//xml").AppendChild(n);

            n = xmlD.CreateNode(XmlNodeType.Element, "CreateTime", "");
            n.InnerText = GetTimeStamp().Trim();
            xmlD.SelectSingleNode("//xml").AppendChild(n);

            n = xmlD.CreateNode(XmlNodeType.Element, "MsgType", "");
            n.InnerXml = "<![CDATA[" + msgType + "]]>";
            xmlD.SelectSingleNode("//xml").AppendChild(n);



            switch (msgType)
            {
                case "text":
                    content = sqlDr["wxreplymsg_content"].ToString().Trim();
                    n = xmlD.CreateNode(XmlNodeType.Element, "Content", "");
                    n.InnerXml = "<![CDATA[" + content + "]]>";
                    xmlD.SelectSingleNode("//xml").AppendChild(n);

                    break;
                case "news":
                    n = xmlD.CreateNode(XmlNodeType.Element, "ArticleCount", "");
                    n.InnerXml = "<![CDATA[" + sqlDr["wxreplymsg_msgcount"].ToString().Trim() + "]]>";
                    xmlD.SelectSingleNode("//xml").AppendChild(n);
                    n = xmlD.CreateNode(XmlNodeType.Element, "Articles", "");
                    n.InnerXml = sqlDr["wxreplymsg_content"].ToString().Trim();
                    xmlD.SelectSingleNode("//xml").AppendChild(n);

                    break;
                default:

                    break;
            }
        }

        sqlDr.Close();
        conn.Close();
        cmd.Dispose();
        conn.Dispose();

        return xmlD;
    }
    public static string GetTimeStamp()
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalSeconds).ToString();
    }
}