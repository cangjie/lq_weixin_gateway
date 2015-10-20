<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        
        string loginCode = ((Request["logincode"] == null) ? "" : Request["logincode"].Trim());
        bool scaned = false;
        SqlConnection conn = new SqlConnection(Util.conStr);
        SqlCommand cmd = new SqlCommand(" select *  from wxreceivemsg   where wxreceivemsg_eventkey like '%"
            + loginCode.Replace("'", "").Trim() + "' ", conn);
        conn.Open();
        string openId = "";
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            openId = dr["wxreceivemsg_from"].ToString().Trim();
            scaned = true;
        }
        dr.Close();
        conn.Close();
        cmd.Dispose();
        conn.Dispose();
        if (scaned)
        {
            Response.Write("{\"status\":0, \"scaned\":1, \"openid\":\"" + openId.Trim() + "\"}");
        }
        else
        {
            Response.Write("{\"status\":0, \"scaned\":0}");
        }
    }
</script>