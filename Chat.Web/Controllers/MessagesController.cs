using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Chat.Web.Models;
using Microsoft.AspNet.Identity;

namespace Chat.Web.Controllers
{
    public class MessagesController : Controller, IChatRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public string GetUsername(string userId)
        {
            return db.Users.SingleOrDefault(u => u.Id == userId)?.UserName;
        }

        public void Add(string userId, string message)
        {
            var _user = db.Users.SingleOrDefault(u => u.Id == userId); // ?? db.Users.SingleOrDefault(u => u.UserName == User.Identity.GetUserName());

            var _message = new Message
            {
                Content = message,
                DateCreated = DateTime.Now,
                Sender = _user,
                Title = String.Empty
            };

            db.Messages.Add(_message);
            db.SaveChanges();
        }

        public async Task<string> GetUsernameAsync(string userId)
        {
            var user = await db.Users.SingleOrDefaultAsync(u => u.Id == userId);

            return user?.UserName;
        }

        public async Task AddAsync(string userId, string message)
        {
            var _user = await db.Users.SingleOrDefaultAsync(u => u.Id == userId); // ?? db.Users.SingleOrDefault(u => u.UserName == User.Identity.GetUserName());

            if (_user == null)
            {
                return;
            }

            var _message = new Message
            {
                Content = message,
                DateCreated = DateTime.Now,
                Sender = _user,
                Title = String.Empty
            };

            db.Messages.Add(_message);
            await db.SaveChangesAsync();
        }
    }
}