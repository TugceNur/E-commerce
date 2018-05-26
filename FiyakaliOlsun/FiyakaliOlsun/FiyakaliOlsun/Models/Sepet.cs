using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiyakaliOlsun.Models
{
    public class Sepet
    {
        public virtual int Id { get; set; }
        public virtual Urunler UrunId { get; set; }
        public virtual int ToplamTutar { get; set; }
        public virtual int Adet { get; set; }
    }

    public class SepetMap : ClassMapping<Sepet>
    {
        public SepetMap()
        {
            Table("sepet");
            Id(x => x.Id, x => x.Generator(Generators.Identity));
            ManyToOne(x => x.UrunId, x =>
            {
                x.Column("urunId");
                x.NotNullable(true);
            });
            Property(x => x.ToplamTutar, x => x.NotNullable(true));
            Property(x => x.Adet, x => x.NotNullable(true));
        }
    }
}