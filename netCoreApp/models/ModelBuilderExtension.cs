using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCoreApp.models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                  new Employee() { Id = 1, Department = Dept.FrontEnd, Email = "a@a.com", Name = "n1" },
                  new Employee() { Id = 2, Department = Dept.BackEnd, Email = "a@b.com", Name = "n2" },
                  new Employee() { Id = 3, Department = Dept.UI, Email = "a@c.com", Name = "n3" }
              );
        }
    }
}
