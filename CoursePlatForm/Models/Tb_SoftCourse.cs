namespace CoursePlatForm.Models
{
    using System;
    using System.Collections.Generic;

    public class Tb_SoftCourse
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string SoftPlatform { get; set; }
        public Nullable<int> StuNum { get; set; }
        public Nullable<int> ApplyID { get; set; }
    }
}
