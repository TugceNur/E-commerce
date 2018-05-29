using FiyakaliOlsun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FiyakaliOlsun.Infrastructure;

namespace FiyakaliOlsun.Areas.Admin.ViewModels
{
    public class PostIndex
    {
     public PagedData<Urunler> Posts { get; set; }
    }
}