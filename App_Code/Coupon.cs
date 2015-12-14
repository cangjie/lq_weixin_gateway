using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
///Coupon 的摘要说明
/// </summary>
public class Coupon
{
    public DataRow _fields;


	public Coupon(string code)
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//

        DataTable dt = DBHelper.GetDataTable(" select * from coupon where code = '" + code.Replace("'", "") + "'  ", Util.ConnectionStringMall);
        if (dt.Rows.Count == 1)
        {
            _fields = dt.Rows[0];
        }
	}



    public int Id
    {
        get
        {
            return int.Parse(_fields["id"].ToString().Trim());
        }
    }

    public int EffectAmount
    {
        get
        {
            return int.Parse(_fields["effect_amount"].ToString());
        }
    }

    public DateTime ExpireDate
    {
        get
        {
            return DateTime.Parse(_fields["expire_date"].ToString());
        }
    }

    public bool Used
    {
        get
        {
            if (_fields["is_used"].ToString().Trim().Equals("1"))
                return true;
            else
                return false;
        }
        
    }

    public int Amount
    {
        get
        {
            return int.Parse(_fields["amount"].ToString());
        }
    }


    

    public static Coupon AddCoupon(int amount)
    {
        string couponCode = GetRandomString(8);

        for (int i = 0; i < 100 && CheckCouponCodeExists(couponCode); i++)
        {
            couponCode = GetRandomString(8);
        }

        if (!CheckCouponCodeExists(couponCode))
        {
            KeyValuePair<string, KeyValuePair<SqlDbType, object>>[] insertParameters = new KeyValuePair<string, KeyValuePair<SqlDbType, object>>[2];
            insertParameters[0] = new KeyValuePair<string, KeyValuePair<SqlDbType, object>>("code",
                new KeyValuePair<SqlDbType, object>(SqlDbType.VarChar, (object)couponCode));
            insertParameters[1] = new KeyValuePair<string, KeyValuePair<SqlDbType, object>>("amount",
                new KeyValuePair<SqlDbType, object>(SqlDbType.Int, (object)amount));
            DBHelper.InsertData("coupon", insertParameters, Util.ConnectionStringMall);
            return new Coupon(couponCode);
        }
        else
        {

            return null;
        }
    }

    public static bool CheckCouponCodeExists(string code)
    {
        Coupon coupon = new Coupon(code);
        if (coupon._fields == null)
            return false;
        else
            return true;
    }
    

    public static string GetRandomString(int digit)
    {
        Dictionary<int, char> charHash = new Dictionary<int, char>();
       
        charHash.Add(0, '1');
        charHash.Add(1, '2');
        charHash.Add(2, '3');
        charHash.Add(3, '4');
        charHash.Add(4, '5');
        charHash.Add(5, '6');
        charHash.Add(6, '7');
        charHash.Add(7, '8');
        charHash.Add(8, '9');
        charHash.Add(9, 'A');
        charHash.Add(10, 'B');
        charHash.Add(11, 'C');
        charHash.Add(12, 'D');
        charHash.Add(13, 'E');
        charHash.Add(14, 'F');
        charHash.Add(15, 'G');
        charHash.Add(16, 'H');
        charHash.Add(17, 'I');
        charHash.Add(18, 'J');
        charHash.Add(19, 'K');
        charHash.Add(20, 'L');
        charHash.Add(21, 'M');
        charHash.Add(22, 'N');
        charHash.Add(23, 'P');
        charHash.Add(24, 'Q');
        charHash.Add(25, 'R');
        charHash.Add(26, 'R');
        charHash.Add(27, 'T');
        charHash.Add(28, 'U');
        charHash.Add(29, 'V');
        charHash.Add(30, 'W');
        charHash.Add(31, 'X');
        charHash.Add(32, 'Y');
        charHash.Add(33, 'Z');
        
        string retCode = "";
        Random rnd = new Random();
        for (int i = 0; i < digit; i++)
        {
            retCode = retCode + charHash[rnd.Next(charHash.Count)];
        }


        return retCode;
    }
}