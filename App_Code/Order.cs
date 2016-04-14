﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Order
/// </summary>
public class Order
{

    public DataRow _fields;

	public Order(string outTradeNo)
	{
        SqlDataAdapter da = new SqlDataAdapter(" select * from orders where order_out_trade_no = " 
            + Int64.Parse(outTradeNo).ToString(), Util.conStr.Trim());
        DataTable dt = new DataTable();
        da.Fill(dt);
        da.Dispose();
        _fields = dt.Rows[0];
	}

    public string PrepayId
    {
        set
        {
            string sql = " update orders set order_prepay_id = '" + value.Trim().Replace("'", "")
                + "'  where order_out_trade_no = '" + _fields["order_out_trade_no"].ToString().Trim() + "'  ";
            SqlConnection conn = new SqlConnection(Util.conStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
        }
    }

    public int Status
    {
        get
        {
            return int.Parse(_fields["order_is_paid"].ToString().Trim());
        }
        set
        {
            string sql = " update orders set order_is_paid = '" + value.ToString()
                + "'  where order_out_trade_no = '" + _fields["order_out_trade_no"].ToString().Trim() + "'  ";
            SqlConnection conn = new SqlConnection(Util.conStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
        }
    }

    public static int CreateOrder(
        string outTradeNo, 
        string appId, 
        string mchId, 
        string nonceStr, 
        string openId, 
        string body, 
        string detail, 
        string productId, 
        int totalFee, 
        string spBillCreateIp
        )
    {
        string sql = "insert into orders ("
            + " order_out_trade_no , "
            + " order_appid , "
            + " order_mchid , "
            + " order_nonce_str , "
            + " order_openid , "
            + " order_body , "
            + " order_detail , "
            + " order_product_id , "
            + " order_total_fee , "
            + " order_spbill_create_ip ) "
            + " values ( "
            + Int64.Parse(outTradeNo).ToString() + "  , "
            + "'" + appId.Trim().Replace("'", "") + "' , "
            + "'" + mchId.Trim().Replace("'", "") + "' , "
            + "'" + nonceStr.Trim().Replace("'", "") + "' , "
            + "'" + openId.Trim().Replace("'", "") + "' , "
            + "'" + body.Trim().Replace("'", "") + "' , "
            + "'" + detail.Trim().Replace("'", "") + "' , "
            + "'" + productId.Trim().Replace("'", "") + "' , "
            + totalFee.ToString() + ","
            + "'" + spBillCreateIp.Trim().Replace("'","") + "'  ) ";

        SqlConnection conn = new SqlConnection(Util.conStr);
        SqlCommand cmd = new SqlCommand(sql,conn);
        conn.Open();
        int i = cmd.ExecuteNonQuery();
        conn.Close();
        cmd.Dispose();
        conn.Dispose();
        return i;
    }

    public static Order GetOrderByOriginInfo(string body, int productId, int amount)
    {
        DataTable dt = DBHelper.GetDataTable(" select * from orders where order_body = '" + body.Trim().Replace("'", "") + "'  and "
            + "  order_product_id = " + productId.ToString() + "  and order_total_fee = " + amount.ToString() + "  ", Util.conStr.Trim());
        if (dt.Rows.Count > 0)
        {
            return new Order(dt.Rows[0][0].ToString());
        }
        else
        {
            return null;
        }

    }

}
