using LuckyD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckyD.ViewModel
{
    public class CustomViewModel
    {
        public WinningNumber WinningNumber { get; set; }
        public Price Price { get; set; }
        public IEnumerable<Price> Prices { get; set; }

    }
}