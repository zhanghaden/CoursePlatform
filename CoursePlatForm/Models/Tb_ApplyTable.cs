namespace CoursePlatForm.Models
{
    using System;
    using System.Collections.Generic;

    public class Tb_ApplyTable
    {
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
    }
}