using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Championship.Data;
using Microsoft.AspNetCore;
using Championship.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Championship.Controllers 
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {
            return View();
        }
    }
}
