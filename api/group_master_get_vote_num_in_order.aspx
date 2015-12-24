<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {
        int actId = int.Parse(Util.GetSafeRequestValue(Request, "actid", "1"));
        GroupMaster[] groupMasterArray = GroupMaster.GetList(actId);
        DataTable dt = new DataTable();
        dt.Columns.Add("group_id" );
        dt.Columns.Add("open_id");
        dt.Columns.Add("vote_num");
        for (int i = 0; i < groupMasterArray.Length; i++)
        {
            DataRow dr = dt.NewRow();
            dr["group_id"] = groupMasterArray[i].ID.ToString();
            dr["open_id"] = groupMasterArray[i]._fields["open_id"].ToString().Trim();
            dr["vote_num"] = int.Parse(groupMasterArray[i].VoteNumberAll.ToString());
            dt.Rows.Add(dr);
        }

        DataRow[] drInOrderArray = dt.Select("", "  vote_num desc ");

        string orderStr = "";

        int j = 0;
        
        foreach (DataRow drInOrder in drInOrderArray)
        {
            orderStr = orderStr + ",{\"group_id\" : \"" + drInOrder["group_id"].ToString().Trim() + "\"  ,  \"open_id\" : \""
                + drInOrder["open_id"].ToString().Trim() + "\" ,  \"vote_num\" : " + drInOrder["vote_num"].ToString() + " } ";
            j++;
        }

        if (orderStr.StartsWith(","))
            orderStr = orderStr.Remove(0, 1);

        Response.Write("{\"status\" : 0 , \"count\" : " + j.ToString() + "  ,  \"group_items\" : ["
            + orderStr + "] }");
        
        
    }
</script>
