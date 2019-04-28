/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：IEnumerablePagedListExtensionsTest                                                    
*│　作    者：yilezhu                                             
*│　版    本：1.0                                                 
*│　创建时间：2019/4/28 21:30:22                             
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Czar.EasyEFCore.Test.Entity;
using Czar.EasyEFCore.Core;
using System.Threading.Tasks;
using Xunit;

namespace Czar.EasyEFCore.Test
{
    public class IEnumerablePagedListExtensionsTest
    {
        [Fact]
        public void ToPagedListT_Test()
        {
            using (var context = SeedData.GetDbContext())
            {
                Func<Student, bool> func = x => x.Age > 12;
                var items = context.Students.Where(func);
                var page = items.ToPagedList(0, 2);
                Assert.NotNull(page);
                Assert.Equal(2, page.Items.Count);
                Assert.Equal(5, page.TotalCount);
                Assert.Equal(3, page.TotalPages);
                Assert.Equal(3, page.Items[0].Id);
                Assert.Equal("Student3", page.Items[0].Name);
                Assert.Equal(13, page.Items[0].Age);
                page = items.ToPagedList(2, 2);
                Assert.NotNull(page);
                Assert.Equal(1, page.Items.Count);
                Assert.Equal(5, page.TotalCount);
                Assert.Equal(3, page.TotalPages);
                Assert.Equal(7, page.Items[0].Id);
                Assert.Equal("Student7", page.Items[0].Name);
                Assert.Equal(17, page.Items[0].Age);
            }   
        }

        [Fact]
        public void ToPagedListTResult_Test()
        {
            Func<Student, bool> func = x => x.Age > 12;
            
        }

        public class StudentResult
        {
            public string FullName { get; set; }
            public int Age { get; set; }

            public ICollection<Enrollment> Enrollments { get; set; }
        }
    }
}
