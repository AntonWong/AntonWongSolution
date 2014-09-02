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
            //����
            var departments = new[]
            {
                new Department {Name = "������"},
                new Department {Name = "����"}
            };
            context.Departments.AddOrUpdate(m => new {m.Name}, departments);
            context.SaveChanges();

            //��ɫ
            var roles = new[]
            {
                new Role {Name = "����������", Department = context.Departments.Single(m => m.Name == "������")},
                new Role {Name = "�����ܼ�", Department = context.Departments.Single(m => m.Name == "������")},
                new Role {Name = "������Ա", Department = context.Departments.Single(m => m.Name == "������")},
                new Role {Name = "���񲿾���", Department = context.Departments.Single(m => m.Name == "����")},
                new Role {Name = "���", Department = context.Departments.Single(m => m.Name == "����")}
            };
            context.Roles.AddOrUpdate(m => new {m.Name}, roles);
            context.SaveChanges();

            //��Ա
            var members = new[]
            {
                new Member
                {
                    UserName = "������",
                    Password = "123456",
                    Roles = new HashSet<Role>
                    {
                        context.Roles.Single(m => m.Name == "������Ա")
                    }
                }
            };
            context.Members.AddOrUpdate(m => new {m.UserName}, members);
            context.SaveChanges();
        }
    }
}
