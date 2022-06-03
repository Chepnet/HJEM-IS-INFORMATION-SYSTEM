using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _HJEM_IS__NOTIFICATION_SYSTEM1
{
    class Message
    {
        private int _MessageId = 0;
        private string _CustomerId = "";
        private string _Messages = "";
        private string _Subject = "";
        private DateTime _Date = DateTime.Now;
        public int MessageId { get { return _MessageId; } set { _MessageId = value; } }
        public string CustomerId { get { return _CustomerId; } set { _CustomerId = value; } }
        public string Messages { get { return _Messages; } set { _Messages = value; } }
        public string Subject { get { return _Subject; } set { _Subject = value; } }
        public DateTime MessageDate { get { return _Date; } set { _Date = value; } }
    }
}
