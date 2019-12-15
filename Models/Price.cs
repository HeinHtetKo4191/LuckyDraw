using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LuckyD.Models
{
    public class Price
    {
        public int Id { get; set; }
        public string PriceName { get; set; }

        public string Winner { get; set; }

        public string AwardedNumber { get; set; }
        public bool IsAwarded { get; set; }
    }
}