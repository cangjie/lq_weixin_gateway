using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for ServiceMessage
/// </summary>
public class ServiceMessage
{
    public struct NewsItem
    {
        public string Title;
        public string Description;
        public string PicUrl;
        public string Url;
    }

    public DataRow _fields;

	public ServiceMessage(int id)
	{
        SqlDataAdapter da = new SqlDataAdapter("select * from wxreplymsg where wxreplymsg_id = " + id.ToString() ,  
            System.Configuration.ConfigurationSettings.AppSettings["constr"].Trim());
        DataTable dt = new DataTable();
        da.Fill(dt);
        da.Dispose();
        _fields = dt.Rows[0];
	}

    public int send(string token)
    {
        string jsonStr = "";
        switch (_fields["wxreplymsg_msgtype"].ToString().Trim().ToUpper())
        { 
            case "TEXT":
                jsonStr = "{\"touser\":\"" + _fields["wxreplymsg_to"].ToString().Trim() +"\",\"msgtype\":\"text\",\"text\":{\"content\":\"" + _fields["wxreplymsg_content"].ToString().Trim() +  "\"}}";
                break;
            default:
                break;
        }

        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + token);
        req.Method = "post";
        req.ContentType = "raw";
        //Stream streamReq = req.GetRequestStream();
        StreamWriter sw = new StreamWriter(req.GetRequestStream());
        sw.Write(jsonStr.Trim());
        sw.Close();
        sw = null;

        HttpWebResponse res = (HttpWebResponse)req.GetResponse();
        Stream s = res.GetResponseStream();
        StreamReader sr = new StreamReader(s);
        string strTicketJson = sr.ReadToEnd();
        sr.Close();
        s.Close();
        sr = null;
        s = null;
        res.Close();
        res = null;
        req.Abort();
        req = null;


        JavaScriptSerializer serializer = new JavaScriptSerializer();
        Dictionary<string, object> json = (Dictionary<string, object>)serializer.DeserializeObject(strTicketJson);
        object v;
        json.TryGetValue("errcode", out v);

        int sendResult = int.Parse(v.ToString());
        if (sendResult == 0)
            sendResult = 1;
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["constr"].Trim());
        SqlCommand cmd = new SqlCommand(" update wxreplymsg set wxreplymsg_send = " + sendResult.ToString() + "  where wxreplymsg_id = " + _fields["wxreplymsg_id"].ToString().Trim(), conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        conn.Dispose();
        cmd.Dispose();
        return sendResult;
    }


    public static int CreateServiceMessage(string from, string to, string type, string content)
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["constr"].Trim());
        SqlCommand cmd = new SqlCommand(" insert into wxreplymsg (wxreplymsg_rootid,wxreplymsg_from,wxreplymsg_to,wxreplymsg_msgcount,wxreplymsg_msgtype,wxreplymsg_content,wxreplymsg_mediaid,wxreplymsg_isservice,wxreplymsg_send) "
            + " values ('',@from,@to,1,@type,@content,@mediaid,1,0) ", conn);
        cmd.Parameters.Add("@from", SqlDbType.VarChar);
        cmd.Parameters.Add("@to", SqlDbType.VarChar);
        cmd.Parameters.Add("@type", SqlDbType.VarChar);
        cmd.Parameters.Add("@content", SqlDbType.VarChar);
        cmd.Parameters.Add("@mediaid", SqlDbType.VarChar);

        cmd.Parameters["@from"].Value = from;
        cmd.Parameters["@to"].Value = to;
        cmd.Parameters["@type"].Value = type;
        if (type.Trim().Equals("text"))
        {
            cmd.Parameters["@content"].Value = content.Trim();
            cmd.Parameters["@mediaid"].Value = "";
        }
        else
        {
            cmd.Parameters["@content"].Value = "";
            cmd.Parameters["@mediaid"].Value = content.Trim();
        }
        conn.Open();
        int i = cmd.ExecuteNonQuery();
        
        cmd.CommandText = " select top 1 wxreplymsg_id from wxreplymsg order by  wxreplymsg_id desc ";

        SqlDataReader drd = cmd.ExecuteReader();
        if (drd.Read())
        {
            i = drd.GetInt32(0);
        }
        drd.Close();
        conn.Close();
        cmd.Parameters.Clear();
        conn.Dispose();
        cmd.Dispose();
        return i;
    }
}