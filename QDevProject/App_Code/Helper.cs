using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace QDevProject.App_Code
{
    public class Helper
    {

        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        }

    }
}