using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class OrderDTO
    {
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
