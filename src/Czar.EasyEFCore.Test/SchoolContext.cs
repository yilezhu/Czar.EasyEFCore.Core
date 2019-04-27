/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：SchoolContext                                                    
*│　作    者：yilezhu                                             
*│　版    本：1.0                                                 
*│　创建时间：2019/4/27 20:44:14                             
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Czar.EasyEFCore.Test.Entity;

namespace Czar.EasyEFCore.Test
{
    public class SchoolContext:DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("school");
        }
    }
}
