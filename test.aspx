<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="System.Xml" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        string token = "24_I3XYivbXEh-klJe8moOnvhawILBxNmrh63nIZbPDk006v-EluhxIlWlme_ao6-a-iv0olFY1hS6mDP1z_ZYnTRPcWbfJ_V71YkGnCOCT-Dsr-grOD4twSG6VYVYDNYOS0k9hHpulaIwFxyYhVNHjABAIAU";
        MpNews.SetReplyNewsMessage("event", "menu_2_1", "九大方向性信号——面包和黄油", token.Trim());
        MpNews.SetReplyNewsMessage("event", "menu_2_2", "【老马实盘】底部双穿折返进场——因赛集团", token.Trim());
        /*
        MpNews.SetReplyNewsMessage("event", "menu_2_3", "", token.Trim());
        MpNews.SetReplyNewsMessage("event", "menu_2_4", "", token.Trim());
        MpNews.SetReplyNewsMessage("event", "menu_2_5", "", token.Trim());
        */
    }

</script>