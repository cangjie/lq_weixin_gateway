using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for PromoteQrcode
/// </summary>
public class PromoteQrcode
{
	public PromoteQrcode()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string GetQrcodeImage(long promoteId, string imageRootPath)
    {
        string imagePath = "";
        SqlDataAdapter da = new SqlDataAdapter(" select top 1 * from qr_invite_list_ticket where qr_invite_list_id = "
            + promoteId.ToString() + " and crt >= dateadd(d,-5,getdate())  order by crt desc  ",Util.conStr.Trim());
        DataTable dt = new DataTable();
        da.Fill(dt);
        da.Dispose();

        if (dt.Rows.Count == 1)
        {
            imagePath = dt.Rows[0]["qr_image_file_name"].ToString().Trim();
        }
        else
        {
            string ticket = Util.GetQrCodeTicketTemp(Util.GetToken(), promoteId);
            byte[] bArr = Util.GetQrCodeByTicket(ticket);
            string path = PrepareDirectory(imageRootPath);
            string fileName = Util.GetTimeStamp()+".jpg";
            SaveQrcodeImage(bArr, imageRootPath + "\\" + path + "\\" + fileName);
            imagePath = path + "\\" + fileName;

            SqlConnection conn = new SqlConnection(Util.conStr);
            SqlCommand cmd = new SqlCommand(" insert into qr_invite_list_ticket (ticket,qr_invite_list_id,qr_image_file_name) values ('"
                + ticket + "'," + promoteId + ", '" + imagePath + "'  )  ", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            conn.Dispose();


        }
        return imagePath;
    }

    public static void SaveQrcodeImage(byte[] bArr, string imagePathAndName)
    {
        if (File.Exists(imagePathAndName))
        {
            File.Delete(imagePathAndName);
        }
        FileStream fileStream = File.OpenWrite(imagePathAndName);
        fileStream.Write(bArr, 0, bArr.Length);
        fileStream.Close();
    }

    public static string PrepareDirectory(string imageRootPath)
    {
        string path = "";
        DateTime nowDate = DateTime.Now;
        if (!Directory.Exists(imageRootPath+"\\"+nowDate.Year.ToString()))
        {
            Directory.CreateDirectory(imageRootPath+"\\"+nowDate.Year.ToString());
        }
        path = path +  nowDate.Year.ToString() + "\\";
        if (!Directory.Exists(imageRootPath + "\\" + path + nowDate.Month.ToString() ))
        {
            Directory.CreateDirectory(imageRootPath + "\\" + path + nowDate.Month.ToString());
        }
        path = path + nowDate.Month.ToString() + "\\";
        if (!Directory.Exists(imageRootPath + "\\" + path + nowDate.Day.ToString()))
        {
            Directory.CreateDirectory(imageRootPath + "\\" + path + nowDate.Day.ToString());
        }
        path = path + nowDate.Day.ToString() + "\\";
        return path;
    }

}