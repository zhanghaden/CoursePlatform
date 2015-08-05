namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tb_ApplyTable
    {
        [Key]
        [Display(Name = "申请表ID")]
        public int ApplyID { get; set; }
        [Display(Name = "单位中文名称")]
        public string UnitNameCH { get; set; }
        [Display(Name = "单位英文名称")]
        public string UnitNameEN { get; set; }
        [Display(Name = "负责人")]
        public string ChargePerson { get; set; }
        [Display(Name = "联系人")]
        public string ContactPerson { get; set; }
        [Display(Name = "电子信箱")]
        public string Email { get; set; }
        [Display(Name = "电话")]
        public string Phone { get; set; }
        [Display(Name = "单位地址")]
        public string UnitAddress { get; set; }
        [Display(Name = "邮编")]
        public string ZipCode { get; set; }
        [Display(Name = " 单位简介 ")]
        public string UnitIntro { get; set; }
        [Display(Name = "教师人数")]
        [Required(ErrorMessage = "请输入{0}")]
        //[StringLength(20, ErrorMessage = "{0}在{2}位至{1}位之间", MinimumLength = 1)]
        //[Range(20, 40)]
        public Nullable<int> TeacherNum { get; set; }
        [Display(Name = "在校生人数")]
        public Nullable<int> StuNum { get; set; }
        [Display(Name = "2015年毕业生人数 ")]
        public Nullable<int> Gradu2015Num { get; set; }
        [Display(Name = "高级职称教师人数")]
        public Nullable<int> SeniorTitleNum { get; set; }
        [Display(Name = "中级职称教师人数")]
        public Nullable<int> IntermediateTitleNum { get; set; }
        [Display(Name = "其他职称教师人数")]
        public Nullable<int> OtherTitleNum { get; set; }
        [Display(Name = "信息技术专业教师人数")]
        public Nullable<int> TechTeacherNum { get; set; }
        [Display(Name = "获得信息技术相关认证教师人数")]
        public Nullable<int> AuthTechTeacherNum { get; set; }
        [Display(Name = "专业计算机房面积")]
        public Nullable<double> EngineRoomArea { get; set; }
        [Display(Name = "计算机台数及基本配置")]
        public string ComputerNumConfig { get; set; }
        [Display(Name = "提交申请时间")]
        public Nullable<System.DateTime> RecordTime { get; set; }
        [Display(Name = "用户ID")]
        public Nullable<int> UserID { get; set; }
        [Display(Name = "是否审核通过")]
        public Nullable<int> IsPass { get; set; }//默认为0即不通过
    }
}