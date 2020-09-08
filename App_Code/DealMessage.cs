using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for DealMessage
/// </summary>
public class DealMessage
{
	public DealMessage()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static RepliedMessage DealReceivedMessage(ReceivedMessage receivedMessage)
    {
        RepliedMessage repliedMessage;
        if (receivedMessage.isEvent)
            repliedMessage = DealEventMessage(receivedMessage);
        else
            repliedMessage = DealUserInputMessage(receivedMessage);
        return repliedMessage;
    }

    public static RepliedMessage DealEventMessage(ReceivedMessage receivedMessage)
    {
        RepliedMessage repliedMessage;
        if (receivedMessage.isMenuClick)
        {
            repliedMessage = DealMenuClickMessage(receivedMessage);
        }
        else
        {
            if (receivedMessage.isMenuView)
            {
                repliedMessage = DealMenuViewMessage(receivedMessage);
            }
            else
            {
                repliedMessage = DealCommonEventMessage(receivedMessage);
            }
        }

        return repliedMessage;
    }

    public static RepliedMessage DealMenuClickMessage(ReceivedMessage receivedMessage)
    {
        RepliedMessage repliedMessage = new RepliedMessage();
        repliedMessage.from = receivedMessage.to;
        repliedMessage.to = receivedMessage.from;
        repliedMessage.rootId = receivedMessage.id.Trim();
        RepliedMessage.news newsContent;
        switch (receivedMessage.eventKey.Trim())
        {
            case "BAOMING":
                repliedMessage.content = Util.GetMenuBaomingHit(receivedMessage.from);
                repliedMessage.messageCount = 2;
                repliedMessage.type = "news";
                break;
            case "PINGTAI":
                repliedMessage.content = Util.GetMenuWodeHit(receivedMessage.from, "http://weixin.luqinwenda.com/dingyue/images/1.jpg"
                                , 1, "卢勤问答平台", "这里是卢勤问答平台，你可以在这里浏览和评论他人的提问。");
                repliedMessage.messageCount = 1;
                repliedMessage.type = "news";
                break;
            case "TIWEN":
                repliedMessage.content = Util.GetMenuWodeHit(receivedMessage.from, "http://weixin.luqinwenda.com/dingyue/images/3.jpg"
                                , 3, "快速提问", "点击进入快速提问，把你的问题提出来，卢勤老师帮你排忧解难。");
                repliedMessage.messageCount = 1;
                repliedMessage.type = "news";
                break;
            case "WENDA":
                repliedMessage.content = Util.GetMenuWodeHit(receivedMessage.from, "http://weixin.luqinwenda.com/dingyue/images/2.jpg"
                                , 2, "卢老师的回答", "卢勤老师的回答都在这里，点击即可浏览。");
                repliedMessage.messageCount = 1;
                repliedMessage.type = "news";
                break;
            case "WODE":
                repliedMessage.content = Util.GetMenuWodeHit(receivedMessage.from, "http://weixin.luqinwenda.com/dingyue/images/4.jpg"
                                , 4, "还记得自己提过的问题吗？点击进入，即可查看提问历史。", "还记得自己提过的问题吗？点击进入，即可查看提问历史。");
                repliedMessage.messageCount = 1;
                repliedMessage.type = "news";
                break;
            case "VIDEO":
                repliedMessage.content = Util.Get2014SummerCampVideoForWexinNews();
                repliedMessage.messageCount = 9;
                repliedMessage.type = "news";
                break;
            case "IMAGE":
                repliedMessage.content = Util.Get2014SummerCampImageForWexinNews();
                repliedMessage.messageCount = 4;
                repliedMessage.type = "news";
                break;
            case "FANGTAN":

                newsContent = new RepliedMessage.news();
                newsContent.picUrl = "http://weixin.luqinwenda.com/images/jianmianhui.jpeg";
                newsContent.url = "http://www.luqinwenda.com/index.php?app=public&mod=MobileNew&act=interviewlist&openid="
                    + receivedMessage.from.Trim();
                newsContent.title = "卢勤问答微信见面会";
                newsContent.description = "你在孩子的成长过程中有什么困惑吗？你与孩子沟通顺利吗？你有什么烦恼想要倾诉吗？你可以在这里随意提问，卢勤老师将倾听你的声音，为你答疑解惑。";
                repliedMessage.newsContent = new RepliedMessage.news[] { newsContent };
                break;
            case "XIALINGYING":
                newsContent = new RepliedMessage.news();
                newsContent.picUrl = "http://weixin.luqinwenda.com/images/pek_summer.jpg";
                newsContent.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=205090874&idx=1&sn=dc902270a746d32e88e8dbcba04d8370#rd"
                    + receivedMessage.from.Trim();
                newsContent.title = "“放飞梦想我能行”知心姐姐北京精品营 再次出发";
                newsContent.description = "猛击上面的“卢勤问答”关注我。每天精选教育资讯和文章，供您浏览。 去年暑假，“放飞梦想我能行”知心姐姐北京营再次出发。";

                repliedMessage.newsContent = new RepliedMessage.news[] { newsContent };
                break;
            case "CANJIA":
                repliedMessage.newsContent = Util.GetInviteMessage(receivedMessage.from.Trim(),"message");
               // repliedMessage.newsContent[0].url = "http://mall.luqinwenda.com/Activity_bj.aspx?fromsource=subscribe&preopenid=" + receivedMessage.from.Trim() + "&openid=" + receivedMessage.from.Trim() + "&source=1";
               // repliedMessage.newsContent[0].url = "http://www.luqinwenda.com";
                break;
            default:
                break;
        }
        return repliedMessage;
    }

    public static RepliedMessage DealMenuViewMessage(ReceivedMessage receivedMessage)
    {
        RepliedMessage repliedMessage = new RepliedMessage();
        repliedMessage.from = receivedMessage.to;
        repliedMessage.to = receivedMessage.from;
        repliedMessage.rootId = receivedMessage.id.Trim();
        if (receivedMessage.eventKey.ToLower().Trim().StartsWith("http://www.luqinwenda.com/index.php?app=public&mod=landingpage"))
        {
            Util.DealLandingRequest(receivedMessage.from);
        }
        return repliedMessage;
    }

    public static RepliedMessage DealCommonEventMessage(ReceivedMessage receivedMessage)
    {
        RepliedMessage repliedMessage = new RepliedMessage();
        repliedMessage.from = receivedMessage.to;
        repliedMessage.to = receivedMessage.from;
        repliedMessage.rootId = receivedMessage.id.Trim();
        if (receivedMessage.eventKey.ToLower().Trim().StartsWith("http://www.luqinwenda.com/index.php?app=public&mod=landingpage"))
        {
            Util.DealLandingRequest(receivedMessage.from);
        }
        switch (receivedMessage.userEvent.Trim())
        { 
            case "subscribe":
                bool deal = false;
                if (!receivedMessage.eventKey.Trim().Equals(""))
                {
                    try
                    {
                        Util.AcceptInvite(receivedMessage.from.Trim(), long.Parse(receivedMessage.eventKey.Replace("qrscene_", "")));
                        repliedMessage.newsContent = Util.GetInviteMessage(receivedMessage.from.Trim(),"subscribe");

                        deal = true;
                    }
                    catch
                    {
                        
                    }
                }
                if (!deal)
                {
                    RepliedMessage.news[] newsArr = new RepliedMessage.news[4];

                    newsArr[0] = new RepliedMessage.news();
                    newsArr[0].picUrl = "http://weixin.luqinwenda.com/dingyue/images/1.jpg";
                    newsArr[0].title = "欢迎关注卢勤问答";
                    newsArr[0].description = "欢迎关注卢勤问答";
                    newsArr[0].url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=201403673&idx=1&sn=1ba5e81f3d925935117caf8abb12ac84#rd";

                    newsArr[1] = new RepliedMessage.news();
                    newsArr[1].title = "文明小使者畅游新加坡——2016新加坡精品冬令营";
                    newsArr[1].description = "文明小使者畅游新加坡——2016新加坡精品冬令营";
                    newsArr[1].url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=400281989&idx=1&sn=c309e1c612690003cc6d15bd64f379c9#rd";
                    newsArr[1].picUrl = "http://weixin.luqinwenda.com/images/singapore_2016_s.jpg";

                    newsArr[2] = new RepliedMessage.news();
                    newsArr[2].picUrl = "http://weixin.luqinwenda.com/images/talk.jpg";
                    newsArr[2].title = "“我要学演说” 少年口才培训火热征募中……";
                    newsArr[2].description = "“我要学演说” 少年口才培训火热征募中……";
                    newsArr[2].url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=213625859&idx=1&sn=b1707b0fcc208232951b36fe66bc4e33#rd";

                    newsArr[3] = new RepliedMessage.news();
                    newsArr[3].picUrl = "http://weixin.luqinwenda.com/images/weiketang.jpg";
                    newsArr[3].title = "报名启动：卢勤公益微课堂 开讲了";
                    newsArr[3].description = "报名启动：卢勤公益微课堂 开讲了";
                    newsArr[3].url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=401732145&idx=2&sn=a27d4b3a904e26c11e47c5f095e4bd01&scene=1&srcid=1127GL8FPbhHEDtwNljbbHOX&key=ff7411024a07f3eb0913a730e8e5ce7baee0049c9eaaeb2ca74ff9c09cc74e4fbafb3dbc59d34431b7b9774da5ae79c2&ascene=0&uin=ODk3MzEzNzY0&devicetype=iMac+MacBookAir6%2C2+OSX+OSX+10.11.1+build(15B42)&version=11020201&pass_ticket=CV%2BXqWh4PB6EpCb%2BekSQtuF6X8nlpfhXEdvNC0vPwnJj4vTXD%2F1FZ3pTgin1zsZH";
                                        

                    repliedMessage.newsContent = newsArr;
                    deal = true;
                }
                break;
            default:
                break;
        }
        return repliedMessage;
    }

    public static string UserInputMessageToCommand(string inputString)
    {
        string command = inputString;
        if (inputString.Trim().StartsWith("送书"))
        {
            command = "送书";
        }
        /*
        if ((inputString.Trim().IndexOf("营") >= 0) || (inputString.Trim().IndexOf("演讲") >= 0)
            || (inputString.Trim().IndexOf("演说") >= 0) || (inputString.Trim().IndexOf("新加坡") >= 0)
            || (inputString.Trim().IndexOf("文明") >= 0))
        {
            command = "营";
        }
        */

        if (inputString.Trim().IndexOf("美国")>=0)
            command = "美国";
        if (inputString.Trim().IndexOf("新加坡") >= 0)
            command = "新加坡";
        if (inputString.Trim().IndexOf("演") >= 0 || inputString.Trim().IndexOf("寒")>=0 || inputString.Trim().IndexOf("冬")>=0)
            command = "演讲";

        return command;
    }

    public static RepliedMessage DealUserInputMessage(ReceivedMessage receivedMessage)
    {
        RepliedMessage repliedMessage = new RepliedMessage();
        repliedMessage.from = receivedMessage.to;
        repliedMessage.to = receivedMessage.from;
        repliedMessage.rootId = receivedMessage.id;

        if (receivedMessage.type.Trim().Equals("image"))
        {
            string userInfoJsonStr = Util.GetUserInfoJsonStringByOpenid(receivedMessage.from.Trim());
            string nick = Util.GetSimpleJsonValueByKey(userInfoJsonStr, "nickname");
            string headImage = Util.GetSimpleJsonValueByKey(userInfoJsonStr, "headimgurl");
            KeyValuePair<string, KeyValuePair<SqlDbType, object>>[] insertParameterArr
                = new KeyValuePair<string, KeyValuePair<SqlDbType, object>>[2];
            insertParameterArr[0] = new KeyValuePair<string, KeyValuePair<SqlDbType, object>>("weixin_nick",
                new KeyValuePair<SqlDbType, object>(SqlDbType.VarChar, (object)nick));
            insertParameterArr[1] = new KeyValuePair<string, KeyValuePair<SqlDbType, object>>("weixin_head_image",
                new KeyValuePair<SqlDbType, object>(SqlDbType.VarChar, (object)headImage));
            DBHelper.InsertData("malldatabase.dbo.donate_list", insertParameterArr, Util.conStr);
            return repliedMessage;
        }





        string command = UserInputMessageToCommand(receivedMessage.content.Trim().ToLower()).Trim();
        if (command.StartsWith("送书"))
            command = "送书";
        switch (command)
        { 
            case "二维码":
                repliedMessage = CreateQrCodeReplyMessage(receivedMessage, repliedMessage);
                break;
            case "送书":
                repliedMessage.type = "text";
                //repliedMessage.content = "感谢您的热情参与，本次活动已经结束，<a href=\"http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=204410162&idx=1&sn=146c47966688ae22cf760d0cbd22faa3&scene=1&key=0ce8fa93c80e41c5b00c430ca64638d8f3dcbe64f24950abca2480c8ae85a44b56641fa7288d01b8fc6f18515264f57a&ascene=0&uin=ODk3MzEzNzY0&devicetype=iMac+MacBookAir6%2C2+OSX+OSX+10.10.2+build(14C109)&version=11020012&pass_ticket=gGeBx6EjjOmbm3rRWxQKTlS0K19Fjt%2F1mZ5XPVJWMrgvgTWG37A0ToJ5Dbyhv11k\" >点击此处</a>查看获奖名单。";
                repliedMessage.content = "感谢您的参与！您离报名成功还差最后一步，将本次活动→_→ 点击蓝色字体【<a href=\"http://mp.weixin.qq.com/s?__biz=MzA3MzM1NjcxNA==&mid=204552207&idx=1&sn=c761928249f45fb4461750c6662b7ab0#rd\" >点击此处</a>】转发到朋友圈，并将截图发送至本公众号平台，即报名成功！请耐心等待抽奖！";
                break;
            case "五十句":
                repliedMessage.type = "news";
                RepliedMessage.news news50Message = new RepliedMessage.news();
                news50Message.title = "卢勤问答";
                news50Message.picUrl = "http://weixin.luqinwenda.com/images/50.jpg";
                news50Message.description = "教育的禁忌：有些话一旦说出口，就伤了孩子的心，你知道有哪五十句话不能对孩子说吗？";
                news50Message.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=201333509&idx=1&sn=ad881eae2e77fd2ef9ddb34c0e15a335#rd";
                repliedMessage.newsContent = new RepliedMessage.news[] {news50Message};

                break;

            case "营":

                RepliedMessage.news singaporeNews = new RepliedMessage.news();
                singaporeNews.title = "文明小使者畅游新加坡——2016新加坡精品冬令营";
                singaporeNews.description = "文明小使者畅游新加坡——2016新加坡精品冬令营";
                singaporeNews.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=400281989&idx=1&sn=c309e1c612690003cc6d15bd64f379c9#rd";
                singaporeNews.picUrl = "http://weixin.luqinwenda.com/images/singapore_2016.jpg";

                RepliedMessage.news speechNews = new RepliedMessage.news();
                speechNews.title = "“我要学演说” 少年口才培训火热征募中……";
                speechNews.description = "“我要学演说” 少年口才培训火热征募中……";
                speechNews.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=213625859&idx=1&sn=b1707b0fcc208232951b36fe66bc4e33#rd";
                speechNews.picUrl = "http://weixin.luqinwenda.com/images/speech_2016.jpg";

                repliedMessage.type = "news";
                repliedMessage.newsContent = new RepliedMessage.news[] { singaporeNews, speechNews  };

                break;

            case "美国":
                repliedMessage.type = "news";
                RepliedMessage.news[] usaNewsArr = new RepliedMessage.news[8];
                usaNewsArr[0] = new RepliedMessage.news();
                usaNewsArr[0].title = "创新科技体验营美国行：美国，我来了！";
                usaNewsArr[0].description = "两天前的开营式已经让大家满怀期待，现在孩子们终于站在了这块土地上，我们一起来期待未来十几天的美国创新科技之旅，在这里，遇见未来的自己！";
                usaNewsArr[0].url = "http://mp.weixin.qq.com/s/BikN9Ze4FXt6pxwyRG22kA";
                usaNewsArr[0].picUrl = "http://weixin.luqinwenda.com/images/usa.jpg";

                usaNewsArr[1] = new RepliedMessage.news();
                usaNewsArr[1].title = "创新：让孩子的潜能充分发挥，孩子一生受益的能力。";
                usaNewsArr[1].description = "两天前的开营式已经让大家满怀期待，现在孩子们终于站在了这块土地上，我们一起来期待未来十几天的美国创新科技之旅，在这里，遇见未来的自己！";
                usaNewsArr[1].url = "https://mp.weixin.qq.com/s/cdsSY7IrOgZIllaB9CvadQ";
                usaNewsArr[1].picUrl = "http://weixin.luqinwenda.com/images/usa1.png";

                usaNewsArr[2] = new RepliedMessage.news();
                usaNewsArr[2].title = "走进科技之都，体验梦想之旅。";
                usaNewsArr[2].description = "两天前的开营式已经让大家满怀期待，现在孩子们终于站在了这块土地上，我们一起来期待未来十几天的美国创新科技之旅，在这里，遇见未来的自己！";
                usaNewsArr[2].url = "https://mp.weixin.qq.com/s/MWS_Pe-LVml7wy4xLd7vKQ";
                usaNewsArr[2].picUrl = "http://weixin.luqinwenda.com/images/usa2.png";

                usaNewsArr[3] = new RepliedMessage.news();
                usaNewsArr[3].title = "在文化的交融互动中感受世界，让孩子自信地认识自己！";
                usaNewsArr[3].description = "两天前的开营式已经让大家满怀期待，现在孩子们终于站在了这块土地上，我们一起来期待未来十几天的美国创新科技之旅，在这里，遇见未来的自己！";
                usaNewsArr[3].url = "https://mp.weixin.qq.com/s/VpGtTePE2OsuOpI9WKlX2w";
                usaNewsArr[3].picUrl = "http://weixin.luqinwenda.com/images/usa3.png";

                usaNewsArr[4] = new RepliedMessage.news();
                usaNewsArr[4].title = "如何让孩子独立起来？放手让孩子学会自我管理。";
                usaNewsArr[4].description = "两天前的开营式已经让大家满怀期待，现在孩子们终于站在了这块土地上，我们一起来期待未来十几天的美国创新科技之旅，在这里，遇见未来的自己！";
                usaNewsArr[4].url = "https://mp.weixin.qq.com/s/Rw5AYN7NO5OeBsc7QmjM0w";
                usaNewsArr[4].picUrl = "http://weixin.luqinwenda.com/images/usa4.png";

                usaNewsArr[5] = new RepliedMessage.news();
                usaNewsArr[5].title = "体验科技，让孩子的生命更饱满！";
                usaNewsArr[5].description = "两天前的开营式已经让大家满怀期待，现在孩子们终于站在了这块土地上，我们一起来期待未来十几天的美国创新科技之旅，在这里，遇见未来的自己！";
                usaNewsArr[5].url = "https://mp.weixin.qq.com/s/FYekStCYab3AU-Gen4zJWA";
                usaNewsArr[5].picUrl = "http://weixin.luqinwenda.com/images/usa5.png";

                usaNewsArr[6] = new RepliedMessage.news();
                usaNewsArr[6].title = "迎接挑战，我们要说“太好了”！";
                usaNewsArr[6].description = "两天前的开营式已经让大家满怀期待，现在孩子们终于站在了这块土地上，我们一起来期待未来十几天的美国创新科技之旅，在这里，遇见未来的自己！";
                usaNewsArr[6].url = "https://mp.weixin.qq.com/s/w0UY9Pan3BfGyaTC4Cr6Vg";
                usaNewsArr[6].picUrl = "http://weixin.luqinwenda.com/images/usa6.png";

                usaNewsArr[7] = new RepliedMessage.news();
                usaNewsArr[7].title = "孩子们的希望，好莱坞的星光。";
                usaNewsArr[7].description = "两天前的开营式已经让大家满怀期待，现在孩子们终于站在了这块土地上，我们一起来期待未来十几天的美国创新科技之旅，在这里，遇见未来的自己！";
                usaNewsArr[7].url = "https://mp.weixin.qq.com/s/QMyHtart06NCOgAOsRQwLg";
                usaNewsArr[7].picUrl = "http://weixin.luqinwenda.com/images/usa6.png";

                repliedMessage.newsContent = usaNewsArr;

                break;
            case "新加坡":

                break;
            case "演讲":

                break;
            case "洗刷刷":
                repliedMessage.type = "news";
                RepliedMessage.news xishuashuaMessage = new RepliedMessage.news();
                xishuashuaMessage.title = "洗刷刷";
                xishuashuaMessage.picUrl = "http://weixin.luqinwenda.com/images/xishuashua.jpg";
                xishuashuaMessage.description = "洗刷刷";
                xishuashuaMessage.url = "http://weidian.com/?userid=842789047&from=singlemessage&isappinstalled=0";
                repliedMessage.newsContent = new RepliedMessage.news[] { xishuashuaMessage };
                break;
            case "微课堂":
                RepliedMessage textMessage = new RepliedMessage();
                textMessage.type = "text";
                textMessage.content = "请分享报名帖【http://dwz.cn/luqinwkt】至朋友圈或分享到100人以上微信群，走心地评论并截图，然后把截图发给客服平台小助手（扫下方二维码加好友），他会加您进听课群。";
                textMessage.from = receivedMessage.to;
                textMessage.to = receivedMessage.from;
                int i = textMessage.SendAsServiceMessage();
                string token = Util.GetToken();
                string filePathName = System.Configuration.ConfigurationSettings.AppSettings["qrcode_path"].Trim() + "\\xiaozhushou.jpg";
                string mediaId = Util.UploadImageToWeixin(filePathName, token);
                repliedMessage.type = "image";
                repliedMessage.content = mediaId;

                break;
            case "微课":
            case "上课":
            case "微客":
            case "我要报名":
            case "报名":
            case "报名参加":
            case "我要参加":
                /*
                string qrXuMediaId1 = Util.UploadImageToWeixin(System.Configuration.ConfigurationSettings.AppSettings["qrcode_path"].Trim()
                       + "\\qrcode_luqinwenda001.jpg", Util.GetToken());
                RepliedMessage imageMessage1 = new RepliedMessage();
                imageMessage1.from = receivedMessage.to;
                imageMessage1.to = receivedMessage.from;
                imageMessage1.type = "image";
                imageMessage1.mediaId = qrXuMediaId1.Trim();
                imageMessage1.SendAsServiceMessage();
                
                repliedMessage.type = "text";
                repliedMessage.content = "为确保最有需要的家长前来听课，请转发本期<a href=\"http://weixin.luqinwenda.com/dingyue/baoming_jump.aspx\" >【悦长大微课堂】本期课程预告图文消息（戳此链接进入）</a>到朋友圈，并带上“报名参加”等评论，截图后发给小助手（luqinwenda001），小助手将拉您进入听课群群，谢谢！";
                */
                repliedMessage.type = "text";
                repliedMessage.content = "您已经报名成功，直播开始前，您将会收到消息提示。";

                break;
            default:
                break;
        }
        return repliedMessage;
    }

    public static RepliedMessage CreateQrCodeReplyMessage(ReceivedMessage receivedMessage, RepliedMessage repliedMessage)
    {
        string token = Util.GetToken();
        long scene = long.Parse(Util.GetInviteCode(receivedMessage.from.Trim(),"二维码命令").ToString());
        string ticket = Util.GetQrCodeTicketTemp(token, scene);
        byte[] qrCodeByteArr = Util.GetQrCodeByTicket(ticket);
        string filePathName = System.Configuration.ConfigurationSettings.AppSettings["qrcode_path"].Trim() + "\\" + scene.ToString() + ".jpg";
        Util.SaveBytesToFile(filePathName, qrCodeByteArr);
        string mediaId = Util.UploadImageToWeixin(filePathName, token);
        repliedMessage.messageCount = 1;
        repliedMessage.type = "image";
        repliedMessage.content = mediaId;
        return repliedMessage;
    }

}