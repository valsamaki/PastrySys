using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class FabricDTO
    {
        public int fabric_id { get; set; }
        public List<Product> products { get; set; }
        public List<Order> orders { get; set; }
        public List<Plan> plans { get; set; }
        public List<Payment> payments { get; set; }
        public List<Gathering> gatherings { get; set; }
    }
}


