﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HiSpaceListingWeb.Controllers
{
    public class ListingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}