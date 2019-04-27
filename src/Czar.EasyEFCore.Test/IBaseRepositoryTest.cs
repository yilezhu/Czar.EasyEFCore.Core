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
        private static readonly SchoolContext context;

        static IBaseRepositoryTest()
        {
            context = new SchoolContext();
            context.AddRange(GetStudents);
            context.AddRange(GetCourses);
            context.AddRange(GetEnrollments);
            context.SaveChanges();
        }

        [Fact]
        public void GetPagedList_TEntity_Test()
        {
            var baseRepository = new BaseRepository<Student>(context);
            var page = baseRepository.GetPagedList(s=>s.Age>12,orderBy:s=>s.OrderByDescending(s=>s
            .Id), include:s=>s.Include(t=>t.Enrollments).ThenInclude(x=>x.Course),pageSize:2);
            Assert.Equal(2, page.Items.Count);
            Assert.Equal(5, page.TotalCount);
            Assert.Equal(3, page.TotalPages);
            Assert.Equal(7, page.Items[0].Id);
            Assert.Equal("Student7", page.Items[0].Name);
            Assert.Equal(17, page.Items[0].Age);
            Assert.Equal(1, page.Items[0].Enrollments.Count);
            Assert.Equal(1, page.Items[0].Enrollments.FirstOrDefault().CourseId);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetPagedList_TEntity_TestAsync()
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



        public static List<Student> GetStudents => new List<Student> {
            new Student{ Id=1,Name="Student1",Age=11},
            new Student{ Id=2,Name="Student2",Age=12},
            new Student{ Id=3,Name="Student3",Age=13},
            new Student{ Id=4,Name="Student4",Age=14},
            new Student{ Id=5,Name="Student5",Age=15},
            new Student{ Id=6,Name="Student6",Age=16},
            new Student{ Id=7,Name="Student7",Age=17},
        };

        public static List<Course> GetCourses => new List<Course>
        {
            new Course{ Id=1,Title="Course1"},
            new Course{ Id=2,Title="Course2"},
            new Course{ Id=3,Title="Course3"},
            new Course{ Id=4,Title="Course4"},
            new Course{ Id=5,Title="Course5"},
        };

        public static List<Enrollment> GetEnrollments => new List<Enrollment>
        {
            new Enrollment{ Id=1,StudentId=1,CourseId=1},
            new Enrollment{ Id=2,StudentId=2,CourseId=2},
            new Enrollment{ Id=3,StudentId=3,CourseId=3},
            new Enrollment{ Id=4,StudentId=4,CourseId=4},
            new Enrollment{ Id=5,StudentId=5,CourseId=5},
            new Enrollment{ Id=6,StudentId=6,CourseId=1},
            new Enrollment{ Id=7,StudentId=7,CourseId=1},

        };


    }
}
