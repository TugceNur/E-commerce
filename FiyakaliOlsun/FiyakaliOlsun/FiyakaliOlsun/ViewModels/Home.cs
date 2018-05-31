using FiyakaliOlsun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiyakaliOlsun.ViewModels
{
    public class HomeIndex
    {
        public IEnumerable<Urunler> urunler { get; set; }

    }
    public class HomeSepet
    {
        public int? Id { get; set; }
        public int mId { get; set; }
        public int uId { get; set; }
        public int fiyat { get; set; }
        public int adet { get; set; }
    }
}