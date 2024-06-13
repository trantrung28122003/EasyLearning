using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EasyLearning.Infrastructure.Data.Entities
{
    public class Email
    {
        public string From { get; set; }
        public string toEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
