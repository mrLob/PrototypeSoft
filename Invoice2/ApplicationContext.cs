using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace Invoice2
{
    public class ApplicationContext : DbContext
    {
        private string con;

        public DbSet<Table> Invoice2 { get; set; }

        public ApplicationContext(string con)
        {
            this.con = con;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(con);
            //optionsBuilder.UseMySQL(@"User Id = root;Host=127.0.0.1;pwd=root;database=zver;charset=utf8");
        }
    }
}
