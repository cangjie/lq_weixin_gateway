﻿<%@ Page Language="C#" %>
<%@ Import Namespace="System.Runtime.Serialization" %>
<%@ Import Namespace="System.Runtime.Serialization.Json" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Web.Script.Serialization" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        string token = Util.GetToken();

        string openId = ((Request["openid"] == null) ? "oqrMvt36Tp9hHcCVgkvqylmsbXRk" : Request["openid"].Trim().Replace("'", ""));

        string userAccessToken = Util.GetSafeRequestValue(Request, "accesstoken", "");
        
        SqlConnection conn = new SqlConnection(Util.conStr.Trim());
        SqlCommand cmd = new SqlCommand(" select info_json , update_time from weixin_user_info where openid = '" + openId.Trim()  +"'  ", conn);

        string json = "";

        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        DateTime updateTime = DateTime.MinValue;
        
        if (reader.Read())
        {
            json = reader.GetString(0);
            updateTime = reader.GetDateTime(1);
        }

        reader.Close();
        conn.Close();
        cmd.Dispose();

        if (updateTime < DateTime.Now.AddDays(-1) || json.IndexOf("nickname") < 0 )
        {
            string[,] keyValue = { { "openid", "varchar", openId } };
            DBHelper.DeleteData("weixin_user_info", keyValue, Util.conStr);
        }
        
        if ((json.Trim().Equals("") || json.IndexOf("nickname")<0) && updateTime < DateTime.Now.AddDays(-1))
        {

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://api.weixin.qq.com/cgi-bin/user/info?access_token="
                + token + "&openid=" + openId + "&lang=zh_CN");
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            Stream s = res.GetResponseStream();
            StreamReader sdr = new StreamReader(s);
            string j = sdr.ReadToEnd();
            sdr.Close();
            s.Close();
            res.Close();
            req.Abort();
            json = j;

            if (json.IndexOf("errcode") > 0 || json.IndexOf("nickname") < 0)
            {
                req = (HttpWebRequest)WebRequest.Create("https://api.weixin.qq.com/sns/userinfo?access_token="
                    + userAccessToken.Trim() + "&openid=" + openId + "&lang=zh_CN");
                res = (HttpWebResponse)req.GetResponse();
                s = res.GetResponseStream();
                sdr = new StreamReader(s);
                j = sdr.ReadToEnd();
                sdr.Close();
                s.Close();
                res.Close();
                req.Abort();
                json = j;
            }
            
            
            //Response.Write(j);


            if (json.IndexOf("errcode") < 0  &&  json.IndexOf("nickname") >= 0)
            {

                cmd.CommandText = " insert into  weixin_user_info (openid,info_json) values (@openid,@json)";
                cmd.Parameters.Add("@openid", SqlDbType.VarChar);
                cmd.Parameters.Add("@json", SqlDbType.VarChar);
                cmd.Parameters["@openid"].Value = openId.Trim();
                cmd.Parameters["@json"].Value = json;
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {

                }
                conn.Close();
                cmd.Parameters.Clear();
            }
            
        }
        cmd.Dispose();
        conn.Dispose();
        Response.Write(json);
    }
</script>