using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPECB_Technical_Assessment.HelperMethods
{
    public class HelperReturnMessages
    {
        public static string BootstrapAlertSuccess(string msg)
        {
            return "<div class=\"alert alert-success\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">×</button>" + msg + "</div>";
        }

        public static string BootstrapAlertFailed(string msg)
        {
            return "<div class=\"alert alert-danger\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">×</button>" + msg + "</div>";
        }
    }
}