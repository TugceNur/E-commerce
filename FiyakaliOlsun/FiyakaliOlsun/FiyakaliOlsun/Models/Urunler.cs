using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiyakaliOlsun.Models
{
    public class Urunler
    {
        public virtual int Id { get; set; }
        public virtual string UrunAdi { get; set; }
        public virtual string UrunResmi { get; set; }
        public virtual string Aciklama { get; set; }
        public virtual int Fiyat { get; set; }

    }
    public class UrunlerMap : ClassMapping<Urunler>
    {
        public UrunlerMap()
        {
            Table("urunler");
            Id(x => x.Id, x => x.Generator(Generators.Identity));
            Property(x => x.UrunAdi, x => x.NotNullable(true));
            Property(x => x.UrunResmi, x => x.NotNullable(true));
            Property(x => x.Aciklama, x => x.NotNullable(true));
            Property(x => x.Fiyat, x => x.NotNullable(true));
        }
    }
}