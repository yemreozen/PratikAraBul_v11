using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #region Debug Mode
            //string connectionString = "Server=94.73.148.205;Database=u1352190_pratika;User=u1352190_prtk34;Password=EmreBengu030521;";
            //ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);
            //optionsBuilder.UseMySql(connectionString, serverVersion);
            #endregion

            #region Publish Mode
            string connectionString = "  Server = localhost; Database = u1352190_pratika; Uid = u1352190_prtk34; Pwd = EmreBengu030521;";
            ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);
            optionsBuilder.UseMySql(connectionString, serverVersion);
            #endregion
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Writer> Writers { get; set; }
        public DbSet<BlogTags> BlogsTags { get; set; }
        public DbSet<CalculationText> CalculationTexts { get; set; }

    }
}
