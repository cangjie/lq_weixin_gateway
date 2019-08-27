<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html>

<script runat="server">

    public static string token = "24_EnlGkx5rRhORQE6JuCBytBknlRX6-H1iuVFXnKQq2JJmCRiKVExGXhkhOo6i7o6viwoV3q5tmD5tZIHSjK8KtWmEjaIUm-ALsRoSkBg-DBqSiyBdSf-TV3vTIEHfV-gWJVn4f-0qIvI48t3IPJScAIAICL";

    protected void btn_Click(object sender, EventArgs e)
    {
        try
        {
            token = Util.GetToken();
        }
        catch
        {

        }
        string errMsg = "";
        string button1Json = "";
        if (!CheckValid(txt_name_1_1.Text.Trim(), drp_type_1_1.SelectedValue.Trim(), txt_content_1_1.Text.Trim()))
        {
            errMsg = errMsg.Trim() + " 第1列第1行";
        }
        else
        {
            if (!txt_name_1_1.Text.Trim().Equals("") && !txt_content_1_1.Text.Trim().Equals(""))
            {
                if (drp_type_1_1.SelectedValue.Trim().Equals("click"))
                {
                    button1Json = button1Json.Trim() + ",{ \"type\":\"click\", \"name\":\"" + txt_name_1_1.Text.Trim() + "\", \"key\":\"menu_1_1\"}";
                }
                else
                {
                    button1Json = button1Json.Trim() + ",{ \"type\":\"view\", \"name\":\"" + txt_name_1_1.Text.Trim() + "\", \"url\":\"" + txt_content_1_1.Text.Trim() + "\"}";
                }
            }
        }
        if (!CheckValid(txt_name_1_2.Text.Trim(), drp_type_1_2.SelectedValue.Trim(), txt_content_1_2.Text.Trim()))
        {
            errMsg = errMsg.Trim() + " 第1列第2行";
        }
        else
        {
            if (!txt_name_1_2.Text.Trim().Equals("") && !txt_content_1_2.Text.Trim().Equals(""))
            {
                if (drp_type_1_2.SelectedValue.Trim().Equals("click"))
                {
                    button1Json = button1Json.Trim() + ",{ \"type\":\"click\", \"name\":\"" + txt_name_1_2.Text.Trim() + "\", \"key\":\"menu_1_2\"}";
                }
                else
                {
                    button1Json = button1Json.Trim() + ",{ \"type\":\"view\", \"name\":\"" + txt_name_1_2.Text.Trim() + "\", \"url\":\"" + txt_content_1_2.Text.Trim() + "\"}";
                }
            }
        }
        if (!CheckValid(txt_name_1_3.Text.Trim(), drp_type_1_3.SelectedValue.Trim(), txt_content_1_3.Text.Trim()))
        {
            errMsg = errMsg.Trim() + " 第1列第3行";
        }
        else
        {
            if (!txt_name_1_3.Text.Trim().Equals("") && !txt_content_1_3.Text.Trim().Equals(""))
            {
                if (drp_type_1_3.SelectedValue.Trim().Equals("click"))
                {
                    button1Json = button1Json.Trim() + ",{ \"type\":\"click\", \"name\":\"" + txt_name_1_3.Text.Trim() + "\", \"key\":\"menu_1_3\"}";
                }
                else
                {
                    button1Json = button1Json.Trim() + ",{ \"type\":\"view\", \"name\":\"" + txt_name_1_3.Text.Trim() + "\", \"url\":\"" + txt_content_1_3.Text.Trim() + "\"}";
                }
            }
        }
        if (!CheckValid(txt_name_1_4.Text.Trim(), drp_type_1_4.SelectedValue.Trim(), txt_content_1_4.Text.Trim()))
        {
            errMsg = errMsg.Trim() + " 第1列第4行";
        }
        else
        {
            if (!txt_name_1_4.Text.Trim().Equals("") && !txt_content_1_4.Text.Trim().Equals(""))
            {
                if (drp_type_1_4.SelectedValue.Trim().Equals("click"))
                {
                    button1Json = button1Json.Trim() + ",{ \"type\":\"click\", \"name\":\"" + txt_name_1_4.Text.Trim() + "\", \"key\":\"menu_1_4\"}";
                }
                else
                {
                    button1Json = button1Json.Trim() + ",{ \"type\":\"view\", \"name\":\"" + txt_name_1_4.Text.Trim() + "\", \"url\":\"" + txt_content_1_4.Text.Trim() + "\"}";
                }
            }
        }
        if (!CheckValid(txt_name_1_5.Text.Trim(), drp_type_1_5.SelectedValue.Trim(), txt_content_1_5.Text.Trim()))
        {
            errMsg = errMsg.Trim() + " 第1列第5行";
        }
        else
        {
            if (!txt_name_1_5.Text.Trim().Equals("") && !txt_content_1_5.Text.Trim().Equals(""))
            {
                if (drp_type_1_5.SelectedValue.Trim().Equals("click"))
                {
                    button1Json = button1Json.Trim() + ",{ \"type\":\"click\", \"name\":\"" + txt_name_1_5.Text.Trim() + "\", \"key\":\"menu_1_5\"}";
                }
                else
                {
                    button1Json = button1Json.Trim() + ",{ \"type\":\"view\", \"name\":\"" + txt_name_1_5.Text.Trim() + "\", \"url\":\"" + txt_content_1_5.Text.Trim() + "\"}";
                }
            }
        }

        string button2Json = "";
        if (!CheckValid(txt_name_2_1.Text.Trim(), drp_type_2_1.SelectedValue.Trim(), txt_content_2_1.Text.Trim()))
        {
            errMsg = errMsg.Trim() + " 第2列第1行";
        }
        else
        {
            if (!txt_name_2_1.Text.Trim().Equals("") && !txt_content_2_1.Text.Trim().Equals(""))
            {
                if (drp_type_2_1.SelectedValue.Trim().Equals("click"))
                {
                    button2Json = button2Json.Trim() + ",{ \"type\":\"click\", \"name\":\"" + txt_name_2_1.Text.Trim() + "\", \"key\":\"menu_2_1\"}";
                }
                else
                {
                    button2Json = button2Json.Trim() + ",{ \"type\":\"view\", \"name\":\"" + txt_name_2_1.Text.Trim() + "\", \"url\":\"" + txt_content_2_1.Text.Trim() + "\"}";
                }
            }
        }
        if (!CheckValid(txt_name_2_1.Text.Trim(), drp_type_2_2.SelectedValue.Trim(), txt_content_2_2.Text.Trim()))
        {
            errMsg = errMsg.Trim() + " 第2列第2行";
        }
        else
        {
            if (!txt_name_2_2.Text.Trim().Equals("") && !txt_content_2_2.Text.Trim().Equals(""))
            {
                if (drp_type_2_2.SelectedValue.Trim().Equals("click"))
                {
                    button2Json = button2Json.Trim() + ",{ \"type\":\"click\", \"name\":\"" + txt_name_2_2.Text.Trim() + "\", \"key\":\"menu_2_2\"}";
                }
                else
                {
                    button2Json = button2Json.Trim() + ",{ \"type\":\"view\", \"name\":\"" + txt_name_2_2.Text.Trim() + "\", \"url\":\"" + txt_content_2_2.Text.Trim() + "\"}";
                }
            }
        }
        if (!CheckValid(txt_name_2_3.Text.Trim(), drp_type_2_3.SelectedValue.Trim(), txt_content_2_3.Text.Trim()))
        {
            errMsg = errMsg.Trim() + " 第2列第3行";
        }
        else
        {
            if (!txt_name_2_3.Text.Trim().Equals("") && !txt_content_2_3.Text.Trim().Equals(""))
            {
                if (drp_type_2_3.SelectedValue.Trim().Equals("click"))
                {
                    button2Json = button2Json.Trim() + ",{ \"type\":\"click\", \"name\":\"" + txt_name_2_3.Text.Trim() + "\", \"key\":\"menu_2_3\"}";
                }
                else
                {
                    button2Json = button2Json.Trim() + ",{ \"type\":\"view\", \"name\":\"" + txt_name_2_3.Text.Trim() + "\", \"url\":\"" + txt_content_2_3.Text.Trim() + "\"}";
                }
            }
        }
        if (!CheckValid(txt_name_2_4.Text.Trim(), drp_type_2_4.SelectedValue.Trim(), txt_content_2_4.Text.Trim()))
        {
            errMsg = errMsg.Trim() + " 第2列第4行";
        }
        else
        {
            if (!txt_name_2_4.Text.Trim().Equals("") && !txt_content_2_4.Text.Trim().Equals(""))
            {
                if (drp_type_2_4.SelectedValue.Trim().Equals("click"))
                {
                    button2Json = button2Json.Trim() + ",{ \"type\":\"click\", \"name\":\"" + txt_name_2_4.Text.Trim() + "\", \"key\":\"menu_2_4\"}";
                }
                else
                {
                    button2Json = button2Json.Trim() + ",{ \"type\":\"view\", \"name\":\"" + txt_name_2_4.Text.Trim() + "\", \"url\":\"" + txt_content_2_4.Text.Trim() + "\"}";
                }
            }
        }
        if (!CheckValid(txt_name_2_5.Text.Trim(), drp_type_2_5.SelectedValue.Trim(), txt_content_2_5.Text.Trim()))
        {
            errMsg = errMsg.Trim() + " 第2列第5行";
        }
        else
        {
            if (!txt_name_2_5.Text.Trim().Equals("") && !txt_content_2_5.Text.Trim().Equals(""))
            {
                if (drp_type_2_5.SelectedValue.Trim().Equals("click"))
                {
                    button2Json = button2Json.Trim() + ",{ \"type\":\"click\", \"name\":\"" + txt_name_2_5.Text.Trim() + "\", \"key\":\"menu_2_5\"}";
                }
                else
                {
                    button2Json = button2Json.Trim() + ",{ \"type\":\"view\", \"name\":\"" + txt_name_2_5.Text.Trim() + "\", \"url\":\"" + txt_content_2_5.Text.Trim() + "\"}";
                }
            }
        }

        string button3Json = "";
        if (!CheckValid(txt_name_3_1.Text.Trim(), drp_type_3_1.SelectedValue.Trim(), txt_content_3_1.Text.Trim()))
        {
            errMsg = errMsg.Trim() + " 第3列第1行";
        }
        else
        {
            if (!txt_name_3_1.Text.Trim().Equals("") && !txt_content_3_1.Text.Trim().Equals(""))
            {
                if (drp_type_3_1.SelectedValue.Trim().Equals("click"))
                {
                    button3Json = button3Json.Trim() + ",{ \"type\":\"click\", \"name\":\"" + txt_name_3_1.Text.Trim() + "\", \"key\":\"menu_3_1\"}";
                }
                else
                {
                    button3Json = button3Json.Trim() + ",{ \"type\":\"view\", \"name\":\"" + txt_name_3_1.Text.Trim() + "\", \"url\":\"" + txt_content_3_1.Text.Trim() + "\"}";
                }
            }
        }
        if (!CheckValid(txt_name_3_2.Text.Trim(), drp_type_3_2.SelectedValue.Trim(), txt_content_3_2.Text.Trim()))
        {
            errMsg = errMsg.Trim() + " 第3列第2行";
        }
        else
        {
            if (!txt_name_3_2.Text.Trim().Equals("") && !txt_content_3_2.Text.Trim().Equals(""))
            {
                if (drp_type_3_2.SelectedValue.Trim().Equals("click"))
                {
                    button3Json = button3Json.Trim() + ",{ \"type\":\"click\", \"name\":\"" + txt_name_3_2.Text.Trim() + "\", \"key\":\"menu_3_2\"}";
                }
                else
                {
                    button3Json = button3Json.Trim() + ",{ \"type\":\"view\", \"name\":\"" + txt_name_3_2.Text.Trim() + "\", \"url\":\"" + txt_content_3_2.Text.Trim() + "\"}";
                }
            }
        }
        if (!CheckValid(txt_name_3_3.Text.Trim(), drp_type_3_3.SelectedValue.Trim(), txt_content_3_3.Text.Trim()))
        {
            errMsg = errMsg.Trim() + " 第3列第3行";
        }
        else
        {
            if (!txt_name_3_3.Text.Trim().Equals("") && !txt_content_3_3.Text.Trim().Equals(""))
            {
                if (drp_type_3_3.SelectedValue.Trim().Equals("click"))
                {
                    button3Json = button3Json.Trim() + ",{ \"type\":\"click\", \"name\":\"" + txt_name_3_3.Text.Trim() + "\", \"key\":\"menu_3_3\"}";
                }
                else
                {
                    button3Json = button3Json.Trim() + ",{ \"type\":\"view\", \"name\":\"" + txt_name_3_3.Text.Trim() + "\", \"url\":\"" + txt_content_3_3.Text.Trim() + "\"}";
                }
            }
        }
        if (!CheckValid(txt_name_3_4.Text.Trim(), drp_type_3_4.SelectedValue.Trim(), txt_content_3_4.Text.Trim()))
        {
            errMsg = errMsg.Trim() + " 第3列第4行";
        }
        else
        {
            if (!txt_name_3_4.Text.Trim().Equals("") && !txt_content_3_4.Text.Trim().Equals(""))
            {
                if (drp_type_3_4.SelectedValue.Trim().Equals("click"))
                {
                    button3Json = button3Json.Trim() + ",{ \"type\":\"click\", \"name\":\"" + txt_name_3_4.Text.Trim() + "\", \"key\":\"menu_3_4\"}";
                }
                else
                {
                    button3Json = button3Json.Trim() + ",{ \"type\":\"view\", \"name\":\"" + txt_name_3_4.Text.Trim() + "\", \"url\":\"" + txt_content_3_4.Text.Trim() + "\"}";
                }
            }
        }
        if (!CheckValid(txt_name_3_5.Text.Trim(), drp_type_3_5.SelectedValue.Trim(), txt_content_3_5.Text.Trim()))
        {
            errMsg = errMsg.Trim() + " 第3列第5行";
        }
        else
        {
            if (!txt_name_3_5.Text.Trim().Equals("") && !txt_content_3_5.Text.Trim().Equals(""))
            {
                if (drp_type_3_5.SelectedValue.Trim().Equals("click"))
                {
                    button3Json = button3Json.Trim() + ",{ \"type\":\"click\", \"name\":\"" + txt_name_3_5.Text.Trim() + "\", \"key\":\"menu_3_5\"}";
                }
                else
                {
                    button3Json = button3Json.Trim() + ",{ \"type\":\"view\", \"name\":\"" + txt_name_3_5.Text.Trim() + "\", \"url\":\"" + txt_content_3_5.Text.Trim() + "\"}";
                }
            }
        }
        if (txt_button_1.Text.Trim().Equals(""))
        {
            errMsg = "第一列";
        }
        if (txt_button_2.Text.Trim().Equals(""))
        {
            errMsg = "第二列";
        }
        if (txt_button_3.Text.Trim().Equals(""))
        {
            errMsg = "第三列";
        }

        if (errMsg.Trim().Equals(""))
        {
            string json = "{\"button\":[{\"name\":\"" + txt_button_1.Text.Trim() + "\", \"sub_button\": [" + (button1Json.StartsWith(",") ? button1Json.Remove(0, 1) : button1Json).Trim() + "]},"
                + "{ \"name\": \"" + txt_button_2.Text.Trim() + "\", \"sub_button\":[" + (button2Json.StartsWith(",") ? button2Json.Remove(0, 1) : button2Json).Trim() + "]},"
                + "{ \"name\": \"" + txt_button_3.Text.Trim() + "\", \"sub_button\":[" + (button3Json.StartsWith(",") ? button3Json.Remove(0, 1) : button3Json).Trim() + "]}]}";
            string oldJson = Util.GetWebContent("https://api.weixin.qq.com/cgi-bin/menu/get?access_token=" + token.Trim(), "POST", "", "html/text");
            string retJson = Util.GetWebContent("https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + token.Trim(), "POST", json.Trim(), "html/text");
            //{\"errcode\":0,\"errmsg\":\"ok\"}
            if (Util.GetSimpleJsonValueByKey(retJson.Trim(), "errcode").Trim().Equals("0") && Util.GetSimpleJsonValueByKey(retJson.Trim(), "errmsg").Trim().Equals("ok"))
            {
                if (!txt_name_1_1.Text.Trim().Equals("") &&  !txt_content_1_1.Text.Trim().Equals("") && drp_type_1_1.SelectedValue.Trim().Equals("click"))
                    MpNews.SetReplyNewsMessage("event", "menu_1_1", txt_content_1_1.Text.Trim(), token.Trim());
                if (!txt_name_1_2.Text.Trim().Equals("") &&  !txt_content_1_2.Text.Trim().Equals("") && drp_type_1_2.SelectedValue.Trim().Equals("click"))
                    MpNews.SetReplyNewsMessage("event", "menu_1_2", txt_content_1_2.Text.Trim(), token.Trim());
                if (!txt_name_1_3.Text.Trim().Equals("") &&  !txt_content_1_3.Text.Trim().Equals("") && drp_type_1_3.SelectedValue.Trim().Equals("click"))
                    MpNews.SetReplyNewsMessage("event", "menu_1_3", txt_content_1_3.Text.Trim(), token.Trim());
                if (!txt_name_1_4.Text.Trim().Equals("") &&  !txt_content_1_4.Text.Trim().Equals("") && drp_type_1_4.SelectedValue.Trim().Equals("click"))
                    MpNews.SetReplyNewsMessage("event", "menu_1_4", txt_content_1_4.Text.Trim(), token.Trim());
                if (!txt_name_1_5.Text.Trim().Equals("") &&  !txt_content_1_5.Text.Trim().Equals("") && drp_type_1_5.SelectedValue.Trim().Equals("click"))
                    MpNews.SetReplyNewsMessage("event", "menu_1_5", txt_content_1_5.Text.Trim(), token.Trim());



                if (!txt_name_2_1.Text.Trim().Equals("") &&  !txt_content_2_1.Text.Trim().Equals("") && drp_type_2_1.SelectedValue.Trim().Equals("click"))
                    MpNews.SetReplyNewsMessage("event", "menu_2_1", txt_content_2_1.Text.Trim(), token.Trim());
                if (!txt_name_2_2.Text.Trim().Equals("") &&  !txt_content_2_2.Text.Trim().Equals("") && drp_type_2_2.SelectedValue.Trim().Equals("click"))
                    MpNews.SetReplyNewsMessage("event", "menu_2_2", txt_content_2_2.Text.Trim(), token.Trim());
                if (!txt_name_2_3.Text.Trim().Equals("") &&  !txt_content_2_3.Text.Trim().Equals("") && drp_type_2_3.SelectedValue.Trim().Equals("click"))
                    MpNews.SetReplyNewsMessage("event", "menu_2_3", txt_content_2_3.Text.Trim(), token.Trim());
                if (!txt_name_2_4.Text.Trim().Equals("") &&  !txt_content_2_4.Text.Trim().Equals("") && drp_type_2_4.SelectedValue.Trim().Equals("click"))
                    MpNews.SetReplyNewsMessage("event", "menu_2_4", txt_content_2_4.Text.Trim(), token.Trim());
                if (!txt_name_2_5.Text.Trim().Equals("") &&  !txt_content_2_5.Text.Trim().Equals("") && drp_type_2_5.SelectedValue.Trim().Equals("click"))
                    MpNews.SetReplyNewsMessage("event", "menu_2_5", txt_content_2_5.Text.Trim(), token.Trim());


                if (!txt_name_3_1.Text.Trim().Equals("") &&  !txt_content_3_1.Text.Trim().Equals("") && drp_type_3_1.SelectedValue.Trim().Equals("click"))
                    MpNews.SetReplyNewsMessage("event", "menu_3_1", txt_content_3_1.Text.Trim(), token.Trim());
                if (!txt_name_3_2.Text.Trim().Equals("") &&  !txt_content_3_2.Text.Trim().Equals("") && drp_type_3_2.SelectedValue.Trim().Equals("click"))
                    MpNews.SetReplyNewsMessage("event", "menu_3_2", txt_content_3_2.Text.Trim(), token.Trim());
                if (!txt_name_3_3.Text.Trim().Equals("") &&  !txt_content_3_3.Text.Trim().Equals("") && drp_type_3_3.SelectedValue.Trim().Equals("click"))
                    MpNews.SetReplyNewsMessage("event", "menu_3_3", txt_content_3_3.Text.Trim(), token.Trim());
                if (!txt_name_3_4.Text.Trim().Equals("") &&  !txt_content_3_4.Text.Trim().Equals("") && drp_type_3_4.SelectedValue.Trim().Equals("click"))
                    MpNews.SetReplyNewsMessage("event", "menu_3_4", txt_content_3_4.Text.Trim(), token.Trim());
                if (!txt_name_3_5.Text.Trim().Equals("") &&  !txt_content_3_5.Text.Trim().Equals("") && drp_type_3_5.SelectedValue.Trim().Equals("click"))
                    MpNews.SetReplyNewsMessage("event", "menu_3_5", txt_content_3_5.Text.Trim(), token.Trim());


            }

            //Response.Write(json.Trim());

        }
        else
        {
            lblMsg.Text = errMsg.Trim();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            try
            {
                token = Util.GetToken();
            }
            catch
            {

            }
            string jsonStr = Util.GetWebContent("https://api.weixin.qq.com/cgi-bin/menu/get?access_token=" + token.Trim(), "POST", "", "html/text");
            Dictionary<string, object> menuJsonObject = (Dictionary<string, object>)Util.GetObjectFromJsonByKey(jsonStr, "menu");
            object[] buttonObjectArray = (object[])menuJsonObject["button"];
            object[] subbuttonObjectArray1 = (object[])(((Dictionary<string, object>)buttonObjectArray[0])["sub_button"]);
            txt_button_1.Text = ((Dictionary<string, object>)buttonObjectArray[0])["name"].ToString().Trim();
            object[] subbuttonObjectArray2 = (object[])(((Dictionary<string, object>)buttonObjectArray[1])["sub_button"]);
            txt_button_2.Text = ((Dictionary<string, object>)buttonObjectArray[1])["name"].ToString().Trim();
            object[] subbuttonObjectArray3 = (object[])(((Dictionary<string, object>)buttonObjectArray[2])["sub_button"]);
            txt_button_3.Text = ((Dictionary<string, object>)buttonObjectArray[2])["name"].ToString().Trim();
            try
            {
                Dictionary<string, object> currentSubButton = (Dictionary<string, object>)subbuttonObjectArray1[0];
                txt_name_1_1.Text = currentSubButton["name"].ToString().Trim();
                if (currentSubButton["type"].ToString().Trim().Equals("click"))
                {
                    drp_type_1_1.SelectedValue = "click";
                    txt_content_1_1.Text = GetEventTitle(currentSubButton["key"].ToString().Trim());
                }
                else
                {
                    drp_type_1_1.SelectedValue = "url";
                    txt_content_1_1.Text = currentSubButton["url"].ToString().Trim();
                }

            }
            catch
            {

            }

            try
            {
                Dictionary<string, object> currentSubButton = (Dictionary<string, object>)subbuttonObjectArray1[1];
                txt_name_1_2.Text = currentSubButton["name"].ToString().Trim();
                if (currentSubButton["type"].ToString().Trim().Equals("click"))
                {
                    drp_type_1_2.SelectedValue = "click";
                    txt_content_1_2.Text = GetEventTitle(currentSubButton["key"].ToString().Trim());
                }
                else
                {
                    drp_type_1_2.SelectedValue = "url";
                    txt_content_1_2.Text = currentSubButton["url"].ToString().Trim();
                }

            }
            catch
            {

            }

            try
            {
                Dictionary<string, object> currentSubButton = (Dictionary<string, object>)subbuttonObjectArray1[2];
                txt_name_1_3.Text = currentSubButton["name"].ToString().Trim();
                if (currentSubButton["type"].ToString().Trim().Equals("click"))
                {
                    drp_type_1_3.SelectedValue = "click";
                    txt_content_1_3.Text = GetEventTitle(currentSubButton["key"].ToString().Trim());
                }
                else
                {
                    drp_type_1_3.SelectedValue = "url";
                    txt_content_1_3.Text = currentSubButton["url"].ToString().Trim();
                }

            }
            catch
            {

            }

            try
            {
                Dictionary<string, object> currentSubButton = (Dictionary<string, object>)subbuttonObjectArray1[3];
                txt_name_1_4.Text = currentSubButton["name"].ToString().Trim();
                if (currentSubButton["type"].ToString().Trim().Equals("click"))
                {
                    drp_type_1_4.SelectedValue = "click";
                    txt_content_1_4.Text = GetEventTitle(currentSubButton["key"].ToString().Trim());
                }
                else
                {
                    drp_type_1_4.SelectedValue = "url";
                    txt_content_1_4.Text = currentSubButton["url"].ToString().Trim();
                }

            }
            catch
            {

            }

            try
            {
                Dictionary<string, object> currentSubButton = (Dictionary<string, object>)subbuttonObjectArray1[4];
                txt_name_1_5.Text = currentSubButton["name"].ToString().Trim();
                if (currentSubButton["type"].ToString().Trim().Equals("click"))
                {
                    drp_type_1_5.SelectedValue = "click";
                    txt_content_1_5.Text = GetEventTitle(currentSubButton["key"].ToString().Trim());
                }
                else
                {
                    drp_type_1_5.SelectedValue = "url";
                    txt_content_1_5.Text = currentSubButton["url"].ToString().Trim();
                }

            }
            catch
            {

            }

            try
            {
                Dictionary<string, object> currentSubButton = (Dictionary<string, object>)subbuttonObjectArray2[0];
                txt_name_2_1.Text = currentSubButton["name"].ToString().Trim();
                if (currentSubButton["type"].ToString().Trim().Equals("click"))
                {
                    drp_type_2_1.SelectedValue = "click";
                    txt_content_2_1.Text = GetEventTitle(currentSubButton["key"].ToString().Trim());
                }
                else
                {
                    drp_type_2_1.SelectedValue = "url";
                    txt_content_2_1.Text = currentSubButton["url"].ToString().Trim();
                }

            }
            catch
            {

            }

            try
            {
                Dictionary<string, object> currentSubButton = (Dictionary<string, object>)subbuttonObjectArray2[1];
                txt_name_2_2.Text = currentSubButton["name"].ToString().Trim();
                if (currentSubButton["type"].ToString().Trim().Equals("click"))
                {
                    drp_type_2_2.SelectedValue = "click";
                    txt_content_2_2.Text = GetEventTitle(currentSubButton["key"].ToString().Trim());
                }
                else
                {
                    drp_type_2_2.SelectedValue = "url";
                    txt_content_2_2.Text = currentSubButton["url"].ToString().Trim();
                }

            }
            catch
            {

            }

            try
            {
                Dictionary<string, object> currentSubButton = (Dictionary<string, object>)subbuttonObjectArray2[2];
                txt_name_2_3.Text = currentSubButton["name"].ToString().Trim();
                if (currentSubButton["type"].ToString().Trim().Equals("click"))
                {
                    drp_type_2_3.SelectedValue = "click";
                    txt_content_2_3.Text = GetEventTitle(currentSubButton["key"].ToString().Trim());
                }
                else
                {
                    drp_type_2_3.SelectedValue = "url";
                    txt_content_2_3.Text = currentSubButton["url"].ToString().Trim();
                }

            }
            catch
            {

            }

            try
            {
                Dictionary<string, object> currentSubButton = (Dictionary<string, object>)subbuttonObjectArray2[3];
                txt_name_2_4.Text = currentSubButton["name"].ToString().Trim();
                if (currentSubButton["type"].ToString().Trim().Equals("click"))
                {
                    drp_type_2_4.SelectedValue = "click";
                    txt_content_2_4.Text = GetEventTitle(currentSubButton["key"].ToString().Trim());
                }
                else
                {
                    drp_type_2_4.SelectedValue = "url";
                    txt_content_2_4.Text = currentSubButton["url"].ToString().Trim();
                }

            }
            catch
            {

            }

            try
            {
                Dictionary<string, object> currentSubButton = (Dictionary<string, object>)subbuttonObjectArray2[4];
                txt_name_2_5.Text = currentSubButton["name"].ToString().Trim();
                if (currentSubButton["type"].ToString().Trim().Equals("click"))
                {
                    drp_type_2_5.SelectedValue = "click";
                    txt_content_2_5.Text = GetEventTitle(currentSubButton["key"].ToString().Trim());
                }
                else
                {
                    drp_type_2_5.SelectedValue = "url";
                    txt_content_2_5.Text = currentSubButton["url"].ToString().Trim();
                }

            }
            catch
            {

            }

            try
            {
                Dictionary<string, object> currentSubButton = (Dictionary<string, object>)subbuttonObjectArray3[0];
                txt_name_3_1.Text = currentSubButton["name"].ToString().Trim();
                if (currentSubButton["type"].ToString().Trim().Equals("click"))
                {
                    drp_type_3_1.SelectedValue = "click";
                    txt_content_3_1.Text = GetEventTitle(currentSubButton["key"].ToString().Trim());
                }
                else
                {
                    drp_type_3_1.SelectedValue = "url";
                    txt_content_3_1.Text = currentSubButton["url"].ToString().Trim();
                }

            }
            catch
            {

            }

            try
            {
                Dictionary<string, object> currentSubButton = (Dictionary<string, object>)subbuttonObjectArray3[1];
                txt_name_3_2.Text = currentSubButton["name"].ToString().Trim();
                if (currentSubButton["type"].ToString().Trim().Equals("click"))
                {
                    drp_type_3_2.SelectedValue = "click";
                    txt_content_3_2.Text = GetEventTitle(currentSubButton["key"].ToString().Trim());
                }
                else
                {
                    drp_type_3_2.Text = "url";
                    txt_content_3_2.Text = currentSubButton["url"].ToString().Trim();
                }

            }
            catch
            {

            }

            try
            {
                Dictionary<string, object> currentSubButton = (Dictionary<string, object>)subbuttonObjectArray3[2];
                txt_name_3_3.Text = currentSubButton["name"].ToString().Trim();
                if (currentSubButton["type"].ToString().Trim().Equals("click"))
                {
                    drp_type_3_3.SelectedValue = "click";
                    txt_content_3_3.Text = GetEventTitle(currentSubButton["key"].ToString().Trim());
                }
                else
                {
                    drp_type_3_3.SelectedValue = "url";
                    txt_content_3_3.Text = currentSubButton["url"].ToString().Trim();
                }

            }
            catch
            {

            }

            try
            {
                Dictionary<string, object> currentSubButton = (Dictionary<string, object>)subbuttonObjectArray3[3];
                txt_name_3_4.Text = currentSubButton["name"].ToString().Trim();
                if (currentSubButton["type"].ToString().Trim().Equals("click"))
                {
                    drp_type_3_4.SelectedValue = "click";
                    txt_content_3_4.Text = GetEventTitle(currentSubButton["key"].ToString().Trim());
                }
                else
                {
                    drp_type_3_4.SelectedValue = "url";
                    txt_content_3_4.Text = currentSubButton["url"].ToString().Trim();
                }

            }
            catch
            {

            }

            try
            {
                Dictionary<string, object> currentSubButton = (Dictionary<string, object>)subbuttonObjectArray3[4];
                txt_name_3_5.Text = currentSubButton["name"].ToString().Trim();
                if (currentSubButton["type"].ToString().Trim().Equals("click"))
                {
                    drp_type_3_5.SelectedValue = "click";
                    txt_content_3_5.Text = GetEventTitle(currentSubButton["key"].ToString().Trim());
                }
                else
                {
                    drp_type_3_5.SelectedValue = "url";
                    txt_content_3_5.Text = currentSubButton["url"].ToString().Trim();
                }

            }
            catch
            {

            }









        }
    }

    public static string GetEventTitle(string eventString)
    {
        DataTable dt = DBHelper.GetDataTable(" select top 1 * from event_reply_messages where event_name = '" + eventString.Trim() + "' order by [id]", Util.conStr);
        string ret = "";
        if (dt.Rows.Count == 1)
        {
            ret = dt.Rows[0]["title"].ToString().Trim();
        }
        dt.Dispose();
        return ret;
    }


    public static bool CheckValid(string name, string type, string content)
    {
        if (name.Trim().Equals("") && content.Trim().Equals(""))
        {
            return true;
        }
        if (!name.Trim().Equals(""))
        {
            if (type.Trim().Equals("url"))
            {
                return (content.Trim().StartsWith("http://") || content.Trim().StartsWith("https://"));
            }
            else
            {
                string mediaId = MpNews.GetMediaIdByFirstTitle(content.Trim(), token.Trim());
                return (!mediaId.Equals("") || content.Trim().Equals("完善中，敬请期待")
                    || (name.Trim().Equals("签到") && content.Trim().Equals("签到成功！您将自动领取老马的每日复盘，把握A股最新动向。")) );
            }
        }
        return false;
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width:100%; column-span:1px; font-size: small;" >
            <tr>
                <td colspan="3" ><asp:Label ID="lblMsg" runat="server" ></asp:Label></td>
            </tr>
            <tr>
                <td><b>菜单名称</b></td>
                <td><b>类型</b></td>
                <td><b>内容</b></td>
            </tr>
            <tr>
                <td colspan="3" ><hr /></td>
            </tr>
            <tr>
                <td colspan="3" >第一列 <asp:TextBox ID="txt_button_1" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_name_1_1" runat="server" ></asp:TextBox></td>
                <td><asp:DropDownList ID="drp_type_1_1" runat="server" >
                    <asp:ListItem Value="click" >消息</asp:ListItem>
                    <asp:ListItem Value="url" >链接</asp:ListItem>
                    </asp:DropDownList></td>
                <td><asp:TextBox ID="txt_content_1_1" runat="server" Width="645px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_name_1_2" runat="server" ></asp:TextBox></td>
                <td><asp:DropDownList ID="drp_type_1_2" runat="server" >
                    <asp:ListItem Value="click" >消息</asp:ListItem>
                    <asp:ListItem Value="url" >链接</asp:ListItem>
                    </asp:DropDownList></td>
                <td><asp:TextBox ID="txt_content_1_2" runat="server" Width="645px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_name_1_3" runat="server" ></asp:TextBox></td>
                <td><asp:DropDownList ID="drp_type_1_3" runat="server" >
                    <asp:ListItem Value="click" >消息</asp:ListItem>
                    <asp:ListItem Value="url" >链接</asp:ListItem>
                    </asp:DropDownList></td>
                <td><asp:TextBox ID="txt_content_1_3" runat="server" Width="645px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_name_1_4" runat="server" ></asp:TextBox></td>
                <td><asp:DropDownList ID="drp_type_1_4" runat="server" >
                    <asp:ListItem Value="click" >消息</asp:ListItem>
                    <asp:ListItem Value="url" >链接</asp:ListItem>
                    </asp:DropDownList></td>
                <td><asp:TextBox ID="txt_content_1_4" runat="server" Width="645px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_name_1_5" runat="server" ></asp:TextBox></td>
                <td><asp:DropDownList ID="drp_type_1_5" runat="server" >
                    <asp:ListItem Value="click" >消息</asp:ListItem>
                    <asp:ListItem Value="url" >链接</asp:ListItem>
                    </asp:DropDownList></td>
                <td><asp:TextBox ID="txt_content_1_5" runat="server" Width="645px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" ><hr /></td>
            </tr>
            <tr>
                <td colspan="3" >第二列 <asp:TextBox ID="txt_button_2" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_name_2_1" runat="server" ></asp:TextBox></td>
                <td><asp:DropDownList ID="drp_type_2_1" runat="server" >
                    <asp:ListItem Value="click" >消息</asp:ListItem>
                    <asp:ListItem Value="url" >链接</asp:ListItem>
                    </asp:DropDownList></td>
                <td><asp:TextBox ID="txt_content_2_1" runat="server" Width="645px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_name_2_2" runat="server" ></asp:TextBox></td>
                <td><asp:DropDownList ID="drp_type_2_2" runat="server" >
                    <asp:ListItem Value="click" >消息</asp:ListItem>
                    <asp:ListItem Value="url" >链接</asp:ListItem>
                    </asp:DropDownList></td>
                <td><asp:TextBox ID="txt_content_2_2" runat="server" Width="645px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_name_2_3" runat="server" ></asp:TextBox></td>
                <td><asp:DropDownList ID="drp_type_2_3" runat="server" >
                    <asp:ListItem Value="click" >消息</asp:ListItem>
                    <asp:ListItem Value="url" >链接</asp:ListItem>
                    </asp:DropDownList></td>
                <td><asp:TextBox ID="txt_content_2_3" runat="server" Width="645px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_name_2_4" runat="server" ></asp:TextBox></td>
                <td><asp:DropDownList ID="drp_type_2_4" runat="server" >
                    <asp:ListItem Value="click" >消息</asp:ListItem>
                    <asp:ListItem Value="url" >链接</asp:ListItem>
                    </asp:DropDownList></td>
                <td><asp:TextBox ID="txt_content_2_4" runat="server" Width="645px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_name_2_5" runat="server" ></asp:TextBox></td>
                <td><asp:DropDownList ID="drp_type_2_5" runat="server" >
                    <asp:ListItem Value="click" >消息</asp:ListItem>
                    <asp:ListItem Value="url" >链接</asp:ListItem>
                    </asp:DropDownList></td>
                <td><asp:TextBox ID="txt_content_2_5" runat="server" Width="645px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" ><hr /></td>
            </tr>
            <tr>
                <td colspan="3" >第三列 <asp:TextBox ID="txt_button_3" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_name_3_1" runat="server" ></asp:TextBox></td>
                <td><asp:DropDownList ID="drp_type_3_1" runat="server" >
                    <asp:ListItem Value="click" >消息</asp:ListItem>
                    <asp:ListItem Value="url" >链接</asp:ListItem>
                    </asp:DropDownList></td>
                <td><asp:TextBox ID="txt_content_3_1" runat="server" Width="645px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_name_3_2" runat="server" ></asp:TextBox></td>
                <td><asp:DropDownList ID="drp_type_3_2" runat="server" >
                    <asp:ListItem Value="click" >消息</asp:ListItem>
                    <asp:ListItem Value="url" >链接</asp:ListItem>
                    </asp:DropDownList></td>
                <td><asp:TextBox ID="txt_content_3_2" runat="server" Width="645px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_name_3_3" runat="server" ></asp:TextBox></td>
                <td><asp:DropDownList ID="drp_type_3_3" runat="server" >
                    <asp:ListItem Value="click" >消息</asp:ListItem>
                    <asp:ListItem Value="url" >链接</asp:ListItem>
                    </asp:DropDownList></td>
                <td><asp:TextBox ID="txt_content_3_3" runat="server" Width="645px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_name_3_4" runat="server" ></asp:TextBox></td>
                <td><asp:DropDownList ID="drp_type_3_4" runat="server" >
                    <asp:ListItem Value="click" >消息</asp:ListItem>
                    <asp:ListItem Value="url" >链接</asp:ListItem>
                    </asp:DropDownList></td>
                <td><asp:TextBox ID="txt_content_3_4" runat="server" Width="645px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_name_3_5" runat="server" ></asp:TextBox></td>
                <td><asp:DropDownList ID="drp_type_3_5" runat="server" >
                    <asp:ListItem Value="click" >消息</asp:ListItem>
                    <asp:ListItem Value="url" >链接</asp:ListItem>
                    </asp:DropDownList></td>
                <td><asp:TextBox ID="txt_content_3_5" runat="server" Width="645px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="3" ><asp:Button ID="btn" runat="server"  Text=" 更 新 " OnClick="btn_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
