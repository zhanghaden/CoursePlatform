namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Tb_ApplySoftList
    {
        [Key]
        [Display(Name = "申请的软件表主键ID")]
        public int ApplySoftID { get; set; }
        [Display(Name = "用软件开设的课程")]
        public string SoftCourseName { get; set; }
        [Display(Name = "每年培养的学生数量")]
        public Nullable<int> TrainNumPerYear { get; set; }
        [Display(Name = "申请的软件套数")]
        public Nullable<int> ApplyNum { get; set; }
        [Display(Name = "申请表ID")]
        public Nullable<int> ApplyID { get; set; }
        [Display(Name = "软件ID")]
        public Nullable<int> SoftID { get; set; }
    }
}