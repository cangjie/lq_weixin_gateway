<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        string openId = Util.GetSafeRequestValue(Request, "openid", "oqrMvtySBUCd-r6-ZIivSwsmzr44").Trim();
        string templateId = Util.GetSafeRequestValue(Request, "templateid", "N5VFMdS_n3SrrO9pNKHKdg1ZkSFwc_2zhUFmvUCHPN8").Trim();
        string first = Util.GetSafeRequestValue(Request, "first", "直播即将开始").Trim();
        string firstColor = Util.GetSafeRequestValue(Request, "firstcolor", "173177").Trim();
        string[] keysArr = Util.GetSafeRequestValue(Request, "keys", "如何让孩子提高动手能力|卢勤|2020年6月22日").Trim().Split('|');
        string keysColor = Util.GetSafeRequestValue(Request, "keyscolor", "173177").Trim();
        string remark = Util.GetSafeRequestValue(Request, "remark", "在抖音中搜索“卢勤”或者输入抖音号luqin1948").Trim();
        string remarkColor = Util.GetSafeRequestValue(Request, "remarkcolor", "173177").Trim();
        string url = Util.GetSafeRequestValue(Request, "url", "").Trim();

        string dataSubJson = "\"first\": {\"value\": \"" + first.Trim() + "\", \"color\": \"#" + firstColor.Trim() + "\" }";
        for (int i = 0; i < keysArr.Length; i++)
        {
            dataSubJson = dataSubJson + ",\"keyword" + (i + 1).ToString() + "\": { \"value\": \"" + keysArr[i].Trim() + "\", \"color\": \"#" + keysColor.Trim() + "\" }";
        }
        dataSubJson = dataSubJson + ", \"remark\": { \"value\": \"" + remark.Trim() + "\", \"color\": \"#" + remarkColor.Trim() + "\" }";
        string json = "{\"touser\": \"" + openId.Trim() + "\", \"template_id\": \"" + templateId.Trim() + "\", \"url\": \"" + url + "\", \"data\": {" + dataSubJson.Trim() + "}}";


        string postUrl = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + Util.GetToken();
        Response.Write(Util.GetWebContent(postUrl, "POST", json, "text/html"));


    }
</script>
