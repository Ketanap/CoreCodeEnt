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
        public IActionResult Login()
        {
             ViewData["msg"]="";
            return View();
        }
        [HttpPost]
        public IActionResult Login(tblUser u)
        {   
            var context = new CoreDBContext();
            var udata= context.tblUser.Where (eu=>eu.Email ==u.Email && eu.Password ==u.Password ).FirstOrDefault();
            if(udata!=null)
            {
                //  ViewData["msg"]="Login Success";
                return RedirectToAction("Index","Contact");
            }
            else
            {
                ViewData["msg"]="Invalid Email or Password";
                return View();
            }
            
           // return RedirectToAction("Login","User");
        }
 
    }
}