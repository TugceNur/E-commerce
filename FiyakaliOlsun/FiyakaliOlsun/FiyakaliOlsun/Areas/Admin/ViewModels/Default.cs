using FiyakaliOlsun.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FiyakaliOlsun.Areas.Admin.ViewModels
{
    public class DefaultIndex
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class DefaultKayit
    {
        [Required, MaxLength(128)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
    public class DefaultHome
    {
        public IEnumerable<Admin_Kullanici>Kullanici { get; set; }
    }
    public class DefaultEdit
    {
        [Required, MaxLength(128)]
        public string Username { get; set; }

        [Required]
        [MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
    public class DefaultResetPassword
    {
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

    }
}