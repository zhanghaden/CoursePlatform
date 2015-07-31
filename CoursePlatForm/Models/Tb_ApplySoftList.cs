namespace CoursePlatForm.Models
{
    using System;
    using System.Collections.Generic;
    
    public class Tb_ApplySoftList
    {
        public int ApplySoftID { get; set; }
        public string SoftCourseName { get; set; }
        public Nullable<int> TrainNumPerYear { get; set; }
        public Nullable<int> ApplyNum { get; set; }
        public Nullable<int> ApplyID { get; set; }
        public Nullable<int> SoftID { get; set; }
    }
}