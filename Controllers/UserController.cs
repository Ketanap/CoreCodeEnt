using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoreEnt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreEnt.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {

        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(tblUser u)
        {   
            var context = new CoreDBContext();
            context.tblUser.Add (u);
            context.SaveChanges();
            return RedirectToAction("Login","User");
        }
    }
}