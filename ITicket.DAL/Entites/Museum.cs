using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITicket.DAL.Entites
{
    public class Museum : TimeStample
    {
        public string? Name { get; set; }
        public string? ImgUrl { get; set; }
        public string? BgImgUrl { get; set; }
        public string? DetailPageImg { set; get; }
        public string? Date { get; set; }
        public string? Location { get; set; }
        public int? Price { get; set; }
        public int? EeventId { get; set; }
    }
}
