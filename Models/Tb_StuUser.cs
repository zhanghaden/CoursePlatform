namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tb_StuUser
    {
        [Key]
        public System.Guid StuID { get; set; }
        public string StuName { get; set; }
        public Nullable<int> StuAge { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public Nullable<int> CityID { get; set; }
        public string DetailAddress { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IDCard { get; set; }
        public string CompanyName { get; set; }
        public string PostCode { get; set; }
        public System.DateTime RecordTime { get; set; }
        public string ClassName { get; set; }
        public string SchoolName { get; set; }
        public string GradeName { get; set; }
        public Nullable<int> ProvinceID { get; set; }
    }
}