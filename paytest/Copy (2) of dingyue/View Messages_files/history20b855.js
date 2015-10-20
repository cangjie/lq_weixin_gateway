function saveLocation(e, t) {
if (e == "info") if (LS.get(biz + "_content")) {
var n = JSON.parse(LS.get(biz + "_content")).concat(t);
LS.set(biz + "_content", JSON.stringify(n));
} else LS.set(biz + "_content", JSON.stringify(t)); else e == "scroll" && (LS.set(biz + "_scroll", getScrollTop()), LS.set(biz + "_time", +(new Date)));
}

function getLocation() {
if (LS.get(biz + "_time")) if (+(new Date) - LS.get(biz + "_time") <= 18e5) {
if (LS.get(biz + "_content")) {
var e = JSON.parse(LS.get(biz + "_content")), t = template.render("list", {
list: e,
biz: biz,
uin: uin,
key: key
});
document.querySelector(".msg_page").innerHTML += t;
}
LS.get(biz + "_scroll") && window.scrollTo(0, LS.get(biz + "_scroll"));
} else LS.remove(biz + "_time"), LS.remove(biz + "_content"), LS.remove(biz + "_scroll"), window.scrollTo(0, 0); else LS.remove(biz + "_time"), LS.remove(biz + "_content"), LS.remove(biz + "_scroll"), window.scrollTo(0, 0);
}

function on_finish_play() {
removeClass(document.querySelector(".cur"), "cur");
}

function hasClass(e, t) {
return e ? e.className.match(new RegExp("(\\s|^)" + t + "(\\s|$)")) : !1;
}

function addClass(e, t) {
this.hasClass(e, t) || (e.className += " " + t);
}

function removeClass(e, t) {
if (hasClass(e, t)) {
var n = new RegExp("(\\s|^)" + t + "(\\s|$)");
e.className = e.className.replace(n, " ");
}
}

function toggleClass(e, t) {
hasClass(e, t) ? removeClass(e, t) : addClass(e, t);
}

function htmlDecode(e) {
return e.replace(/&#39;/g, "'").replace(/<br\s*(\/)?\s*>/g, "\n").replace(/&nbsp;/g, " ").replace(/&lt;/g, "<").replace(/&gt;/g, ">").replace(/&quot;/g, '"').replace(/&amp;/g, "&");
}

function replaceEmoji(e) {
var t = {
url: "http://res.mail.qq.com/zh_CN/images/mo/DEFAULT2/",
data: {
"0": "微笑",
"1": "撇嘴",
"2": "色",
"3": "发呆",
"4": "得意",
"5": "流泪",
"6": "害羞",
"7": "闭嘴",
"8": "睡",
"9": "大哭",
"10": "尴尬",
"11": "发怒",
"12": "调皮",
"13": "呲牙",
"14": "惊讶",
"15": "难过",
"16": "酷",
"17": "冷汗",
"18": "抓狂",
"19": "吐",
"20": "偷笑",
"21": "可爱",
"22": "白眼",
"23": "傲慢",
"24": "饥饿",
"25": "困",
"26": "惊恐",
"27": "流汗",
"28": "憨笑",
"29": "大兵",
"30": "奋斗",
"31": "咒骂",
"32": "疑问",
"33": "嘘",
"34": "晕",
"35": "折磨",
"36": "衰",
"37": "骷髅",
"38": "敲打",
"39": "再见",
"40": "擦汗",
"41": "抠鼻",
"42": "鼓掌",
"43": "糗大了",
"44": "坏笑",
"45": "左哼哼",
"46": "右哼哼",
"47": "哈欠",
"48": "鄙视",
"49": "委屈",
"50": "快哭了",
"51": "阴险",
"52": "亲亲",
"53": "吓",
"54": "可怜",
"55": "菜刀",
"56": "西瓜",
"57": "啤酒",
"58": "篮球",
"59": "乒乓",
"60": "咖啡",
"61": "饭",
"62": "猪头",
"63": "玫瑰",
"64": "凋谢",
"65": "示爱",
"66": "爱心",
"67": "心碎",
"68": "蛋糕",
"69": "闪电",
"70": "炸弹",
"71": "刀",
"72": "足球",
"73": "瓢虫",
"74": "便便",
"75": "月亮",
"76": "太阳",
"77": "礼物",
"78": "拥抱",
"79": "强",
"80": "弱",
"81": "握手",
"82": "胜利",
"83": "抱拳",
"84": "勾引",
"85": "拳头",
"86": "差劲",
"87": "爱你",
"88": "NO",
"89": "OK",
"90": "爱情",
"91": "飞吻",
"92": "跳跳",
"93": "发抖",
"94": "怄火",
"95": "转圈",
"96": "磕头",
"97": "回头",
"98": "跳绳",
"99": "挥手",
"100": "激动",
"101": "街舞",
"102": "献吻",
"103": "左太极",
"104": "右太极"
},
ext: ".gif"
}, n, r, i = t.url, s = t.ext, o = t.data;
for (n in o) r = new RegExp("/" + o[n], "g"), e = e.replace(r, '<img src="' + i + n + s + '" alt="mo-' + o[n] + '"/>');
return e;
}

function getScrollTop() {
return document.documentElement.scrollTop || document.body.scrollTop;
}

function getWindowHeight() {
return window.innerHeight || document.documentElement.clientHeight;
}

function setProperty(e, t, n, r) {
e.style.setProperty ? e.style.setProperty(t, n, r) : e.style.cssText && (e.style.cssText += t + ":" + n + "!" + r + ";");
}

function getDocumentHeiht() {
return document.body.scrollHeight;
}

function ajax(e) {
var t = (e.type || "GET").toUpperCase(), n = e.url, r = typeof e.async == "undefined" ? !0 : e.async, i = typeof e.data == "string" ? e.data : null, s = new XMLHttpRequest, o = null;
s.open(t, n, r), s.onreadystatechange = function() {
s.readyState == 3 && e.received && e.received(s), s.readyState == 4 && (s.status >= 200 && s.status < 400 && (clearTimeout(o), e.success && e.success(s.responseText)), e.complete && e.complete(), e.complete = null);
}, t == "POST" && s.setRequestHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8"), s.setRequestHeader("X-Requested-With", "XMLHttpRequest"), s.send(i), typeof e.timeout != "undefined" && (o = setTimeout(function() {
s.abort("timeout"), e.complete && e.complete(), e.complete = null;
}, e.timeout));
}

function addEventHandler(e, t, n, r) {
var i = n;
r && (i = function(e) {
n.call(this, r);
}), e.attachEvent ? e.attachEvent("on" + t, i) : e.addEventListener ? e.addEventListener(t, i, !1) : e["on" + t] = i;
}

function removeEventHandler(e, t, n) {
e.removeEventListener ? e.removeEventListener(t, n, !1) : e.detachEvent ? e.detachEvent("on" + t, n) : delete e["on" + t];
}

function isScrollEnd() {
return getScrollTop() + getWindowHeight() > getDocumentHeiht() - 1.5 * clipHeight;
}

function hasData() {
return parseInt(isContinue) == 1 ? !0 : !1;
}

function renderList(e) {
if (template) {
var t = template.render("list", {
list: e,
biz: biz,
uin: uin,
key: key
}), n = document.createElement("div");
n.innerHTML = t, document.querySelector(".msg_page").appendChild(n);
}
handleMedia();
}

function lazyInit() {
var e = document.getElementsByTagName("img"), t = document.getElementById("msg_page");
t.currentStyle ? sw = t.currentStyle.width : typeof getComputedStyle != "undefined" && (sw = getComputedStyle(t).width), sw = 1 * sw.replace("px", "");
for (var n = 0, r = e.length; n < r; n++) {
var i = e.item(n);
if (!i.getAttribute("data-src")) continue;
images.push({
el: i,
src: i.getAttribute("data-src"),
height: i.parentNode.offsetHeight == 150 ? 150 : 50,
show: !1
}), setProperty(i, "visibility", "hidden", "important");
}
detect();
}

function detect() {
var e = getWindowHeight(), t = e + 40, n = getScrollTop() - 20;
for (var r = 0, i = images.length; r < i; r++) {
var s = images[r], o = s.el.parentNode.getAttribute("class") == "msg_img" ? s.el.parentNode.parentNode.parentNode.offsetTop : s.el.parentNode.offsetTop;
if (!s.show && n < o + s.height && n + t + clipHeight > o) {
var u = s.src;
!!s.el.dataset && s.el.dataset.s == "300" && u.indexOf("http://mmbiz.qpic.cn") == 0 && (u = u.replace(/\/0$/, "/300")), !!s.el.dataset && s.el.dataset.s == "640" && u.indexOf("http://mmbiz.qpic.cn") == 0 && s.el.dataset.t > +(new Date("2014-06-01")) && (u = u.replace(/\/0$/, "/640")), s.el.setAttribute("src", u), s.el.removeAttribute("data-src"), s.show = !0, setProperty(s.el, "visibility", "visible", "important");
}
}
}

function getMinMsgId() {
var e = document.querySelectorAll("div[msgid]"), t = e.length;
return t > 0 ? parseInt(e[t - 1].getAttribute("msgid")) : 4294967295;
}

function handleVoiceLength() {
var e = document.querySelectorAll(".msg_item.voice"), t = e.length;
for (var n = 0; n < t; n++) {
var r = parseInt(e[n].getAttribute("length")) / 1e3 / 60 * 150, i = "10px " + (r > 150 ? 150 : r).toString() + "px 10px 8px";
e[n].style.padding = i;
}
if (window.navigator.userAgent.indexOf("Mac") == -1) for (var n = 0; n < t; n++) e[n].parentNode.parentNode.parentNode.style.display = "none";
}

function successHandler(data) {
var data = eval("(" + data + ")");
loading.style.display = "none";
if (!data || data.ret != 0) {
alert("系统繁忙，请稍后再试"), isLoading = !1;
return;
}
isContinue = data.is_continue;
var tmpList = JSON.parse(data.general_msg_list);
saveLocation("info", tmpList.list), renderList(tmpList.list), isLoading = !1, isContinue == 0 ? document.querySelector(".no_more").style.display = "" : loading.style.display = "", lazyInit();
return;
}

function showImg(e) {
function t(e) {
var t = e.height, n = e.width, r = document.documentElement.clientHeight, i = document.documentElement.clientWidth, s, o;
if (t > r || n > i) t / r > n / i ? (n = r / t * n, t = r) : (t = i / n * t, n = i);
return s = (r - t) / 2, o = (i - n) / 2, {
img_top: s,
img_left: o
};
}
e = e.replace("small", "normal");
var n = new Image;
n.src = e, n.onload = function() {
var r = t(n), i = "";
document.querySelector("#show_normal_img") ? i = document.querySelector("#show_normal_img") : i = document.createElement("div"), i.id = "show_normal_img", i.innerHTML = '<img id="normal_img" style="top:' + r.img_top + "px;left:" + r.img_left + 'px; position: absolute;" src="' + e + '" />', document.body.appendChild(i), document.getElementById("show_normal_img").onclick = function() {
document.querySelector("#show_normal_img").style.display = "none";
}, document.querySelector("#show_normal_img").style.display = "";
}, addEventHandler(window, "resize", function() {
var e = t(n);
document.querySelector("#normal_img").style.top = e.img_top + "px", document.querySelector("#normal_img").style.left = e.img_left + "px";
});
}

function handleMedia() {
var e = document.querySelectorAll(".msg_text");
for (var t = 0, n = e.length; t < n; t++) e[t].innerHTML = replaceEmoji(e[t].innerHTML);
var r = document.querySelectorAll(".msg_item.voice");
for (var t = 0, n = r.length; t < n; t++) {
var i = parseInt(r[t].getAttribute("length")), s = Math.ceil(i / 1e3), o = s + '"';
document.querySelectorAll(".msg_item.voice .msg_desc")[t].innerHTML = o;
}
}

function voicePlay(e) {
var t = e.querySelector("audio");
if (!hasClass(e, "cur")) {
if (document.querySelector(".cur")) try {
removeClass(document.querySelector(".cur"), "cur");
var n = e.querySelector("audio");
n.src = n.src, n.currentTime = 0;
} catch (r) {}
addClass(e, "cur"), t.play();
} else try {
removeClass(e, "cur");
var n = e.querySelector("audio");
n.src = n.src, n.currentTime = 0;
} catch (r) {}
}

function redirect(e) {
saveLocation("scroll"), location.href = e;
}

function init() {
msgList = JSON.parse(htmlDecode(msgList)), document.querySelector(".msg_page").innerHTML += template.render("list", {
list: msgList.list,
biz: biz,
uin: uin,
key: key
}), getLocation(), handleVoiceLength(), handleMedia(), lazyInit();
}

typeof template != "undefined" && (template.openTag = "{{", template.closeTag = "}}", template.helper("dateFormat", function(e, t) {
e = new Date(e);
var n = {
M: e.getMonth() + 1,
d: e.getDate(),
h: e.getHours(),
m: e.getMinutes(),
s: e.getSeconds(),
q: Math.floor((e.getMonth() + 3) / 3),
S: e.getMilliseconds()
};
return t = t.replace(/([yMdhmsqSa])+/g, function(t, r) {
var i = n[r];
return i !== undefined ? (t.length > 1 && (i = "0" + i, i = i.substr(i.length - 2)), i) : r === "y" ? (e.getFullYear() + "").substr(4 - t.length) : t;
}), t;
})), function(e, t, n) {
if (t) var r = {
set: function(e, n) {
this.get(e) !== null && this.remove(e), t.setItem(e, n);
},
get: function(e) {
var r = t.getItem(e);
return r === n ? null : r;
},
remove: function(e) {
t.removeItem(e);
},
clear: function() {
t.clear();
},
each: function(e) {
var n = t.length, r = 0, e = e || function() {}, i;
for (; r < n; r++) {
i = t.key(r);
if (e.call(this, i, this.get(i)) === !1) break;
t.length < n && (n--, r--);
}
}
}; else var r = {
set: function(e, t) {},
get: function(e) {}
};
e.LS = e.LS || r;
}(window, window.localStorage), init(), addEventHandler(window, "scroll", function() {
detect();
if (isLoading) return;
if (!parseInt(isFriend)) return;
if (hasData() && isScrollEnd()) {
loading.style.display = "", isLoading = !0;
var e = [ "__biz=" + biz, "uin=" + uin, "key=" + key, "f=json", "frommsgid=" + getMinMsgId(), "count=10" ].join("&");
ajax({
url: "/mp/getmasssendmsg?" + e,
type: "get",
success: function(e) {
successHandler(e);
}
});
}
});