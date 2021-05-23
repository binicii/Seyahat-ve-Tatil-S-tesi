 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Seyahat.Models.Siniflar
{
    public class Context : DbContext  /* VERİ TABANLARI ARASINDA İLİŞKİ KURDUK*/

    {
        internal List<iletisimler> deger;

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdresBlog> AdresBlogs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Hakkımızda> Hakkımızdas { get; set; }
        public DbSet<iletisimler> iletisims { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }

    }
}