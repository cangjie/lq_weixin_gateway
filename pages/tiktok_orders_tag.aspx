<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html>

<script runat="server">

    public DataTable dt = new DataTable();

    protected void btn_Click(object sender, EventArgs e)
    {
        dt.Dispose();
        dt.Columns.Add("orderid");
        dt.Columns.Add("name");
        dt.Columns.Add("usermemo");
        dt.Columns.Add("shopmemo");
        Stream s = upload.FileContent;
        StreamReader sr = new StreamReader(s);
        string[] uploadRows = sr.ReadToEnd().Split('\n');
        for (int i = 1; i < uploadRows.Length; i++)
        {
            string[] rows = uploadRows[i].Split(',');
            int r = 0;
            try
            {
                r = DBHelper.InsertData("tiktok_orders", new string[,] {
                    {"tiktok_order_id", "varchar", rows[0].Trim().Replace("'", "").Trim() },
                    {"name", "varchar", rows[1].Trim()},
                    {"user_memo", "varchar", rows[23].Trim()},
                    {"shop_memo", "varchar", rows[27].Trim()},
                    {"count", "int",  rows[6].Trim()}
                }, Util.conStr.Trim());
            }
            catch(Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.ToString());
            }
            if (r > 0)
            {
                DataRow dr = dt.NewRow();
                dr["orderid"] = rows[0].Trim().Replace("'", "").Trim();
                dr["name"] = rows[1].Trim();
                dr["usermemo"] = rows[23].Trim();
                dr["shopmemo"] = rows[27].Trim();
                dt.Rows.Add(dr);
            }
        }
        sr.Close();

    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server" >
        <asp:FileUpload ID="upload" runat="server" /> <asp:Button ID="btn" runat="server" Text=" 上 传 " OnClick="btn_Click" />
        <table border="1" style="width:1000px;border-spacing:10px;" >
<%
    for (int i = 0; i < dt.Rows.Count / 3; i++)
    {
    %>
            <tr style="height:350px">
                <td style="width:330px;align-items:center;vertical-align:top">
                    <font size="6">
                    <%=dt.Rows[i*3]["usermemo"].ToString().Trim() %><br />
                    <%=dt.Rows[i*3]["shopmemo"].ToString().Trim() %><br /><br />
                    <%=dt.Rows[i*3]["orderid"].ToString().Trim() %><br />
                    <%=dt.Rows[i*3]["name"].ToString().Trim() %><br />
                    </font>
                </td>
                <td style="width:330px;align-items:center;vertical-align:top">
                    <font size="6">
                    <%if (i * 3 + 1 < dt.Rows.Count)
                        {%>
                    <%=dt.Rows[i * 3 + 1]["usermemo"].ToString().Trim() %><br />
                    <%=dt.Rows[i * 3 + 1]["shopmemo"].ToString().Trim() %><br />
                    <%=dt.Rows[i * 3 + 1]["orderid"].ToString().Trim() %><br />
                    <%=dt.Rows[i * 3 + 1]["name"].ToString().Trim() %><br />
                    <%
                        }
                        else
                        { 
                        %>
                    &nbsp;
                    <%
                        }
                        %>
                    </font>
                </td>
                <td style="width:330px;align-items:center;vertical-align:top">
                    <font size="6">
                    <%if (i * 3 + 2 < dt.Rows.Count)
                        {%>
                    <%=dt.Rows[i * 3 + 2]["usermemo"].ToString().Trim() %><br />
                    <%=dt.Rows[i * 3 + 2]["shopmemo"].ToString().Trim() %><br />
                    <%=dt.Rows[i * 3 + 2]["orderid"].ToString().Trim() %><br />
                    <%=dt.Rows[i * 3 + 2]["name"].ToString().Trim() %><br />
                    <%
                        }
                        else
                        { 
                        %>
                    &nbsp;
                    <%
                        }
                        %>
                    </font>
                </td>
            </tr>
    <%
        }
        %>
        </table>
    </form>
</body>
</html>
