using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MvcEvent.Models
{
    public class SignUpDal
    {
        SQLDAL objSql = new SQLDAL();
        static string strConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        MySqlConnection conn = new MySqlConnection(strConn);


        public String CreateSignUp(int intMasterId, string strname, string strEmail, string strMobileno, string strpwd, string strcpwd, string strmobileotp, string stremailotp, int intCreatedById)
        {
            string strRetVal = "";
            SQLDAL objSql = new SQLDAL();
            MySqlCommand objCmd = new MySqlCommand();
            MySqlDataAdapter objda = new MySqlDataAdapter();
            try
            {

                objCmd = objSql.CreateCommand(objCmd, CommandType.StoredProcedure, "signupSp");
                objSql.AddParameter(objCmd, "pAction", MySqlDbType.VarChar, ParameterDirection.Input, 50, "InsertSignUp");
                objSql.AddParameter(objCmd, "psignupId", MySqlDbType.Int32, ParameterDirection.Input, 50, intMasterId);
                objSql.AddParameter(objCmd, "pfullName", MySqlDbType.VarChar, ParameterDirection.Input, 200, strname);
                objSql.AddParameter(objCmd, "peMail", MySqlDbType.VarChar, ParameterDirection.Input, 25, strEmail);
                objSql.AddParameter(objCmd, "pmobileNo", MySqlDbType.VarChar, ParameterDirection.Input, 50, strMobileno);
                objSql.AddParameter(objCmd, "ppwd", MySqlDbType.VarChar, ParameterDirection.Input, 200, strpwd);
                objSql.AddParameter(objCmd, "pcpwd", MySqlDbType.VarChar, ParameterDirection.Input, 25, strcpwd);
                objSql.AddParameter(objCmd, "pmobileOtp", MySqlDbType.VarChar, ParameterDirection.Input, 200, strmobileotp);
                objSql.AddParameter(objCmd, "pemailOtp", MySqlDbType.VarChar, ParameterDirection.Input, 25, stremailotp);
                objSql.AddParameter(objCmd, "pcreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 25, intCreatedById);
                strRetVal = objCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
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

        public String UpdMobileVerify( string strMobileno)
        {
            string strRetVal = "";
            SQLDAL objSql = new SQLDAL();
            MySqlCommand objCmd = new MySqlCommand();
            MySqlDataAdapter objda = new MySqlDataAdapter();
            try
            {

                objCmd = objSql.CreateCommand(objCmd, CommandType.StoredProcedure, "signupSp");
                objSql.AddParameter(objCmd, "pAction", MySqlDbType.VarChar, ParameterDirection.Input, 50, "updmobileotp");
                objSql.AddParameter(objCmd, "psignupId", MySqlDbType.Int32, ParameterDirection.Input, 50, null);
                objSql.AddParameter(objCmd, "pfullName", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "peMail", MySqlDbType.VarChar, ParameterDirection.Input, 25, null);
                objSql.AddParameter(objCmd, "pmobileNo", MySqlDbType.VarChar, ParameterDirection.Input, 50, strMobileno);
                objSql.AddParameter(objCmd, "ppwd", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "pcpwd", MySqlDbType.VarChar, ParameterDirection.Input, 25, null);
                objSql.AddParameter(objCmd, "pmobileOtp", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "pemailOtp", MySqlDbType.VarChar, ParameterDirection.Input, 25, null);
                objSql.AddParameter(objCmd, "pcreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 25, null);
                strRetVal = objCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
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

        public String UpdEmailVerify(string strEmail)
        {
            string strRetVal = "";
            SQLDAL objSql = new SQLDAL();
            MySqlCommand objCmd = new MySqlCommand();
            MySqlDataAdapter objda = new MySqlDataAdapter();
            try
            {

                objCmd = objSql.CreateCommand(objCmd, CommandType.StoredProcedure, "signupSp");
                objSql.AddParameter(objCmd, "pAction", MySqlDbType.VarChar, ParameterDirection.Input, 50, "updemailotp");
                objSql.AddParameter(objCmd, "psignupId", MySqlDbType.Int32, ParameterDirection.Input, 50, null);
                objSql.AddParameter(objCmd, "pfullName", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "peMail", MySqlDbType.VarChar, ParameterDirection.Input, 25, strEmail);
                objSql.AddParameter(objCmd, "pmobileNo", MySqlDbType.VarChar, ParameterDirection.Input, 50, null);
                objSql.AddParameter(objCmd, "ppwd", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "pcpwd", MySqlDbType.VarChar, ParameterDirection.Input, 25, null);
                objSql.AddParameter(objCmd, "pmobileOtp", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "pemailOtp", MySqlDbType.VarChar, ParameterDirection.Input, 25, null);
                objSql.AddParameter(objCmd, "pcreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 25, null);
                strRetVal = objCmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
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



        public List<SignUp> ListAllSignUp()
        {
            List<SignUp> lst = new List<SignUp>();
            DataTable dt = new DataTable();
            SQLDAL objSql = new SQLDAL();
            MySqlCommand objCmd = new MySqlCommand();
            MySqlDataAdapter objda = new MySqlDataAdapter();
            try
            {
                conn.Open();
                objCmd = objSql.CreateCommand(objCmd, CommandType.StoredProcedure, "signupSp");
                objSql.AddParameter(objCmd, "pAction", MySqlDbType.VarChar, ParameterDirection.Input, 50, "selectsignin");
                objSql.AddParameter(objCmd, "psignupId", MySqlDbType.Int32, ParameterDirection.Input, 50, null);
                objSql.AddParameter(objCmd, "pfullName", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "peMail", MySqlDbType.VarChar, ParameterDirection.Input, 25, null);
                objSql.AddParameter(objCmd, "pmobileNo", MySqlDbType.VarChar, ParameterDirection.Input, 50, null);
                objSql.AddParameter(objCmd, "ppwd", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "pcpwd", MySqlDbType.VarChar, ParameterDirection.Input, 25, null);
                objSql.AddParameter(objCmd, "pmobileOtp", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "pemailOtp", MySqlDbType.VarChar, ParameterDirection.Input, 25, null);
                objSql.AddParameter(objCmd, "pcreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 25, null);
                objda.SelectCommand = objCmd;
                objda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    lst.Add(new SignUp
                        {
                            SignUpUserId = Convert.ToInt32(dr["signupUserId"]),
                            fullName = Convert.ToString(dr["fullName"]),
                            email = Convert.ToString(dr["eMail"]),
                            mobileNo = Convert.ToString(dr["mobileNo"]),
                            pwd = Convert.ToString(dr["pwd"]),
                            cpwd = Convert.ToString(dr["cpwd"]),
                            mobileOtp = Convert.ToString(dr["mobileOtp"]),
                            emailOtp = Convert.ToString(dr["emailOtp"]),
                            mobileverify = Convert.ToString(dr["mobileVerify"]),
                            emailverify = Convert.ToString(dr["emailVerify"])
                        });
                }
                
            }
            catch (Exception ex)
            {
                return lst;
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
            return lst;
        }

        public DataTable VerifyMobileOtp(string strMobileNo,string strMobOTP)
        {
            DataTable dtVendorInfo = new DataTable();
            SQLDAL objSql = new SQLDAL();
            MySqlCommand objCmd = new MySqlCommand();
            MySqlDataAdapter objda = new MySqlDataAdapter();
            try
            {
                objCmd = objSql.CreateCommand(objCmd, CommandType.StoredProcedure, "signupSp");
                objSql.AddParameter(objCmd, "pAction", MySqlDbType.VarChar, ParameterDirection.Input, 20, "verifymobileotp");
                objSql.AddParameter(objCmd, "psignupId", MySqlDbType.Int32, ParameterDirection.Input, 50, null);
                objSql.AddParameter(objCmd, "pfullName", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "peMail", MySqlDbType.VarChar, ParameterDirection.Input, 25, null);
                objSql.AddParameter(objCmd, "pmobileNo", MySqlDbType.VarChar, ParameterDirection.Input, 50, strMobileNo);
                objSql.AddParameter(objCmd, "ppwd", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "pcpwd", MySqlDbType.VarChar, ParameterDirection.Input, 25, null);
                objSql.AddParameter(objCmd, "pmobileOtp", MySqlDbType.VarChar, ParameterDirection.Input, 200, strMobOTP);
                objSql.AddParameter(objCmd, "pemailOtp", MySqlDbType.VarChar, ParameterDirection.Input, 25, null);
                objSql.AddParameter(objCmd, "pcreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 25, null);
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

        public DataTable VerifyEmailOtp(string strEmail, string strEmailOTP)
        {
            DataTable dtVendorInfo = new DataTable();
            SQLDAL objSql = new SQLDAL();
            MySqlCommand objCmd = new MySqlCommand();
            MySqlDataAdapter objda = new MySqlDataAdapter();
            try
            {
                objCmd = objSql.CreateCommand(objCmd, CommandType.StoredProcedure, "signupSp");
                objSql.AddParameter(objCmd, "pAction", MySqlDbType.VarChar, ParameterDirection.Input, 20, "verifyemailotp");
                objSql.AddParameter(objCmd, "psignupId", MySqlDbType.Int32, ParameterDirection.Input, 50, null);
                objSql.AddParameter(objCmd, "pfullName", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "peMail", MySqlDbType.VarChar, ParameterDirection.Input, 25, strEmail);
                objSql.AddParameter(objCmd, "pmobileNo", MySqlDbType.VarChar, ParameterDirection.Input, 50, null);
                objSql.AddParameter(objCmd, "ppwd", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "pcpwd", MySqlDbType.VarChar, ParameterDirection.Input, 25, null);
                objSql.AddParameter(objCmd, "pmobileOtp", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "pemailOtp", MySqlDbType.VarChar, ParameterDirection.Input, 25, strEmailOTP);
                objSql.AddParameter(objCmd, "pcreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 25, null);
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

        public DataTable DtGetAllSignUp()
        {
            DataTable dtVendorInfo = new DataTable();
            SQLDAL objSql = new SQLDAL();
            MySqlCommand objCmd = new MySqlCommand();
            MySqlDataAdapter objda = new MySqlDataAdapter();
            try
            {
                objCmd = objSql.CreateCommand(objCmd, CommandType.StoredProcedure, "signupSp");
                objSql.AddParameter(objCmd, "pAction", MySqlDbType.VarChar, ParameterDirection.Input, 20, "selectverifiedsignin");
                objSql.AddParameter(objCmd, "psignupId", MySqlDbType.Int32, ParameterDirection.Input, 50, null);
                objSql.AddParameter(objCmd, "pfullName", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "peMail", MySqlDbType.VarChar, ParameterDirection.Input, 25, null);
                objSql.AddParameter(objCmd, "pmobileNo", MySqlDbType.VarChar, ParameterDirection.Input, 50, null);
                objSql.AddParameter(objCmd, "ppwd", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "pcpwd", MySqlDbType.VarChar, ParameterDirection.Input, 25, null);
                objSql.AddParameter(objCmd, "pmobileOtp", MySqlDbType.VarChar, ParameterDirection.Input, 200, null);
                objSql.AddParameter(objCmd, "pemailOtp", MySqlDbType.VarChar, ParameterDirection.Input, 25, null);
                objSql.AddParameter(objCmd, "pcreatedBy", MySqlDbType.Int32, ParameterDirection.Input, 25, null);
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
