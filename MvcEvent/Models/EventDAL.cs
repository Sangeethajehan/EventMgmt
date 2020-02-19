using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcEvent.Models
{
    public class EventDAL
    {
        SQLDAL objSql = new SQLDAL();
        static string strConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        MySqlConnection conn = new MySqlConnection(strConn);

        public string CreateEvent(int intEventId, int intUserId, string strEventName, string strStartDate, string strStartTime, string strEndDate, string strEndTime,
     string strDescription, string strEventType, string strVenueEventType, string strAddress, string strVenue, string strCity,
     string strState, string strCountry, string strPinCode, string strEventLogo, string strCoverPicture, string strFinalEventType, string strDraft, string strStatus, int intCreatedById)
        {
            string strRetVal = "";
            SQLDAL objSql = new SQLDAL();
            MySqlCommand objCmd = new MySqlCommand();
            MySqlDataAdapter objda = new MySqlDataAdapter();
            try
            {
                objCmd = objSql.CreateCommand(objCmd, CommandType.StoredProcedure, "EventsSp");
                objSql.AddParameter(objCmd, "pAction", MySqlDbType.VarChar, ParameterDirection.Input, 50, "InsertEvent");
                objSql.AddParameter(objCmd, "peventId", MySqlDbType.Int32, ParameterDirection.Input, 50, intEventId);
                objSql.AddParameter(objCmd, "puserId", MySqlDbType.Int32, ParameterDirection.Input, 50, intUserId);
                objSql.AddParameter(objCmd, "peventName", MySqlDbType.VarChar, ParameterDirection.Input, 50, strEventName);
                objSql.AddParameter(objCmd, "pstartDate", MySqlDbType.VarChar, ParameterDirection.Input, 50, strStartDate);
                objSql.AddParameter(objCmd, "pstartTime", MySqlDbType.VarChar, ParameterDirection.Input, 50, strStartTime);
                objSql.AddParameter(objCmd, "pendDate", MySqlDbType.VarChar, ParameterDirection.Input, 50, strEndDate);
                objSql.AddParameter(objCmd, "pendTime", MySqlDbType.VarChar, ParameterDirection.Input, 50, strEndTime);
                objSql.AddParameter(objCmd, "pdescription", MySqlDbType.VarChar, ParameterDirection.Input, 50, strDescription);
                objSql.AddParameter(objCmd, "peventType", MySqlDbType.VarChar, ParameterDirection.Input, 50, strEventType);
                objSql.AddParameter(objCmd, "pvenueEventType", MySqlDbType.VarChar, ParameterDirection.Input, 50, strVenueEventType);
                objSql.AddParameter(objCmd, "paddress", MySqlDbType.VarChar, ParameterDirection.Input, 50, strAddress);
                objSql.AddParameter(objCmd, "pvenue", MySqlDbType.VarChar, ParameterDirection.Input, 50, strVenue);
                objSql.AddParameter(objCmd, "pstate", MySqlDbType.VarChar, ParameterDirection.Input, 50, strCity);
                objSql.AddParameter(objCmd, "pcity", MySqlDbType.VarChar, ParameterDirection.Input, 50, strState);
                objSql.AddParameter(objCmd, "pcountry", MySqlDbType.VarChar, ParameterDirection.Input, 50, strCountry);
                objSql.AddParameter(objCmd, "ppinCode", MySqlDbType.VarChar, ParameterDirection.Input, 50, strPinCode);
                objSql.AddParameter(objCmd, "peventLogo", MySqlDbType.VarChar, ParameterDirection.Input, 50, strEventLogo);
                objSql.AddParameter(objCmd, "pcoverPic", MySqlDbType.VarChar, ParameterDirection.Input, 50, strCoverPicture);
                objSql.AddParameter(objCmd, "pfinaleventtype", MySqlDbType.VarChar, ParameterDirection.Input, 50, strFinalEventType);
                objSql.AddParameter(objCmd, "pdraft", MySqlDbType.VarChar, ParameterDirection.Input, 50, strDraft);
                objSql.AddParameter(objCmd, "pstatus", MySqlDbType.VarChar, ParameterDirection.Input, 50, strStatus);
                objSql.AddParameter(objCmd, "pCreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 25, intCreatedById);
                strRetVal = objCmd.ExecuteScalar().ToString();

            }
            catch (Exception ex)
            {
                throw ex;
                //CreateErrorlog.WriteError(ex.Message.ToString() + "\r\n" + ex.StackTrace);
            }
            finally
            {
                if (!(objCmd == null))
                {
                    objCmd.Dispose();
                    if (objSql != null)
                        objSql.Dispose();
                    if (objda != null)
                        objda.Dispose();
                }
            }
            return strRetVal;
        }

        public DataTable GetAllEvents()
        {
            DataTable dtVendorInfo = new DataTable();
            SQLDAL objSql = new SQLDAL();
            MySqlCommand objCmd = new MySqlCommand();
            MySqlDataAdapter objda = new MySqlDataAdapter();
            try
            {
                objCmd = objSql.CreateCommand(objCmd, CommandType.StoredProcedure, "View");
                objSql.AddParameter(objCmd, "pAction", MySqlDbType.VarChar, ParameterDirection.Input, 20, "GetEvent");
                objda.SelectCommand = objCmd;
                objda.Fill(dtVendorInfo);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (!(objCmd == null))
                {
                    objCmd.Dispose();
                    if (objSql != null)
                        objSql.Dispose();
                    if (objda != null)
                        objda.Dispose();
                }
            }
            return dtVendorInfo;
        }

    }
    
}