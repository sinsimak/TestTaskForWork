﻿using System.Web;
using System.Web.Mvc;

namespace Bank_MVC_Web_App
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}