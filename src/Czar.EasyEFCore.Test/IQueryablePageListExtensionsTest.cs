/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：IQueryablePageListExtensionsTest                                                    
*│　作    者：yilezhu                                             
*│　版    本：1.0                                                 
*│　创建时间：2019/4/28 22:27:53                             
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Czar.EasyEFCore.Test.Entity;
using Xunit;
using Czar.EasyEFCore.Core;

namespace Czar.EasyEFCore.Test
{
    public class IQueryablePageListExtensionsTest
    {
        [Fact]
        public async System.Threading.Tasks.Task ToPagedListAsync_TestAsync()
        {
            using (var context = SeedData.GetDbContext())
            {
                var items = context.Students.Where(x => x.Age > 12);
                var page = await items.ToPagedListAsync(0, 2);
                Assert.NotNull(page);
                Assert.Equal(2, page.Items.Count);
                Assert.Equal(5, page.TotalCount);
                Assert.Equal(3, page.TotalPages);
                Assert.Equal(3, page.Items[0].Id);
                Assert.Equal("Student3", page.Items[0].Name);
                Assert.Equal(13, page.Items[0].Age);
                page = await items.ToPagedListAsync(2, 2);
                Assert.NotNull(page);
                Assert.Equal(1, page.Items.Count);
                Assert.Equal(5, page.TotalCount);
                Assert.Equal(3, page.TotalPages);
                Assert.Equal(7, page.Items[0].Id);
                Assert.Equal("Student7", page.Items[0].Name);
                Assert.Equal(17, page.Items[0].Age);
            }

        }
    }
}
