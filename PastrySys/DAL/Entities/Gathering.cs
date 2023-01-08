using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Gathering
    {
        [Key]
        public int gathering_id { get; set; }
        public DateTime date { get; set; }
        public String status { get; set; }
    }
}
