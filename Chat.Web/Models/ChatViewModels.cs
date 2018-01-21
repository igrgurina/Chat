using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Chat.Web.Models
{
    public class ChatViewModel
    {
        public List<Message> Messages { get; set; }

        public List<ApplicationUser> Users { get; set; }
    }
}