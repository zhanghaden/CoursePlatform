namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Tb_ApplySoftList
    {
        [Key]
        public int ApplySoftID { get; set; }
        public string SoftCourseName { get; set; }
        public Nullable<int> TrainNumPerYear { get; set; }
        public Nullable<int> ApplyNum { get; set; }
        public Nullable<int> ApplyID { get; set; }
        public Nullable<int> SoftID { get; set; }
    }
}