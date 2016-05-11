using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Drawing
/// </summary>
public class Drawing
{
	public Drawing()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static int DrawingPlay(string opneId, int actId)
    {
        DataTable dt = DBHelper.GetDataTable(" select * from random_awards where open_id = '" + opneId.Trim() + "'  and act_id = " + actId.ToString(), Util.ConnectionStringGame);
        int i = 0;
        if (dt.Rows.Count > 0)
        {
            i = int.Parse(dt.Rows[0]["id"].ToString());
        }
        else
        {
            i = NewDrawing(opneId, actId);
        }
        dt.Dispose();
        return i;
    }

    public static int NewDrawing(string openId, int actId)
    {
        
        int numBra = 0;
        DataTable dtBook;
        dtBook = DBHelper.GetDataTable(" select * from random_awards where award = '朱林禾羽独家定制科学内衣（文胸）' and act_id = " + actId.ToString(), Util.ConnectionStringGame);
        numBra = dtBook.Rows.Count;
        dtBook.Dispose();


        int numPant = 0;
        dtBook = DBHelper.GetDataTable(" select * from random_awards where award = '朱林禾羽独家定制科学内衣（内裤）' and act_id = " + actId.ToString(), Util.ConnectionStringGame);
        numPant = dtBook.Rows.Count;
        dtBook.Dispose();
        


        string award = "";
        int seed = (new Random()).Next(0, 100);
        if (seed < 40)
        {
            Coupon coupon = Coupon.AddCoupon(1000);
            award = "10元优惠券:" + coupon._fields["code"].ToString().Trim();
        }
        else
        {
            if (seed < 80)
            {
                Coupon coupon = Coupon.AddCoupon(1500);
                award = "15元优惠券:" + coupon._fields["code"].ToString().Trim();
            }
            else
            {

                if (seed == 80 && numPant < 12)
                {
                    award = "朱林禾羽独家定制科学内衣（内裤）";
                }
                else
                {
                    if (seed == 90 && numBra < 5)
                    {
                        award = "朱林禾羽独家定制科学内衣（文胸）";
                    }
                    else
                    {
                        Coupon coupon = Coupon.AddCoupon(2000);
                        award = "20元优惠券:" + coupon._fields["code"].ToString().Trim();
                    }
                }
               
            }
        }

        string[,] insertParameter = {{"act_id", "int", actId.ToString()},
                                    {"open_id", "varchar", openId.Trim()},
                                    {"seed", "int", seed.ToString()},
                                    {"award", "varchar", award.Trim()}};

        int i = DBHelper.InsertData("random_awards", insertParameter, Util.ConnectionStringGame);

        if (i == 1)
        {
            DataTable dt = DBHelper.GetDataTable(" select top 1 * from random_awards order by [id] desc ", Util.ConnectionStringGame);
            if (dt.Rows.Count == 1)
            {
                i = int.Parse(dt.Rows[0]["id"].ToString());
            }
            dt.Dispose();
        }

        return i;
    }


    /*
    public static int NewDrawing(string opneId, int actId)
    {
        int numFannao = 0;
        int numCD = 0;
        int numZhangda = 0;

        DataTable dt;
        dt = DBHelper.GetDataTable(" select * from random_awards where award = '和烦恼说再见' and act_id = " + actId.ToString() , Util.ConnectionStringGame);
        numFannao = dt.Rows.Count;
        dt.Dispose();

        dt = DBHelper.GetDataTable(" select * from random_awards where award = '家庭教育光盘' and act_id = " + actId.ToString(), Util.ConnectionStringGame);
        numCD = dt.Rows.Count;
        dt.Dispose();

        dt = DBHelper.GetDataTable(" select * from random_awards where award = '长大不容易' and act_id = " + actId.ToString(), Util.ConnectionStringGame);
        numZhangda = dt.Rows.Count;
        dt.Dispose();

        int seed = (new Random()).Next(0, 100);
        string award = "";

        if (numZhangda + numFannao + numCD < 200)
        {
            if (seed < 10 && numCD < 100)
            {
                award = "家庭教育光盘";
            }
            else
            {
                if (seed < 20 && numZhangda < 100)
                {
                    award = "长大不容易";
                }
                else
                {
                    if (seed < 30 && numFannao < 200)
                    {
                        award = "和烦恼说再见";
                    }
                    else
                    {
                        if (seed < 35)
                        {
                            Coupon coupon = Coupon.AddCoupon(500);
                            award = "5元优惠券:" + coupon._fields["code"].ToString().Trim();
                        }
                        else
                        {
                            if (seed < 75)
                            {
                                Coupon coupon = Coupon.AddCoupon(1000);
                                award = "10元优惠券:" + coupon._fields["code"].ToString().Trim();
                            }
                            else
                            {
                                Coupon coupon = Coupon.AddCoupon(2000);
                                award = "20元优惠券:" + coupon._fields["code"].ToString().Trim();
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (seed < 1 && numCD < 100)
            {
                award = "家庭教育光盘";
            }
            else
            {
                if (seed < 2 && numZhangda < 100)
                {
                    award = "长大不容易";
                }
                else
                {
                    if (seed < 3 && numFannao < 200)
                    {
                        award = "和烦恼说再见";
                    }
                    else
                    {
                        if (seed < 35)
                        {
                            Coupon coupon = Coupon.AddCoupon(500);
                            award = "5元优惠券:" + coupon._fields["code"].ToString().Trim();
                        }
                        else
                        {
                            if (seed < 75)
                            {
                                Coupon coupon = Coupon.AddCoupon(1000);
                                award = "10元优惠券:" + coupon._fields["code"].ToString().Trim();
                            }
                            else
                            {
                                Coupon coupon = Coupon.AddCoupon(2000);
                                award = "20元优惠券:" + coupon._fields["code"].ToString().Trim();
                            }
                        }
                    }
                }
            }
        }



        

        string[,] insertParameter = {{"act_id", "int", actId.ToString()},
                                    {"open_id", "varchar", opneId.Trim()},
                                    {"seed", "int", seed.ToString()},
                                    {"award", "varchar", award.Trim()}};

        int i = DBHelper.InsertData("random_awards", insertParameter, Util.ConnectionStringGame);

        if (i == 1)
        {
            dt = DBHelper.GetDataTable(" select top 1 * from random_awards order by [id] desc ", Util.ConnectionStringGame);
            if (dt.Rows.Count == 1)
            { 
                i = int.Parse(dt.Rows[0]["id"].ToString());
            }
            dt.Dispose();
        }

        return i;
    }

    */
}