using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GroupMaster
/// </summary>
public class GroupMaster
{

    public DataRow _fields;

	public GroupMaster()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public GroupMaster(int id)
    {
        DataTable dt = DBHelper.GetDataTable(" select * from group_master_list where [id] = " + id.ToString(), Util.conStr);
        if (dt.Rows.Count == 1)
        {
            _fields = dt.Rows[0];
        }
        else
        {
            throw new Exception("Group master is not exists");
        }
    }

    public void AddVote()
    {
        int voteNumber = VoteNumber;
        voteNumber++;
        string[,] updateParameters = { { "reply_num", "int", voteNumber.ToString()} };
        string[,] keyPatameters = {{"id", "int", ID.ToString()}};
        DBHelper.UpdateData("group_master_list", updateParameters, keyParameters, Util.conStr);
    }

    public int ID
    {
        get
        {
            return int.Parse(_fields["id"].ToString().Trim());
        }
    }

    public int VoteNumber
    {
        get
        {
            return int.Parse(_fields["vote_num"].ToString());
        }
    }

    public static GroupMaster CreateNew(string openId)
    { 
        string[,] insertParameter =  {{"open_id", "varchar", openId}};
        int i = DBHelper.InsertData("group_master_list", insertParameter, Util.conStr);
        GroupMaster groupMaster = new GroupMaster();
        if (i == 1)
        {
            DataTable dt = DBHelper.GetDataTable(" select top 1 * from group_master_list order by [id] desc  ", Util.conStr);
            if (dt.Rows.Count == 1)
            {
                groupMaster._fields = dt.Rows[0];
            }
            else
            {
                throw new Exception("Create group master failed.");
            }
        }
        else
        {
            throw new Exception("Create group master failed.");
        }
        return groupMaster;
    }
}