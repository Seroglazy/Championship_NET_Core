using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace Championship.Data.Models
{
    public class Players
    {
        public int Id { set; get; }
        public string Profile { set; get; }
        public string Alias { set; get; }
        public string Pass { set; get; }
        //public string Img { set; get; }
        public int Rating { set; get; }
    }
}
