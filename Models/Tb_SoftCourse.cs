namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tb_SoftCourse
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string SoftPlatform { get; set; }
        public Nullable<int> StuNum { get; set; }
        public Nullable<int> ApplyID { get; set; }
    }
}
