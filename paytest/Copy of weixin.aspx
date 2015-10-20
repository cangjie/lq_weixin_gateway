<%@ Page Language="C#" %>
<%@ Import Namespace="System.Security.Cryptography" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<script runat="server">

    public string token = "jihuowangluo";
    public string validResult = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (valid())
        {
            try
            {
                Stream s = Request.InputStream;
                XmlDocument xmlD = new XmlDocument();
                xmlD.Load(s);
                
                try
                {
                    SaveReceiveMessage(xmlD);
		    //File.AppendAllText(Server.MapPath("log/errr.txt"), xmlD.InnerXml.Trim() + "\r\n\r\n");
                }
                catch(Exception err)
                {
                    string errMsg = DateTime.Now.ToString() + "\r\n";
                    errMsg = errMsg + err.ToString() + "\r\n";
                    errMsg = errMsg + xmlD.InnerXml.Trim();
                    File.AppendAllText(Server.MapPath("log/err.txt"), errMsg.Trim() + "\r\n\r\n");
                }
            }
            catch
            {
                //File.AppendAllText(Server.MapPath("log/err.txt"),  "asdfasdfsawwww\r\n\r\n");
                Response.Write(Request["echostr"].Trim());
            }
        }
        else
        {
            //File.AppendAllText(Server.MapPath("log/err.txt"), "asdfasdfsawwww\r\n\r\n");
            Response.Write(validResult);
        }
    }

    public int SaveReceiveMessage(XmlDocument xmlD)
    {
        
        string to = xmlD.SelectSingleNode("//xml/ToUserName").InnerText.Trim();
        string from = xmlD.SelectSingleNode("//xml/FromUserName").InnerText.Trim();
        string createTime = xmlD.SelectSingleNode("//xml/CreateTime").InnerText.Trim();
        string msgType = xmlD.SelectSingleNode("//xml/MsgType").InnerText.Trim();
        string msgId = "";
        if (msgType == "event")
        {
            DateTime nowDate = DateTime.Now;
            msgId = "event_" + nowDate.Year.ToString() + nowDate.Month.ToString().PadLeft(2, '0') + nowDate.Day.ToString().PadLeft(2, '0')
                + nowDate.Hour.ToString().PadLeft(2, '0') + nowDate.Minute.ToString().PadLeft(2, '0') + nowDate.Second.ToString().PadLeft(2, '0')
                + nowDate.Millisecond.ToString().PadLeft(3, '0');
        }
        else
        {
            
            msgId = xmlD.SelectSingleNode("//xml/MsgId").InnerText.Trim();
            //File.AppendAllText(Server.MapPath("log/err.txt"), msgId + "\r\n\r\n");
        }
        SqlCommand cmd = new SqlCommand();
        string insertClause = " wxreceivemsg_id , wxreceivemsg_to , wxreceivemsg_from , wxreceivemsg_time , wxreceivemsg_type ";
        string valuesClause = " @id , @to , @from , @time , @type ";
        cmd.Parameters.Add("@id",SqlDbType.VarChar);
        cmd.Parameters["@id"].Value = msgId.Trim();
        cmd.Parameters.Add("@to", SqlDbType.VarChar);
        cmd.Parameters["@to"].Value = to.Trim();
        cmd.Parameters.Add("@from", SqlDbType.VarChar);
        cmd.Parameters["@from"].Value = from.Trim();
        cmd.Parameters.Add("@time", SqlDbType.VarChar);
        cmd.Parameters["@time"].Value = createTime.Trim();
        cmd.Parameters.Add("@type", SqlDbType.VarChar);
        cmd.Parameters["@type"].Value = msgType.Trim();

        switch (msgType)
        { 
            case "text":
                insertClause = insertClause + " , wxreceivemsg_content ";
                valuesClause = valuesClause + " , @content ";
                cmd.Parameters.Add("@content", SqlDbType.VarChar);
                cmd.Parameters["@content"].Value = xmlD.SelectSingleNode("//xml/Content").InnerText.Trim();
                
                break;
            case "event":
                insertClause = insertClause + " , wxreceivemsg_event ";
                valuesClause = valuesClause + " , @event ";
                cmd.Parameters.Add("@event", SqlDbType.VarChar);
                cmd.Parameters["@event"].Value = xmlD.SelectSingleNode("//xml/Event").InnerText.Trim();



		try
                {
                    XmlNode keyNode = xmlD.SelectSingleNode("//xml/EventKey");
                    if (keyNode != null)
                    {
                        insertClause = insertClause + " , wxreceivemsg_eventkey ";
                        valuesClause = valuesClause + " , @eventkey ";
                        cmd.Parameters.Add("@eventkey", SqlDbType.VarChar);
                        cmd.Parameters["@eventkey"].Value = keyNode.InnerText.Trim();
                    }
                }
                catch
                { 
                
                }



                if (xmlD.SelectSingleNode("//xml/Event").InnerText.Trim() == "LOCATION")
                {
                    insertClause = insertClause + " , wxreceivemsg_locationx ";
                    valuesClause = valuesClause + " , @locationx ";
                    cmd.Parameters.Add("@locationx", SqlDbType.VarChar);
                    cmd.Parameters["@locationx"].Value = xmlD.SelectSingleNode("//xml/Latitude").InnerText.Trim();


                    insertClause = insertClause + " , wxreceivemsg_locationy ";
                    valuesClause = valuesClause + " , @locationy ";
                    cmd.Parameters.Add("@locationy", SqlDbType.VarChar);
                    cmd.Parameters["@locationy"].Value = xmlD.SelectSingleNode("//xml/Longitude").InnerText.Trim();

                    insertClause = insertClause + " , wxreceivemsg_scale ";
                    valuesClause = valuesClause + " , @scale ";
                    cmd.Parameters.Add("@scale", SqlDbType.VarChar);
                    cmd.Parameters["@scale"].Value = xmlD.SelectSingleNode("//xml/Precision").InnerText.Trim();
                
                    
                    
                }
                
                break;
            case "image":
                insertClause = insertClause + " , wxreceivemsg_picurl ";
                valuesClause = valuesClause + " , @picurl ";
                cmd.Parameters.Add("@picurl", SqlDbType.VarChar);
                cmd.Parameters["@picurl"].Value = xmlD.SelectSingleNode("//xml/PicUrl").InnerText.Trim();
                
                insertClause = insertClause + " , wxreceivemsg_mediaid ";
                valuesClause = valuesClause + " , @mediaid ";
                cmd.Parameters.Add("@mediaid", SqlDbType.VarChar);
                cmd.Parameters["@mediaid"].Value = xmlD.SelectSingleNode("//xml/MediaId").InnerText.Trim();
                break;
            case "voice":
                insertClause = insertClause + " , wxreceivemsg_format ";
                valuesClause = valuesClause + " , @format ";
                cmd.Parameters.Add("@format", SqlDbType.VarChar);
                cmd.Parameters["@format"].Value = xmlD.SelectSingleNode("//xml/Format").InnerText.Trim();
                
                insertClause = insertClause + " , wxreceivemsg_mediaid ";
                valuesClause = valuesClause + " , @mediaid ";
                cmd.Parameters.Add("@mediaid", SqlDbType.VarChar);
                cmd.Parameters["@mediaid"].Value = xmlD.SelectSingleNode("//xml/MediaId").InnerText.Trim();

                try
                {
                    insertClause = insertClause + " , wxreceivemsg_recognition ";
                    valuesClause = valuesClause + " , @recognition ";
                    cmd.Parameters.Add("@recognition", SqlDbType.VarChar);
                    cmd.Parameters["@recognition"].Value = xmlD.SelectSingleNode("//xml/Recognition").InnerText.Trim();

                }
                catch
                { 
                
                }
                
                
                break;
            case "video":
                insertClause = insertClause + " , wxreceivemsg_thumbmediaid ";
                valuesClause = valuesClause + " , @thumbmediaid ";
                cmd.Parameters.Add("@thumbmediaid", SqlDbType.VarChar);
                cmd.Parameters["@thumbmediaid"].Value = xmlD.SelectSingleNode("//xml/ThumbMediaId").InnerText.Trim();
                
                insertClause = insertClause + " , wxreceivemsg_mediaid ";
                valuesClause = valuesClause + " , @mediaid ";
                cmd.Parameters.Add("@mediaid", SqlDbType.VarChar);
                cmd.Parameters["@mediaid"].Value = xmlD.SelectSingleNode("//xml/MediaId").InnerText.Trim();
                break;
            case "location":
                insertClause = insertClause + " , wxreceivemsg_locationx ";
                valuesClause = valuesClause + " , @locationx ";
                cmd.Parameters.Add("@locationx", SqlDbType.VarChar);
                cmd.Parameters["@locationx"].Value = xmlD.SelectSingleNode("//xml/Location_X").InnerText.Trim();
                
                
                insertClause = insertClause + " , wxreceivemsg_locationy ";
                valuesClause = valuesClause + " , @locationy ";
                cmd.Parameters.Add("@locationy", SqlDbType.VarChar);
                cmd.Parameters["@locationy"].Value = xmlD.SelectSingleNode("//xml/Location_Y").InnerText.Trim();
                
                
                
                insertClause = insertClause + " , wxreceivemsg_scale ";
                valuesClause = valuesClause + " , @scale ";
                cmd.Parameters.Add("@scale", SqlDbType.VarChar);
                cmd.Parameters["@scale"].Value = xmlD.SelectSingleNode("//xml/Scale").InnerText.Trim();
                
                insertClause = insertClause + " , wxreceivemsg_label ";
                valuesClause = valuesClause + " , @label ";
                cmd.Parameters.Add("@label", SqlDbType.VarChar);
                cmd.Parameters["@label"].Value = xmlD.SelectSingleNode("//xml/Label").InnerText.Trim();
                
                break;
            case "link":

                insertClause = insertClause + " , wxreceivemsg_title ";
                valuesClause = valuesClause + " , @title ";
                cmd.Parameters.Add("@title", SqlDbType.VarChar);
                cmd.Parameters["@title"].Value = xmlD.SelectSingleNode("//xml/Title").InnerText.Trim();
                
                
                insertClause = insertClause + " , wxreceivemsg_description ";
                valuesClause = valuesClause + " , @description ";
                cmd.Parameters.Add("@description", SqlDbType.VarChar);
                cmd.Parameters["@description"].Value = xmlD.SelectSingleNode("//xml/Description").InnerText.Trim();
                
                
                
                insertClause = insertClause + " , wxreceivemsg_url ";
                valuesClause = valuesClause + " , @url ";
                cmd.Parameters.Add("@url", SqlDbType.VarChar);
                cmd.Parameters["@url"].Value = xmlD.SelectSingleNode("//xml/Url").InnerText.Trim();
                
                
                
                break;
            default:
                break;
        }

        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["constr"].Trim());
        cmd.Connection = conn;
        cmd.CommandText = " insert into wxreceivemsg ( " + insertClause + " )  values ( " + valuesClause + " )  " ;
        conn.Open();
        int i = cmd.ExecuteNonQuery();
        //File.AppendAllText(Server.MapPath("log/err.txt"),xmlD.InnerXml.Trim() + "\r\n\r\n");
        if (i == 0)
        {
            throw new Exception("Insert failed, the SQL clause is: " + cmd.CommandText.Trim());
        }
        conn.Close();
        cmd.Parameters.Clear();
        cmd.Dispose();
        conn.Dispose();
        return i;
    }
    
    public bool valid()
    {
        string sign = Request["signature"].Trim();
        string time = Request["timestamp"].Trim();
        string nonce = Request["nonce"].Trim();
        string[] strArr = new string[3];
        strArr[0] = token;
        strArr[1] = time;
        strArr[2] = nonce;
        Array.Sort(strArr);
        string arrStr = String.Join("", strArr);
        SHA1 sha = SHA1.Create();
        ASCIIEncoding enc = new ASCIIEncoding();
        byte[] bArr = enc.GetBytes(arrStr);
        bArr = sha.ComputeHash(bArr);
        validResult = "";
        for (int i = 0; i < bArr.Length; i++)
        {
            validResult = validResult + bArr[i].ToString("x").PadLeft(2,'0');
        }
        if (validResult == sign)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
</script>