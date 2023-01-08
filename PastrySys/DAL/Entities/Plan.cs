using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Plan
    {
        [Key]
        public int plan_id { get; set; }
        public DateTime deadline { get; set; }
        public String status { get; set; }

        List<Order> orders { get; set; }

    }
}
