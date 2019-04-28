/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：IBaseRepositoryTest                                                    
*│　作    者：yilezhu                                             
*│　版    本：1.0                                                 
*│　创建时间：2019/4/27 20:49:12                             
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;
using Czar.EasyEFCore.Test.Entity;
using Xunit;
using Czar.EasyEFCore.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Czar.EasyEFCore.Test
{
    public class IBaseRepositoryTest
    {
        [Fact]
        public void GetPagedList_TEntity_Test()
        {
            using (var context = SeedData.GetDbContext())
            {
                var baseRepository = new BaseRepository<Student>(context);
                var page = baseRepository.GetPagedList(s => s.Age > 12, orderBy: s => s.OrderByDescending(s => s
                        .Id), include: s => s.Include(t => t.Enrollments).ThenInclude(x => x.Course), pageSize: 2);
                Assert.Equal(2, page.Items.Count);
                Assert.Equal(5, page.TotalCount);
                Assert.Equal(3, page.TotalPages);
                Assert.Equal(7, page.Items[0].Id);
                Assert.Equal("Student7", page.Items[0].Name);
                Assert.Equal(17, page.Items[0].Age);
                Assert.Equal(1, page.Items[0].Enrollments.Count);
                Assert.Equal(1, page.Items[0].Enrollments.FirstOrDefault().CourseId);
            }

        }

        [Fact]
        public async System.Threading.Tasks.Task GetPagedList_TEntity_TestAsync()
        {
            using (var context = SeedData.GetDbContext())
            {
                var baseRepository = new BaseRepository<Student>(context);
                var page = await baseRepository.GetPagedListAsync(s => s.Age > 12, orderBy: s => s.OrderByDescending(s => s
                        .Id), include: s => s.Include(t => t.Enrollments).ThenInclude(x => x.Course), pageSize: 2);
                Assert.Equal(2, page.Items.Count);
                Assert.Equal(5, page.TotalCount);
                Assert.Equal(3, page.TotalPages);
                Assert.Equal(7, page.Items[0].Id);
                Assert.Equal("Student7", page.Items[0].Name);
                Assert.Equal(17, page.Items[0].Age);
                Assert.Equal(1, page.Items[0].Enrollments.Count);
                Assert.Equal(1, page.Items[0].Enrollments.FirstOrDefault().CourseId);
            }

        }

        [Fact]
        public void GetPagedList_TResult_Test()
        {
            using (var context = SeedData.GetDbContext())
            {
                var baseRepository = new BaseRepository<Student>(context);
                var page = baseRepository.GetPagedList(s => s.Age > 12, orderBy: s => s.OrderByDescending(s => s
                        .Id), include: s => s.Include(t => t.Enrollments).ThenInclude(x => x.Course), pageSize: 2);
                Assert.Equal(2, page.Items.Count);
                Assert.Equal(5, page.TotalCount);
                Assert.Equal(3, page.TotalPages);
                Assert.Equal(7, page.Items[0].Id);
                Assert.Equal("Student7", page.Items[0].Name);
                Assert.Equal(17, page.Items[0].Age);
                Assert.Equal(1, page.Items[0].Enrollments.Count);
            }
        }
    }
}
