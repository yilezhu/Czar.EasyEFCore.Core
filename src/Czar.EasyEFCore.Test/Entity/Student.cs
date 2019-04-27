/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：Student                                                    
*│　作    者：yilezhu                                             
*│　版    本：1.0                                                 
*│　创建时间：2019/4/27 20:29:28                             
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.EasyEFCore.Test.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
