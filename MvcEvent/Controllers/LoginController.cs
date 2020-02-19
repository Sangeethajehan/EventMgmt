using MvcEvent.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEvent.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        SignUpDal SignUpDal = new SignUpDal();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public JsonResult login(Login login)
        {
            var result = new { Success = "false" };
            List<SignUp> lst = new List<SignUp>();
            DataTable dt = SignUpDal.DtGetAllSignUp();
            if (dt.Rows.Count > 0)
            {
                var SelRow = dt.Select("email='" + login.email + "' AND pwd='" + login.pwd + "' ");
                if (SelRow != null && SelRow.Length > 0)
                {
                    dt = SelRow.CopyToDataTable();
                    lst.Add(new SignUp
                    {
                        SignUpUserId = Convert.ToInt32(dt.Rows[0]["signupUserId"]),
                        fullName = Convert.ToString(dt.Rows[0]["fullName"]),
                        email = Convert.ToString(dt.Rows[0]["eMail"]),
                        mobileNo = Convert.ToString(dt.Rows[0]["mobileNo"]),
                        pwd = Convert.ToString(dt.Rows[0]["pwd"]),
                        cpwd = Convert.ToString(dt.Rows[0]["cpwd"]),
                        mobileOtp = Convert.ToString(dt.Rows[0]["mobileOtp"]),
                        emailOtp = Convert.ToString(dt.Rows[0]["emailOtp"]),
                        mobileverify = Convert.ToString(dt.Rows[0]["mobileVerify"]),
                        emailverify = Convert.ToString(dt.Rows[0]["emailVerify"])
                    });
                    return Json(new { Success = "true", User = lst });

                }
                else
                {
                    return Json(result);
                }
            }
            else
            {
                return Json(result);
            }
        }
    }
}
