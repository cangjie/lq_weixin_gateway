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
    public static string qrXiaozhushouMediaId = "";

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
                repliedMessage.content = Util.GetMenuWodeHit(receivedMessage.from, "http://weixin.luqinwenda.com/dingyue/images/1.jpg?aaww"
                                , 1, "专家问答平台", "这里是悦长大家庭教育专家问答平台，你可以在这里浏览和评论他人的提问。");
                repliedMessage.messageCount = 1;
                repliedMessage.type = "news";
                break;
            case "TIWEN":
                repliedMessage.content = Util.GetMenuWodeHit(receivedMessage.from, "http://weixin.luqinwenda.com/dingyue/images/3.jpg?wweweasdsdss"
                                , 3, "快速提问", "点击进入快速提问，把你的问题提出来，教育专家帮你排忧解难。");
                repliedMessage.messageCount = 1;
                repliedMessage.type = "news";
                break;
            case "WENDA":
                repliedMessage.content = Util.GetMenuWodeHit(receivedMessage.from, "http://weixin.luqinwenda.com/dingyue/images/2.jpg?kdieieidkd"
                                , 2, "专家的回答", "专家老师的回答都在这里，点击即可浏览。");
                repliedMessage.messageCount = 1;
                repliedMessage.type = "news";
                break;
            case "WODE":
                repliedMessage.content = Util.GetMenuWodeHit(receivedMessage.from, "http://weixin.luqinwenda.com/dingyue/images/2.jpg?ssss"
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
/*
            case "HEZUO":

                string qrXuMediaId = Util.UploadImageToWeixin(System.Configuration.ConfigurationSettings.AppSettings["qrcode_path"].Trim()
                    + "\\qr_xu.jpg", Util.GetToken());

                RepliedMessage textMessage = new RepliedMessage();
                textMessage.from = receivedMessage.to;
                textMessage.to = receivedMessage.from;
                textMessage.type = "text";
                textMessage.content = "您好，欢迎关注卢勤问答平台订阅号！麻烦您将商务合作细则、内容发至hezuo@luqinwenda.com，我们的工作人员会尽快与您联系！您也可以扫描以下二维码和旭老师联系。";
                textMessage.SendAsServiceMessage();

                System.Threading.Thread.Sleep(500);

                RepliedMessage imageMessage = new RepliedMessage();
                imageMessage.from = receivedMessage.to;
                imageMessage.to = receivedMessage.from;
                imageMessage.type = "image";
                imageMessage.mediaId = qrXuMediaId.Trim();
                imageMessage.SendAsServiceMessage();


                repliedMessage.type = "";
                repliedMessage.mediaId = qrXuMediaId;
                //repliedMessage.content = "您好，欢迎关注卢勤问答平台订阅号！麻烦您将商务合作细则、内容发至hezuo@luqinwenda.com，我们的工作人员会尽快与您联系！";
                break;
*/
            case "HUIGU":
                repliedMessage = BuildMessageByKeyword(repliedMessage, "女儿");
                break;
	    case "COOP":
string qrXuMediaId = Util.UploadImageToWeixin(System.Configuration.ConfigurationSettings.AppSettings["qrcode_path"].Trim()
                    + "\\qr_xu.jpg", Util.GetToken());

                RepliedMessage textMessage = new RepliedMessage();
                textMessage.from = receivedMessage.to;
                textMessage.to = receivedMessage.from;
                textMessage.type = "text";
                textMessage.content = "商务合作、课程转播等请联系悦长大平台旭老师，18511998488(电话/微信)。";
                textMessage.SendAsServiceMessage();

                System.Threading.Thread.Sleep(500);

                RepliedMessage imageMessage = new RepliedMessage();
                imageMessage.from = receivedMessage.to;
                imageMessage.to = receivedMessage.from;
                imageMessage.type = "image";
                imageMessage.mediaId = qrXuMediaId.Trim();
                imageMessage.SendAsServiceMessage();


                repliedMessage.type = "";
                repliedMessage.mediaId = qrXuMediaId;
		break;
	    case "SPEECH":
		
		newsContent = new RepliedMessage.news();
                newsContent.picUrl = "http://weixin.luqinwenda.com/dingyue/images/speech_rec.jpg";
                newsContent.url = "http://mp.weixin.qq.com/s/jg6ObWKDHHNVwOanU6LD5g";
                   
                newsContent.title = "2017少年演说家潜能开发营、提高营火热报名中！";
                newsContent.description = "想学说话，就要找中国最会说话的人！名师一对一授学，让孩子敢说话、会说话、说自己的话，善于运用语言的力量！";


        RepliedMessage.news newsContent1 = new RepliedMessage.news();
		newsContent1.picUrl = "http://weixin.luqinwenda.com/dingyue/images/speech_sqr.png";
                newsContent1.url = "http://mp.weixin.qq.com/s/kSZGzf7mB-3DTpvp6UaAPQ";
                   
                newsContent1.title = "2017“少年演说家”智慧父母课堂火热报名中！";
                newsContent1.description = "孩子参营学习，家长更不能落后！“少年演说家”活动组委会同期开设“智慧父母课堂”，名师大咖加盟，助力打造幸福家庭，让父母与孩子齐步并肩，共成长！";

	

                repliedMessage.newsContent = new RepliedMessage.news[] { newsContent, newsContent1 };


		break;
            case "GLOBAL":

                newsContent = new RepliedMessage.news();
                newsContent.picUrl = "http://weixin.luqinwenda.com/dingyue/images/jpn_rec.jpg";
                newsContent.url = "http://mp.weixin.qq.com/s/M8iZoAcnrNz7fy_eFvRq5A";

                newsContent.title = "“大开眼界”日本科技文化发现之旅";
                newsContent.description = "在东京！在大阪！体验科技，玩转动漫，感受传统文化与多元文化的融合。开阔视野，在日本学与游当中能获得丰富多彩意想不到的收获！";

                RepliedMessage.news newsContent2 = new RepliedMessage.news();
                newsContent2.picUrl = "http://weixin.luqinwenda.com/dingyue/images/aus.png";
                newsContent2.url = "http://mp.weixin.qq.com/s/ekPi71MpNSq3vLhBVthXLQ";

                newsContent2.title = "“大开眼界”澳大利亚交流之旅火热报名中！";
                newsContent2.description = "这是一个集文化探访、都市采风、自然探索为一体的夏令营。";



                repliedMessage.newsContent = new RepliedMessage.news[] { newsContent, newsContent2 };


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
                    RepliedMessage.news[] newsArr = new RepliedMessage.news[6];

                    newsArr[0] = new RepliedMessage.news();
                    newsArr[0].picUrl = "http://weixin.luqinwenda.com/dingyue/images/speech_rec.jpg";
                    newsArr[0].title = "2017少年演说家潜能开发营、提高营火热报名中！";
                    newsArr[0].description = "想学说话，就要找中国最会说话的人！名师一对一授学，让孩子敢说话、会说话、说自己的话，善于运用语言的力量！";
                    newsArr[0].url = "https://mp.weixin.qq.com/s/jg6ObWKDHHNVwOanU6LD5g";

                    newsArr[1] = new RepliedMessage.news();
                    newsArr[1].picUrl = "http://weixin.luqinwenda.com/dingyue/images/subscribe_2.png";
                    newsArr[1].title = "2017“少年演说家”智慧父母课堂火热报名中！";
                    newsArr[1].description = "孩子参营学习，家长更不能落后！“少年演说家”活动组委会同期开设“智慧父母课堂”，名师大咖加盟，助力打造幸福家庭，让父母与孩子齐步并肩，共成长！";
                    newsArr[1].url = "http://mp.weixin.qq.com/s/kSZGzf7mB-3DTpvp6UaAPQ";

                    
                    newsArr[2] = new RepliedMessage.news();
                    newsArr[2].picUrl = "http://weixin.luqinwenda.com/dingyue/images/subscribe_3.jpg";
                    newsArr[2].title = "“大开眼界”日本科技文化发现之旅";
                    newsArr[2].description = "在东京！在大阪！体验科技，玩转动漫，感受传统文化与多元文化的融合。开阔视野，在日本学与游当中能获得丰富多彩意想不到的收获。";
                    newsArr[2].url = "https://mp.weixin.qq.com/s/M8iZoAcnrNz7fy_eFvRq5A";

                    newsArr[3] = new RepliedMessage.news();
                    newsArr[3].picUrl = "http://weixin.luqinwenda.com/dingyue/images/subscribe_4.png";
                    newsArr[3].title = "“大开眼界”澳大利亚交流之旅火热报名中！";
                    newsArr[3].description = "这是一个集文化探访、都市采风、自然探索为一体的夏令营。";
                    newsArr[3].url = "http://mp.weixin.qq.com/s/K_yAyIBz_mJeM0gnBWmY0g";


                    newsArr[4] = new RepliedMessage.news();
                    newsArr[4].picUrl = "http://weixin.luqinwenda.com/dingyue/images/subscribe_6.png";
                    newsArr[4].title = "问答指南：如何向专家提问？";
                    newsArr[4].description = "问答指南：如何向专家提问？";
                    newsArr[4].url = "http://mp.weixin.qq.com/s/fFaRmHsHZctCRCYPkrDFzQ";

                    newsArr[5] = new RepliedMessage.news();
                    newsArr[5].picUrl = "http://weixin.luqinwenda.com/dingyue/images/subscribe_7.png";
                    newsArr[5].title = "“悦长大微课堂”，和孩子共同成长！";
                    newsArr[5].description = "悦长大家庭教育专家问答平台创办的，每周以微信群的方式进行授课的互动式线上课堂。";
                    newsArr[5].url = "http://mp.weixin.qq.com/s/V5dgg4Jwlslxu7MDHrhBPA";








                    /* 
                      newsArr[1] = new RepliedMessage.news();
                      newsArr[1].picUrl = "http://weixin.luqinwenda.com/images/wenda.jpg";
                      newsArr[1].title = "问答指南：如何向卢勤老师提问？";
                      newsArr[1].description = "问答指南：如何向卢勤老师提问？";
                      newsArr[1].url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=404790715&idx=3&sn=76ce5ed22f81bc384d749ffbf39b0594#rd";

                      newsArr[2] = new RepliedMessage.news();
                      newsArr[2].picUrl = "http://weixin.luqinwenda.com/images/tushu.jpg";
                      newsArr[2].title = "卢勤老师亲著图书介绍";
                      newsArr[2].description = "卢勤老师亲著图书介绍";
                      newsArr[2].url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=404790715&idx=4&sn=11e7c46abdd6b8da9219838919693bf9#rd";

                      newsArr[3] = new RepliedMessage.news();
                      newsArr[3].picUrl = "http://weixin.luqinwenda.com/images/ying.jpg";
                      newsArr[3].title = "【活动】“少年演说家”潜能开发营初级班火热征募中~";
                      newsArr[3].description = "【活动】“少年演说家”潜能开发营初级班火热征募中~";
                      newsArr[3].url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=404790715&idx=5&sn=d95feb398f1f3142332ce5d5713c321a#rd";
              */

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
        if (inputString.Trim().IndexOf("微课") >= 0)
        {
            command = "微课";
        }


        if (inputString.Trim().IndexOf("美国") >= 0)
            command = "美国";
        if (inputString.Trim().IndexOf("新加坡") >= 0)
            command = "新加坡";
	if (inputString.Trim().IndexOf("摄影") >= 0)
            command = "新加坡";
        if (inputString.Trim().IndexOf("演") >= 0 || inputString.Trim().IndexOf("寒") >= 0 || inputString.Trim().IndexOf("冬") >= 0)
            command = "演讲";


        //if (inputString.Trim().Equals("")

        if (inputString.ToLower().StartsWith("k"))
        {
            string subCommand = inputString.Remove(0, 1);
            try
            {
                int subCommandId = int.Parse(subCommand);
                if (subCommandId > 0)
                {
                    command = "k";
                }
            }
            catch
            { 
            
            }
        }
        if (inputString.ToLower().StartsWith("w"))
        {
            string subCommand = inputString.Remove(0, 1);
            try
            {
                int subCommandId = int.Parse(subCommand);
                if (subCommandId > 0)
                {
                    command = "w";
                }
            }
            catch
            {

            }
        }
        if (inputString.Trim().ToLower().StartsWith("a"))
        {
            string subCommand = inputString.Remove(0, 1);
            try
            {
                int subCommandId = int.Parse(subCommand);
                if (subCommandId > 0)
                {
                    command = "a";
                }
            }
            catch
            {

            }
        }
        if (inputString.Trim().ToLower().StartsWith("b"))
        {
            string subCommand = inputString.Remove(0, 1);
            try
            {
                int subCommandId = int.Parse(subCommand);
                if (subCommandId > 0)
                {
                    command = "b";
                }
            }
            catch
            {

            }
        }
        if (inputString.Trim().ToLower().StartsWith("g"))
        {
            command = "g";
        }

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
                repliedMessage.newsContent = new RepliedMessage.news[] { news50Message };

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
                usaNewsArr[7].picUrl = "http://weixin.luqinwenda.com/images/usa7.png";

                repliedMessage.newsContent = usaNewsArr;

                break;
            case "新加坡":
                repliedMessage.type = "news";
                RepliedMessage.news[] sinNewsArr = new RepliedMessage.news[8];
                sinNewsArr[0] = new RepliedMessage.news();
                sinNewsArr[0].title = "【夏令营】“大开眼界”新加坡摄影营（7月15-21）";
                sinNewsArr[0].description = "当地球已以一个村庄的形态出现之时，面对未来，面对必然的世界公民，打开眼界，跨出国门，感受新异，已成为很多父母培养孩子的必须。因为他们深深知道，眼界决定未来，视野开启航向！";
                sinNewsArr[0].url = "https://mp.weixin.qq.com/s/7DkwA_b7UwaNdL1Bnr9wAQ";
                sinNewsArr[0].picUrl = "http://weixin.luqinwenda.com/dingyue/images/singapore.png";

                sinNewsArr[1] = new RepliedMessage.news();
                sinNewsArr[1].title = "开启信心之旅，让“我能行＂成为生命底色。";
                sinNewsArr[1].description = "当地球已以一个村庄的形态出现之时，面对未来，面对必然的世界公民，打开眼界，跨出国门，感受新异，已成为很多父母培养孩子的必须。因为他们深深知道，眼界决定未来，视野开启航向！";
                sinNewsArr[1].url = "http://mp.weixin.qq.com/s/wjEoU_j6XUSpcFJSNUD45w";
                sinNewsArr[1].picUrl = "http://weixin.luqinwenda.com/images/sin1.png";

                sinNewsArr[2] = new RepliedMessage.news();
                sinNewsArr[2].title = "让自由和爱心飞扬。";
                sinNewsArr[2].description = "当地球已以一个村庄的形态出现之时，面对未来，面对必然的世界公民，打开眼界，跨出国门，感受新异，已成为很多父母培养孩子的必须。因为他们深深知道，眼界决定未来，视野开启航向！";
                sinNewsArr[2].url = "https://mp.weixin.qq.com/s/Ff2o1gyqnBeWIB-PLf6AWQ";
                sinNewsArr[2].picUrl = "http://weixin.luqinwenda.com/images/sin2.png";

                sinNewsArr[3] = new RepliedMessage.news();
                sinNewsArr[3].title = "学会关心，感恩成长。";
                sinNewsArr[3].description = "当地球已以一个村庄的形态出现之时，面对未来，面对必然的世界公民，打开眼界，跨出国门，感受新异，已成为很多父母培养孩子的必须。因为他们深深知道，眼界决定未来，视野开启航向！";
                sinNewsArr[3].url = "https://mp.weixin.qq.com/s/YKfK6PSXC5sgGqm-8fMjjA";
                sinNewsArr[3].picUrl = "http://weixin.luqinwenda.com/images/sin3.png";

                sinNewsArr[4] = new RepliedMessage.news();
                sinNewsArr[4].title = "亲近自然 学会交流 感悟孝心。";
                sinNewsArr[4].description = "当地球已以一个村庄的形态出现之时，面对未来，面对必然的世界公民，打开眼界，跨出国门，感受新异，已成为很多父母培养孩子的必须。因为他们深深知道，眼界决定未来，视野开启航向！";
                sinNewsArr[4].url = "https://mp.weixin.qq.com/s/5jOkyyzUcaWuJlWt6QJ5TQ";
                sinNewsArr[4].picUrl = "http://weixin.luqinwenda.com/images/sin4.png";

                sinNewsArr[5] = new RepliedMessage.news();
                sinNewsArr[5].title = "留驻＂五心＂回程 ，带着梦想起飞。";
                sinNewsArr[5].description = "当地球已以一个村庄的形态出现之时，面对未来，面对必然的世界公民，打开眼界，跨出国门，感受新异，已成为很多父母培养孩子的必须。因为他们深深知道，眼界决定未来，视野开启航向！";
                sinNewsArr[5].url = "https://mp.weixin.qq.com/s/_rKKK9LvFjbTVk-L7gNHfA";
                sinNewsArr[5].picUrl = "http://weixin.luqinwenda.com/images/sin5.png";

                sinNewsArr[6] = new RepliedMessage.news();
                sinNewsArr[6].title = "大开眼界，文明小使者感受新加坡”冬令营-精彩瞬间。";
                sinNewsArr[6].description = "当地球已以一个村庄的形态出现之时，面对未来，面对必然的世界公民，打开眼界，跨出国门，感受新异，已成为很多父母培养孩子的必须。因为他们深深知道，眼界决定未来，视野开启航向！";
                sinNewsArr[6].url = "https://mp.weixin.qq.com/s/n3noplufiw3ne5ejhpfovA";
                sinNewsArr[6].picUrl = "http://weixin.luqinwenda.com/images/sin6.png";

                sinNewsArr[7] = new RepliedMessage.news();
                sinNewsArr[7].title = "大开眼界，文明小使者感受新加坡”冬令营——精彩回顾。";
                sinNewsArr[7].description = "当地球已以一个村庄的形态出现之时，面对未来，面对必然的世界公民，打开眼界，跨出国门，感受新异，已成为很多父母培养孩子的必须。因为他们深深知道，眼界决定未来，视野开启航向！";
                sinNewsArr[7].url = "https://mp.weixin.qq.com/s/rqUhJi_UYAeEhGCtzRpYGA";
                sinNewsArr[7].picUrl = "http://weixin.luqinwenda.com/images/sin7.png";

                repliedMessage.newsContent = sinNewsArr;

                break;
            case "演讲":

                RepliedMessage.news speechNewsSingle = new RepliedMessage.news();
                speechNewsSingle.title = "“少年演说家”潜能开发营（香港/深圳）寒假营火热报名中！";
                speechNewsSingle.description = "家庭教育专家为家长分享最实用的育儿干货。著名家庭教育专家卢勤老师《爱孩子的八种方法》、中国正面管教协会主委会成员郑淑丽老师《如何与孩子有效沟通》等多堂精品家庭教育课程，家长学做智慧父母，为孩子成长助力！";
                speechNewsSingle.url = "https://mp.weixin.qq.com/s/qafnrLQlRO93EmbKQ544Ww";
                speechNewsSingle.picUrl = "http://weixin.luqinwenda.com/images/speech.jpg";

                repliedMessage.newsContent = new RepliedMessage.news[] { speechNewsSingle };

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
                repliedMessage.newsContent = new RepliedMessage.news[] { singaporeNews, speechNews };

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
            case "a":
            case "b":
            case "w":
                
                string replyContentW = receivedMessage.content.Trim();
                int groupIdW = int.Parse(replyContentW.Remove(0, 1));
                GroupMaster groupMasterW = new GroupMaster(groupIdW);
                bool hadVoted = groupMasterW.HadVoted(receivedMessage.from);

                string messageWVote = "";

                
                string messageWUnVote = "";

                if (!hadVoted)
                    groupMasterW.AddVote(receivedMessage.from, receivedMessage.id.Trim());

                string url = "";
                string imageUrl = "";
                groupMasterW = new GroupMaster(groupIdW);
                switch (command.ToLower())
                {
                    case "a":
                        messageWVote = "支持成功！目前" + receivedMessage.content.Trim() + "的支持票数为" + groupMasterW.VoteNumber.ToString() + "。满300票之即可申请成为转播群，50个名额先到先得。";
                        messageWUnVote = "您已投过支持票，不能重复支持！目前" + replyContentW + "的支持票数为" + groupMasterW.VoteNumber.ToString() + "。满300票之即可申请成为转播群，50个名额先到先得。";
                        url = "http://game.luqinwenda.com/weiketang/GroupJoin.aspx?id=";
                        imageUrl = "http://game.luqinwenda.com/images/groupjoinBanner.jpg";
                        break;
                    case "b":
                        messageWVote = "支持成功！目前" + receivedMessage.content.Trim() + "的支持票数为" + groupMasterW.VoteNumber.ToString() + "。满10票就可以申请加入卢勤微课群。";
                        messageWUnVote = "您已投过支持票，不能重复支持！目前" + replyContentW + "的支持票数为" + groupMasterW.VoteNumber.ToString() + "。满10票就可以申请加入卢勤微课群。";
                        url = "http://game.luqinwenda.com/weiketang/PersonalJoin.aspx?id=";
                        imageUrl = "http://game.luqinwenda.com/images/personaljoinBanner.jpg";
                        break;
                    default:
                        messageWVote = "支持成功！目前" + receivedMessage.content.Trim() + "的支持票数为" + groupMasterW.VoteNumber.ToString() + "。满300票之即可申请成为转播群，50个名额先到先得。";
                        messageWUnVote = "您已投过支持票，不能重复支持！目前" + replyContentW + "的支持票数为" + groupMasterW.VoteNumber.ToString() + "。满300票之即可申请成为转播群，50个名额先到先得。";
                        url = "http://game.luqinwenda.com/weiketang/GroupJoin.aspx?id=";
                        imageUrl = "http://game.luqinwenda.com/images/groupjoinBanner.jpg";
                        break;
                }

                url = url + groupIdW.ToString() + "&code=" + receivedMessage.content.Trim().ToLower();


                RepliedMessage texGroupMastertMessageW = new RepliedMessage();
                texGroupMastertMessageW.type = "text";

                if (hadVoted)
                {
                    //throw new Exception("1"+messageWUnVote);
                    texGroupMastertMessageW.content = messageWUnVote;
                }
                else
                {
                    //throw new Exception("2" + messageWVote);
                    texGroupMastertMessageW.content = messageWVote;
                }

                

                texGroupMastertMessageW.from = receivedMessage.to;
                texGroupMastertMessageW.to = receivedMessage.from;
                //texGroupMastertMessageW.SendAsServiceMessage();

                repliedMessage = texGroupMastertMessageW;


                /*
                repliedMessage.type = "news";
                RepliedMessage.news inviteMessageW = new RepliedMessage.news();
                inviteMessageW.title = "微课邀请函";
                inviteMessageW.picUrl = imageUrl;
                inviteMessageW.description = "微课邀请函";
                inviteMessageW.url = url.Trim();
                repliedMessage.newsContent = new RepliedMessage.news[] { inviteMessageW };
                */
                break;
            case "4":
                /*
                GroupMaster groupMaster = GroupMaster.CreateNew(repliedMessage.to.Trim());
                string randGroupCode = "K"+groupMaster.ID.ToString().PadLeft(4,'0');
                //repliedMessage.type = "text";
                //repliedMessage.content = "把邀请码【" + randGroupCode + "】发放到群里，让群成员关注“卢勤问答平台”，并在输入框里输入邀请码【" + randGroupCode + "】，点击弹出的文章里面的同意。当同意人数超过300人，请将同意人数截图给平台小助手，然后由平台小助手安排授课。";

                RepliedMessage texGroupMastertMessage = new RepliedMessage();
                texGroupMastertMessage.type = "text";
                texGroupMastertMessage.content = "把邀请码【" + randGroupCode + "】发放到群里，让群成员关注“卢勤问答平台”，并在输入框里输入邀请码【" + randGroupCode + "】，点击弹出的文章里面的支持。当支持人数超过300人，请将支持人数截图给平台小助手，然后由平台小助手安排授课。";
                texGroupMastertMessage.from = receivedMessage.to;
                texGroupMastertMessage.to = receivedMessage.from;
                texGroupMastertMessage.SendAsServiceMessage();
                //string tokenGroupMaster = Util.GetToken();
                //string filePathNameGroupMaster = System.Configuration.ConfigurationSettings.AppSettings["qrcode_path"].Trim() + "\\qrcode_dingyue.jpg";

                string mediaIdGroupMaster = "Ik-fUq6f9E8oyjmTajypkgxfiTAcFj9maXKtMf51iO0ZThpxYYEQyzcWn2oe66FV";
                repliedMessage.type = "image";
                repliedMessage.content = mediaIdGroupMaster;
                */
                break;
            case "k":
                
                string replyContent = receivedMessage.content.Trim();
                int groupId = int.Parse(replyContent.Remove(0, 1));
                GroupMaster groupMasterK = new GroupMaster(groupId);
                
                groupMasterK.AddVote(receivedMessage.from, receivedMessage.id.Trim());
       
                repliedMessage.type = "news";
                RepliedMessage.news inviteMessage = new RepliedMessage.news();
                inviteMessage.title = "微课邀请函";
                inviteMessage.picUrl = "http://game.luqinwenda.com/images/wkt_invite.jpg";
                inviteMessage.description = "微课邀请函";
                inviteMessage.url = "http://game.luqinwenda.com/weiketang/kaike.aspx?id=" + groupId.ToString();
                repliedMessage.newsContent = new RepliedMessage.news[] { inviteMessage };
               
                break;
                /*
            case "戒尺":
                repliedMessage.type = "news";
                RepliedMessage.news jieChi1 = new RepliedMessage.news();
                jieChi1.title = "【微课堂】回顾：教育，不能完全放下“戒尺”（上）";
                jieChi1.picUrl = "http://weixin.luqinwenda.com/images/jiechi.jpg";
                jieChi1.description = "【微课堂】回顾：教育，不能完全放下“戒尺”（上）";
                jieChi1.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=402196345&idx=2&sn=cbcc1514927fcef28df6cada167f3d70&scene=1&srcid=1210HPxeIfav3FTYsvIBXkS2#wechat_redirect";
                RepliedMessage.news jieChi2 = new RepliedMessage.news();
                jieChi2.title = "【微课堂】回顾：教育，不能完全放下“戒尺”（下）";
                jieChi2.picUrl = "http://weixin.luqinwenda.com/images/jiechi.jpg";
                jieChi2.description = "【微课堂】回顾：教育，不能完全放下“戒尺”（下）";
                jieChi2.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=402196345&idx=3&sn=ce62e3a0b564541a5993f8a707236b9c&scene=1&srcid=1210mGOhZbtGnzG9JBtSFhuf#wechat_redirect";
                
                repliedMessage.newsContent = new RepliedMessage.news[] { jieChi1, jieChi2};
                break;*/
            case "分工":
                repliedMessage.type = "news";
                RepliedMessage.news fenGong = new RepliedMessage.news();
                fenGong.title = "【卢勤微课堂】99%家长在犯错，家庭教育中夫妻如何分工";
                fenGong.picUrl = "http://weixin.luqinwenda.com/images/fengong.jpg";
                fenGong.description = "【卢勤微课堂】99%家长在犯错，家庭教育中夫妻如何分工";
                fenGong.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=401925682&idx=2&sn=a927a70a459ba926708d5a51eb53b501&scene=1&srcid=1210sO097zRyvsmkJoQYwpum&from=singlemessage&isappinstalled=0#wechat_redirect";
                repliedMessage.newsContent = new RepliedMessage.news[] { fenGong };
                break;
                /*
            case "信心":
            case "自信":
            case "元旦":
                RepliedMessage.news newYearMessage = new RepliedMessage.news();
                newYearMessage.title = "卢勤老师祝您2016年元旦快乐";
                newYearMessage.picUrl = "https://mmbiz.qlogo.cn/mmbiz/2x9sALwpIbXX0Xp6yLq049EJX5aZLDnIpJHQU103t55Y3ed1dy0Fvsa0AWUk9FIfR4HzL9g4XRDR0nfbhPYABw/0?wx_fmt=jpeg";
                newYearMessage.description = "卢勤老师祝您2016年元旦快乐";
                newYearMessage.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=403132220&idx=1&sn=ef57a87e2f9baa9c0a68aec7901d42e7#rd";

                RepliedMessage.news xinXinMessage1 = new RepliedMessage.news();
                xinXinMessage1.title = "【微课堂】回顾：自信，让孩子喊出“我能行”1231（上）";
                xinXinMessage1.description = "【微课堂】回顾：自信，让孩子喊出“我能行”1231（上）";
                xinXinMessage1.picUrl = "https://mmbiz.qlogo.cn/mmbiz/2x9sALwpIbXX0Xp6yLq049EJX5aZLDnISTsL2hSwAGQFFdABqvxuzwpZUNxXGKtZmFLxTEAdxQ2J0LfPKbeUZg/0?wx_fmt=jpeg";
                xinXinMessage1.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=403132220&idx=2&sn=3c90d24dbc06513fe83cea413a6eece9#rd";

                RepliedMessage.news xinXinMessage2 = new RepliedMessage.news();
                xinXinMessage2.title = "【微课堂】回顾：自信，让孩子喊出“我能行”1231（中）";
                xinXinMessage2.description = "【微课堂】回顾：自信，让孩子喊出“我能行”1231（中）";
                xinXinMessage2.picUrl = "https://mmbiz.qlogo.cn/mmbiz/2x9sALwpIbXX0Xp6yLq049EJX5aZLDnISTsL2hSwAGQFFdABqvxuzwpZUNxXGKtZmFLxTEAdxQ2J0LfPKbeUZg/0?wx_fmt=jpeg";
                xinXinMessage2.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=403132220&idx=3&sn=87b460db5bb5f1db61740dbfac8b378c#rd";

                RepliedMessage.news xinXinMessage3 = new RepliedMessage.news();
                xinXinMessage3.title = "【微课堂】回顾：自信，让孩子喊出“我能行”1231（下）";
                xinXinMessage3.description = "【微课堂】回顾：自信，让孩子喊出“我能行”1231（下）";
                xinXinMessage3.picUrl = "https://mmbiz.qlogo.cn/mmbiz/2x9sALwpIbXX0Xp6yLq049EJX5aZLDnISTsL2hSwAGQFFdABqvxuzwpZUNxXGKtZmFLxTEAdxQ2J0LfPKbeUZg/0?wx_fmt=jpeg";
                xinXinMessage3.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=403132220&idx=4&sn=31fcd85d06a342215ae8b1c437f71df2#rd";


                repliedMessage.type = "news";

                repliedMessage.newsContent = new RepliedMessage.news[] { newYearMessage, xinXinMessage1, xinXinMessage2, xinXinMessage3 };

                break;
                 */ 
	    case "杨澜":
            case "天下女人":
            case "读书卡":
            case "礼物":
            case "抽奖":
            //case "中国教育报":
                //repliedMessage.type = "text";
                //repliedMessage.content = "我们的抽奖活动已经结束。";
                

                DateTime startTime = DateTime.Parse("2016-11-3 20:30");
                DateTime endTime = DateTime.Parse("2016-11-4 12:00");

                if (startTime < DateTime.Now && DateTime.Now < endTime)
                {
                    int actId = 10;
                    int drawId = Drawing.DrawingPlay(receivedMessage.from.Trim(), actId);
                    repliedMessage.type = "news";
                    RepliedMessage.news drawing = new RepliedMessage.news();
                    drawing.title = "请领取悦长大书城读书卡";
                    drawing.picUrl = "http://game.luqinwenda.com/images/draw_banner.jpg?yuezhangda";
                    drawing.url = "http://game.luqinwenda.com/weiketang/LuckDraw.aspx?id=" + drawId.ToString() + "&openid=" + receivedMessage.from.Trim();
                    drawing.description = "为答谢广大家长对“悦长大微课堂”的厚爱和大力支持，卢勤老师邀您参加书城读书活动！请领取您的专属读书卡！多读书，读好书，让您的孩子发现读书的乐趣！";
                    repliedMessage.newsContent = new RepliedMessage.news[] { drawing };
                }
                break;
                /*
            case "平安":
                repliedMessage.type = "news";
                RepliedMessage.news pingAn1 = new RepliedMessage.news();
                pingAn1.title = "【微课堂】回顾：给孩子一个平安的世界1214（上）";
                pingAn1.picUrl = "http://mmbiz.qpic.cn/mmbiz/2x9sALwpIbWt1X6wuZof9Jd4dHFUpKFgjn7K2MONpyUFVtexJGWibPSCCQkJSSiczo1D1ffWGq9ibjhT3bKhxyRwQ/640?wx_fmt=jpeg&wxfrom=5&wx_lazy=1";
                pingAn1.description = "【微课堂】回顾：给孩子一个平安的世界1214（上）";
                pingAn1.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=402385605&idx=2&sn=12e96dc35ccd970ffe383f113d083c1e&scene=0#wechat_redirect";
                
                RepliedMessage.news pingAn2 = new RepliedMessage.news();
                pingAn2.title = "【微课堂】回顾：给孩子一个平安的世界1214（下）";
                pingAn2.picUrl = "https://mmbiz.qlogo.cn/mmbiz/2x9sALwpIbUN9L0g5RkVhwO3KJT4KurpchXibibNIbVvYPM4p889ib2nyYAnDlxBVIGgeWQGl9GyGcaiaPNSK3gw4A/0?wx_fmt=jpeg";
                pingAn2.description = "【微课堂】回顾：给孩子一个平安的世界1214（下）";
                pingAn2.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=402385605&idx=3&sn=0c2a998ad65c4b07585b47edfce56241&scene=0#wechat_redirect";


                repliedMessage.newsContent = new RepliedMessage.news[] { pingAn1, pingAn2  };
                break;
            case "孝心":
                repliedMessage.type = "news";

                RepliedMessage.news xiaoXin1 = new RepliedMessage.news();
                xiaoXin1.title = "【微课堂】回顾：孝心，凝聚家人的力量1222（上）";
                xiaoXin1.description = "【微课堂】回顾：孝心，凝聚家人的力量1222（上）";
                xiaoXin1.picUrl = "http://mmbiz.qpic.cn/mmbiz/2x9sALwpIbUecibmIiaXmCwZQQflfdRxXkFBY5pccvRomKnVFNFJ5pL4HjvBOpgPIsdzwGkJ0WicibZOfRlNQbIhxQ/640?wx_fmt=jpeg&wxfrom=5&wx_lazy=1";
                xiaoXin1.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=402823939&idx=2&sn=1fc919e1a4974cb4e7c1e212e83868f8#rd";

                RepliedMessage.news xiaoXin2 = new RepliedMessage.news();

                xiaoXin2.title = "【微课堂】回顾：孝心，凝聚家人的力量1222（下）";
                xiaoXin2.description = "【微课堂】回顾：孝心，凝聚家人的力量1222（下）";
                xiaoXin2.picUrl = "http://mmbiz.qpic.cn/mmbiz/2x9sALwpIbUecibmIiaXmCwZQQflfdRxXkFBY5pccvRomKnVFNFJ5pL4HjvBOpgPIsdzwGkJ0WicibZOfRlNQbIhxQ/640?wx_fmt=jpeg&wxfrom=5&wx_lazy=1";
                xiaoXin2.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=402823939&idx=3&sn=f42075b18dc9ff3a9da22a797aadf441#rd";

                repliedMessage.newsContent = new RepliedMessage.news[] { xiaoXin1, xiaoXin2 };

                break;
                 */ 
                /*
            case "真爱":
                RepliedMessage.news zhenAi1 = new RepliedMessage.news();
                zhenAi1.title = "【微课堂】回顾：给孩子一个真爱的世界0112（上）";
                zhenAi1.description = "【微课堂】回顾：给孩子一个真爱的世界0112（上）";
                zhenAi1.picUrl = "https://mmbiz.qlogo.cn/mmbiz/2x9sALwpIbUx1XnOMDXSuT7wUJkicRLQTWnqnKaCyMlBsKoR0CicaNMIbUtRKDIfLHYQF0LsIwohT0UJW8jJ0uQg/0?wx_fmt=jpeg";
                zhenAi1.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=403415400&idx=3&sn=6fddcdeb3dc615421f779930ea28b7a2#rd";

                RepliedMessage.news zhenAi2 = new RepliedMessage.news();
                zhenAi2.title = "【微课堂】回顾：给孩子一个真爱的世界0112（下）";
                zhenAi2.description = "【微课堂】回顾：给孩子一个真爱的世界0112（下）";
                zhenAi2.picUrl = "https://mmbiz.qlogo.cn/mmbiz/2x9sALwpIbUx1XnOMDXSuT7wUJkicRLQTWnqnKaCyMlBsKoR0CicaNMIbUtRKDIfLHYQF0LsIwohT0UJW8jJ0uQg/0?wx_fmt=jpeg";
                zhenAi2.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=403415400&idx=4&sn=846efb13d1f95ca3a5631e9514c01362#rd";

                repliedMessage.newsContent = new RepliedMessage.news[] { zhenAi1, zhenAi2 };

                break;
                 */ 
            case "人才":
                RepliedMessage.news renCai = new RepliedMessage.news();
                renCai.title = "【微课堂】回顾：贺淑曼-站在人才的高度务教育0304";
                renCai.description = "【微课堂】回顾：贺淑曼-站在人才的高度务教育0304";
                renCai.picUrl = "http://mmbiz.qpic.cn/mmbiz/2x9sALwpIbUKMZiciaficqqibia6hcdXl9oQ8p9g2D6LeIX1MZ29agib7DJ5f0rhESNCBMuuTH4qL0ObGSE6hiasZEZhg/640?wx_fmt=jpeg&wxfrom=5&wx_lazy=1";
                renCai.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=404944624&idx=1&sn=f8818dc2a96761f08100af2b3160b5f8#rd";
                repliedMessage.type = "news";
                repliedMessage.newsContent = new RepliedMessage.news[] { renCai };
                break;
            case "目标":
                RepliedMessage.news target = new RepliedMessage.news();
                target.title = "【微课堂】回顾：卢勤-心灵的成长需要目标0308";
                target.description = "【微课堂】回顾：卢勤-心灵的成长需要目标0308";
                target.picUrl = "http://mmbiz.qpic.cn/mmbiz/2x9sALwpIbXfdrbCVI3MGfMmtwwk1aGIWy4nHsp5mLPcqCa99IdLwfGcDRVPGv8Y4ibpakk6R6geiby5nXqLt1UQ/640?wx_fmt=jpeg&wxfrom=5&wx_lazy=1";
                target.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=405127063&idx=1&sn=2a63a852b07a563176f251261e4c1123#rd";
                repliedMessage.type = "news";
                repliedMessage.newsContent = new RepliedMessage.news[] { target };
                break;
            case "营养国":
            case "中国教育报":
     
            
            //case "中国教育报":
                GroupMaster groupMasterWeikeTang = GroupMaster.CreateNew(repliedMessage.to.Trim());
                string randGroupCodeWeikeTang = "B" + groupMasterWeikeTang.ID.ToString().PadLeft(6, '0');

                RepliedMessage texGroupMastertMessageWeikeTang = new RepliedMessage();
                texGroupMastertMessageWeikeTang.type = "text";
                texGroupMastertMessageWeikeTang.content = "您的邀请码是【" + randGroupCodeWeikeTang + "】把下面的页面转发到100人以上的微信群或者您的朋友圈，让您的朋友在“卢勤问答平台”公众号中，回复您的邀请码【"
                    + randGroupCodeWeikeTang + "】即可获得支持票。支持人数超过10人，可申请加入听课群。达到数量后请将支持人数截图给平台小助手，然后由平台小助手安排加群。";
                texGroupMastertMessageWeikeTang.from = receivedMessage.to;
                texGroupMastertMessageWeikeTang.to = receivedMessage.from;
                texGroupMastertMessageWeikeTang.SendAsServiceMessage();

                //string token = Util.GetToken();
                //string filePathNameWeike = System.Configuration.ConfigurationSettings.AppSettings["qrcode_path"].Trim() + "\\xiaozhushou.jpg";

                if (qrXiaozhushouMediaId.Trim().Equals(""))
                {
                    qrXiaozhushouMediaId = Util.UploadImageToWeixin(@"D:\webs\weixin.luqinwenda.com\dingyue\images\xiaozhushou.jpg", Util.GetToken());
                }


                try
                {
                    string mediaIdWeikeTang = qrXiaozhushouMediaId;
                    RepliedMessage xiaoZhuShouQrcodeReplymessageTang = new RepliedMessage();
                    xiaoZhuShouQrcodeReplymessageTang.type = "image";
                    xiaoZhuShouQrcodeReplymessageTang.mediaId = mediaIdWeikeTang;
                    xiaoZhuShouQrcodeReplymessageTang.from = receivedMessage.to;
                    xiaoZhuShouQrcodeReplymessageTang.to = receivedMessage.from;
                    xiaoZhuShouQrcodeReplymessageTang.SendAsServiceMessage();
                }
                catch
                {
                    qrXiaozhushouMediaId = Util.UploadImageToWeixin(@"D:\webs\weixin.luqinwenda.com\dingyue\images\xiaozhushou.jpg", Util.GetToken());
                    string mediaIdWeikeTang = qrXiaozhushouMediaId;
                    RepliedMessage xiaoZhuShouQrcodeReplymessageTang = new RepliedMessage();
                    xiaoZhuShouQrcodeReplymessageTang.type = "image";
                    xiaoZhuShouQrcodeReplymessageTang.mediaId = mediaIdWeikeTang;
                    xiaoZhuShouQrcodeReplymessageTang.from = receivedMessage.to;
                    xiaoZhuShouQrcodeReplymessageTang.to = receivedMessage.from;
                    xiaoZhuShouQrcodeReplymessageTang.SendAsServiceMessage();

                }
                System.Threading.Thread.Sleep(500);

                repliedMessage.type = "news";
                RepliedMessage.news inviteMessageWKTang = new RepliedMessage.news();
                inviteMessageWKTang.title = "微课邀请函";
                inviteMessageWKTang.picUrl = "http://game.luqinwenda.com/images/personaljoinBanner.jpg";
                inviteMessageWKTang.description = "微课邀请函";
                inviteMessageWKTang.url = "http://game.luqinwenda.com/weiketang/PersonalJoin.aspx?id="
                    + groupMasterWeikeTang.ID.ToString() + "&code=" + randGroupCodeWeikeTang;
                repliedMessage.newsContent = new RepliedMessage.news[] { inviteMessageWKTang };


                break;
/*
            case "申请转播群":

                GroupMaster groupMasterWeike = GroupMaster.CreateNew(repliedMessage.to.Trim(),1);
                string randGroupCodeWeike = "A" + groupMasterWeike.ID.ToString().PadLeft(6, '0');

                RepliedMessage texGroupMastertMessageWeike = new RepliedMessage();
                texGroupMastertMessageWeike.type = "text";
                texGroupMastertMessageWeike.content = "您的申请码是【" + randGroupCodeWeike + "】，把以下页面发放到群里或转发朋友圈，请您的朋友在“卢勤问答平台”公众号中，回复您的申请码【" + randGroupCodeWeike + "】即可获得支持票。得票数满300个支持的群主，请将截图发送给平台旭老师（详见下方二维码），即可获得合作转播群资格。";
                texGroupMastertMessageWeike.from = receivedMessage.to;
                texGroupMastertMessageWeike.to = receivedMessage.from;
                texGroupMastertMessageWeike.SendAsServiceMessage();

                //string token = Util.GetToken();
                //string filePathNameWeike = System.Configuration.ConfigurationSettings.AppSettings["qrcode_path"].Trim() + "\\xiaozhushou.jpg";
                try
                {
                    string mediaIdWeike = "kwiALQLMgF4AyJ4GkenGXJYnP9ZCviumOKvqoO6f20t950ovC1ClA6CRZytyLGan";
                    RepliedMessage xiaoZhuShouQrcodeReplymessage = new RepliedMessage();
                    xiaoZhuShouQrcodeReplymessage.type = "image";
                    xiaoZhuShouQrcodeReplymessage.mediaId = mediaIdWeike;
                    xiaoZhuShouQrcodeReplymessage.from = receivedMessage.to;
                    xiaoZhuShouQrcodeReplymessage.to = receivedMessage.from;
                    xiaoZhuShouQrcodeReplymessage.SendAsServiceMessage();
                }
                catch
                { 
                
                }
                System.Threading.Thread.Sleep(500);
                
                repliedMessage.type = "news";
                RepliedMessage.news inviteMessageWK = new RepliedMessage.news();
                inviteMessageWK.title = "微课邀请函";
                inviteMessageWK.picUrl = "http://game.luqinwenda.com/images/groupjoinBanner.jpg";
                inviteMessageWK.description = "微课邀请函";
                inviteMessageWK.url = "http://game.luqinwenda.com/weiketang/GroupJoin.aspx?id=" + groupMasterWeike.ID.ToString()
                    + "&code=" + randGroupCodeWeike;
                repliedMessage.newsContent = new RepliedMessage.news[] { inviteMessageWK };


                break;
 */ 
            case "g":
                string replyGameContent = receivedMessage.content.Trim();
                int gameId = int.Parse(replyGameContent.Trim().Remove(0,1));
                NewYearBox newYearBox = new NewYearBox(gameId);
                bool ret = newYearBox.Support(receivedMessage.from.Trim(), "reply");
                string replyWord = "";
                if (ret)
                {
                    replyWord = "感谢您为您朋友新年礼盒的开启提供了一份帮助。";
                }
                else
                {
                    replyWord = "您已经帮助过您的朋友了，再次感谢！";
                }
                repliedMessage.type = "text";
                repliedMessage.content = replyWord.Trim();
                break;
            case "创造力":
                RepliedMessage.news createMessage1 = new RepliedMessage.news();
                createMessage1.picUrl = "http://mmbiz.qpic.cn/mmbiz/2x9sALwpIbVicgKQUbubAibd9l2ic2P1K9InTjHeiaRBicgjLCkhs04fic6XCibl4XK95oBlq0ibRLAClREl7Ak5ruPmQg/640?wx_fmt=jpeg&wxfrom=5&wx_lazy=1";
                createMessage1.title = "【微课堂】回顾：点燃孩子的创造力0121（程淮老师）";
                createMessage1.description = "【微课堂】回顾：点燃孩子的创造力0121（程淮老师）";
                createMessage1.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=403626135&idx=2&sn=0b8e5f4b7ed076cb6f13f8b2e830cafa#rd";
                RepliedMessage.news createMessage2 = new RepliedMessage.news();
                createMessage2.picUrl = "http://weixin.luqinwenda.com/dingyue/images/weike_review.jpg";
                createMessage2.title = "【微课堂】回顾：点燃孩子的创造力0121（卢勤老师）";
                createMessage2.description = "【微课堂】回顾：点燃孩子的创造力0121（卢勤老师）";
                createMessage2.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=403626135&idx=3&sn=714c8d76ef7991df7712c03433694146#rd";
                repliedMessage.newsContent = new RepliedMessage.news[] { createMessage1, createMessage2 };
                break;
            case "未来你好":

                repliedMessage.type = "text";
                repliedMessage.content = "http://weixin.luqinwenda.com/dingyue/pages/go_to_classroom.aspx?dingyue_openid=" + receivedMessage.from;


                break;
/*
            case "微课":
            case "上课":

            case "微客":
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
                break;
*/
            case "我要报名":
            case "报名":
            case "报名参加":
            case "我要参加":
                string qrXuMediaIdYaoqing = Util.UploadImageToWeixin(System.Configuration.ConfigurationSettings.AppSettings["qrcode_path"].Trim()
                       + "\\qr_xiaozhushou.jpg", Util.GetToken());

                RepliedMessage imageMessageYaoqing = new RepliedMessage();
                imageMessageYaoqing.from = receivedMessage.to;
                imageMessageYaoqing.to = receivedMessage.from;
                imageMessageYaoqing.type = "image";
                imageMessageYaoqing.mediaId = qrXuMediaIdYaoqing.Trim();
                imageMessageYaoqing.SendAsServiceMessage();
                repliedMessage.type = "text";
                repliedMessage.content = "为确保最有需要的家长前来听课，请转发<a href=\"http://mp.weixin.qq.com/s/9comEfTUYMX2rfpQjDqKpg\" >本期【悦长大微课堂】图文消息（戳此链接进入）</a>到朋友圈，并带上“报名参加”等评论，截图后发给小助手（luqinwenda001），小助手将拉您进入听课群，谢谢！";

                break;
            case "合作":
            case "转播":
            case "合作转播":
            case "商务合作":
                string qrXuMediaId = Util.UploadImageToWeixin(System.Configuration.ConfigurationSettings.AppSettings["qrcode_path"].Trim()
                    + "\\qr_xu.jpg", Util.GetToken());

                RepliedMessage textMessage = new RepliedMessage();
                textMessage.from = receivedMessage.to;
                textMessage.to = receivedMessage.from;
                textMessage.type = "text";
                textMessage.content = "商务合作、课程转播等请联系悦长大平台旭老师，18511998488(电话/微信)。";
                textMessage.SendAsServiceMessage();

                System.Threading.Thread.Sleep(500);

                RepliedMessage imageMessage = new RepliedMessage();
                imageMessage.from = receivedMessage.to;
                imageMessage.to = receivedMessage.from;
                imageMessage.type = "image";
                imageMessage.mediaId = qrXuMediaId.Trim();
                imageMessage.SendAsServiceMessage();


                repliedMessage.type = "";
                repliedMessage.mediaId = qrXuMediaId;
                break;
            default:
                repliedMessage = BuildMessageByKeyword(repliedMessage, command.Trim());
		
                break;
        }
        return repliedMessage;
    }


    public static RepliedMessage BuildMessageByKeyword(RepliedMessage message, string keyword)
    {
        DataTable dtAllMessages = DBHelper.GetDataTable(" select * from weixin_reply_message order by sort , [id]  ", Util.conStr);
        DataTable dtReadyToBuild = dtAllMessages.Clone();

        foreach (DataRow drAllMessages in dtAllMessages.Rows)
        {
            string[] keyWordsArray = drAllMessages["keywords"].ToString().Trim().Split(',');
            bool keyWordIsMatch = false;
            foreach (string keywordToBeMatch in keyWordsArray)
            { 
                if (keywordToBeMatch.Trim().Equals(keyword))
                {
                    keyWordIsMatch = true;
                    break;
                }
            }
            if (keyWordIsMatch)
            {
                DataRow drReadyToBuild = dtReadyToBuild.NewRow();
                foreach(DataColumn c in dtReadyToBuild.Columns)
                {
                    drReadyToBuild[c] = drAllMessages[c.Caption.Trim()];
                }
                dtReadyToBuild.Rows.Add(drReadyToBuild);
            }
        }

        if (dtReadyToBuild.Rows.Count == 1)
        {
            message.type = dtReadyToBuild.Rows[0]["type"].ToString();
        }
        else
        {
	    if (dtReadyToBuild.Rows.Count != 0)
	    {
	    	message.type = "news";
	    }	    
                
        }

        switch (message.type.Trim())
        { 
            case "news":
                RepliedMessage.news[] newsArray = new RepliedMessage.news[dtReadyToBuild.Rows.Count];
                for (int i = 0; i < dtReadyToBuild.Rows.Count; i++)
                {
                    newsArray[i] = new RepliedMessage.news();
                    newsArray[i].title = dtReadyToBuild.Rows[i]["title"].ToString().Trim();
                    newsArray[i].description = dtReadyToBuild.Rows[i]["memo"].ToString().Trim();
                    newsArray[i].picUrl = dtReadyToBuild.Rows[i]["image_url"].ToString().Trim();
                    newsArray[i].url = dtReadyToBuild.Rows[i]["target_url"].ToString().Trim();

                }
                message.newsContent = newsArray;
                break;
	    default:
		break;
        }


        return message;
    
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