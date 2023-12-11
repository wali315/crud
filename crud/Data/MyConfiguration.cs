using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace crud.Data
{
    public static class MyConfiguration
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        }
    }
}