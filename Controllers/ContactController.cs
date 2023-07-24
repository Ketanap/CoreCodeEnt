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
  
    public class ContactController : Controller
    {
        
        public IActionResult Index()
        {         
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId"))) 
            {           
                return RedirectToAction("Login","User");
            }
            else
            {
                var context = new CoreDBContext();
                var data=context.tblContact.Where(
                    data =>data.UserId == Convert.ToInt32(HttpContext.Session.GetString("_userId")) )
                .ToList(); 
                return View(data);
            }
            
        }
        public IActionResult Add()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId"))) 
            {           
                return RedirectToAction("Login","User");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Add(tblContact data)
        {
            var context = new CoreDBContext();
            data.UserId=Convert.ToInt32( HttpContext.Session.GetString("_userId"));
            context.tblContact.Add (data);        
            context.SaveChanges();
            return RedirectToAction("Index","Contact");
          
        }

    }
}