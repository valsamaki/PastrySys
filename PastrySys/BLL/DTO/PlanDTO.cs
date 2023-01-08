using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class PlanDTO
    {
        public int plan_id { get; set; }
        public DateTime deadline { get; set; }
        public String status { get; set; }

        List<Order> orders { get; set; }
    }
}
