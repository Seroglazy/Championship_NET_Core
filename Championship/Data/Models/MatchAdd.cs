using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Championship.Data.Models
{
    public class MatchAdd
    {


        [BindNever]
        public int id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string win { get; set; }
        public string lose { get; set; }
        public string comment { get; set; }
        [DataType(DataType.DateTime)]
        [Required(AllowEmptyStrings = false,ErrorMessage = "Неверный формат даты")]
        public DateTime time { get; set; }

    }
}
