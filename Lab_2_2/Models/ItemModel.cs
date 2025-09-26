using System;

namespace Lab_2_2.Models
{
    public class ItemModel
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public DateTime ReceivedDate { get; set; }
        public DateTime InterestFreePeriodEndDate { get; set; }
        public DateTime DeathLineDate { get; set; }

        public float InterestPerDay { get; set; }

        public ClientModel Owner { get; set; }
    }
}
