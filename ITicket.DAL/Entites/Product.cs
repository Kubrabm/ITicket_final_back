using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITicket.DAL.Entites
{
    public class Product : TimeStample
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
    }
}
