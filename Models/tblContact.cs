using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace CoreEnt.Models;


public class tblContact
{
    [Key]
    public int ContactId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? Contact { get; set; }
    public string? Address { get; set; }
    
     public tblUser User { get; set; }
}
