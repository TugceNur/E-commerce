using FiyakaliOlsun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FiyakaliOlsun.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace FiyakaliOlsun.Areas.Admin.ViewModels
{
    public class PostIndex
    {
     public PagedData<Urunler> Posts { get; set; }
    }
    public class PostForm
    {
        public bool IsNew { get; set; }
        public int? urunId { get; set; }
        public string urunAdi { get; set; }

        [Required]
        public string urunResim { get; set; }

        [Required]
        public int Fiyat { get; set; }

        [Required, DataType(DataType.MultilineText)]
        public string Aciklama { get; set; }
    }
}