using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PE_Chat.Data.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public DateTime AddedDate { get; set; }

        public string Text { get; set; }

        public virtual User Author { get; set; }
    }
}