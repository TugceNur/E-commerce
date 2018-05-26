using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiyakaliOlsun.Models
{
    public class Admin_Kullanici
    {
        public virtual int Id { get; set; }
        public virtual string KullaniciAdi { get; set; }
        public virtual int Parola { get; set; }
    }
    public class AdminKullaniciMap : ClassMapping<Admin_Kullanici>
    {
        public AdminKullaniciMap()
        {
            Table("adminKullanici");
            Id(x => x.Id, x => x.Generator(Generators.Identity));
            Property(x => x.KullaniciAdi, x => x.NotNullable(true));
            Property(x => x.Parola, x => x.NotNullable(true));
        }
    }
}