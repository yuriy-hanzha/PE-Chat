using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PE_Chat.Data.Entities
{
    public class User: IdentityUser
    {
        public virtual ICollection<Message> Messages { get; set; } 

        public User()
        {
            Messages = new HashSet<Message>();
        }
    }
}