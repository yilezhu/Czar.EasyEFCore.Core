/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：Enrollment                                                    
*│　作    者：yilezhu                                             
*│　版    本：1.0                                                 
*│　创建时间：2019/4/27 20:26:29                             
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.EasyEFCore.Test.Entity
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }

    }
}
