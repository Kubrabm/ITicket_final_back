using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ITicket.DAL.Data
{
    public class RequestEmail
    {

        public string ToEmail { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
