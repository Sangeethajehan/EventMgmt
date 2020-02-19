using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEvent.Models
{
    public class SignUp
    {
        public int SignUpUserId { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string mobileNo { get; set; }
        public string pwd { get; set; }
        public string cpwd { get; set; }
        public string mobileOtp { get; set; }
        public string emailOtp { get; set; }
        public string mobileverify { get; set; }
        public string emailverify { get; set; }
        public int createdBy { get; set; }
    }
}