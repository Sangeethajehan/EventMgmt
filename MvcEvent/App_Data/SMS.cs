using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for SMS
/// </summary>
public class SMS
{
    string clientKey = WebConfigurationManager.AppSettings["clientKey"];
    string ApiKey = WebConfigurationManager.AppSettings["ApiKey"];
    string uri = WebConfigurationManager.AppSettings["uri"];
    string senderid = WebConfigurationManager.AppSettings["senderid"];
    string template = string.Empty;
    string HtmlResult = string.Empty;

    public SMS()
    {
        
    }

    public string SendSMS(string strMobileNo,string strActivationCode)
    {
        string template = "Your Mobile Activation Code:" + strActivationCode;
        string parameters = "apikey=" + ApiKey + "&clientId=" + clientKey + "&msisdn=" + strMobileNo + "&sid=" + senderid + "&msg=" + template + "&fl=0&gwid=2";
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            HtmlResult = wc.UploadString(uri, parameters);
        }
        if (!HtmlResult.Contains("Success"))
        {
            //CreateErrorlog.WriteError(HtmlResult.ToString());
        }
        return HtmlResult;
    }

    
  

}