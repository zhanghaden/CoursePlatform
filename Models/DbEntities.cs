using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Models
{
    public class DBEntities : DbContext
    {
        //public DbSet<Admin> Admin { get; set; }
        public DbSet<Tb_ApplySoftList> Tb_ApplySoftList { get; set; }
        public DbSet<Tb_ApplyTable> Tb_ApplyTable { get; set; }
        public DbSet<Tb_SoftCourse> Tb_SoftCourse { get; set; }
        public DbSet<Tb_SoftList> Tb_SoftList { get; set; }
        public DbSet<Tb_SoftUser> Tb_SoftUser { get; set; }
       

        //第一次请求时 会根据数据库连接字符串 和model 创建数据库
        public DBEntities()
            : base("name=DBEntities")
        {
            // 如果数据库不存在 则创建。
            //Database.SetInitializer<DBEntities>(new DropCreateDatabaseIfModelChanges<DBEntities>());
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}