using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Code_First.Models;
using Gmf.Demo.EFUpdate.Models;

namespace Code_First.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext context)
        {
            //部门
            var departments = new[]
            {
                new Department {Name = "技术部"},
                new Department {Name = "财务部"}
            };
            context.Departments.AddOrUpdate(m => new {m.Name}, departments);
            context.SaveChanges();

            //角色
            var roles = new[]
            {
                new Role {Name = "技术部经理", Department = context.Departments.Single(m => m.Name == "技术部")},
                new Role {Name = "技术总监", Department = context.Departments.Single(m => m.Name == "技术部")},
                new Role {Name = "技术人员", Department = context.Departments.Single(m => m.Name == "技术部")},
                new Role {Name = "财务部经理", Department = context.Departments.Single(m => m.Name == "财务部")},
                new Role {Name = "会计", Department = context.Departments.Single(m => m.Name == "财务部")}
            };
            context.Roles.AddOrUpdate(m => new {m.Name}, roles);
            context.SaveChanges();

            //人员
            var members = new[]
            {
                new Member
                {
                    UserName = "郭明锋",
                    Password = "123456",
                    Roles = new HashSet<Role>
                    {
                        context.Roles.Single(m => m.Name == "技术人员")
                    }
                }
            };
            context.Members.AddOrUpdate(m => new {m.UserName}, members);
            context.SaveChanges();
        }
    }
}
