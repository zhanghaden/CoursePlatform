namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tb_SoftCourse
    {
        [Key]
        [Display(Name = "课程ID")]
        public int CourseID { get; set; }
        [Display(Name = "课程名称")]
        public string CourseName { get; set; }
        [Display(Name = "软件使用的平台")]
        public string SoftPlatform { get; set; }
        [Display(Name = "培养学生人数")]
        public Nullable<int> StuNum { get; set; }
        [Display(Name = "申请表ID")]
        public Nullable<int> ApplyID { get; set; }
    }
}
