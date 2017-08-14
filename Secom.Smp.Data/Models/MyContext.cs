/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Data.Models
* 文件名: MyContext
* 创建者: 邹琼俊
* 创建时间: 2017/6/26 10:34:38
* 版权所有： 紫衡技术
******************************************************************/
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Secom.Smp.Data.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MyContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“MyContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“CodeFirstDemo.Models.MyContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“MyContext”
        //连接字符串。
        public MyContext()
            : base("name=MyContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //解决EF动态建库数据库表名变为复数问题  
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OperatorLog> OperatorLogs { get; set; }
    }
}