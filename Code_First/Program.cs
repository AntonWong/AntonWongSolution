using System;
using System.Data.Entity;
using System.Linq;
using Code_First.Migrations;
using Code_First.Models;

namespace Code_First
{
    internal class Program
    {
        private static void Main()
        {
           
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
                using (var db = new DataContext())
                {
                    //db.Database.Initialize(false);
                    //Console.WriteLine("数据初始化完成：部门信息{0}条，角色信息{1}条，人员信息{2}条", db.Departments.Count(), db.Roles.Count(),
                    //db.Members.Count());


                }
              
            
        }
    }
}
