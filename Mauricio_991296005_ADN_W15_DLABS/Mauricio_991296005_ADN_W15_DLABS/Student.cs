//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mauricio_991296005_ADN_W15_DLABS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }
    
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string selectedCourses { get; set; }
        public string StudentNum { get; set; }
    
        public virtual ICollection<Course> Courses { get; set; }
    }
}
