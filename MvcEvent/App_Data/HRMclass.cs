using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Reflection;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Net.Security;
using System.Net.Sockets;
using System.Net;
using System.Xml;
using System.Security.Cryptography;
/// <summary>
/// Summary description for HRMclass
/// </summary>
public class HRMclass
{
    public static string EmpDetId;
    public HRMclass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}


public class ErrorMessage
{
    /// <summary>
    /// To show error message to user and to write the error in log.
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="objPage"></param>

}

public class CreateErrorlog
{
    public static object WriteError(System.Web.UI.Page objPage, string Exception)
    {
        try
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now.Date;
            string LOGDATE = null;
            string strPath = null;
            System.Web.UI.Page objpg = new System.Web.UI.Page();
            LOGDATE = dt.ToString("MMM d yyyy");
            strPath = objPage.Server.MapPath("~/" + ConfigurationManager.AppSettings["LogPath"].ToString());
            StreamWriter stwriter = new StreamWriter(strPath + "/" + "ErrorLog" + LOGDATE + ".txt", true);
            stwriter.WriteLine("*********************************************************************");
            stwriter.WriteLine("");
            stwriter.WriteLine("DATE TIME  :" + DateTime.Now.ToString());
            stwriter.WriteLine("PAGE TITLE :" + objPage.Request.Url.AbsolutePath);
            stwriter.WriteLine("ERROR INFO :" + Exception.ToString());
            stwriter.WriteLine("");
            stwriter.WriteLine("");
            stwriter.Flush();
            stwriter.Close();
        }
        catch (Exception ex)
        {
        }
        return true;
    }
    public static object WriteError(string Exception)
    {
        try
        {
            System.Web.UI.Page objPage = new System.Web.UI.Page();
            DateTime dt = new DateTime();
            dt = DateTime.Now.Date;
            string LOGDATE = null;
            string strPath = null;
            System.Web.UI.Page objpg = new System.Web.UI.Page();
            LOGDATE = dt.ToString("MMM d yyyy");
            strPath = objPage.Server.MapPath("~/" + ConfigurationManager.AppSettings["LogPath"].ToString());
            StreamWriter stwriter = new StreamWriter(strPath + "/" + "ErrorLog" + LOGDATE + ".txt", true);
            stwriter.WriteLine("*********************************************************************");
            stwriter.WriteLine("");
            stwriter.WriteLine("DATE TIME  :" + DateTime.Now.ToString());
            stwriter.WriteLine("ERROR INFO :" + Exception.ToString());
            stwriter.WriteLine("");
            stwriter.WriteLine("");
            stwriter.Flush();
            stwriter.Close();
        }
        catch (Exception ex)
        {
        }
        return true;
    }

}