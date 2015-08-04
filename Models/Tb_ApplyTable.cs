namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tb_ApplyTable
    {
        [Key]
        public int ApplyID { get; set; }
        public string UnitNameCH { get; set; }
        public string UnitNameEN { get; set; }
        public string ChargePerson { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UnitAddress { get; set; }
        public string ZipCode { get; set; }
        public string UnitIntro { get; set; }
        [Display(Name = "教师数量")]
        [Required(ErrorMessage = "请输入{0}")]
        [StringLength(20, ErrorMessage = "{0}在{2}位至{1}位之间", MinimumLength = 1)]
        [Range(20, 40)]
        public Nullable<int> TeacherNum { get; set; }
        public Nullable<int> StuNum { get; set; }
        public Nullable<int> Gradu2015Num { get; set; }
        public Nullable<int> SeniorTitleNum { get; set; }
        public Nullable<int> IntermediateTitleNum { get; set; }
        public Nullable<int> OtherTitleNum { get; set; }
        public Nullable<int> TechTeacherNum { get; set; }
        public Nullable<int> AuthTechTeacherNum { get; set; }
        public Nullable<double> EngineRoomArea { get; set; }
        public string ComputerNumConfig { get; set; }
        public Nullable<System.DateTime> RecordTime { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> IsPass { get; set; }//默认为0即不通过
    }
}