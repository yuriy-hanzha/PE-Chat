using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Identity;
using PE_Chat.Data.Entities;
using System.Threading.Tasks;

namespace PE_Chat.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        ApplicationDbContext _dbContext;
        public ChatHub()
        {
            _dbContext = new ApplicationDbContext();
        }

        public void SendMessage(string messageBody)
        {
            if (string.IsNullOrEmpty(messageBody))
                return;

            var userId = Context.User.Identity.GetUserId();
            var user = _dbContext.Users.FirstOrDefault(item => item.Id == userId);
            var mess = new Message()
            {
                Author = user,
                Text = messageBody
            };
            Clients.All.broadcastMessage(user.UserName, messageBody, mess.AddedDate.ToString());

            _dbContext.Messages.Add(mess);
            _dbContext.SaveChanges();
        }

        //public override Task OnDisconnected(bool stopCalled)
        //{
        //    var userId = Context.User.Identity.GetUserId();
        //    var user = _dbContext.Users.FirstOrDefault(item => item.Id == userId);
        //    Clients.Others.userDisconnect(user.UserName);
        //    return base.OnDisconnected(stopCalled);
        //}

        //public override Task OnConnected()
        //{
        //    var userId = Context.User.Identity.GetUserId();
        //    var user = _dbContext.Users.FirstOrDefault(item => item.Id == userId);
        //    Clients.Others.userConnect(user.UserName);
        //    return base.OnConnected();
        //}
    }
}