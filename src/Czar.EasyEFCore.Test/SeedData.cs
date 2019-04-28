/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：SeedData                                                    
*│　作    者：yilezhu                                             
*│　版    本：1.0                                                 
*│　创建时间：2019/4/28 21:32:06                             
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Czar.EasyEFCore.Test.Entity;
using Microsoft.EntityFrameworkCore;

namespace Czar.EasyEFCore.Test
{
    public class SeedData
    {

        public static SchoolContext GetDbContext()
        {
            var context = new SchoolContext();
            if (context.Students.Any())
            {
                return context;
            }
            context.AddRange(SeedData.GetStudents);
            context.AddRange(SeedData.GetCourses);
            context.AddRange(SeedData.GetEnrollments);
            context.SaveChanges();
            return context;
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
