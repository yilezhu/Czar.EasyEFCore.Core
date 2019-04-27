/*
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：Course                                                    
*│　作    者：yilezhu                                             
*│　版    本：1.0                                                 
*│　创建时间：2019/4/27 20:29:40                             
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.EasyEFCore.Test.Entity
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
