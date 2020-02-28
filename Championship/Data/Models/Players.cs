using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;

namespace Championship.Data.Models
{
    public class Players
    {
        public int Id { set; get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя не введено")]
        public string Profile { set; get; }
        public string Alias { set; get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите пароль")]
        public string Pass { set; get; }
        //public string Img { set; get; }
        public int Rating { set; get; }
    }
}
