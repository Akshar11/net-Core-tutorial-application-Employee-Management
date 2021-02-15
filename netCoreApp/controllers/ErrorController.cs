using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace netCoreApp.controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{StatusCode}")]
        public IActionResult ShowErrorPage(int StatusCode)
        {
            string text;
            switch (StatusCode)
            {
                case 404:
                    text = "Sorry , Requested Page do not exist.Let's try something else";
                    break;
                default:
                    text = "Resource not available";
                    break;
            }
            ViewBag.message = text;
            ViewBag.statusCode = StatusCode;
            return View("ErrorPage");
        }
    }
}
