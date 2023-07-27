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
        
        public IActionResult Index(int id=0)
        {         
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId"))) 
            {           
                return RedirectToAction("Login","User");
            }
            else
            {
                var context = new CoreDBContext();
                if(id!=0)
                {
                    var delContact=context.tblContact.Where(
                    data =>data.ContactId==id).FirstOrDefault();
                   context.tblContact.Remove(delContact);
                   context.SaveChanges();
                }
                
                var data=context.tblContact.Where(
                    data =>data.UserId == Convert.ToInt32(HttpContext.Session.GetString("_userId")) )
                .ToList(); 
                return View(data);
            }
            
        }
        public IActionResult Add(int id=0)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("_userId"))) 
            {           
                return RedirectToAction("Login","User");
            }
            else
            {
                var context = new CoreDBContext();
                tblContact editContact=new tblContact();
                if(id>0)
                {
                    editContact=context.tblContact.Where(
                    data =>data.ContactId==id).FirstOrDefault();                   
                }
                return View(editContact);
            }
        }
        [HttpPost]
        public IActionResult Add(tblContact data)
        {
            var context = new CoreDBContext();
            if(data.ContactId==0)
            {
                data.UserId=Convert.ToInt32( HttpContext.Session.GetString("_userId"));
                context.tblContact.Add (data);        
                context.SaveChanges();
            }
            else
            {
                    var editContact=context.tblContact.Where(
                    tbldata =>tbldata.ContactId==data.ContactId).FirstOrDefault();    
                    editContact.Name=data.Name;
                    editContact.Address =data.Address ;
                    editContact.Email = data.Email ;
                    editContact.Contact =data.Contact ;
                    context.SaveChanges();
 
            }
            return RedirectToAction("Index","Contact");          
        }

    }
}