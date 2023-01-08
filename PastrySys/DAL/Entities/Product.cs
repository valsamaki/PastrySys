using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Product
    {
        [Key]
        public int product_id { get; set; }
        public String status { get; set; }
    }
}
