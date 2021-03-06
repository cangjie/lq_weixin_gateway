﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        switch (receivedMessage.eventKey.Trim())
        {
            case "BAOMING":
                repliedMessage.content = Util.GetMenuBaomingHit();
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
                repliedMessage.messageCount = 5;
                repliedMessage.type = "news";
                break;
            case "IMAGE":
                repliedMessage.content = Util.Get2014SummerCampImageForWexinNews();
                repliedMessage.messageCount = 4;
                repliedMessage.type = "news";
                break;
            case "FANGTAN":
                RepliedMessage.news newsContent = new RepliedMessage.news();
                newsContent.picUrl = "http://weixin.luqinwenda.com/images/jianmianhui.jpeg";
                newsContent.url = "http://www.luqinwenda.com/index.php?app=public&mod=MobileNew&act=interviewlist&openid="
                    + receivedMessage.from.Trim();
                newsContent.title = "卢勤问答微信见面会";
                newsContent.description = "你在孩子的成长过程中有什么困惑吗？你与孩子沟通顺利吗？你有什么烦恼想要倾诉吗？你可以在这里随意提问，卢勤老师将倾听你的声音，为你答疑解惑。";

                repliedMessage.newsContent = new RepliedMessage.news[] { newsContent };

                //repliedMessage.messageCount = 1;
                //repliedMessage.type = "news";
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
        return repliedMessage;
    }

    public static RepliedMessage DealUserInputMessage(ReceivedMessage receivedMessage)
    {
        RepliedMessage repliedMessage = new RepliedMessage();
        repliedMessage.from = receivedMessage.to;
        repliedMessage.to = receivedMessage.from;
        repliedMessage.rootId = receivedMessage.id;
        switch (receivedMessage.content.Trim().ToLower())
        { 
            case "二维码":
                repliedMessage = CreateQrCodeReplyMessage(receivedMessage, repliedMessage);
                break;
            case "送书":
                repliedMessage.type = "text";
                repliedMessage.content = "感谢您的热情参与，本次活动已经结束，<a href=\"http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=204410162&idx=1&sn=146c47966688ae22cf760d0cbd22faa3&scene=1&key=0ce8fa93c80e41c5b00c430ca64638d8f3dcbe64f24950abca2480c8ae85a44b56641fa7288d01b8fc6f18515264f57a&ascene=0&uin=ODk3MzEzNzY0&devicetype=iMac+MacBookAir6%2C2+OSX+OSX+10.10.2+build(14C109)&version=11020012&pass_ticket=gGeBx6EjjOmbm3rRWxQKTlS0K19Fjt%2F1mZ5XPVJWMrgvgTWG37A0ToJ5Dbyhv11k\" >点击此处</a>查看获奖名单。";
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
            default:
                break;
        }
        return repliedMessage;
    }

    public static RepliedMessage CreateQrCodeReplyMessage(ReceivedMessage receivedMessage, RepliedMessage repliedMessage)
    {
        string token = Util.GetToken();
        long scene = long.Parse(Util.GetInviteCode(receivedMessage.to.Trim()));
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