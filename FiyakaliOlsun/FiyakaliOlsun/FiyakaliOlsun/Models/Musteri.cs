using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiyakaliOlsun.Models
{
    public class Musteri
    {
        public virtual int Id { get; set; }
        public virtual string AdSoyad { get; set; }
        public virtual string email { get; set; }
        public virtual string  Tel { get; set; }
        public virtual string Adres { get; set; }
        public virtual DateTime DogumTarihi { get; set; }
        public virtual string KullaniciAdi { get; set; }
        public virtual int Parola { get; set; }
    }
    public class MusteriMap : ClassMapping<Musteri>
    {
        public MusteriMap()
        {
            Table("Musteri");
            Id(x => x.Id, x => x.Generator(Generators.Identity));

            
            Property(x => x.AdSoyad, x => x.NotNullable(true));
            Property(x => x.email, x => x.NotNullable(true));
            Property(x => x.Tel, x => x.NotNullable(true));
            Property(x => x.Adres, x => x.NotNullable(true));
            Property(x => x.DogumTarihi, x => x.NotNullable(true));
            Property(x => x.KullaniciAdi, x => x.NotNullable(true));
            Property(x => x.Parola, x => x.NotNullable(true));
        }
    }
}