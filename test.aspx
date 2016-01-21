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

        StreamReader sr = File.OpenText(Server.MapPath("xml.txt"));
        string xmlStr = sr.ReadToEnd();
        string reponseStr = "";
        sr.Close();
        XmlDocument xmlD = new XmlDocument();
        xmlD.LoadXml(xmlStr);
        xmlStr = xmlD.InnerXml.Trim();


        System.Security.Cryptography.X509Certificates.X509CertificateCollection cerArr
            = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();
        System.Security.Cryptography.X509Certificates.X509Certificate cer
            = new System.Security.Cryptography.X509Certificates.X509Certificate(Server.MapPath("cer/client.crt"));

        cerArr.Add(cer);
        
        
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://121.8.124.249:19210/syn10086");
        req.ClientCertificates = cerArr;
        req.ContentType = "text/xml;charset=gbk";
        req.Method = "post";
        // 开始请求
        using (StreamWriter sw = new StreamWriter(req.GetRequestStream()))
        {
            sw.Write(xmlStr);
        }
        Console.WriteLine("请求报文：\n" + xmlStr);
        // 获得响应
        HttpWebResponse res = (HttpWebResponse)req.GetResponse();
        using (StreamReader srr = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding("GBK")))
        {
            reponseStr = srr.ReadToEnd();
        }
        Response.Write("响应报文：\n" + reponseStr);


    }
    
</script>