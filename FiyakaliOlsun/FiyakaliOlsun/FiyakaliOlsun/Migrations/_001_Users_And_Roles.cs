using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiyakaliOlsun.Migrations
{
    [Migration(1)]
    public class _001_Urun_Sepet_Musteri_Admin : Migration
    {
        public override void Down()
        {
            Delete.Table("urunler");
            Delete.Table("sepet");
            Delete.Table("musteri");
            Delete.Table("adminKullanici");
        }

        public override void Up()
        {
            Create.Table("urunler")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("urunAdi").AsString(128)
                .WithColumn("urunResim").AsString(128)
                .WithColumn("fiyat").AsInt32()
                .WithColumn("aciklama").AsString(255);

            Create.Table("sepet")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("urunId").AsInt32()
                .WithColumn("toplamTutar").AsInt32()
                .WithColumn("adet").AsInt32();

            Create.Table("musteri")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("adSoyad").AsString(128)
                .WithColumn("email").AsString(128)
                .WithColumn("tel").AsString(128)
                .WithColumn("adres").AsString(255)
                .WithColumn("dogumTarihi").AsDateTime()
                .WithColumn("kullaniciAdi").AsString(30)
                .WithColumn("parola").AsString(30)
                .WithColumn("MusteriId").AsInt32();

            Create.Table("adminKullanici")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("kullaniciAdi").AsString(30)
                .WithColumn("parola").AsString(30)
                .WithColumn("mail").AsString(128);
        }
    }
}