using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }
        public int seller_id { get; set; }
        public String status { get; set; }
        public float cost { get; set; }
        public int amount { get; set; }
        public String recipe { get; set; }

        public DateTime deadline { get; set; }

        public Product product { get; set; }
    }
}
