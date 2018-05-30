using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FiyakaliOlsun.ViewModels
{
    public class AuthIndex
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public int Password { get; set; }
    }
    public class AuthKayit
    {
        [Required]
        public string AdSoyad { get; set; }

        [Required]
        [MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Tel { get; set; }

        [Required]
        public string Adres { get; set; }

        [Required]
        public DateTime DogumTarihi { get; set; }

        [Required, MaxLength(128)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public int Password { get; set; }
    }
}