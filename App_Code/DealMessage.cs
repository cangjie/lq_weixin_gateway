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
                    newsArr[0].picUrl = "https://mmbiz.qlogo.cn/mmbiz/2x9sALwpIbUhS5ice0CpZZ6BpVIscFXDjwVSwvk59DJnSicLpB8WwTg5mhCgCYJbxHpS33lh1FAZFQ0XcsQrdFGA/0?wx_fmt=jpeg";
                    newsArr[0].title = "卢勤和她的朋友们微课堂";
                    newsArr[0].description = "卢勤和她的朋友们微课堂";
                    newsArr[0].url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=402860995&idx=1&sn=453d71462f565c127f775aa3b9951b14#rd";

                  
                    newsArr[1] = new RepliedMessage.news();
                    newsArr[1].picUrl = "https://mmbiz.qlogo.cn/mmbiz/2x9sALwpIbUhS5ice0CpZZ6BpVIscFXDjQ6zKJfYlNZEqaqsYCpngSNoJNkQaat5EGfribcXnUoEVibgAwdzxlT3w/0?wx_fmt=jpeg";
                    newsArr[1].title = "【卢勤和她的朋友们微课堂】精彩微课回顾";
                    newsArr[1].description = "【卢勤和她的朋友们微课堂】精彩微课回顾";
                    newsArr[1].url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=402860995&idx=2&sn=e280fe151147a4a27d0a377815427d9c#rd";
                    
                   
                    newsArr[2] = new RepliedMessage.news();
                    newsArr[2].picUrl = "https://mmbiz.qlogo.cn/mmbiz/2x9sALwpIbUhS5ice0CpZZ6BpVIscFXDjGrrPCb0wvCC21UbW9OCwFrHCMlyPx1dWSDDicIJLNGTTtw4z192A4XQ/0?wx_fmt=jpeg";
                    newsArr[2].title = "问答指南：如何向卢勤老师提问？";
                    newsArr[2].description = "问答指南：如何向卢勤老师提问？";
                    newsArr[2].url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=402860995&idx=3&sn=d76829cb64c7e1911d10abec2c0eb328#rd";

                    newsArr[3] = new RepliedMessage.news();
                    newsArr[3].picUrl = "https://mmbiz.qlogo.cn/mmbiz/2x9sALwpIbUhS5ice0CpZZ6BpVIscFXDjc6IOWSkyxFztUPgf6MPJsu6oIJaoeVZS5pNtLely7wXn23WvEdiaOIg/0?wx_fmt=jpeg";
                    newsArr[3].title = "【活动】“我要学演说” 少年口才培训火热征募中……";
                    newsArr[3].description = "【活动】“我要学演说” 少年口才培训火热征募中……";
                    newsArr[3].url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=402859079&idx=1&sn=2ef5a37e2857b5f9f17d384e2ad9df55#rd";


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
        if ((inputString.Trim().IndexOf("营") >= 0) || (inputString.Trim().IndexOf("演讲") >= 0)
            || (inputString.Trim().IndexOf("演说") >= 0) || (inputString.Trim().IndexOf("新加坡") >= 0)
            || (inputString.Trim().IndexOf("文明") >= 0))
        {
            command = "营";
        }

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
            case "微课":
                repliedMessage.type = "text";
                repliedMessage.content = "此活动已结束，请关注本公众号，即将推出的加群新规。";
                break;
            case "w":
                /*
                string replyContentW = receivedMessage.content.Trim();
                int groupIdW = int.Parse(replyContentW.Remove(0, 1));
                GroupMaster groupMasterW = new GroupMaster(groupIdW);
                if (GroupMaster.CanVote(receivedMessage.from))
                {
                    groupMasterW.AddVote(receivedMessage.from, receivedMessage.id.Trim());
                }

                groupMasterW = new GroupMaster(groupIdW);

                string messageWVote = "支持成功！目前" + receivedMessage.content.Trim() + "的支持票数为" + groupMasterW.VoteNumber.ToString() + "。满10票就可以申请加入卢勤微课群，满300票可以邀请卢勤公益微课堂在您的群（群里的人数需要超过300）中授课。回复“微课”查询申请加群的方法。";

                string messageWUnVote = "您已投过支持票，不能重复支持！目前" + replyContentW + "的支持票数为" + groupMasterW.VoteNumber.ToString() + "。满10票就可以申请加入卢勤微课群，满300票可以邀请卢勤公益微课堂在您的群（群里的人数需要超过300）中授课。回复“微课”查询申请加群的方法。";


                RepliedMessage texGroupMastertMessageW = new RepliedMessage();
                texGroupMastertMessageW.type = "text";
                if (groupMasterW.HadVoted(receivedMessage.from))
                    texGroupMastertMessageW.content = messageWUnVote;
                else
                    texGroupMastertMessageW.content = messageWVote;
                texGroupMastertMessageW.from = receivedMessage.to;
                texGroupMastertMessageW.to = receivedMessage.from;
                texGroupMastertMessageW.SendAsServiceMessage();




                repliedMessage.type = "news";
                RepliedMessage.news inviteMessageW = new RepliedMessage.news();
                inviteMessageW.title = "微课邀请函";
                inviteMessageW.picUrl = "http://game.luqinwenda.com/images/wkt_invite.jpg";
                inviteMessageW.description = "微课邀请函";
                inviteMessageW.url = "http://game.luqinwenda.com/weiketang/InviteGroup.aspx?id=" + groupIdW.ToString();
                repliedMessage.newsContent = new RepliedMessage.news[] { inviteMessageW };
                */
                break;
            case "4":
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

                break;
            case "k":
                /*
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
                 * */
                break;
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
                break;
            case "分工":
                repliedMessage.type = "news";
                RepliedMessage.news fenGong = new RepliedMessage.news();
                fenGong.title = "【卢勤微课堂】99%家长在犯错，家庭教育中夫妻如何分工";
                fenGong.picUrl = "http://weixin.luqinwenda.com/images/fengong.jpg";
                fenGong.description = "【卢勤微课堂】99%家长在犯错，家庭教育中夫妻如何分工";
                fenGong.url = "http://mp.weixin.qq.com/s?__biz=MzA3MTM1OTIwNg==&mid=401925682&idx=2&sn=a927a70a459ba926708d5a51eb53b501&scene=1&srcid=1210sO097zRyvsmkJoQYwpum&from=singlemessage&isappinstalled=0#wechat_redirect";
                repliedMessage.newsContent = new RepliedMessage.news[] { fenGong };
                break;
            case "抽奖" :
                DateTime startTime = DateTime.Parse("2015-12-22 20:30");
                DateTime endTime = DateTime.Parse("2015-12-23 23:59");
                if (startTime < DateTime.Now && DateTime.Now < endTime)
                {
                    int actId = 2;
                    int drawId = Drawing.DrawingPlay(receivedMessage.from.Trim(), actId);
                    repliedMessage.type = "news";
                    RepliedMessage.news drawing = new RepliedMessage.news();
                    drawing.title = "“卢勤微课堂”幸运抽奖活动";
                    drawing.picUrl = "http://game.luqinwenda.com/images/draw_banner.jpg";
                    drawing.url = "http://game.luqinwenda.com/weiketang/LuckDraw.aspx?id=" + drawId.ToString() + "&openid=" + receivedMessage.from.Trim();
                    drawing.description = "“卢勤微课堂”幸运抽奖活动";
                    repliedMessage.newsContent = new RepliedMessage.news[] { drawing };
                }
                break;
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